using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using Rigel.Transactions;

// ReSharper disable InconsistentNaming

namespace Rigel.Data
{
    public class DB
    {
        private readonly string _connString;

        public DB(string connString)
        {
            _connString = connString;
        }

        public IEnumerable<T> Query<T>(string sqlCommandText)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result = conn.Query<T>(sqlCommandText, null);
                scope.Complete();
                return result;
            }
        }

        public IEnumerable<dynamic> Query(string sqlCommandText)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result =  conn.Query(sqlCommandText);
                scope.Complete();
                return result;
            }
        }

        public IEnumerable<dynamic> Query(string sqlCommandText, object parameters)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result = conn.Query(sqlCommandText, parameters);
                scope.Complete();
                return result;
            }
        }

        public IEnumerable<T> Query<T>(string sqlCommandText, object parameters)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result = conn.Query<T>(sqlCommandText, parameters);
                scope.Complete();
                return result;
            }
        }

        public int Add<T>(string sqlCommandText, T parameter)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result = conn.Execute(sqlCommandText, parameter);
                scope.Complete();
                return result;
            }
        }

        public int Update<T>(string sqlCommandText, T parameter)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result =  conn.Execute(sqlCommandText, parameter);
                scope.Complete();
                return result;
            }
        }

        public int Execute(string sqlCommandText)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result =  conn.Execute(sqlCommandText);
                scope.Complete();
                return result;
            }
        }

        public int Delete<T>(string sqlCommandText, T parameter)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                var result = conn.Execute(sqlCommandText, parameter);
                scope.Complete();
                return result;
            }
        }

        public void ExecuteProcedure(string procedureName, object parameters)
        {
            using (var scope = ScopeFactory.CreateScope())
            using (var conn = GetOpenConnection())
            {
                conn.Execute(procedureName, parameters, null, null, CommandType.StoredProcedure);
                scope.Complete();
            }
        }

        public virtual DbConnection GetOpenConnection()
        {
            var conn = new SqlConnection(_connString);
            conn.Open();
            return conn;
        }

        //private T 

        //private T ExecuteTransactional<T>(Func<T> func)
        //{
        //    var result = default(T);

        //    using (var scope = ScopeFactory.CreateScope())
        //    {
        //        result = func();
        //        scope.Complete();
        //    }

        //    return result;
        //}
    }
}