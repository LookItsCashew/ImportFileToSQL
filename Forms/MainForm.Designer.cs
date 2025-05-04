using CustomerImportSQL.TSQL;

namespace CustomerImportSQL.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        FileImportGroupBox = new System.Windows.Forms.GroupBox();
        FilePathLabel = new System.Windows.Forms.Label();
        CsvImportButton = new System.Windows.Forms.Button();
        TSQLGroupBox = new System.Windows.Forms.GroupBox();
        WhereComboBox = new System.Windows.Forms.ComboBox();
        WhereLabel = new System.Windows.Forms.Label();
        ColumnLabel = new System.Windows.Forms.Label();
        ColumnsCheckedListBox = new System.Windows.Forms.CheckedListBox();
        TableTextBox = new System.Windows.Forms.TextBox();
        TableLabel = new System.Windows.Forms.Label();
        TSQLTypeLabel = new System.Windows.Forms.Label();
        TSQLTypeComboBox = new System.Windows.Forms.ComboBox();
        CsvDataGrid = new System.Windows.Forms.DataGridView();
        FileImportGroupBox.SuspendLayout();
        TSQLGroupBox.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)CsvDataGrid).BeginInit();
        SuspendLayout();
        // 
        // FileImportGroupBox
        // 
        FileImportGroupBox.Controls.Add(FilePathLabel);
        FileImportGroupBox.Controls.Add(CsvImportButton);
        FileImportGroupBox.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        FileImportGroupBox.ForeColor = System.Drawing.Color.White;
        FileImportGroupBox.Location = new System.Drawing.Point(23, 23);
        FileImportGroupBox.Name = "FileImportGroupBox";
        FileImportGroupBox.Size = new System.Drawing.Size(715, 333);
        FileImportGroupBox.TabIndex = 0;
        FileImportGroupBox.TabStop = false;
        FileImportGroupBox.Text = "File Import";
        // 
        // FilePathLabel
        // 
        FilePathLabel.Location = new System.Drawing.Point(16, 152);
        FilePathLabel.Name = "FilePathLabel";
        FilePathLabel.Size = new System.Drawing.Size(680, 49);
        FilePathLabel.TabIndex = 1;
        FilePathLabel.Text = "<File Name>";
        // 
        // CsvImportButton
        // 
        CsvImportButton.FlatAppearance.BorderSize = 0;
        CsvImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        CsvImportButton.Image = ((System.Drawing.Image)resources.GetObject("CsvImportButton.Image"));
        CsvImportButton.Location = new System.Drawing.Point(16, 38);
        CsvImportButton.Name = "CsvImportButton";
        CsvImportButton.Size = new System.Drawing.Size(99, 92);
        CsvImportButton.TabIndex = 0;
        CsvImportButton.UseVisualStyleBackColor = true;
        CsvImportButton.Click += CsvImportButton_Click;
        // 
        // TSQLGroupBox
        // 
        TSQLGroupBox.Controls.Add(WhereComboBox);
        TSQLGroupBox.Controls.Add(WhereLabel);
        TSQLGroupBox.Controls.Add(ColumnLabel);
        TSQLGroupBox.Controls.Add(ColumnsCheckedListBox);
        TSQLGroupBox.Controls.Add(TableTextBox);
        TSQLGroupBox.Controls.Add(TableLabel);
        TSQLGroupBox.Controls.Add(TSQLTypeLabel);
        TSQLGroupBox.Controls.Add(TSQLTypeComboBox);
        TSQLGroupBox.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        TSQLGroupBox.ForeColor = System.Drawing.Color.White;
        TSQLGroupBox.Location = new System.Drawing.Point(758, 23);
        TSQLGroupBox.Name = "TSQLGroupBox";
        TSQLGroupBox.Size = new System.Drawing.Size(1093, 333);
        TSQLGroupBox.TabIndex = 1;
        TSQLGroupBox.TabStop = false;
        TSQLGroupBox.Text = "Configure T-SQL";
        // 
        // WhereComboBox
        // 
        WhereComboBox.FormattingEnabled = true;
        WhereComboBox.Location = new System.Drawing.Point(706, 78);
        WhereComboBox.Name = "WhereComboBox";
        WhereComboBox.Size = new System.Drawing.Size(295, 40);
        WhereComboBox.TabIndex = 7;
        // 
        // WhereLabel
        // 
        WhereLabel.Location = new System.Drawing.Point(706, 38);
        WhereLabel.Name = "WhereLabel";
        WhereLabel.Size = new System.Drawing.Size(381, 37);
        WhereLabel.TabIndex = 6;
        WhereLabel.Text = "WHERE {Column} = {Value}";
        // 
        // ColumnLabel
        // 
        ColumnLabel.Location = new System.Drawing.Point(324, 38);
        ColumnLabel.Name = "ColumnLabel";
        ColumnLabel.Size = new System.Drawing.Size(351, 37);
        ColumnLabel.TabIndex = 5;
        ColumnLabel.Text = "Select columns to include";
        // 
        // ColumnsCheckedListBox
        // 
        ColumnsCheckedListBox.FormattingEnabled = true;
        ColumnsCheckedListBox.Location = new System.Drawing.Point(324, 78);
        ColumnsCheckedListBox.Name = "ColumnsCheckedListBox";
        ColumnsCheckedListBox.Size = new System.Drawing.Size(351, 184);
        ColumnsCheckedListBox.TabIndex = 4;
        // 
        // TableTextBox
        // 
        TableTextBox.Location = new System.Drawing.Point(17, 192);
        TableTextBox.Name = "TableTextBox";
        TableTextBox.Size = new System.Drawing.Size(269, 39);
        TableTextBox.TabIndex = 3;
        // 
        // TableLabel
        // 
        TableLabel.Location = new System.Drawing.Point(17, 152);
        TableLabel.Name = "TableLabel";
        TableLabel.Size = new System.Drawing.Size(160, 37);
        TableLabel.TabIndex = 2;
        TableLabel.Text = "Table";
        // 
        // TSQLTypeLabel
        // 
        TSQLTypeLabel.Location = new System.Drawing.Point(17, 38);
        TSQLTypeLabel.Name = "TSQLTypeLabel";
        TSQLTypeLabel.Size = new System.Drawing.Size(160, 37);
        TSQLTypeLabel.TabIndex = 1;
        TSQLTypeLabel.Text = "T-SQL Type";
        // 
        // TSQLTypeComboBox
        // 
        TSQLTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        TSQLTypeComboBox.FormattingEnabled = true;
        TSQLTypeComboBox.Location = new System.Drawing.Point(17, 78);
        TSQLTypeComboBox.Name = "TSQLTypeComboBox";
        TSQLTypeComboBox.Size = new System.Drawing.Size(269, 40);
        TSQLTypeComboBox.TabIndex = 0;
        // 
        // CsvDataGrid
        // 
        CsvDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)((byte)53)), ((int)((byte)92)), ((int)((byte)125)));
        CsvDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        CsvDataGrid.ColumnHeadersHeight = 60;
        CsvDataGrid.Location = new System.Drawing.Point(23, 362);
        CsvDataGrid.Name = "CsvDataGrid";
        CsvDataGrid.RowHeadersWidth = 62;
        CsvDataGrid.Size = new System.Drawing.Size(1828, 555);
        CsvDataGrid.TabIndex = 2;
        // 
        // MainForm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        AutoSize = true;
        AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)53)), ((int)((byte)92)), ((int)((byte)125)));
        ClientSize = new System.Drawing.Size(1874, 940);
        Controls.Add(CsvDataGrid);
        Controls.Add(TSQLGroupBox);
        Controls.Add(FileImportGroupBox);
        Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        ForeColor = System.Drawing.Color.White;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        Location = new System.Drawing.Point(22, 22);
        Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
        MaximizeBox = false;
        Padding = new System.Windows.Forms.Padding(20);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Customer import to SQL";
        TransparencyKey = System.Drawing.Color.Crimson;
        Load += MainForm_Load;
        FileImportGroupBox.ResumeLayout(false);
        TSQLGroupBox.ResumeLayout(false);
        TSQLGroupBox.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)CsvDataGrid).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label ColumnLabel;

    private System.Windows.Forms.DataGridView CsvDataGrid;

    private System.Windows.Forms.ComboBox WhereComboBox;

    private System.Windows.Forms.Label WhereLabel;

    private System.Windows.Forms.CheckedListBox ColumnsCheckedListBox;

    private System.Windows.Forms.TextBox TableTextBox;

    private System.Windows.Forms.Label TableLabel;

    private System.Windows.Forms.ComboBox TSQLTypeComboBox;
    private System.Windows.Forms.Label TSQLTypeLabel;

    private System.Windows.Forms.GroupBox TSQLGroupBox;

    private System.Windows.Forms.Label FilePathLabel;

    private System.Windows.Forms.Button CsvImportButton;

    private System.Windows.Forms.GroupBox FileImportGroupBox;

    #endregion
}