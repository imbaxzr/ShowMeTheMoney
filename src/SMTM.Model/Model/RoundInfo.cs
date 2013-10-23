using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XZR.Model;
namespace SMTM.Model
{
    /// <summary>
    /// 活动信息
    /// </summary>
    public class ActionInfo : IdModel
    {
        public string GroupId { get; set; }
        /// <summary>
        /// 活动名
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 活动日期
        /// </summary>
        public DateTime ActionDate { get; set; }
        /// <summary>
        /// 此次活动消费
        /// </summary>
        public decimal ActionAmount { get; set; }

        public virtual IList<UserInfo> UserInfo { get; set; }

        public virtual IList<ExpenditureLog> ExpenditureLog { get; set; }
    }
}
