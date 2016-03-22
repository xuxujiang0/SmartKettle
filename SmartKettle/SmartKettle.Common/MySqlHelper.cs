using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.Common
{
    /// <summary>
    /// mysql数据库操作帮助类
    /// </summary>
    public class MySqlHelper
    {
        #region Fields
        private readonly static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;

        #endregion

        #region --- ExecuteNonQuery ---
        /// <summary>
        /// 执行sql命令，返回影响行数 (启用事务)
        /// </summary>
        /// <param name="sqlText">数据库命令：存储过程名或sql语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="sqlParam">sql命令的一个参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlText, CommandType cmdType, MySqlParameter sqlParam)
        {
            var result = 0;
            MySqlTransaction trans = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                trans = conn.BeginTransaction();
                var cmd = new MySqlCommand(sqlText, conn);
                cmd.CommandType = cmdType;
                if (sqlParam != null)
                {
                    cmd.Parameters.Add(sqlParam);
                }
                cmd.Transaction = trans;
                result = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
            return result;
        }

        /// <summary>
        /// 执行sql命令，返回影响行数 (启用事务)
        /// </summary>
        /// <param name="sqlText">数据库命令：存储过程名或sql语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="sqlParams">sql命令的参数数组（可为空）</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlText, CommandType cmdType, MySqlParameter[] sqlParams)
        {
            var result = 0;
            MySqlTransaction trans = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                trans = conn.BeginTransaction();
                var cmd = new MySqlCommand(sqlText, conn);
                cmd.CommandType = cmdType;
                if (sqlParams != null && sqlParams.Length > 0)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }
                cmd.Transaction = trans;
                result = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
            return result;
        }
        #endregion

        #region --- ExecuteScalar ---
        /// <summary>
        /// 执行sql命令，返回第一行第一列（启用事务）
        /// </summary>
        /// <param name="sqlText">数据库命令：存储过程名或sql语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="sqlParam">sql命令参数 （可为空）</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlText, CommandType cmdType, MySqlParameter sqlParam)
        {
            object result = null;
            MySqlTransaction trans = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                trans = conn.BeginTransaction();
                var cmd = new MySqlCommand(sqlText, conn);
                cmd.CommandType = cmdType;
                if (sqlParam != null)
                {
                    cmd.Parameters.Add(sqlParam);
                }
                cmd.Transaction = trans;
                result = cmd.ExecuteScalar();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
            return result;
        }

        /// <summary>
        /// 执行sql命令，返回第一行第一列（启用事务）
        /// </summary>
        /// <param name="sqlText">数据库命令：存储过程名或sql语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="sqlParams">sql命令参数 （可为空）</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlText, CommandType cmdType, MySqlParameter[] sqlParams)
        {
            object result = null;
            MySqlTransaction trans = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                trans = conn.BeginTransaction();
                var cmd = new MySqlCommand(sqlText, conn);
                cmd.CommandType = cmdType;
                if (sqlParams != null && sqlParams.Length > 0)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }
                cmd.Transaction = trans;
                result = cmd.ExecuteScalar();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
            return result;
        }
        #endregion

        #region --- Query Collection ---
        public static DataSet QueryForDataSet(string sqlText, CommandType cmdType, MySqlParameter[] sqlParams)
        {
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sqlText, conn);
                cmd.CommandType = cmdType;
                if (sqlParams != null && sqlParams.Length > 0)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            return ds;
        }
        public static DataTable QueryForDataTable(string sqlText, CommandType cmdType, MySqlParameter[] sqlParams)
        {
            DataTable dt = null;
            DataSet ds = QueryForDataSet(sqlText, cmdType, sqlParams);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        #endregion

        #region --- Method ---
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="conn"></param>
        public static void CloseConnection(IDbConnection conn)
        {
            if (conn == null)
            {
                return;
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        #endregion
    }
}
