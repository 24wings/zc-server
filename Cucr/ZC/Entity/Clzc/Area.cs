using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucr.CucrSaas.ZC.Entity.Clzc {
    /// <summary>
    /// 
    /// </summary>
    [Table ("sys_area")]
    public class Area {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int PID { get; set; }
        public string NAME { get; set; }
        public string PINYIN { get; set; }
        public string SHOT_PINYIN { get; set; }
        public string TIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool? TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string EXPAND { get; set; }
    }
}