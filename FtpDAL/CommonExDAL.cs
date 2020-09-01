using BingYing.DataBase.Sql;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace FtpDAL
{
    public class CommonExDAL<T> : BaseExDal<T>
    {   
        public CommonExDAL()
        {
            InitDb();          
            bWithNolock = false;
        }
        /// <summary>
        /// 初始化数据库
        /// </summary>
        private void InitDb()
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data\\Ftp.db");
            var fileDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            //如果文件夹不存在则创建文件夹
            if (!Directory.Exists(fileDir)) Directory.CreateDirectory(fileDir);
            //如果数据库文件不存在则创建数据库文件
            if (!File.Exists(dbPath)) SQLiteConnection.CreateFile(dbPath);
            var initHelper = new InitSqliteHelper(dbPath);
            //如果表不存在则创建表
            if (!initHelper.IsExistsTable("Project")) initHelper.CtProject();
            //如果表不存在则创建表
            if (!initHelper.IsExistsTable("FileHash")) initHelper.CtFileHash();           
            sql = new SqliteHelper($"Data Source={dbPath};Version=3;");
        }

        public override T GetModel<TType>(TType mainKey, string colums = "*")
        {
            string strSql = string.Format("select {0} from {1} a where {2}=@{2}", colums, typeof(T).Name, GetOrderColumn());
            return sql.ExcuteReaderEntity<T>(strSql, sql.MakeInParam("@" + GetOrderColumn(), mainKey));
        }

        public override T GetModel(string strWhere, params IDataParameter[] ps)
        {
            string strSql = string.Format("SELECT  * from {0} a   {1} ", typeof(T).Name, !string.IsNullOrEmpty(strWhere) ? " where " + strWhere : "");
            return sql.ExcuteReaderEntity<T>(strSql, ps);
        }
        
    }
}
