using Modules.DTOs.Qry10001;

namespace Demo.Interfaces
{
    public interface IQry10001Service
    {
        /// <summary>
        /// 查詢 商品過期狀態 介面
        /// </summary>
        /// <param name="SysDateTime">Pos機系統時間</param>
        /// <param name="Barcode">條碼</param>
        /// <returns></returns>
        string GetProductStatus(string SysDateTime, string Barcode);

        /// <summary>
        /// Mapper Desc
        /// </summary>
        /// <param name="SysDateTime">Pos機系統時間</param>
        /// <param name="Barcode">條碼</param>
        /// <returns></returns>
        string GetProductStatusDesc(string productStatus);
    }
}