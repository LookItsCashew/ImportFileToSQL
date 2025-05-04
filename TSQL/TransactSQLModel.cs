using System.Text;

namespace CustomerImportSQL.TSQL
{
    public struct TransactSqlModel()
    {
        public string TransactStatement { get; private set; } = null!;

        public TransactSQLType TransactionType { get; set; }

        public string TargetTable { get; set; } = null!;

        public Dictionary<string, string> ColumnValueDict { get; set; } = null!;

        public string ConditionColumn { get; set; } = null!;

        public string ConditionValue { get; set; } = null!;

        public void BuildTransactStatement()
        {
            StringBuilder sb = new StringBuilder();
            switch (TransactionType)
            {
                case TransactSQLType.UPDATE:
                    sb.Append($"UPDATE {TargetTable} SET ");
                    foreach (string key in ColumnValueDict.Keys)
                    {
                        sb.Append($"{key} = '{ColumnValueDict[key]}', ");
                    }
                    sb.Append($"WHERE {ConditionColumn} = '{ConditionValue}'");
                    break;
                case TransactSQLType.DELETE:
                    sb.Append($"DELETE FROM {TargetTable} WHERE {ConditionColumn} = '{ConditionValue}'");
                    break;
                case TransactSQLType.INSERT:
                    sb.Append($"INSERT INTO {TargetTable} VALUES (");
                    int i = 1;
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
                    }
                    break;
            }
            TransactStatement = sb.ToString();
        }
    }
}
