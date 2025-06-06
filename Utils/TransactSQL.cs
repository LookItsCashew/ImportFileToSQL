using System.Diagnostics;
using System.IO;
using System.Text;
using CustomerImportSQL.TSQL;

namespace CustomerImportSQL.Utils;

public enum TransactSQLType
{
    UPDATE,
    DELETE,
    INSERT
}

public static class TransactSQLExport
{
    public static Action<string>? SQLFileSavedEvent;

    public static void WriteTSQLToTextBox(List<TransactSQLModel> models, TextBox textBox)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string[] statements = new string[models.Count];
        try
        {
            for (int i = 0; i < models.Count; i++)
            {
                statements[i] = models[i].TransactStatement;
            }

            textBox.Lines = statements;
            sw.Stop();
            MessageBox.Show($"Time to paste objects: {sw.ElapsedMilliseconds.ToString()}ms");
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

    /// <summary>
    /// Populates the model's TransactStatement property based on the 
    /// configured property values
    /// </summary>
    public static void BuildTransactStatement(TransactSQLModel model)
    {
        StringBuilder sb = new StringBuilder();
        switch (model.TransactionType)
        {
            case TransactSQLType.UPDATE:
                sb.Append($"UPDATE {model.TargetTable} SET ");
                // must have selected at least one column to be here
                int keyUpdateCount = 1;
                int whereUpdateCount = 1;
                foreach (string key in model.ColumnValueDict.Keys)
                {
                    sb.Append($"{key} = '{model.ColumnValueDict[key]}'");
                    if (keyUpdateCount < model.ColumnValueDict.Keys.Count)
                    {
                        sb.Append(", ");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                    keyUpdateCount++;
                }
                sb.Append("WHERE ");
                foreach (string key in model.WhereValueDict.Keys)
                {
                    sb.Append($"{key} = '{model.WhereValueDict[key]}'");
                    if (whereUpdateCount < model.WhereValueDict.Keys.Count)
                    {
                        sb.Append(" AND ");
                    }
                    whereUpdateCount++;
                }
                break;
            case TransactSQLType.DELETE:
                sb.Append($"DELETE FROM {model.TargetTable} WHERE ");

                int whereDeleteCount = 1;
                foreach (string key in model.WhereValueDict.Keys)
                {
                    sb.Append($"{key} = '{model.WhereValueDict[key]}'");
                    if (whereDeleteCount < model.WhereValueDict.Keys.Count)
                    {
                        sb.Append(" AND ");
                    }
                    whereDeleteCount++;
                }
                break;
            case TransactSQLType.INSERT:
                sb.Append($"INSERT INTO {model.TargetTable} (");
                int i = 1;
                foreach (string key in model.ColumnValueDict.Keys)
                {
                    sb.Append($"'{key}'");
                    if (i == model.ColumnValueDict.Keys.Count)
                    {
                        sb.Append(")");
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    i++;
                }

                sb.Append(" VALUES (");
                i = 1;
                foreach (string value in model.ColumnValueDict.Values)
                {
                    sb.Append($"'{value}'");
                    if (i == model.ColumnValueDict.Keys.Count)
                    {
                        sb.Append(")");
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    i++;
                }
                break;
        }
        model.TransactStatement = sb.ToString();
    }
}