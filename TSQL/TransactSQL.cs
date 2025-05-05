using System.Text;

namespace CustomerImportSQL.TSQL;

public enum TransactSQLType
{
    UPDATE,
    DELETE,
    INSERT
}

public static class TransactSQLExport
{
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
}