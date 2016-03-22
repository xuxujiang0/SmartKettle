using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.Common
{
    /// <summary>
    /// 返回的结果code
    /// </summary>
    public class ResultCode
    {
        //错误码
        /// <summary>
        /// 成功！200
        /// </summary>
        public static String CODE_SUCCESS = "200"; // 成功
        //错误码
        /// <summary>
        /// 失败但不影响流程！300
        /// </summary>
        public static String CODE_Fail = "300"; // 失败但不影响流程
        /// <summary>
        /// 异常！500
        /// </summary>
        public static String CODE_EXCEPTION = "500"; // 异常
        /// <summary>
        /// 未登陆！600
        /// </summary>
        public static String CODE_NOT_LOGIN = "600"; //未登陆
    }
}
