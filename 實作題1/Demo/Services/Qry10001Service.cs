using Demo.Interfaces;
using Modules.DTOs.Qry10001;

namespace Demo.Services
{
    public class Qry10001Service : IQry10001Service
    {
        private ILogger<Qry10001Service> _logger;

        public Qry10001Service(ILogger<Qry10001Service> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 系統時間轉DateTime
        /// </summary>
        /// <param name="SysDateTime">Pos機系統時間</param>
        /// <returns></returns>
        private DateTime GetSysDateTime(string sysDtStr)
        {
            DateTime sysDt = DateTime.Parse(sysDtStr);
            return sysDt;
        }

        /// <summary>
        /// BarCode取DateTime
        /// </summary>
        /// <param name="Barcode">條碼</param>
        /// <returns></returns>
        private DateTime GetBarcodeDateTime(string barcode)
        {
            int year = int.Parse(barcode.Substring(5, 4));
            int month = int.Parse(barcode.Substring(9, 2));
            int day = int.Parse(barcode.Substring(11, 2));
            int hour = int.Parse(barcode.Substring(13, 2));
            DateTime productDt = new DateTime(year, month, day, hour, 0, 0);

            return productDt;
        }

        /// <summary>
        /// 查詢 商品過期狀態 服務
        /// </summary>
        /// <param name="sysDtStr"></param>
        /// <param name="barcode"></param>
        /// <returns>-1: 未過期; 0: 即將到期; 1: 已過期</returns>
        public string GetProductStatus(string sysDtStr, string barcode)
        {
            DateTime sysDt = GetSysDateTime(sysDtStr);
            DateTime productDt = GetBarcodeDateTime(barcode);

            TimeSpan ts = new TimeSpan(productDt.Ticks - sysDt.Ticks);
            if (ts.TotalMinutes >= 5 && ts.TotalMinutes <= 60)
                return "0";
            else if (ts.TotalMinutes > 60)
                return "-1";
            else
                return "1";
        }

        /// <summary>
        /// Mapper ProductStatus Desc
        /// </summary>
        /// <param name="productStatus"></param>
        /// <returns>-1: 未過期; 0: 即將到期; 1: 已過期</returns>
        public string GetProductStatusDesc(string productStatus)
        {
            if (productStatus == "0")
                return "商品即將到期";
            else if (productStatus == "-1")
                return "商品未過期";
            else
                return "商品已過期";
        }
    }
}