using MySql.Data.MySqlClient;
using SmartKettle.Common;
using SmartKettle.Interfaces.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.BLL
{
    public class BasicsBLL : IBasicsBLL
    {
        #region --- 单例 ---
        public readonly static BasicsBLL _Current = new BasicsBLL();
        #endregion

        public int ExecuteNonQuery(string sqlText, System.Data.CommandType cmdType, MySql.Data.MySqlClient.MySqlParameter sqlParam)
        {
            return MySqlDataHelper.ExecuteNonQuery(sqlText, cmdType, sqlParam);
        }

        public int ExecuteNonQuery(string sqlText, System.Data.CommandType cmdType, MySql.Data.MySqlClient.MySqlParameter[] sqlParams)
        {
            return MySqlDataHelper.ExecuteNonQuery(sqlText, cmdType, sqlParams);
        }

        public object ExecuteScalar(string sqlText, System.Data.CommandType cmdType, MySql.Data.MySqlClient.MySqlParameter sqlParam)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string sqlText, System.Data.CommandType cmdType, MySql.Data.MySqlClient.MySqlParameter[] sqlParams)
        {
            throw new NotImplementedException();
        }

        public object QueryForDataSet(string sqlText, System.Data.CommandType cmdType, MySql.Data.MySqlClient.MySqlParameter sqlParam)
        {
            throw new NotImplementedException();
        }

        public object QueryForDataSet(string sqlText, System.Data.CommandType cmdType, MySql.Data.MySqlClient.MySqlParameter[] sqlParams)
        {
            throw new NotImplementedException();
        }
    }
}
