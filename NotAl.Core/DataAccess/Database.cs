using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.Core.DataAccess
{
    public class Database
    {
        public static readonly string connectionString = new FbConnectionStringBuilder
        {
            Database = "notes.fdb",
            ServerType = FbServerType.Embedded,
            UserID = "SYSDBA",
            Password = "masterkey",
            ClientLibrary = "fbclient.dll"
        }.ToString();
    }
}
