using System.Text;

namespace CustomerImportSQL.TSQL
{
    public struct TransactSQLModel()
    {
        public string TransactStatement { get; private set; } = null!;

        public TransactSQLType TransactionType { get; set; }

        public string TargetTable { get; set; } = null!;

        public Dictionary<string, string> ColumnValueDict { get; set; } = null!;

        public string ConditionColumn { get; set; } = null!;

        public string ConditionValue { get; set; } = null!;

        /// <summary>
        /// Populates the model's TransactStatement property based on the 
        /// configured property values
        /// </summary>
        public void BuildTransactStatement()
        {
            StringBuilder sb = new StringBuilder();
            switch (TransactionType)
            {
                case TransactSQLType.UPDATE:
                    sb.Append($"UPDATE {TargetTable} SET ");
                    int keyCount = 1;  // must have selected at least one column to be here
                    foreach (string key in ColumnValueDict.Keys)
                    {
                        sb.Append($"{key} = '{ColumnValueDict[key]}'");
                        if (keyCount < ColumnValueDict.Keys.Count)
                        {
                            sb.Append(", ");
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                        keyCount++;
                    }
                    sb.Append($"WHERE {ConditionColumn} = '{ConditionValue}'");
                    break;
                case TransactSQLType.DELETE:
                    sb.Append($"DELETE FROM {TargetTable} WHERE {ConditionColumn} = '{ConditionValue}'");
                    break;
                case TransactSQLType.INSERT:
                    sb.Append($"INSERT INTO {TargetTable} (");
                    int i = 1;
                    foreach (string key in ColumnValueDict.Keys)
                    {
                        sb.Append($"'{key}'");
                        if (i == ColumnValueDict.Keys.Count)
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
                    foreach (string value in ColumnValueDict.Values)
                    {
                        sb.Append($"'{value}'");
                        if (i == ColumnValueDict.Keys.Count)
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
            TransactStatement = sb.ToString();
        }
    }
}
