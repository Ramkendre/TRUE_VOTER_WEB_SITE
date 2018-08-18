using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.App_Code.BAL
{
    public class LoginBAL
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }

        public DataSet GetLoginDetails(LoginBAL objloginBAL)
        {
            LoginDAL objLoginDAL=new LoginDAL();
            return objLoginDAL.GetLoginDetails(objloginBAL);
        }

        public DataSet GetLoginPassword(LoginBAL objloginBAL)
        {
            LoginDAL objLoginDAL = new LoginDAL();
            return objLoginDAL.GetLoginDetailsPwd(objloginBAL);
        }
    }
}