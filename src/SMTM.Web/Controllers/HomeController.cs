using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SMTM.Model;
using SMTM.Model.Business;
namespace SMTM.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            List<UserInfo> userList = UserInfoBLL.Search().Take(5).ToList();


            return PartialView("_UserList", userList);
        }
    }
}
