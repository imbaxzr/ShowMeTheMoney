using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SMTM.Model;
using SMTM.Model.Business;
namespace SMTM.Web.Controllers
{
    public class ActionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 新建活动
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateNewAction()
        {
            return View();
        }
        /// <summary>
        /// 活动中允许出现的用户
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInAction()
        {
            List<UserInfo> userList = UserInfoBLL.Search().OrderBy(e => e.UserName).ToList();

            return PartialView("_UserInAction", userList);
        }
        /// <summary>
        /// 付款人列表
        /// </summary>
        /// <returns></returns>
        public ActionResult OwnerList()
        {
            List<UserInfo> userList = UserInfoBLL.Search().OrderBy(e => e.UserName).ToList();
            return PartialView("_OwnerList", userList);
        }
        /// <summary>
        /// 创建活动
        /// </summary>
        /// <param name="actionJson"></param>
        /// <param name="users"></param>
        /// <param name="date"></param>
        /// <param name="payerId"></param>
        public void CreateAction(string actionJson, string users, string date, string payerId)
        {
            try
            {
                ActionInfo entity = JsonTools.JsonToObject<ActionInfo>(actionJson);
                List<string> userList = JsonTools.JsonToObject<List<string>>(users);

                if (entity != null && userList.Count > 0)
                {
                    //保存活动信息
                    ActionInfo actionEntity = SaveActionInfo(entity, date);
                    //保存支付人信息
                    SavePayerInfo(payerId, actionEntity);
                    //按照活动金额计算用户余额
                    SaveUserInfo(actionEntity, userList);
                    //按照活动信息计算用户消费日志
                    SaveExpenditureInfo(actionEntity, userList);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存支付人信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        private void SavePayerInfo(string id, ActionInfo action)
        {
            if (!string.IsNullOrEmpty(id))
            {
                UserInfo user = UserInfoBLL.Search(id);
                user.UserTotal = user.UserTotal + action.ActionAmount;
                UserInfoBLL.Update(user);
            }
        }

        /// <summary>
        /// 保存Action
        /// </summary>
        /// <param name="action"></param>
        private ActionInfo SaveActionInfo(ActionInfo action, string date)
        {
            action.ActionDate = DateTime.Parse(date);
            return ActionInfoBLL.Create(action);
        }
        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="action"></param>
        /// <param name="idList"></param>
        private void SaveUserInfo(ActionInfo action, List<string> idList)
        {
            var userAvg = action.ActionAmount / idList.Count;

            foreach (var id in idList)
            {
                if (string.IsNullOrEmpty(id))
                {
                    continue;
                }

                UserInfo user = UserInfoBLL.Search(id);
                user.UserTotal = user.UserTotal - userAvg;
                UserInfoBLL.Update(user);
            }
        }
        /// <summary>
        /// 保存消费记录
        /// </summary>
        /// <param name="action"></param>
        /// <param name="idList"></param>
        private void SaveExpenditureInfo(ActionInfo action, List<string> idList)
        {
            foreach (var id in idList)
            {
                ExpenditureLog log = new ExpenditureLog();
                log.ActionId = action.Id;
                log.ExpenditureTime = action.ActionDate;
                log.ExpenditureTotall = action.ActionAmount / idList.Count;
                log.UserId = id;

                ExpenditureLogBLL.Create(log);
            }

        }
    }
}
