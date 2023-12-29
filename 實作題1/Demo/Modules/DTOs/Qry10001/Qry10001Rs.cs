namespace Modules.DTOs.Qry10001
{
    /// <summary>
    /// Qry10001 Response DTO
    /// </summary>
    public class Qry10001Rs : Qry10001Rq
    {
        /// <summary>
        /// 商品過期狀態
        /// </summary>
        /// <value></value>
        public string ProductStatus { get; set; }

        /// <summary>
        /// 商品過期狀態描述
        /// </summary>
        /// <value></value>
        public string ProductDesc { get; set; }
    }
}