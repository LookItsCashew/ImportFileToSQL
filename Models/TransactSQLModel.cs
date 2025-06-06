using System.Text;
using CustomerImportSQL.Utils;

namespace CustomerImportSQL.TSQL
{
    public class TransactSQLModel()
    {
        public string TransactStatement { get; set; } = null!;

        public TransactSQLType TransactionType { get; set; }

        public string TargetTable { get; set; } = null!;

        public Dictionary<string, string> ColumnValueDict { get; set; } = null!;

        public Dictionary<string, string> WhereValueDict { get; set; } = null!;
    }
}
