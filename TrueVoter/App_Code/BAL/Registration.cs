using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrueVoter.App_Code.BAL
{
    public class Registration
    {
        private string registrationName, userMobileNo, loginUserName, loginPassword;
        public Registration(string name, string mobileNo, string userName, string password)
        {
            this.registrationName = name;
            this.userMobileNo = mobileNo;
            this.loginUserName = userName;
            this.loginPassword = password;
        }
        public bool isValid()
        {
            if (
                registrationName == null || registrationName == " " ||
                userMobileNo == null || userMobileNo == " " || userMobileNo.Length != 10 ||
                loginUserName == null || loginUserName == " " ||
                loginPassword == null || loginPassword == " ")
            {
                return false;
            }
            else
                return true;
        }
    }
}