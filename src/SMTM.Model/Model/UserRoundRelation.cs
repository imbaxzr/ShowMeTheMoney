using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XZR.Model;
namespace SMTM.Model
{
    public class UserActionRelation : IdModel
    {
        public string UserId { get; set; }

        public string ActionId { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建者Id
        /// </summary>
        public string CreatePersonId { get; set; }
    }
}
