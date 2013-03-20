using System.Data.Common;
using System.Data.SQLite;
using Rigel.Data;

// ReSharper disable InconsistentNaming
namespace Chinook.DataAccess.Test
{
    public class SQLiteDB : DB 
    {
        public SQLiteDB(string connString) : base(connString)
        {
        }

        public override DbConnection GetOpenConnection()
        {
            var conn = new SQLiteConnection(_connString);
            conn.Open();

            return conn;
        }
    }
}