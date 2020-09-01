using System;
using System.Data;
using System.Data.SQLite;

namespace FtpDAL
{
    public class InitSqliteHelper
    {
        private readonly string dbPath = "";

        public InitSqliteHelper(string dbPath)
        {
            this.dbPath = dbPath;
        }

        /// <summary>
        /// 创建Project表
        /// </summary>
        public void CtProject()
        {
            var sqliteConn = new SQLiteConnection("data source=" + this.dbPath);
            if (sqliteConn.State != ConnectionState.Open)
            {
                sqliteConn.Open();
                var cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = "CREATE TABLE Project ( " +
                    "Id INTEGER PRIMARY KEY," +
                    "Name VARCHAR(50)," +
                    "IpAddr VARCHAR(50)," +
                    "UserName VARCHAR(50)," +
                    "Password VARCHAR(50)," +
                    "WebDir VARCHAR(50)," +
                    "LocalDir VARCHAR(50)," +
                    "DomainName VARCHAR(50)," +
                    "Pxh INT)";
                cmd.ExecuteNonQuery();
            }
            sqliteConn.Close();
        }

        /// <summary>
        /// 创建FileHash表
        /// </summary>
        public void CtFileHash()
        {
            var sqliteConn = new SQLiteConnection("data source=" + this.dbPath);
            if (sqliteConn.State != ConnectionState.Open)
            {
                sqliteConn.Open();
                var cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = "CREATE TABLE FileHash ( " +
                    "Id INTEGER PRIMARY KEY," +
                    "FilePath VARCHAR(256)," +
                    "Hash VARCHAR(64)," +
                    "ProjectId INTEGER)";
                cmd.ExecuteNonQuery();
            }
            sqliteConn.Close();
        }
       

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsExistsTable(string tableName)
        {
            var i = 0;
            var sqliteConn = new SQLiteConnection("data source=" + this.dbPath);
            if (sqliteConn.State != ConnectionState.Open)
            {
                sqliteConn.Open();
                var cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = $"SELECT COUNT(*) FROM sqlite_master where type='table' and name='{tableName}';";
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            sqliteConn.Close();
            return i == 1;
        }
    }
}

