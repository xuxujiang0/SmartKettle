using MySql.Data.MySqlClient;
using SmartKettle.BLL;
using SmartKettle.Common;
using SmartKettle.Models.CommonEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartKettle.WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Login()
        {
            ApiResult<bool> apiResult = new ApiResult<bool> { code = ResultCode.CODE_SUCCESS };

            string sqlText = "INSERT INTO TB_BS_User(`ID`,`Account`,`Passwd`,`CreationUser`,`CreationDate`) VALUE(?ID,?Account,?Passwd,?CreationUser,?CreationDate)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter { ParameterName = "ID", Value = Guid.NewGuid(), MySqlDbType = MySqlDbType.VarChar });
            paramList.Add(new MySqlParameter { ParameterName = "Account", Value = "Account", MySqlDbType = MySqlDbType.VarChar });
            paramList.Add(new MySqlParameter { ParameterName = "Passwd", Value = "Passwd", MySqlDbType = MySqlDbType.VarChar });
            paramList.Add(new MySqlParameter { ParameterName = "CreationUser", Value = "CreationUser", MySqlDbType = MySqlDbType.VarChar });
            paramList.Add(new MySqlParameter { ParameterName = "CreationDate", Value = DateTime.Now, MySqlDbType = MySqlDbType.DateTime });

            int result = BasicsBLL._Current.ExecuteNonQuery(sqlText, CommandType.Text, paramList.ToArray());

            return JsonHelper.SerializeObjectToWebApi(apiResult);
        }
    }
}
