using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.Models.CommonEntities
{
 
    [Serializable]
    public class ApiResult
    {
        public string code { get; set; }
        public string msg { get; set; }
    }


    [Serializable]
    public class ApiResult<T> : ApiResult
    {
        public T data { get; set; }
    }
}
