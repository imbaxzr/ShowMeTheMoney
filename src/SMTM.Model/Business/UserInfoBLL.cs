using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SMTM.DataAccess;
namespace SMTM.Model.Business
{
    public class UserInfoBLL
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        static public UserInfo Search(string userId)
        {
            UserInfo user = new UserInfoDAL().SearchById(userId);
            // LoadWalletInfo(user);
            //LoadExpenditureLog(user);
            return user;
        }
        static public List<UserInfo> Search()
        {
            return new UserInfoDAL().Search().OrderBy(e => e.UserTotal).ToList();
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        static public Exception Create(UserInfo user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                user.UserCreateDate = DateTime.Now;
                WalletInfo wallet = new WalletInfo { UserId = user.Id };
                var result = WalletInfoBLL.Create(wallet);
                if (result == null)
                {
                    new UserInfoDAL().Create(user);
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
        /// <summary>
        /// 更改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        static public Exception Update(UserInfo user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Id) || user == null)
                {
                    return new Exception("User does not exits or empty!");
                }
                new UserInfoDAL().Update(user);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
        /// <summary>
        /// 加载钱包信息
        /// </summary>
        /// <param name="user"></param>
        static public WalletInfo LoadWalletInfo(UserInfo user)
        {
            user.WalletInfo = WalletInfoBLL.SearchByUserId(user.Id);
            return user.WalletInfo;
        }
        /// <summary>
        /// 加载消费日志
        /// </summary>
        /// <param name="user"></param>
        static public IList<ExpenditureLog> LoadExpenditureLog(UserInfo user)
        {
            user.ExpenditureLog = ExpenditureLogBLL.SearchByUserId(user.Id);
            return user.ExpenditureLog;
        }
    }
}
