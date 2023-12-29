using System.ComponentModel.DataAnnotations;

namespace Modules.DTOs.Qry10001
{
    /// <summary>
    /// Qry10001 Request DTO
    /// </summary>
    public class Qry10001Rq
    {
        /// <summary>
        /// Pos機系統時間
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "{0}為必填欄位")]
        public string SysDateTime { get; set; }

        /// <summary>
        /// 條碼
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "{0}為必填欄位")]
        [MaxLength(15, ErrorMessage = "{0}不得多於{1}個字元")]
        [MinLength(15, ErrorMessage = "{0}不得低於{1}個字元")]
        public string Barcode { get; set; }
    }
}