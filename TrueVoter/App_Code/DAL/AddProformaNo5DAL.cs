using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.App_Code.DAL
{
    public class AddProformaNo5DAL
    {
        int result = 0;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);

        public int InsertAddProforma5(AddProformNo5BAL objBAL)
        {
            try
            {
                //   [Id],[PartyTypeId],[PartyNameId],[DistrictId],[LocalBodyTypeID],[LocalBodyTypeName]
                //  ,[LocalBodyId],[LocalBodyName],[ElectionTypeId],[ElectionType] ,[ElectionDate],[CandidateName]
                //  ,[CandidateMoNo],[WardNo],[SeatNo],[VerifiedId],[Verified],[NomiWithdrawId],[NomiWithdraw],[ElectionResultId]
                //  ,[ElectionResult],[CreatedBy],[CreatedDate],[IsActive]
                cmd = new SqlCommand();
                cmd.CommandText = "uspInsertAddProformaNo5Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar, 10).Value = objBAL.PartyTypeId;
                cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar, 10).Value = objBAL.PartyNameId;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = objBAL.DistrictId;
                cmd.Parameters.Add("@LocalBodyTypeID", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyTypeID;
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.NVarChar, 500).Value = objBAL.LocalBodyTypeName;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyId;
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 1000).Value = objBAL.LocalBodyName;
                cmd.Parameters.Add("@ElectionTypeId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionTypeId;
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 100).Value = objBAL.ElectionType;
                cmd.Parameters.Add("@ElectionDate", SqlDbType.NVarChar, 100).Value = objBAL.ElectionDate;
                cmd.Parameters.Add("@CandidateName", SqlDbType.NVarChar, 1000).Value = objBAL.CandidateName;
                cmd.Parameters.Add("@CandidateMoNo", SqlDbType.NVarChar, 10).Value = objBAL.CandidateMoNo;
                cmd.Parameters.Add("@WardNo", SqlDbType.NVarChar, 10).Value = objBAL.WardNo;
                cmd.Parameters.Add("@SeatNo", SqlDbType.NVarChar, 10).Value = objBAL.SeatNo;
                cmd.Parameters.Add("@VerifiedId", SqlDbType.NVarChar, 10).Value = objBAL.VerifiedId;
                cmd.Parameters.Add("@Verified", SqlDbType.NVarChar, 100).Value = objBAL.Verified;
                cmd.Parameters.Add("@NomiWithdrawId", SqlDbType.NVarChar, 10).Value = objBAL.NomiWithdrawId;
                cmd.Parameters.Add("@NomiWithdraw", SqlDbType.NVarChar, 100).Value = objBAL.NomiWithdraw;
                cmd.Parameters.Add("@ElectionResultId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionResultId;
                cmd.Parameters.Add("@ElectionResult", SqlDbType.NVarChar, 100).Value = objBAL.ElectionResult;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 100).Value = objBAL.CreatedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public int InsertAddProforma6(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspInsertAddProformaNo6Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar, 10).Value = objBAL.PartyTypeId;
                cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar, 10).Value = objBAL.PartyNameId;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = objBAL.DistrictId;
                cmd.Parameters.Add("@LocalBodyTypeID", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyTypeID;
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.NVarChar, 500).Value = objBAL.LocalBodyTypeName;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyId;
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 1000).Value = objBAL.LocalBodyName;
                cmd.Parameters.Add("@ElectionTypeId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionTypeId;
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 100).Value = objBAL.ElectionType;
                cmd.Parameters.Add("@ExpenseDate", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseDate;
                cmd.Parameters.Add("@ExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.ExpenseHeadId;
                cmd.Parameters.Add("@ExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseHeadName;
                cmd.Parameters.Add("@SubExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.SubExpenseHeadId;
                cmd.Parameters.Add("@SubExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.SubExpenseHeadName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = objBAL.Description;
                cmd.Parameters.Add("@Amount", SqlDbType.NVarChar, 100).Value = objBAL.Amount;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 100).Value = objBAL.CreatedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public int InsertAddProforma7(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspInsertAddProformaNo7Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar, 10).Value = objBAL.PartyTypeId;
                cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar, 10).Value = objBAL.PartyNameId;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = objBAL.DistrictId;
                cmd.Parameters.Add("@LocalBodyTypeID", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyTypeID;
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.NVarChar, 500).Value = objBAL.LocalBodyTypeName;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyId;
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 1000).Value = objBAL.LocalBodyName;
                cmd.Parameters.Add("@ElectionTypeId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionTypeId;
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 100).Value = objBAL.ElectionType;

                cmd.Parameters.Add("@WardNo", SqlDbType.NVarChar, 100).Value = objBAL.WardNo;
                cmd.Parameters.Add("@SeatNo", SqlDbType.NVarChar, 100).Value = objBAL.SeatNo;
                cmd.Parameters.Add("@CandidateName", SqlDbType.NVarChar, 100).Value = objBAL.CandidateName;
                cmd.Parameters.Add("@CandidateMoNo", SqlDbType.NVarChar, 100).Value = objBAL.CandidateMoNo;

                cmd.Parameters.Add("@ExpenseDate", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseDate;
                cmd.Parameters.Add("@ExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.ExpenseHeadId;
                cmd.Parameters.Add("@ExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseHeadName;
                cmd.Parameters.Add("@SubExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.SubExpenseHeadId;
                cmd.Parameters.Add("@SubExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.SubExpenseHeadName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = objBAL.Description;
                cmd.Parameters.Add("@Amount", SqlDbType.NVarChar, 100).Value = objBAL.Amount;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 100).Value = objBAL.CreatedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public int UpdateAddProforma5(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspUpdateAddProformaNo5Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = objBAL.Id;
                cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar, 10).Value = objBAL.PartyTypeId;
                cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar, 10).Value = objBAL.PartyNameId;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = objBAL.DistrictId;
                cmd.Parameters.Add("@LocalBodyTypeID", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyTypeID;
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.NVarChar, 500).Value = objBAL.LocalBodyTypeName;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyId;
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 1000).Value = objBAL.LocalBodyName;
                cmd.Parameters.Add("@ElectionTypeId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionTypeId;
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 100).Value = objBAL.ElectionType;
                cmd.Parameters.Add("@ElectionDate", SqlDbType.NVarChar, 100).Value = objBAL.ElectionDate;
                cmd.Parameters.Add("@CandidateName", SqlDbType.NVarChar, 1000).Value = objBAL.CandidateName;
                cmd.Parameters.Add("@CandidateMoNo", SqlDbType.NVarChar, 10).Value = objBAL.CandidateMoNo;
                cmd.Parameters.Add("@WardNo", SqlDbType.NVarChar, 10).Value = objBAL.WardNo;
                cmd.Parameters.Add("@SeatNo", SqlDbType.NVarChar, 10).Value = objBAL.SeatNo;
                cmd.Parameters.Add("@VerifiedId", SqlDbType.NVarChar, 10).Value = objBAL.VerifiedId;
                cmd.Parameters.Add("@Verified", SqlDbType.NVarChar, 100).Value = objBAL.Verified;
                cmd.Parameters.Add("@NomiWithdrawId", SqlDbType.NVarChar, 10).Value = objBAL.NomiWithdrawId;
                cmd.Parameters.Add("@NomiWithdraw", SqlDbType.NVarChar, 100).Value = objBAL.NomiWithdraw;
                cmd.Parameters.Add("@ElectionResultId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionResultId;
                cmd.Parameters.Add("@ElectionResult", SqlDbType.NVarChar, 100).Value = objBAL.ElectionResult;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 100).Value = objBAL.CreatedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public int UpdateAddProforma6(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspUpdateAddProformaNo6Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = objBAL.Id;
                cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar, 10).Value = objBAL.PartyTypeId;
                cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar, 10).Value = objBAL.PartyNameId;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = objBAL.DistrictId;
                cmd.Parameters.Add("@LocalBodyTypeID", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyTypeID;
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.NVarChar, 500).Value = objBAL.LocalBodyTypeName;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyId;
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 1000).Value = objBAL.LocalBodyName;
                cmd.Parameters.Add("@ElectionTypeId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionTypeId;
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 100).Value = objBAL.ElectionType;
                cmd.Parameters.Add("@ExpenseDate", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseDate;
                cmd.Parameters.Add("@ExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.ExpenseHeadId;
                cmd.Parameters.Add("@ExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseHeadName;
                cmd.Parameters.Add("@SubExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.SubExpenseHeadId;
                cmd.Parameters.Add("@SubExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.SubExpenseHeadName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = objBAL.Description;
                cmd.Parameters.Add("@Amount", SqlDbType.NVarChar, 100).Value = objBAL.Amount;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 100).Value = objBAL.CreatedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public int UpdateAddProforma7(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspUpdateAddProformaNo7Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = objBAL.Id;
                cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar, 10).Value = objBAL.PartyTypeId;
                cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar, 10).Value = objBAL.PartyNameId;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = objBAL.DistrictId;
                cmd.Parameters.Add("@LocalBodyTypeID", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyTypeID;
                cmd.Parameters.Add("@LocalBodyTypeName", SqlDbType.NVarChar, 500).Value = objBAL.LocalBodyTypeName;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 10).Value = objBAL.LocalBodyId;
                cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 1000).Value = objBAL.LocalBodyName;
                cmd.Parameters.Add("@ElectionTypeId", SqlDbType.NVarChar, 10).Value = objBAL.ElectionTypeId;
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 100).Value = objBAL.ElectionType;
                cmd.Parameters.Add("@ExpenseDate", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseDate;
                cmd.Parameters.Add("@ExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.ExpenseHeadId;
                cmd.Parameters.Add("@ExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.ExpenseHeadName;
                cmd.Parameters.Add("@SubExpenseHeadId", SqlDbType.NVarChar, 10).Value = objBAL.SubExpenseHeadId;
                cmd.Parameters.Add("@SubExpenseHead", SqlDbType.NVarChar, 100).Value = objBAL.SubExpenseHeadName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = objBAL.Description;
                cmd.Parameters.Add("@Amount", SqlDbType.NVarChar, 100).Value = objBAL.Amount;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 100).Value = objBAL.CreatedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;
                cmd.Parameters.Add("@WardNo", SqlDbType.NVarChar, 100).Value = objBAL.WardNo;
                cmd.Parameters.Add("@SeatNo", SqlDbType.NVarChar, 100).Value = objBAL.SeatNo;
                cmd.Parameters.Add("@CandidateName", SqlDbType.NVarChar, 100).Value = objBAL.CandidateName;
                cmd.Parameters.Add("@CandidateMoNo", SqlDbType.NVarChar, 100).Value = objBAL.CandidateMoNo;
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public DataSet BindDistrictDAL()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindDistrict";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindBasicDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindPartyRespData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@createdBy", SqlDbType.NVarChar,10).Value = objBAL.CreatedBy;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindExpenseHeadDAL()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindExpenseHead";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
       
        public DataSet BindPartyExpenseHeadDAL()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindPartyExpenseHead";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindCanPartyExpenseHeadDAL()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindCanPartyExpenseHead";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindLocalBodyDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindLocalBodyDistrictWise";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@distID", SqlDbType.Int).Value = objBAL.DistrictId;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindSubExpenseHeadDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindSubExpenseHead";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@distID", SqlDbType.Int).Value = objBAL.DistrictId;
            cmd.Parameters.Add("@ExpenseHead", SqlDbType.Int).Value = objBAL.ExpenseHead;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindPartySubExpenseHeadDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspPartyBindSubExpenseHead";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@distID", SqlDbType.Int).Value = objBAL.DistrictId;
            cmd.Parameters.Add("@ExpenseHead", SqlDbType.Int).Value = objBAL.ExpenseHead;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindCanPartySubExpenseHeadDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspCanPartyBindSubExpenseHead";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@distID", SqlDbType.Int).Value = objBAL.DistrictId;
            cmd.Parameters.Add("@ExpenseHead", SqlDbType.Int).Value = objBAL.ExpenseHead;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindPartytypeDAL()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindPartyType";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindPartyDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindParty";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@PartyType", SqlDbType.Int).Value = objBAL.PartyTypeId; ;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindSelectedData(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindIDwiseCandidateData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = objBAL.Id; ;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindSelectedDataProformaNo6DAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindIDwisePartyExpenses";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = objBAL.Id; ;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindSelectedDataProformaNo7DAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindIDwisePartyExpensesOnCandidate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = objBAL.Id; ;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindGridViewDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindGvCandidateData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = objBAL.CreatedBy; ;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet BindGridViewProforma6DAL(AddProformNo5BAL objBAL)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspBindgvPartyExpenses";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = objBAL.CreatedBy; ;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }

        }
        public DataSet BindGridViewProforma7DAL(AddProformNo5BAL objBAL)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspBindPartyExpenseOnCandidate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = objBAL.CreatedBy; ;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }

        }

        public int ChangeStatusDAL(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspActiveDeactiveAddProformaNo5Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = objBAL.Id;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }

        }

        public int ChangeStatusProformaNo6DAL(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspActiveDeactiveAddProformaNo6Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = objBAL.Id;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }

        }

        public int ChangeStatusProformaNo7DAL(AddProformNo5BAL objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspActiveDeactiveAddProformaNo7Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 10).Value = objBAL.Id;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 10).Value = objBAL.IsActive;
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }

        }

        public DataSet BindCandidatesDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindCandidateFromBasicData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@DistrictId", SqlDbType.Int).Value = objBAL.DistrictId;
            cmd.Parameters.Add("@LocalBodyId", SqlDbType.Int).Value = objBAL.LocalBodyId;
            cmd.Parameters.Add("@SeatNo", SqlDbType.NVarChar).Value = objBAL.SeatNo;
            cmd.Parameters.Add("@WardNo", SqlDbType.NVarChar).Value = objBAL.WardNo;
            cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar).Value = objBAL.PartyTypeId;
            cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar).Value = objBAL.PartyNameId;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public DataSet BindCandidatesFormPartyCadiListDAL(AddProformNo5BAL objBAL)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspBindCandidateFromPartyCandiList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@DistrictId", SqlDbType.Int).Value = objBAL.DistrictId;
            cmd.Parameters.Add("@LocalBodyId", SqlDbType.Int).Value = objBAL.LocalBodyId;
            cmd.Parameters.Add("@SeatNo", SqlDbType.NVarChar).Value = objBAL.SeatNo;
            cmd.Parameters.Add("@WardNo", SqlDbType.NVarChar).Value = objBAL.WardNo;
            cmd.Parameters.Add("@PartyTypeId", SqlDbType.NVarChar).Value = objBAL.PartyTypeId;
            cmd.Parameters.Add("@PartyNameId", SqlDbType.NVarChar).Value = objBAL.PartyNameId;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
}