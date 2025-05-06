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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        FileImportGroupBox = new GroupBox();
        FilePathLabel = new Label();
        CsvImportButton = new Button();
        TSQLGroupBox = new GroupBox();
        ExportFileLabel = new Label();
        ExportSQLButton = new Button();
        WhereCheckedListBox = new CheckedListBox();
        CopyTSQLButton = new Button();
        WhereLabel = new Label();
        ColumnLabel = new Label();
        ColumnsCheckedListBox = new CheckedListBox();
        TableTextBox = new TextBox();
        TableLabel = new Label();
        TSQLTypeLabel = new Label();
        TSQLTypeComboBox = new ComboBox();
        CsvDataGrid = new DataGridView();
        Results = new GroupBox();
        ExportedSQLLabel = new Label();
        ResultsTextBox = new TextBox();
        FileImportGroupBox.SuspendLayout();
        TSQLGroupBox.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)CsvDataGrid).BeginInit();
        Results.SuspendLayout();
        SuspendLayout();
        // 
        // FileImportGroupBox
        // 
        FileImportGroupBox.Controls.Add(FilePathLabel);
        FileImportGroupBox.Controls.Add(CsvImportButton);
        FileImportGroupBox.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        FileImportGroupBox.ForeColor = Color.White;
        FileImportGroupBox.Location = new Point(23, 23);
        FileImportGroupBox.Name = "FileImportGroupBox";
        FileImportGroupBox.Size = new Size(715, 337);
        FileImportGroupBox.TabIndex = 0;
        FileImportGroupBox.TabStop = false;
        FileImportGroupBox.Text = "File Import";
        // 
        // FilePathLabel
        // 
        FilePathLabel.Location = new Point(16, 152);
        FilePathLabel.Name = "FilePathLabel";
        FilePathLabel.Size = new Size(680, 49);
        FilePathLabel.TabIndex = 1;
        FilePathLabel.Text = "<File Name>";
        // 
        // CsvImportButton
        // 
        CsvImportButton.Cursor = Cursors.Hand;
        CsvImportButton.FlatAppearance.BorderSize = 0;
        CsvImportButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(177, 88, 114);
        CsvImportButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 108, 134);
        CsvImportButton.FlatStyle = FlatStyle.Flat;
        CsvImportButton.Image = (Image)resources.GetObject("CsvImportButton.Image");
        CsvImportButton.Location = new Point(16, 38);
        CsvImportButton.Name = "CsvImportButton";
        CsvImportButton.Size = new Size(99, 98);
        CsvImportButton.TabIndex = 0;
        CsvImportButton.UseVisualStyleBackColor = true;
        CsvImportButton.Click += CsvImportButton_Click;
        // 
        // TSQLGroupBox
        // 
        TSQLGroupBox.Controls.Add(ExportFileLabel);
        TSQLGroupBox.Controls.Add(ExportSQLButton);
        TSQLGroupBox.Controls.Add(WhereCheckedListBox);
        TSQLGroupBox.Controls.Add(CopyTSQLButton);
        TSQLGroupBox.Controls.Add(WhereLabel);
        TSQLGroupBox.Controls.Add(ColumnLabel);
        TSQLGroupBox.Controls.Add(ColumnsCheckedListBox);
        TSQLGroupBox.Controls.Add(TableTextBox);
        TSQLGroupBox.Controls.Add(TableLabel);
        TSQLGroupBox.Controls.Add(TSQLTypeLabel);
        TSQLGroupBox.Controls.Add(TSQLTypeComboBox);
        TSQLGroupBox.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TSQLGroupBox.ForeColor = Color.White;
        TSQLGroupBox.Location = new Point(758, 23);
        TSQLGroupBox.Name = "TSQLGroupBox";
        TSQLGroupBox.Size = new Size(1093, 337);
        TSQLGroupBox.TabIndex = 1;
        TSQLGroupBox.TabStop = false;
        TSQLGroupBox.Text = "Configure T-SQL";
        // 
        // ExportFileLabel
        // 
        ExportFileLabel.AutoSize = true;
        ExportFileLabel.Location = new Point(17, 279);
        ExportFileLabel.Name = "ExportFileLabel";
        ExportFileLabel.Size = new Size(0, 32);
        ExportFileLabel.TabIndex = 10;
        // 
        // ExportSQLButton
        // 
        ExportSQLButton.BackColor = Color.FromArgb(197, 108, 134);
        ExportSQLButton.Cursor = Cursors.Hand;
        ExportSQLButton.FlatAppearance.BorderColor = Color.FromArgb(114, 90, 122);
        ExportSQLButton.FlatAppearance.BorderSize = 5;
        ExportSQLButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(114, 90, 122);
        ExportSQLButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(177, 88, 114);
        ExportSQLButton.FlatStyle = FlatStyle.Flat;
        ExportSQLButton.Location = new Point(461, 265);
        ExportSQLButton.Name = "ExportSQLButton";
        ExportSQLButton.Size = new Size(295, 61);
        ExportSQLButton.TabIndex = 9;
        ExportSQLButton.Text = "Export to .sql";
        ExportSQLButton.UseVisualStyleBackColor = false;
        ExportSQLButton.Click += ExportSQLButton_Click;
        // 
        // WhereCheckedListBox
        // 
        WhereCheckedListBox.FormattingEnabled = true;
        WhereCheckedListBox.Location = new Point(706, 78);
        WhereCheckedListBox.Name = "WhereCheckedListBox";
        WhereCheckedListBox.Size = new Size(351, 184);
        WhereCheckedListBox.TabIndex = 9;
        // 
        // CopyTSQLButton
        // 
        CopyTSQLButton.BackColor = Color.FromArgb(197, 108, 134);
        CopyTSQLButton.Cursor = Cursors.Hand;
        CopyTSQLButton.FlatAppearance.BorderColor = Color.FromArgb(114, 90, 122);
        CopyTSQLButton.FlatAppearance.BorderSize = 5;
        CopyTSQLButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(114, 90, 122);
        CopyTSQLButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(177, 88, 114);
        CopyTSQLButton.FlatStyle = FlatStyle.Flat;
        CopyTSQLButton.Location = new Point(762, 265);
        CopyTSQLButton.Name = "CopyTSQLButton";
        CopyTSQLButton.Size = new Size(295, 61);
        CopyTSQLButton.TabIndex = 8;
        CopyTSQLButton.Text = "Export to textbox";
        CopyTSQLButton.UseVisualStyleBackColor = false;
        CopyTSQLButton.Click += CopyTSQLButton_Click;
        // 
        // WhereLabel
        // 
        WhereLabel.Location = new Point(706, 38);
        WhereLabel.Name = "WhereLabel";
        WhereLabel.Size = new Size(381, 37);
        WhereLabel.TabIndex = 6;
        WhereLabel.Text = "WHERE {Column} = {Value}";
        // 
        // ColumnLabel
        // 
        ColumnLabel.Location = new Point(324, 38);
        ColumnLabel.Name = "ColumnLabel";
        ColumnLabel.Size = new Size(351, 37);
        ColumnLabel.TabIndex = 5;
        ColumnLabel.Text = "Select columns to include";
        // 
        // ColumnsCheckedListBox
        // 
        ColumnsCheckedListBox.FormattingEnabled = true;
        ColumnsCheckedListBox.Location = new Point(324, 78);
        ColumnsCheckedListBox.Name = "ColumnsCheckedListBox";
        ColumnsCheckedListBox.Size = new Size(351, 184);
        ColumnsCheckedListBox.TabIndex = 4;
        // 
        // TableTextBox
        // 
        TableTextBox.Location = new Point(17, 192);
        TableTextBox.Name = "TableTextBox";
        TableTextBox.Size = new Size(269, 39);
        TableTextBox.TabIndex = 3;
        // 
        // TableLabel
        // 
        TableLabel.Location = new Point(17, 152);
        TableLabel.Name = "TableLabel";
        TableLabel.Size = new Size(160, 37);
        TableLabel.TabIndex = 2;
        TableLabel.Text = "Table";
        // 
        // TSQLTypeLabel
        // 
        TSQLTypeLabel.Location = new Point(17, 38);
        TSQLTypeLabel.Name = "TSQLTypeLabel";
        TSQLTypeLabel.Size = new Size(160, 37);
        TSQLTypeLabel.TabIndex = 1;
        TSQLTypeLabel.Text = "T-SQL Type";
        // 
        // TSQLTypeComboBox
        // 
        TSQLTypeComboBox.BackColor = Color.FromArgb(197, 108, 134);
        TSQLTypeComboBox.Cursor = Cursors.Hand;
        TSQLTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        TSQLTypeComboBox.ForeColor = Color.White;
        TSQLTypeComboBox.Location = new Point(17, 78);
        TSQLTypeComboBox.Name = "TSQLTypeComboBox";
        TSQLTypeComboBox.Size = new Size(269, 40);
        TSQLTypeComboBox.TabIndex = 0;
        // 
        // CsvDataGrid
        // 
        CsvDataGrid.AllowUserToAddRows = false;
        CsvDataGrid.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 117, 130);
        dataGridViewCellStyle1.Font = new Font("Segoe UI Emoji", 12F);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(114, 90, 122);
        CsvDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        CsvDataGrid.BackgroundColor = Color.FromArgb(53, 92, 125);
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(114, 90, 122);
        dataGridViewCellStyle2.Font = new Font("Segoe UI Emoji", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(197, 108, 134);
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        CsvDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        CsvDataGrid.ColumnHeadersHeight = 60;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = Color.FromArgb(197, 108, 134);
        dataGridViewCellStyle3.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        dataGridViewCellStyle3.ForeColor = Color.White;
        dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(114, 90, 122);
        dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        CsvDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
        CsvDataGrid.Location = new Point(23, 366);
        CsvDataGrid.Name = "CsvDataGrid";
        CsvDataGrid.ReadOnly = true;
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = Color.FromArgb(114, 90, 122);
        dataGridViewCellStyle4.Font = new Font("Segoe UI Emoji", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
        dataGridViewCellStyle4.ForeColor = Color.White;
        dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
        CsvDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
        CsvDataGrid.RowHeadersVisible = false;
        CsvDataGrid.RowHeadersWidth = 62;
        CsvDataGrid.Size = new Size(1085, 551);
        CsvDataGrid.TabIndex = 2;
        // 
        // Results
        // 
        Results.Controls.Add(ExportedSQLLabel);
        Results.Controls.Add(ResultsTextBox);
        Results.ForeColor = Color.White;
        Results.Location = new Point(1133, 366);
        Results.Name = "Results";
        Results.Padding = new Padding(10);
        Results.Size = new Size(718, 551);
        Results.TabIndex = 3;
        Results.TabStop = false;
        Results.Text = "Results";
        // 
        // ExportedSQLLabel
        // 
        ExportedSQLLabel.AutoSize = true;
        ExportedSQLLabel.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ExportedSQLLabel.Location = new Point(13, 479);
        ExportedSQLLabel.Name = "ExportedSQLLabel";
        ExportedSQLLabel.Size = new Size(0, 32);
        ExportedSQLLabel.TabIndex = 1;
        // 
        // ResultsTextBox
        // 
        ResultsTextBox.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ResultsTextBox.Location = new Point(13, 51);
        ResultsTextBox.Multiline = true;
        ResultsTextBox.Name = "ResultsTextBox";
        ResultsTextBox.ReadOnly = true;
        ResultsTextBox.ScrollBars = ScrollBars.Vertical;
        ResultsTextBox.Size = new Size(692, 487);
        ResultsTextBox.TabIndex = 0;
        ResultsTextBox.Visible = false;
        // 
        // MainForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(53, 92, 125);
        ClientSize = new Size(1874, 940);
        Controls.Add(Results);
        Controls.Add(CsvDataGrid);
        Controls.Add(TSQLGroupBox);
        Controls.Add(FileImportGroupBox);
        Font = new Font("Segoe UI Emoji", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Location = new Point(22, 22);
        Margin = new Padding(5, 4, 5, 4);
        MaximizeBox = false;
        Name = "MainForm";
        Padding = new Padding(20);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Customer import to SQL";
        TransparencyKey = Color.Crimson;
        Load += MainForm_Load;
        FileImportGroupBox.ResumeLayout(false);
        TSQLGroupBox.ResumeLayout(false);
        TSQLGroupBox.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)CsvDataGrid).EndInit();
        Results.ResumeLayout(false);
        Results.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label ColumnLabel;

    private System.Windows.Forms.DataGridView CsvDataGrid;

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

    private Button CopyTSQLButton;
    private GroupBox Results;
    private TextBox ResultsTextBox;
    private CheckedListBox WhereCheckedListBox;
    private Button ExportSQLButton;
    private Label ExportFileLabel;
    private Label ExportedSQLLabel;
}