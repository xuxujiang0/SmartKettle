using MySql.Data.MySqlClient;
using SmartKettle.BLL;
using SmartKettle.Common;
using SmartKettle.Models;
using SmartKettle.Models.CommonEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartKettle.Factory;
using SmartKettle.Interfaces.IBLL;

namespace SmartKettle.WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        //[HttpGet]
        //public HttpResponseMessage Login()
        //{
        //    ApiResult<bool> apiResult = new ApiResult<bool> { code = ResultCode.CODE_SUCCESS };


        //    return JsonHelper.SerializeObjectToWebApi(apiResult);
        //}
        [HttpGet]
        public void test()
        {
            //List<MySqlParameter> paramList = new List<MySqlParameter>();
            //paramList.Add(new MySqlParameter { ParameterName = "ID", Value = Guid.NewGuid(), MySqlDbType = MySqlDbType.VarChar });
            //paramList.Add(new MySqlParameter { ParameterName = "Account", Value = "Account", MySqlDbType = MySqlDbType.VarChar });
            //paramList.Add(new MySqlParameter { ParameterName = "Passwd", Value = "Passwd", MySqlDbType = MySqlDbType.VarChar });
            //paramList.Add(new MySqlParameter { ParameterName = "CreationUser", Value = "CreationUser", MySqlDbType = MySqlDbType.VarChar });
            //paramList.Add(new MySqlParameter { ParameterName = "CreationDate", Value = DateTime.Now, MySqlDbType = MySqlDbType.DateTime });
            try
            {
                TB_MemberInfo info = new TB_MemberInfo() { Account = "xuxujiang0", Passwd = "xuxujiang0", Name = "徐大师", Age = 18, CreationDate = DateTime.Now, CreationUser = "xuxujiang0" };
                List<MySqlParameter> paramList = MySqlParameterHelper.GetMySqlParameter<TB_MemberInfo>(info);
                string sqlText = "INSERT INTO tb_memberinfo(`Account`,`Passwd`,`CreationUser`,`CreationDate`) VALUE(?Account,?Passwd,?CreationUser,?CreationDate)";
                IBasicsBLL model = Factory.Factory.CreateInstall<BasicsBLL, IBasicsBLL>();
                 int result = model.ExecuteNonQuery(sqlText, CommandType.Text, paramList.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
