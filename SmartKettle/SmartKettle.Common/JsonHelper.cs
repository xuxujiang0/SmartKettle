using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// WebApi 返回josn使用，解决返回值带转义字符
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static HttpResponseMessage SerializeObjectToWebApi(object t)
        {
            //ObjectAttributeNullProcessingHelper.ObjectDefault(t);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
    }
}
