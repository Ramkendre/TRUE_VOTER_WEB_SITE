using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.App_Code.BAL
{
    public class AddProformNo5BAL
    {
        //   [Id],[PartyTypeId],[PartyNameId],[DistrictId],[LocalBodyTypeID],[LocalBodyTypeName]
        //  ,[LocalBodyId],[LocalBodyName],[ElectionTypeId],[ElectionType] ,[ElectionDate],[CandidateName]
        //  ,[CandidateMoNo],[WardNo],[SeatNo],[VerifiedId],[Verified],[NomiWithdrawId],[NomiWithdraw],[ElectionResultId]
        //  ,[ElectionResult],[CreatedBy],[CreatedDate],[IsActive]
        int result = 0;

        public int Id { get; set; }
        public int PartyTypeId { get; set; }
        public int PartyNameId { get; set; }
        public int DistrictId { get; set; }
        public int LocalBodyTypeID { get; set; }
        public string LocalBodyTypeName { get; set; }
        public int LocalBodyId { get; set; }
        public string LocalBodyName { get; set; }
        public int ElectionTypeId { get; set; }
        public string ElectionType { get; set; }
        public DateTime ElectionDate { get; set; }
        public string CandidateName { get; set; }
        public string CandidateMoNo { get; set; }
        public string WardNo { get; set; }
        public string SeatNo { get; set; }
        public int VerifiedId { get; set; }
        public string Verified { get; set; }
        public int NomiWithdrawId { get; set; }
        public string NomiWithdraw { get; set; }
        public int ElectionResultId { get; set; }
        public string ElectionResult { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IsActive { get; set; }

        public DateTime ExpenseDate { get; set; }
        public string ExpenseHead { get; set; }
        public int ExpenseHeadId { get; set; }
        public string ExpenseHeadName { get; set; }
        public int SubExpenseHeadId { get; set; }
        public string SubExpenseHeadName { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }

        AddProformaNo5DAL objPro5DAL = new AddProformaNo5DAL();
        public int InsertData(AddProformNo5BAL objBAL)
        {
            try
            {
                result = objPro5DAL.InsertAddProforma5(objBAL);
                return result;
            }
            catch
            {
                return result;
            }
        }
        public int InsertProformaNo6Data(AddProformNo5BAL objBAL)
        {
            try
            {
                result = objPro5DAL.InsertAddProforma6(objBAL);
                return result;
            }
            catch
            {
                return result;
            }
        }
        public int InsertProformaNo7Data(AddProformNo5BAL objBAL)
        {
            try
            {
                result = objPro5DAL.InsertAddProforma7(objBAL);
                return result;
            }
            catch
            {
                return result;
            }
        }
        public int UpdateData(AddProformNo5BAL objBAL)
        {
            try
            {
                result = objPro5DAL.UpdateAddProforma5(objBAL);
                return result;
            }
            catch
            {
                return result;
            }
        }
        public int UpdateProformaNo6Data(AddProformNo5BAL objBAL)
        {
            try
            {
                result = objPro5DAL.UpdateAddProforma6(objBAL);
                return result;
            }
            catch
            {
                return result;
            }
        }
        public int UpdateProformaNo7Data(AddProformNo5BAL objBAL)
        {
            try
            {
                result = objPro5DAL.UpdateAddProforma7(objBAL);
                return result;
            }
            catch
            {
                return result;
            }
        }
        public DataSet BindDistrictBAL()
        {
            return objPro5DAL.BindDistrictDAL();
        }
        public DataSet BindExpenseHeadBAL()
        {
            return objPro5DAL.BindExpenseHeadDAL();
        }
        public DataSet BindPartyExpenseHeadBAL()
        {
            return objPro5DAL.BindPartyExpenseHeadDAL();
        }
        public DataSet BindCanPartyExpenseHeadBAL()
        {
            return objPro5DAL.BindCanPartyExpenseHeadDAL();
        }
        public DataSet BindLocalBodyBAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindLocalBodyDAL(objBAL);
        }
        public DataSet BindSubExpenseHeadBAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindSubExpenseHeadDAL(objBAL);
        }
        public DataSet BindPartySubExpenseHeadBAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindPartySubExpenseHeadDAL(objBAL);
        }
        public DataSet BindCanPartySubExpenseHeadBAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindCanPartySubExpenseHeadDAL(objBAL);
        }
        public DataSet BindPartyTypeBAL()
        {
            return objPro5DAL.BindPartytypeDAL();
        }
        public DataSet BindPartyBAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindPartyDAL(objBAL);
        }
        public DataSet BindSelectedData(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindSelectedData(objBAL);
        }
        public DataSet BindGridViewBAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindGridViewDAL(objBAL);
        }
        public DataSet BindGridViewBALProforma6(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindGridViewProforma6DAL(objBAL);
        }
        public DataSet BindGridViewBALProforma7(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindGridViewProforma7DAL(objBAL);
        }
        public DataSet BindSelectedDataProformaNo6BAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindSelectedDataProformaNo6DAL(objBAL);
        }
        public DataSet BindSelectedDataProformaNo7BAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.BindSelectedDataProformaNo7DAL(objBAL);
        }
        public int ChangeStatusBAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.ChangeStatusDAL(objBAL);
        }
         public int ChangeStatusProformaNo6BAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.ChangeStatusProformaNo6DAL(objBAL);
        }
         public int ChangeStatusProformaNo7BAL(AddProformNo5BAL objBAL)
        {
            return objPro5DAL.ChangeStatusProformaNo7DAL(objBAL);
        }

         public DataSet BindCandidatesBAL(AddProformNo5BAL objBAL)
         {
             return objPro5DAL.BindCandidatesDAL(objBAL);
         }
         public DataSet BindCandidatesFromPartyCandiListBAL(AddProformNo5BAL objBAL)
         {
             return objPro5DAL.BindCandidatesFormPartyCadiListDAL(objBAL);
         }
         public DataSet BindBasicBAL(AddProformNo5BAL objBAL)
         {
             return objPro5DAL.BindBasicDAL(objBAL);
         }
    }
}