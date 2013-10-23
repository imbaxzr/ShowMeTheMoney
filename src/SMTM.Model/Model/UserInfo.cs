using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XZR.Model;
namespace SMTM.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : IdModel
    {
        public string WalletId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? UserCreateDate { get; set; }
        /// <summary>
        /// 剩余金额
        /// </summary>
        public decimal UserTotal { get; set; }
        /// <summary>
        /// 钱包信息
        /// </summary>
        public virtual WalletInfo WalletInfo { get; set; }

        public virtual IList<ExpenditureLog> ExpenditureLog { get; set; }

    }
}
