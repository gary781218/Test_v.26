using Microsoft.AspNetCore.Mvc;
using Modules.CommonModules.Controllers;
using Modules.CommonModules.Contants;
using Demo.Interfaces;
using Modules.DTOs.Qry10001;
using Modules.CommonModules.DTOs;

namespace Demo.Controllers;

public class Qry10001Controller : BaseApiController
{
    private const string ControllerTXID = "Qry10001";
    private const string ControllerTXNAME = "";
    private readonly ILogger<Qry10001Controller> _logger;
    private readonly IQry10001Service _Qry10001Service;


    /// <summary>
    /// Qry10001類型 API
    /// </summary>
    public Qry10001Controller(
        ILogger<Qry10001Controller> logger,
        IQry10001Service Qry10001Service
    )
    {
        _logger = logger;
        _Qry10001Service = Qry10001Service;
    }

    #region 查詢 商品過期狀態 API
    /// <summary>
    /// 查詢 商品過期狀態 API
    /// </summary>
    /// <remarks>
    /// <pre>
    ///
    /// ==========================================================================
    /// 未過期範例:
    /// { 
    ///    "SysDateTime": "2023/12/28 21:55",
    ///    "Barcode": "ABCDE2023122823"
    /// }
    /// ==========================================================================
    /// 商品即將到期範例:
    /// { 
    ///    "SysDateTime": "2023/12/28 22:00",
    ///    "Barcode": "ABCDE2023122823"
    /// }
    /// ==========================================================================
    /// 過期範例:
    /// { 
    ///    "SysDateTime": "2023/12/28 22:56",
    ///    "Barcode": "ABCDE2023120123"
    /// }
    /// ==========================================================================
    ///
    /// </pre>
    /// </remarks>
    /// <param name="rqObj"></param>
    /// <returns></returns>
    [HttpPost("Query")]
    public JsonResponse<Qry10001Rs> Query(Qry10001Rq rqObj)
    {
        DateTime apiStartDt = DateTime.Now;
        Qry10001Rs rs = new Qry10001Rs();

        try
        {
            // 1. Mapper rq
            rs.SysDateTime = rqObj.SysDateTime;
            rs.Barcode = rqObj.Barcode;

            // 2. 取得過期狀態
            string productStatus = _Qry10001Service.GetProductStatus(rqObj.SysDateTime, rqObj.Barcode);

            // 3. 取得過期訊息
            string productStatudDesc = _Qry10001Service.GetProductStatusDesc(productStatus);

            // 4. Desc 回填
            rs.ProductStatus = productStatus;
            rs.ProductDesc = productStatudDesc;


            return GetJsonResult(rs, ApiStatusCode.SUCCESS, apiStartDt);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, "Qry10001 Query Error");
            return GetJsonResult<Qry10001Rs>(rs, ApiStatusCode.ERROR, apiStartDt);
        }
        finally
        {

        }
    }
    #endregion
}
