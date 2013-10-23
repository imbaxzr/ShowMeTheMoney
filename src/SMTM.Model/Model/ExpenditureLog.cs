using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XZR.Model;
namespace SMTM.Model
{
    /// <summary>
    /// 消费记录
    /// </summary>
    public class ExpenditureLog : IdModel
    {
        public string UserId { get; set; }
        public string ActionId { get; set; }
        /// <summary>
        /// 消费合计
        /// </summary>
        public decimal ExpenditureTotall { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime ExpenditureTime { get; set; }
    }
}
