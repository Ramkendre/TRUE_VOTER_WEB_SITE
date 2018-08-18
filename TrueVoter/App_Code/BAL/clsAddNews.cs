using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.App_Code.BAL
{
    public class clsAddNews
    {
        clsAddNewsDAL objCls = new clsAddNewsDAL();
        //Id, NewsScope, NewsScopeName, DistrictId, localBodyId, Header, Description, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, IsActive
        public int Id { get; set; }
        public int NewsScope { get; set; }
        public string NewsScopeName { get; set; }
        public int DistrictId { get; set; }
        public int localBodyId { get; set; }
        public string Header{ get; set; }
        public string Description { get; set; }
        public string  CreatedBy{ get; set; }
        public string CreatedDate { get; set; }

        public string Insert(clsAddNews objBAL)
        {
            try
            {
                return objCls.Insert(objBAL);
            }
            catch
            {
                return "0";
            }
        }

        public DataSet BindGridBAL(clsAddNews objBAL)
        {
            try
            {
                return objCls.BindGridBAL(objBAL);
            }
            catch
            {
                return objCls.BindGridBAL(objBAL);
            }
        }
    }
}