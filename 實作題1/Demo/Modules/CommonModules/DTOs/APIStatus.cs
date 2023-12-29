namespace Modules.CommonModules.DTOs
{
    /// <summary>
    /// API 結果 DTO
    /// </summary>
    public class APIStatus
    {
        /// <summary>
        /// API 結果代碼
        /// </summary>
        /// <value></value>
        public string Code { get; set; }

        /// <summary>
        /// API 結果敘述 
        /// </summary>
        /// <value></value>
        public string Desc { get; set; }

        

        /// <summary>
        /// API 起始時間
        /// </summary>
        /// <value></value>
        public string StartTime { get; set; }

        /// <summary>
        /// API 執行完成時間
        /// </summary>
        /// <value></value>
        public string EndTime { get; set; }
    }
}