using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrueVoter.App_Code.BAL
{
    public class ExpenseLimit
    {
        private string _electiontype;

        public string ElectionType
        {
            get { return _electiontype; }
            set { _electiontype = value; }
        }
        private string _members;

        public string Members
        {
            get { return _members; }
            set { _members = value; }
        }
        private string _expenselimit;

        public string Expenselimit
        {
            get { return _expenselimit; }
            set { _expenselimit = value; }
        }

        #region List Of Expense Limit Data
        DataTable dt = new DataTable();
        public DataTable CreateMcList()
        {
           // List<ExpenseLimit> listExpenseLimit = new List<ExpenseLimit>
           //{
           //    new ExpenseLimit { ElectionType = "M.C", Members = "BMMC", Expenselimit = "1000000.00" },
           //    new ExpenseLimit { ElectionType = "M.C", Members = "161 to 175 Members", Expenselimit = "1000000.00" },
           //     new ExpenseLimit { ElectionType = "M.C", Members = "151 To 160 Members", Expenselimit = "1000000.00" },
           //    new ExpenseLimit { ElectionType = "M.C", Members = "116 To 150 Members", Expenselimit = "800000.00" },
           //    new ExpenseLimit { ElectionType = "M.C", Members = "89 To 85 Members", Expenselimit = "700000.00" },
           //    new ExpenseLimit { ElectionType = "M.C", Members = "65 To 85 Members", Expenselimit = "500000.00" }
           //};
           // return listExpenseLimit.ToList();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                using(SqlCommand cmd=new SqlCommand())
                {
                    using(SqlDataAdapter da=new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "ExpenseLimitData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@electiontype", 1);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable CreateZpList()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "ExpenseLimitData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@electiontype", 4);
                       
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataTable CreatePsList()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "ExpenseLimitData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@electiontype", 5);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataTable CreateGpList()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "ExpenseLimitData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@electiontype", 6);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        //public List<ExpenseLimit> CreateMCouncilList()
        //{
        //    List<ExpenseLimit> listExpenseLimit = new List<ExpenseLimit>
        //   {
        //       new ExpenseLimit { ElectionType = "1", Members = "BMMC", ExpenseLimit = "1000000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "161 to 175 Members", ExpenseLimit = "1000000.00" },
        //        new ExpenseLimit { ElectionType = "1", Members = "151 To 160 Members", ExpenseLimit = "1000000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "116 To 150 Members", ExpenseLimit = "800000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "89 To 85 Members", ExpenseLimit = "700000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "65 To 160 Members", ExpenseLimit = "500000.00" }
        //   };
        //    return listExpenseLimit.ToList();
        //}
        //public List<ExpenseLimit> CreateNpList()
        //{
        //    List<ExpenseLimit> listExpenseLimit = new List<ExpenseLimit>
        //   {
        //       new ExpenseLimit { ElectionType = "1", Members = "BMMC", ExpenseLimit = "1000000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "161 to 175 Members", ExpenseLimit = "1000000.00" },
        //        new ExpenseLimit { ElectionType = "1", Members = "151 To 160 Members", ExpenseLimit = "1000000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "116 To 150 Members", ExpenseLimit = "800000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "89 To 85 Members", ExpenseLimit = "700000.00" },
        //       new ExpenseLimit { ElectionType = "1", Members = "65 To 160 Members", ExpenseLimit = "500000.00" }
        //   };
        //    return listExpenseLimit.ToList();
        //}
        #endregion
    }
}