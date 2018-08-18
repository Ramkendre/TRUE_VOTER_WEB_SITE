using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.App_Code.BAL
{
    public class frmDownloadSRateBAL
    {
        frmDownloadSRateDAL objSRDAL = new frmDownloadSRateDAL();
        public int  DistID { get; set; }

        public int LocalBodyId { get; set; }
        public DataSet BindDistrictBAL()
        {
            return objSRDAL.BindDistrictDAL();
        }
        public DataSet BindLocalBodyBAL(frmDownloadSRateBAL objBAL)
        {
            return objSRDAL.BindLocalBodyDAL(objBAL);
        }
        public DataSet BindSRates(frmDownloadSRateBAL objBAL)
        {
            return objSRDAL.BindStandardRates(objBAL);
        }
    }
}