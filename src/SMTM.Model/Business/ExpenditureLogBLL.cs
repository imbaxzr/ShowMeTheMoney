using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SMTM.DataAccess;
namespace SMTM.Model.Business
{
    public class ExpenditureLogBLL
    {
        //public List<ExpenditureLog> Search()
        //{ 

        //}
        //public ExpenditureLog Search(string id)
        //{

        //}
        static public List<ExpenditureLog> SearchByUserId(string userId)
        {
            return new ExpenditureLogDAL().Search(new ExpenditureLog { UserId = userId });
        }

        static public Exception Create(ExpenditureLog log)
        {
            try
            {
                log.Id = Guid.NewGuid().ToString();
                new ExpenditureLogDAL().Create(log);
            }
            catch (Exception ex)
            {

                return ex;
            }
            return null;
        }
    }
}
