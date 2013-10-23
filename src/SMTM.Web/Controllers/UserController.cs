using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SMTM.Model;
using SMTM.Model.Business;
namespace SMTM.Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 用户Session的Key
        /// </summary>
        private const string Session_UserKey = "_session_user_key_";

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIn()
        {
            UserInfo currentUser = (UserInfo)Session[Session_UserKey];
            if (currentUser == null)
            {
                return PartialView("_LogIn");
            }
            else
            {
                return Content("");
            }
        }

        /// <summary>
        /// 显示用户名
        /// </summary>
        /// <returns></returns>
        public ActionResult UserName()
        {
            UserInfo currentUser = (UserInfo)Session[Session_UserKey];
            return PartialView("_UserName", currentUser);
        }

        /// <summary>
        /// 新建用户
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUser()
        {
            return View();
        }

        public void SaveUser(string userJson)
        {

            try
            {
                var user = JsonTools.ToObject<UserInfo>(userJson);
                UserInfoBLL.Create(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
