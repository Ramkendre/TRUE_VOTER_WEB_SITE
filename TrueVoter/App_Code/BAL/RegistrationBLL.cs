using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using TrueVoter.App_Code.DAL;
using TrueVoter.App_Code.BAL;
using System.Security;
using App_Code.BAL;

namespace TrueVoter.App_Code.BAL
{
    public class RegistrationBLL : CommonCode
    {
        public RegistrationBLL()
        { }
        EncDecArrayClass objenc = new EncDecArrayClass();
        public string NewRegistration(string registrationString) //Want to change in this service as enc and dec algo
        {
            try
            {
                if (registrationString != null && !String.IsNullOrEmpty(registrationString) && !String.IsNullOrWhiteSpace(registrationString))
                {
                    String[] dataArray = registrationString.Split(new char[] { '*' });
                    if (dataArray.Length == 8)
                    {
                        //insert into database
                        Random otpGenerator = new Random();
                        string otpNumber = otpGenerator.Next(1000, 9999).ToString();
                        RegistrationDAL registrationDal = new RegistrationDAL();
                        CommonCode commonCode = new CommonCode();
                       // string password = commonCode.DESEncrypt(dataArray[3]);

                        //string password = dataArray[3];
                        string password = dataArray[3];
                        string userName = dataArray[2];

                        userName = EncryptDecrypt.DecodeAndDecrypt(userName);
                        password = EncryptDecrypt.DecodeAndDecrypt(password);


                        string pw = password.Substring(0, password.Length - 12);
                        password = commonCode.DESEncrypt(pw);

                        string dt1 = userName.Substring(userName.Length - 12);
                        userName = userName.Substring(0, userName.Length - 12);

                        string retVal = objenc.DateTimeDec(dt1);

                        if (retVal == "0")
                        {
                            return CommonCode.SQL_ERROR.ToString();
                        }

                        //string result = registrationDal.newRegistration(dataArray[0], dataArray[1], dataArray[2], password, otpNumber, dataArray[4], dataArray[5], dataArray[6], dataArray[7]);
                        string result = registrationDal.newRegistration(dataArray[0], dataArray[1], userName, password, otpNumber, dataArray[4], dataArray[5], dataArray[6], dataArray[7]);
                        string[] r = result.Split(new Char[] { '*' });
                        if (r[0] == CommonCode.OK.ToString())
                        {
                            //string message = "Dear " + dataArray[2] + " thanks to Register your Voter Profile in True Voter app. OTP for profile confirmation is " + otpNumber + "";
                            string message = "Dear " + userName + " thanks to Register your Voter Profile in True Voter app. OTP for profile confirmation is " + otpNumber + "";
                            SendSMS(dataArray[1], message);
                        }
                        return result.ToString();
                    }
                    else
                    {
                        return CommonCode.WRONG_INPUT.ToString();
                    }
                }
                return CommonCode.WRONG_INPUT.ToString();
            }
            catch (Exception)
            {
                return CommonCode.ERROR.ToString();
            }
        }

        public string checkOtp(string mobileNo, string otp) //Want to change in this service as enc and dec algo
        {
            RegistrationDAL registrationDal = new RegistrationDAL();

            string[] uregid = mobileNo.Split('$');
            string[] otpid = otp.Split('$');

            mobileNo = objenc.DecryptInteger(uregid[0], uregid[1]);
            otp = objenc.DecryptInteger(otpid[0], otpid[1]);

            return registrationDal.checkOtp(mobileNo, otp);
        }

        public string resendOtp(string mobileNo) //Want to change in this service as enc and dec algo
        {
            string[] uregid = mobileNo.Split('$');
            mobileNo = objenc.DecryptInteger(uregid[0], uregid[1]);

            RegistrationDAL registrationDal = new RegistrationDAL();
            string result = registrationDal.resendOTP(mobileNo);
            if (result != "" && result != CommonCode.WRONG_INPUT.ToString() && result != CommonCode.SQL_ERROR.ToString() && result != CommonCode.ERROR.ToString() && result != CommonCode.WRONG_INPUT.ToString())
            {
                CommonCode commoncode = new CommonCode();
                string message = "Dear " + mobileNo + " thanks to Register your Voter Profile in True Voter app. OTP for profile confirmation is " + result + "";
                commoncode.SMS(mobileNo, message);
                return CommonCode.OK.ToString();
            }
            else
            {
                return WRONG_INPUT.ToString();
            }
        }

        public int newProfile(string profileString, string photo)
        {
            try
            {
                string[] dataArray = profileString.Split(new char[] { '*' });
                if (dataArray.Length == 35)
                {
                    Profile userProfile = new Profile();

                    string[] uregid = dataArray[0].Split('$');
                    string substr = uregid[0].Substring(0, 3);
                    string ump = uregid[0].ToString();
                    int len = ump.Length;
                    len = len - 3;
                    ump = ump.Substring(3, len);

                    userProfile.RegId = objenc.DecryptInteger(ump, uregid[1]);
                    userProfile.RegId = substr + userProfile.RegId;

                    //dataArray[0];
                    userProfile.dob = dataArray[1];
                    userProfile.email = dataArray[2];
                    userProfile.photo = photo;
                    userProfile.userType = 1;
                    userProfile.imeiNo = dataArray[3];
                    userProfile.registrationDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    userProfile.updationDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    userProfile.status = 1;
                    userProfile.loginId = "0";
                    userProfile.acno = dataArray[4];
                    userProfile.partNo = dataArray[5];
                    userProfile.slnoinpart = dataArray[6];
                    userProfile.houseNo = dataArray[7];
                    userProfile.sectionno = dataArray[8];
                    userProfile.fm_name_v1 = dataArray[9];
                    userProfile.Lastname_v1 = dataArray[10];
                    userProfile.RLN_TYPE = dataArray[11];
                    userProfile.RLN_FM_NM_v1 = dataArray[12];
                    userProfile.RLN_L_NM_v1 = dataArray[13];
                    userProfile.IDCARD_NO = dataArray[14];
                    userProfile.STATUSTYPE = dataArray[15];
                    userProfile.SEX = dataArray[16];
                    userProfile.AGE = dataArray[17];
                    userProfile.FM_NAMEEN = dataArray[18];
                    userProfile.LASTNAMEEN = dataArray[19];
                    userProfile.RLN_FM_NMEN = dataArray[20];
                    userProfile.RLN_L_NMEN = dataArray[21];
                    userProfile.FULL_NAMEEN = dataArray[22];
                    userProfile.EB_No = dataArray[23];
                    userProfile.Allocated_Ward = dataArray[24];
                    userProfile.SerialNo_InWard = dataArray[25];
                    userProfile.BoothNo = dataArray[26];
                    userProfile.SerialNo_ForFinalList = dataArray[27];
                    userProfile.old_serialIn_ward = dataArray[28];
                    userProfile.localBody = dataArray[29];
                    userProfile.uid = dataArray[30];
                    userProfile.latitude = dataArray[31];
                    userProfile.langitute = dataArray[32];
                    userProfile.distritId = dataArray[33];
                    userProfile.assemblyId = dataArray[34];
                    userProfile.assemblyId = dataArray[35]; //Added18-1-17
                    RegistrationDAL registrationDal = new RegistrationDAL();
                    return registrationDal.addProfile(userProfile);
                }
                else
                    return CommonCode.WRONG_INPUT;
            }
            catch (Exception)
            {
                return CommonCode.ERROR;
            }
        }
    }
}