using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    public class MySQLDBHelp
    {
        #region  建立MySql数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回MySqlConnection对象</returns>
        public static MySqlConnection Getmysqlcon()
        {
            //string M_str_sqlcon = "server=localhost;port=3306;user id=root;password=root;database=assistant"; //根据自己的设置
            string M_str_sqlcon = "server=27.124.10.181;port=3306;user id=ass;password=pJTdIkmW3yIRbPDN;database=assistant"; //根据自己的设置
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            return myCon;
        }
        #endregion

        #region  执行MySqlCommand命令
        /// <summary>
        /// 执行MySqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public static int Getmysqlcom(string M_str_sqlstr)
        {
            int Number_of_rows_affected;
            try
            {
                using (MySqlConnection mysqlcon = Getmysqlcon())
                {
                    mysqlcon.Open();
                    MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
                    Number_of_rows_affected = mysqlcom.ExecuteNonQuery();
                    mysqlcom.Dispose();
                    mysqlcon.Close();
                    mysqlcon.Dispose();
                }
            }
            catch (Exception)
            {
                Number_of_rows_affected = -1;
            }
            return Number_of_rows_affected;
        }
        #endregion

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="sqlList"></param>
        public static void ExecuteSqlTransaction(List<string> sqlList)
        {
            using (MySqlConnection connection = Getmysqlcon())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                MySqlTransaction mySqlTransaction = connection.BeginTransaction();
                command.Transaction = mySqlTransaction;
                try
                {
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        string sql = sqlList[i].ToString();
                        if (sql.Trim().Length > 1)
                        {
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                        }
                        if (i > 0 && (i % 500 == 0 || i == sqlList.Count() - 1))
                        {
                            mySqlTransaction.Commit();
                            mySqlTransaction = connection.BeginTransaction();
                        }
                    }
                }
                catch (Exception E)
                {
                    mySqlTransaction.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }


        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query_for_mysql(string SQLString)
        {
            using (MySqlConnection connection = Getmysqlcon())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                    return ds;
                }
                catch (MySqlException ex)
                {
                    connection.Close();
                    return null;
                    //throw new Exception(ex.Message);
                }
                
            }
        }
        public static DataSet Query_for_mysql(string SQLString, int Times)
        {
            using (MySqlConnection connection = Getmysqlcon())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (MySqlException ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (MySqlConnection connection = Getmysqlcon())
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySqlException e)
                    {
                        connection.Close();
                        return "Database_connection_failed";
                        //return e;链接数据库失败
                    }
                }
            }
        }

        /*
        /// <summary> 
        /// 准备执行一个命令 
        /// </summary> 
        /// <param name="cmd">sql命令</param> 
        /// <param name="conn">OleDb连接</param> 
        /// <param name="trans">OleDb事务</param> 
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param> 
        /// <param name="cmdText">命令文本,例如:Select * from Products</param> 
        /// <param name="cmdParms">执行命令的参数</param> 
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)

            {

                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }


        /// <summary>
        /// 返回插入值ID
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteNonExist(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteNonQuery();

                return cmd.LastInsertedId;
            }
        }
        */
    }
}
