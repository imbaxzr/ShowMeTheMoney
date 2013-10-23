using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SMTM.DataAccess;
namespace SMTM.Model.Business
{
    public class WalletInfoBLL
    {
        static public WalletInfo Search(string id)
        {
            return new WalletInfoDAL().SearchById(id);
        }

        static public WalletInfo SearchByUserId(string userId)
        {
            return new WalletInfoDAL().Search(new WalletInfo { UserId = userId }).First();
        }

        static public Exception Create(WalletInfo wallet)
        {
            try
            {
                wallet.Id = Guid.NewGuid().ToString();
                new WalletInfoDAL().Create(wallet);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
    }
}
