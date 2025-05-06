using System.IO;

namespace CustomerImportSQL.TSQL;

public enum TransactSQLType
{
    UPDATE,
    DELETE,
    INSERT
}

public static class TransactSQLExport
{
    public static Action<string> SQLFileSavedEvent;

    public static void WriteTSQLToTextBox(List<TransactSQLModel> models, TextBox textBox)
    {
        string[] statements = new string[models.Count];
        try
        {
            for (int i = 0; i < models.Count; i++)
            {
                statements[i] = models[i].TransactStatement;
            }

            textBox.Lines = statements;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public static async Task WriteTSQLToFile(List<TransactSQLModel> models)
    {
        SaveFileDialog dlg = new SaveFileDialog();

        dlg.Filter = "sql files (*.sql)|*.sql";
        dlg.FilterIndex = 2;
        dlg.RestoreDirectory = true;

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string[] lines = new string[models.Count];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = models[i].TransactStatement;
                }
                await File.WriteAllLinesAsync(dlg.FileName, lines);
                SQLFileSavedEvent?.Invoke(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}