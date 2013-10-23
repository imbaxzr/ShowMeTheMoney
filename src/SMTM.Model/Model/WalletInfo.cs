using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XZR.Model;
namespace SMTM.Model
{
    public class WalletInfo : IdModel
    {
        public string UserId { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        public decimal WalletTotal { get; set; }
    }
}
