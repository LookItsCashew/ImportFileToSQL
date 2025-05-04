using System.Data;
using System.Diagnostics;
using CustomerImportSQL.TSQL;

namespace CustomerImportSQL.Forms;

public partial class MainForm : Form
{
    private const string DefaultSelectLabelText = "Select columns to include";
    private const string DefaultWhereLabelText = "WHERE {Column} = {Value}";

    public MainForm()
    {
        InitializeComponent();
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

        if (WhereComboBox.Items.Count > 0)
        {
            WhereComboBox.Items.Clear();
            WhereLabel.Text = DefaultWhereLabelText;
        }
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
                WhereComboBox.Items.AddRange(headers);
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
        TransactSQLType[] tsqlTypes = [ TransactSQLType.UPDATE, TransactSQLType.INSERT, TransactSQLType.DELETE ];
        TSQLTypeComboBox.DataSource = tsqlTypes;
    }

    private void WhereComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string currColumn = WhereLabel.Text.Split(' ')[1];
        WhereLabel.Text = WhereLabel.Text.Replace(currColumn, WhereComboBox.SelectedItem!.ToString());
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

    private void GenerateTSQLButton_Click(object sender, EventArgs e)
    {
        // validate we have enough data to generate the TSQL
        if (TableTextBox.Text == "" || ColumnsCheckedListBox.CheckedItems.Count == 0 || 
            WhereComboBox.SelectedItem == null)
        {
            MessageBox.Show("Not enough information to produce T-SQL.\n\n" +
                "Must include a target table, at least one column for values if not a DELETE, " +
                "and a column to determine condition of the T-SQL statement.");

            return;
        }

        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<TransactSqlModel> models = new List<TransactSqlModel>();

            foreach (DataGridViewRow row in CsvDataGrid.Rows)
            {
                TransactSqlModel model = new TransactSqlModel();
                
                string[] colKeys = GetModelKeysFromIncludedColumns();
                Dictionary<string, string> columnValues = new Dictionary<string, string>();
                
                int addedCols = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // break out of the loop if we've already gone through all added columns, or the first cell of
                    // a row is null since this means the row is blank
                    if (addedCols == ColumnsCheckedListBox.CheckedItems.Count || cell.Value == null)
                    {
                        break;
                    }

                    // get values for selected columns
                    if (colKeys.Contains(cell.OwningColumn.HeaderText))
                    {
                        columnValues.Add(cell.OwningColumn.HeaderText, cell.Value.ToString()!);
                        addedCols++;
                    }

                    // since we're iterating each cell per row, get the value of the WHERE condition column
                    if (cell.OwningColumn.HeaderText == (string)WhereComboBox.SelectedItem!)
                    {
                        model.ConditionValue = cell.Value.ToString()!;
                    }
                }
                model.TargetTable = TableTextBox.Text;
                model.ColumnValueDict = columnValues;
                model.TransactionType = (TransactSQLType)TSQLTypeComboBox.SelectedItem!;
                model.ConditionColumn = (string)WhereComboBox.SelectedItem;
                model.BuildTransactStatement();
                models.Add(model);
            }
            stopwatch.Stop();
            MessageBox.Show($"Time taken to generate T-SQL: {stopwatch.ElapsedMilliseconds}ms");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}