using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.Interfaces.IBLL
{
    public interface IBasicsBLL
    {
        int ExecuteNonQuery(string sqlText, CommandType cmdType, MySqlParameter sqlParam);
        int ExecuteNonQuery(string sqlText, CommandType cmdType, MySqlParameter[] sqlParams);

        object ExecuteScalar(string sqlText, CommandType cmdType, MySqlParameter sqlParam);
        object ExecuteScalar(string sqlText, CommandType cmdType, MySqlParameter[] sqlParams);

        object QueryForDataSet(string sqlText, CommandType cmdType, MySqlParameter sqlParam);
        object QueryForDataSet(string sqlText, CommandType cmdType, MySqlParameter[] sqlParams);
    }
}
