using SmartKettle.Common;
using SmartKettle.Models.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartKettle.WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(string account, string password)
        {
            ApiResult<bool> apiResult = new ApiResult<bool> { code = ResultCode.CODE_SUCCESS};
             
            return JsonHelper.SerializeObjectToWebApi(apiResult);
        }
    }
}
