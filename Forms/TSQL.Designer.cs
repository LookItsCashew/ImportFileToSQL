using System.ComponentModel;

namespace CustomerImportSQL.Forms;

partial class TSQL
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        TSQLTextBox = new System.Windows.Forms.TextBox();
        SqlLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // TSQLTextBox
        // 
        TSQLTextBox.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        TSQLTextBox.Location = new System.Drawing.Point(54, 99);
        TSQLTextBox.Margin = new System.Windows.Forms.Padding(4);
        TSQLTextBox.Multiline = true;
        TSQLTextBox.Name = "TSQLTextBox";
        TSQLTextBox.Size = new System.Drawing.Size(870, 477);
        TSQLTextBox.TabIndex = 0;
        TSQLTextBox.Visible = false;
        // 
        // SqlLabel
        // 
        SqlLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        SqlLabel.Location = new System.Drawing.Point(54, 50);
        SqlLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        SqlLabel.Name = "SqlLabel";
        SqlLabel.Size = new System.Drawing.Size(266, 45);
        SqlLabel.TabIndex = 1;
        SqlLabel.Text = "T-SQL";
        // 
        // TSQL
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)53)), ((int)((byte)92)), ((int)((byte)125)));
        ClientSize = new System.Drawing.Size(978, 694);
        Controls.Add(SqlLabel);
        Controls.Add(TSQLTextBox);
        Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
        ForeColor = System.Drawing.Color.White;
        Location = new System.Drawing.Point(22, 22);
        Margin = new System.Windows.Forms.Padding(4);
        Padding = new System.Windows.Forms.Padding(50);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        TopMost = true;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label SqlLabel;

    private System.Windows.Forms.TextBox TSQLTextBox;

    #endregion
}