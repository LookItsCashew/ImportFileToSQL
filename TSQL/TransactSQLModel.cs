using System.Text;

namespace CustomerImportSQL.TSQL
{
    public struct TransactSqlModel()
    {
        public string TransactStatement { get; private set; } = null!;

        public TransactSQLType TransactionType { get; set; }

        public string TargetTable { get; set; } = null!;

        public string[] IncludedColumns { get; set; } = null!;

        public string[] ColumnValues { get; set; } = null!;

        public Dictionary<string, string> ColumnValueDict { get; set; } = null!;

        public string ConditionColumn { get; set; } = null!;

        public void BuildTransactStatement()
        {
            StringBuilder sb = new StringBuilder();
            switch (TransactionType)
            {
                case TransactSQLType.UPDATE:
                    sb.Append($"UPDATE {TargetTable} SET ");
                    for (int i = 0; i < IncludedColumns.Length; i++)
                    {
                        // the col values should be based on the included columns, so should be the same length 
                        sb.Append($"{IncludedColumns[i]} = '{ColumnValues[i]}'");

                        // if not on the last column, 
                        if (i != IncludedColumns.Length - 1)
                        {
                            sb.Append(", ");
                        }
                    }
                    sb.Append($"WHERE {ConditionColumn} = ");
                    break;
                case TransactSQLType.DELETE:
                    sb.Append($"DELETE FROM {TargetTable} WHERE {ConditionColumn} = ");
                    break;
                case TransactSQLType.INSERT:
                    sb.Append($"INSERT INTO {TargetTable} VALUES (");
                    for(int i = 0; i < ColumnValues.Length; i++)
                    {
                        sb.Append($"'{ColumnValues[i]}'");
                        if (i == ColumnValues.Length - 1)
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
