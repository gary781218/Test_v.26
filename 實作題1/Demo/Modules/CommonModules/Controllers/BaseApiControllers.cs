using Microsoft.AspNetCore.Mvc;
using Modules.CommonModules.DTOs;

namespace Modules.CommonModules.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        /// <summary>
        /// 回傳 JsonBody
        /// </summary>
        /// <param name="t"></param>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="apiStartTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected JsonResponse<T> GetJsonResult<T>(T t, string code, DateTime apiStartTime)
        {
            JsonResponse<T> rs = new JsonResponse<T>();
            rs.Body = t;
            rs.ApiStatus = new APIStatus()
            {
                Code = code,
                StartTime = apiStartTime.ToString("yyyy/MM/dd HH:mm:ss"),
                EndTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            };

            return rs;
        }
    }
}