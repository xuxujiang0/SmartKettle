using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.Common
{
    public class MySqlParameterHelper
    {
        public static List<MySqlParameter> GetMySqlParameter(Dictionary<string, object> paramDicList)
        {
            List<MySqlParameter> param = new List<MySqlParameter>();
            foreach (var item in paramDicList)
            {
                Type objType = item.Value.GetType();
                MySqlDbType tt = MySqlDbType.Int32;
                switch (objType.FullName)
                {
                    case "System.Int32":
                        tt = MySqlDbType.Int32;
                        break;
                    case "System.String":
                        tt = MySqlDbType.VarChar;
                        break;
                    case "System.DateTime":
                        tt = MySqlDbType.DateTime;
                        break;
                    case "System.Boolean":
                        tt = MySqlDbType.Bit;
                        break;
                    case "System.Single":
                        tt = MySqlDbType.Float;
                        break;
                    case "System.Double":
                        tt = MySqlDbType.Double;
                        break;
                }
                param.Add(new MySqlParameter { ParameterName = string.Format("?{0}", item.Key), Value = item.Value, MySqlDbType = tt });
            }
            return param;
        }

    }
}
