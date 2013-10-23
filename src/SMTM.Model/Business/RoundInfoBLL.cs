using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SMTM.DataAccess;
namespace SMTM.Model.Business
{
    public class ActionInfoBLL
    {
        /// <summary>
        /// 创建Action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        static public ActionInfo Create(ActionInfo action)
        {
            try
            {
                action.Id = Guid.NewGuid().ToString();
                action.ActionDate = DateTime.Now;
                new ActionInfoDAL().Create(action);
            }
            catch (Exception ex)
            {

            }
            return action;
        }
    }
}
