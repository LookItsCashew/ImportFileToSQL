using System.Data;
using System.Diagnostics;
using CustomerImportSQL.TSQL;

namespace CustomerImportSQL.Forms;

public partial class MainForm : Form
{
    private const string DefaultSelectLabelText = "Select columns to include";

    public MainForm()
    {
        InitializeComponent();
        TransactSQLExport.SQLFileSavedEvent += OnSQLFileSavedEvent;
    }

    /// <summary>
    /// Constructs an array of data table column headers in string form.
    /// The array should be used to populate the column select combo box.
    /// </summary>
    /// <param name="cols">Collection of columns from a DataTable object</param>
    /// <returns>Array of type string that represents column headers from DataTable coulmn collection</returns>
    private string[] GetColumnHeadersAsStringArray(DataColumnCollection cols)
    {
        string[] headers = new string[cols.Count];

        for (int i = 0; i < headers.Length; i++)
        {
            headers[i] = cols[i].ColumnName;
        }

        return headers;
    }

    /// <summary>
    /// Reset the values of the form when a new file is selected. 
    /// </summary>
    private void ResetFormControls()
    {
        if (ColumnsCheckedListBox.Items.Count > 0)
        {
            ColumnsCheckedListBox.Items.Clear();
            ColumnLabel.Text = DefaultSelectLabelText;
        }

        if (TableTextBox.Text != "")
        {
            TableTextBox.Text = "";
        }
    }

    private bool ValidateSQLInput()
    {
        bool result = true;
        switch ((TransactSQLType)TSQLTypeComboBox.SelectedItem!)
        {
            case TransactSQLType.UPDATE:
                // validate we have enough data to generate the TSQL
                if (TableTextBox.Text == "" || ColumnsCheckedListBox.CheckedItems.Count == 0 ||
                    WhereCheckedListBox.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Not enough information for UPDATE T-SQL.\n\n" +
                        "Must include a target table, at least one column for values " +
                        "and a column to determine condition of the T-SQL statement.");

                    result = false;
                }
                break;
            case TransactSQLType.DELETE:
                if (TableTextBox.Text == "" || WhereCheckedListBox.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Need at least a target table and conditional column for the WHERE clause."
                        + "Don't delete an entire table's contents...");
                    result = false;
                }
                break;
            case TransactSQLType.INSERT:
                if (TableTextBox.Text == "" || ColumnsCheckedListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Need a target table and the appropriate columns to perform INSERT.");
                    result = false;
                }
                break;
        }
        return result;
    }

    private string[] GetModelKeysFromIncludedColumns()
    {
        string[] keys = new string[ColumnsCheckedListBox.CheckedItems.Count];

        for (int i = 0; i < keys.Length; i++)
        {
            // this shouldn't be null if we're here
            keys[i] = ColumnsCheckedListBox.CheckedItems[i]!.ToString()!;
        }

        return keys;
    }

    private string[] GetSelectedWhereColumns()
    {
        string[] checkedWhere = new string[WhereCheckedListBox.CheckedItems.Count];

        for (int i = 0; i < checkedWhere.Length; i++)
        {
            checkedWhere[i] = WhereCheckedListBox.CheckedItems[i]!.ToString()!;
        }

        return checkedWhere;
    }

    private List<TransactSQLModel>? GetTransactSQLModels()
    {
        List<TransactSQLModel> models = new List<TransactSQLModel>();
        try
        {
            if (!ValidateSQLInput())
            {
                return null;
            }

            // selected columns
            string[] colKeys = GetModelKeysFromIncludedColumns();

            // where columns
            string[] whereCols = GetSelectedWhereColumns();

            foreach (DataGridViewRow row in CsvDataGrid.Rows)
            {
                TransactSQLModel model = new TransactSQLModel();

                Dictionary<string, string> columnValues = new Dictionary<string, string>();
                Dictionary<string, string> whereValues = new Dictionary<string, string>();

                int addedColsCount = 0;
                int whereColsCount = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // break out of the loop if we've already gone through all added columns, or the first cell of
                    // a row is null since this means the row is blank
                    if (cell.Value == null ||
                        (addedColsCount == ColumnsCheckedListBox.CheckedItems.Count && whereColsCount == WhereCheckedListBox.CheckedItems.Count))
                    {
                        break;
                    }

                    // get values for selected columns
                    if (colKeys.Contains(cell.OwningColumn.HeaderText))
                    {
                        columnValues.Add(cell.OwningColumn.HeaderText, cell.Value!.ToString()!);
                        addedColsCount++;
                    }

                    // since we're iterating each cell per row, get the value of the WHERE condition column
                    if (whereCols.Contains(cell.OwningColumn.HeaderText))
                    {
                        whereValues.Add(cell.OwningColumn.HeaderText, cell.Value.ToString()!);
                        whereColsCount++;
                    }
                }

                // configure rest of model data
                model.TargetTable = TableTextBox.Text;
                model.ColumnValueDict = columnValues;
                model.TransactionType = (TransactSQLType)TSQLTypeComboBox.SelectedItem!;
                model.WhereValueDict = whereValues;
                model.BuildTransactStatement();
                models.Add(model);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return models;
    }

    #region Main Form Events Region
    private void OnSQLFileSavedEvent(string fileName)
    {
        MessageBox.Show($"Exported SQL to {fileName}");
    }

    private async void CsvImportButton_Click(object sender, EventArgs e)
    {
        // this is in case the user wants to import multiple files.
        ResetFormControls();

        // configure Windows file dialog pop-up
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.Filter = @"CSV files (*.csv)|*.csv";
        dlg.InitialDirectory = @"C:\";
        dlg.RestoreDirectory = true;

        UseWaitCursor = true;

        try
        {
            // will return result after the dialog is closed
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FilePathLabel.Text = dlg.FileName;
                CsvDataGrid.Visible = true;

                var csvDataSource = await CsvFileImport.GetDataViewFromCsvFileAsync(dlg.FileName);
                CsvDataGrid.DataSource = csvDataSource;

                string[] headers = GetColumnHeadersAsStringArray(csvDataSource.Columns);
                WhereCheckedListBox.Items.AddRange(headers);
                ColumnsCheckedListBox.Items.AddRange(headers);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            UseWaitCursor = false;
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        TransactSQLType[] tsqlTypes = [TransactSQLType.UPDATE, TransactSQLType.INSERT, TransactSQLType.DELETE];
        TSQLTypeComboBox.DataSource = tsqlTypes;
    }

    private void CopyTSQLButton_Click(object sender, EventArgs e)
    {
        try
        {
            List<TransactSQLModel>? models = GetTransactSQLModels();

            if (models == null || models.Count == 0)
            {
                return;
            }

            ResultsTextBox.Visible = true;
            TransactSQLExport.WriteTSQLToTextBox(models, ResultsTextBox);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void ExportSQLButton_Click(object sender, EventArgs e)
    {
        try
        {
            List<TransactSQLModel>? models = GetTransactSQLModels();

            if (models == null || models.Count == 0)
            {
                return;
            }

            await TransactSQLExport.WriteTSQLToFile(models);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    #endregion
}