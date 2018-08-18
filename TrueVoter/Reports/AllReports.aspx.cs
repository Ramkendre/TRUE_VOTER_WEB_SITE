//using BLL;
//using BOL;
using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class AllReports : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet dscount = new DataSet();
        ArrayList ArryLst1 = new ArrayList();
        ArrayList ArryLst2 = new ArrayList();
        string LSTString = "";
        string Chklist = "";
        string tableName = string.Empty;
        string LblColName = string.Empty;

        string AdminMobNo = string.Empty;
        DataSet ds2 = new DataSet();

        string mob = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //loadDDLField();
                loadAllTable();
            }
        }

        public string loginSession()
        {
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
            }
            else
            {
                Response.Redirect("../Home/Logout");
            }
            return mob;
        }

        public void loadAllTable()
        {
            string sql = "select [TId],[DisplayTableName] from [ItemMasterTable]";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);

            ddlMstTable.DataSource = ds.Tables[0];
            ddlMstTable.DataTextField = "DisplayTableName";
            ddlMstTable.DataValueField = "TId";
            ddlMstTable.DataBind();
            ddlMstTable.Items.Add("--Select--");
            ddlMstTable.SelectedIndex = ddlMstTable.Items.Count - 1;           
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Sql = string.Empty;
            string fldMstId = string.Empty; string DuptColname = string.Empty;
            string colId = string.Empty; string dtype = string.Empty;

            SqlDataAdapter da = new SqlDataAdapter();
            Sql = "Select [TableColumnName],[TableId],[LblColumnName],[ColId],[Type] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
            DataSet Dtset = new DataSet();
            da = new SqlDataAdapter(Sql, con);
            da.Fill(Dtset);
            lstbox2.Items.Clear();
            colId = Convert.ToString(Dtset.Tables[0].Rows[0]["ColId"]);
            dtype = Convert.ToString(Dtset.Tables[0].Rows[0]["Type"]);
            if (Dtset.Tables[0].Rows.Count > 0)
            {
                //if (colId == "21")
                //{
                //    Sql = "select [EID],[ExpenseType] from [tblExpenseType]  where [fieldId]='" + colId + "'";
                //    DataSet ds = new DataSet();
                //    da = new SqlDataAdapter(Sql, con);
                //    da.Fill(ds);

                //    ddlFieldItem.DataSource = ds.Tables[0];
                //    ddlFieldItem.DataTextField = "ExpenseType";
                //    ddlFieldItem.DataValueField = "EID";
                //    ddlFieldItem.DataBind();

                //    ddlFieldItem.Items.Add("--Select--");
                //    ddlFieldItem.SelectedIndex = ddlFieldItem.Items.Count - 1;
                //    ddlFieldItem.Visible = true;
                //    txtSrchNumber.Visible = false;
                //    txtDate.Visible = false;
                //}
                if (dtype == "date")
                {
                    txtDate.Visible = true;
                    txtSrchNumber.Visible = false;
                    ddlFieldItem.Visible = false;
                    txtSrchChar.Visible = false;
                }

                else if (colId == "9" || colId == "5" || colId == "21" || colId == "13" || colId == "16" || colId == "142")
                {
                    Sql = "select [fixid],[Name] from [ItemValueSubMasterTable] where [fieldid]='" + colId + "'";
                    DataSet ds = new DataSet();
                    da = new SqlDataAdapter(Sql, con);
                    da.Fill(ds);

                    ddlFieldItem.DataSource = ds.Tables[0];
                    ddlFieldItem.DataTextField = "Name";
                    ddlFieldItem.DataValueField = "fixid";
                    ddlFieldItem.DataBind();

                    ddlFieldItem.Items.Add("--Select--");
                    ddlFieldItem.SelectedIndex = ddlFieldItem.Items.Count - 1;
                    ddlFieldItem.Visible = true;
                    txtSrchNumber.Visible = false;
                    txtDate.Visible = false;
                    txtSrchChar.Visible = false;
                }
                else if (dtype == "int")
                {
                    txtSrchNumber.Visible = true;
                    txtSrchChar.Visible = false;
                    ddlFieldItem.Visible = false;
                    txtDate.Visible = false;
                }
                else
                {
                    txtSrchChar.Visible = true;
                    txtSrchNumber.Visible = false;
                    ddlFieldItem.Visible = false;
                    txtDate.Visible = false;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string field = string.Empty; string fielditem = string.Empty;
            string oprt = string.Empty; string valOrdate = string.Empty;
            string Sql = string.Empty; string textval = string.Empty;
            string textDate = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                DataSet ds1 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds1);

                LblColName = Convert.ToString(ds1.Tables[0].Rows[0]["TableColumnName"]);

                fielditem = ddlFieldItem.SelectedValue;
                oprt = ddlOperator.SelectedItem.Text;
                textval = txtSrchNumber.Text;
                textDate = txtDate.Text;
                if (fielditem != "")
                {
                    ChkAddList.Items.Add(LblColName + " " + oprt + " " + "'" + fielditem + "'");
                }
                else if (textval != "")
                {
                    ChkAddList.Items.Add(LblColName + " " + oprt + " " + "'" + textval + "'");
                }
                else if (textDate != "")
                {
                    ChkAddList.Items.Add(LblColName + " " + oprt + " " + "'" + textDate + "'");
                }
                else if (txtSrchChar.Text != "")
                {
                    ChkAddList.Items.Add(LblColName + " " + oprt + " " + "'" + txtSrchChar.Text + "'");
                }
                ddlFieldItem.Items.Clear();
            }
            catch
            {

            }
        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstbox1.SelectedIndex >= 0)
                {
                    for (int i = 0; i < lstbox1.Items.Count; i++)
                    {
                        if (lstbox1.Items[i].Selected)
                        {
                            if (!ArryLst1.Contains(lstbox1.Items[i]))
                            {
                                ArryLst1.Add(lstbox1.Items[i]);
                            }
                        }
                    }
                    for (int i = 0; i < ArryLst1.Count; i++)
                    {
                        if (!lstbox2.Items.Contains(((ListItem)ArryLst1[i])))
                        {
                            lstbox2.Items.Add(((ListItem)ArryLst1[i]));
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnleft_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstbox2.SelectedIndex >= 0)
                {
                    for (int i = 0; i < lstbox2.Items.Count; i++)
                    {
                        if (lstbox2.Items[i].Selected)
                        {
                            if (!ArryLst2.Contains(lstbox2.Items[i]))
                            {
                                ArryLst2.Add(lstbox2.Items[i]);
                            }
                        }
                    }
                    for (int i = 0; i < ArryLst2.Count; i++)
                    {
                        if (!lstbox1.Items.Contains(((ListItem)ArryLst2[i])))
                        {
                            lstbox1.Items.Add(((ListItem)ArryLst2[i]));
                        }
                        lstbox2.Items.Remove(((ListItem)ArryLst2[i]));
                    }
                    lstbox1.SelectedIndex = -1;
                }
            }
            catch
            {

            }
        }

        public void BindGvTrngReport(string LSTString, string chklist)
        {
            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                DataSet ds2 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds2);
                tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                DataSet ds3 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds3);
                LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                if (ddlOperator.SelectedValue == "6")
                {
                    ViewState["LSTString"] = LSTString;

                    //string SqlQry = string.Empty; string Countid = string.Empty;
                    //string Sql = string.Empty;
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                    //DataSet ds2 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds2);
                    //tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                    //Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                    //DataSet ds3 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds3);
                    //LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + ddlFieldItem.SelectedValue + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;

                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }

                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    //GridView1.Visible = false;
                    //GridView2.DataSource = ds.Tables[0];
                    //GridView2.DataBind();

                }
                else
                {
                    ViewState["LSTString"] = LSTString;

                    //string SqlQry = string.Empty; string Countid = string.Empty;
                    //string Sql = string.Empty;
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                    //DataSet ds2 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds2);

                    //tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                    //Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                    //DataSet ds3 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds3);

                    //LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;

                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }

                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    //GridView1.Visible = false;
                    //GridView2.DataSource = ds.Tables[0];
                    //GridView2.DataBind();
                }
            }
            catch
            {
                GridView1.EmptyDataText = "No Data Found";
            }

        }

        public void BindGvTrngReport17(string LstString11, string chklist)
        {
            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                DataSet ds2 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds2);
                tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                DataSet ds3 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds3);
                LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                if (ddlOperator.SelectedValue == "6")
                {
                    ViewState["LSTString"] = LstString11;

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + chklist + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " like '" + ddlFieldItem.SelectedValue + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;

                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }

                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    ViewState["LSTString"] = LstString11;

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + chklist + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;

                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LstString11 + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }

                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
            catch
            {
                GridView1.EmptyDataText = "No Data Found";
            }

        }
        string lsttext = string.Empty;

        public void SelectAllTextInListBox()
        {
            foreach (ListItem item in lstbox2.Items)
            {
                item.Selected = true;
            }
        }

        public void LoginWiseDataBind(string LSTString, string chklist)
        {
            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                DataSet ds2 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds2);
                tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                DataSet ds3 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds3);
                LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                string SQLQRY = "select [CreatedBy] from " + tableName + " where [CreatedBy] ='" + loginSession() + "'";
                DataSet LgnDs = new DataSet();
                da = new SqlDataAdapter(SQLQRY, con);
                da.Fill(LgnDs);

                if (ddlOperator.SelectedValue == "6")
                {
                    ViewState["LSTString"] = LSTString;

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + ddlFieldItem.SelectedValue + "%' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    //  GridView2.Visible = false;
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    ViewState["LSTString"] = LSTString;

                    //Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                    //DataSet ds21 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds21);
                    //tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                    //Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                    //DataSet ds31 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds31);
                    //LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;

                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' and [CreatedBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    // GridView2.Visible = false;
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }

            catch
            {
                string SQLQRY = "select [InsertBy] from " + tableName + " where [InsertBy] ='" + loginSession() + "'";
                DataSet LgnDs = new DataSet();
                da = new SqlDataAdapter(SQLQRY, con);
                da.Fill(LgnDs);

                if (ddlOperator.SelectedValue == "6")
                {
                    ViewState["LSTString"] = LSTString;

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + ddlFieldItem.SelectedValue + "%' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    //  GridView2.Visible = false;
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    ViewState["LSTString"] = LSTString;

                    //Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                    //DataSet ds2 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds2);
                    //tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                    //Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                    //DataSet ds3 = new DataSet();
                    //da = new SqlDataAdapter(Sql, con);
                    //da.Fill(ds3);
                    //LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' and [InsertBy] ='" + loginSession() + "'";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    // GridView2.Visible = false;
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
        }

        protected void btdisplay_Click(object sender, EventArgs e)
        {
            //if (ddlMstTable.SelectedValue == "6" || ddlMstTable.SelectedValue == "8" || ddlMstTable.SelectedValue == "9" || ddlMstTable.SelectedValue == "11" || ddlMstTable.SelectedValue == "14")
            //{
            //    SelectAllTextInListBox();
            //    CommanData();
            //    if(ddlField.SelectedItem.Text != "Active")
            //    {
            //        BindGvTrngReport(LSTString, Chklist);
            //    }
            //    else
            //    {
            //        LoginWiseDataBind(LSTString, Chklist);
            //    }
            //}
            //else
            //{
            SelectAllTextInListBox();
            CommanData();
            BindGvTrngReport(LSTString, Chklist);
            // }
            //lstbox2.Items.Clear();
        }

        public void CommanData()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            for (int i = 0; i < lstbox2.Items.Count; i++)
            {
                if (lstbox2.Items[i].Selected == true)
                {
                    lsttext = lsttext + "," + Convert.ToString(lstbox2.Items[i].Value);
                }
            }
            lsttext = lsttext.Substring(1);

            string sql = "select [TableColumnName] from [ItemValueMasterTable] where [ColId] IN (" + lsttext + ")";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int itm = 0; itm < ds.Tables[0].Rows.Count; itm++)
                {
                    LSTString = LSTString + "," + Convert.ToString(ds.Tables[0].Rows[itm][0]);
                }
                //LSTString = LSTString.Substring(1);
            }
            //LSTString = LSTString + "," + lsttext;                 


            //LSTString = LSTString + "," + lstbox2.Items[i].Text;      not deleted this line
            // }
            // }
            if (LSTString.Length > 1)
            {
                LSTString = LSTString.Substring(1);
            }

            //string Chklist = "";
            for (int c = 0; c < ChkAddList.Items.Count; c++)
            {
                if (ChkAddList.Items[c].Selected == true)
                {
                    Chklist = Chklist + " and " + ChkAddList.Items[c].Text;
                }
            }
            if (Chklist.Length > 1)
            {
                Chklist = Chklist.Substring(4);
            }
            // BindGvTrngReport(LSTString, Chklist);
        }

        public void CommanData1()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            for (int i = 0; i < lstbox2.Items.Count; i++)
            {
                if (lstbox2.Items[i].Selected == true)
                {
                    lsttext = lsttext + "," + Convert.ToString(lstbox2.Items[i].Value);
                }
            }
            lsttext = lsttext.Substring(1);

            string sql = "select [TableColumnName] from [ItemValueMasterTable] where [ColId] IN (" + lsttext + ")";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int itm = 0; itm < ds.Tables[0].Rows.Count; itm++)
                {
                    LSTString = LSTString + "," + Convert.ToString(ds.Tables[0].Rows[itm][0]);
                }
                //LSTString = LSTString.Substring(1);
            }
            //LSTString = LSTString + "," + lsttext;                 


            //LSTString = LSTString + "," + lstbox2.Items[i].Text;      not deleted this line
            // }
            // }
            //if (LSTString.Length > 1)
            //{
            //    LSTString = LSTString.Substring(1);
            //}

            //string Chklist = "";
            for (int c = 0; c < ChkAddList.Items.Count; c++)
            {
                if (ChkAddList.Items[c].Selected == true)
                {
                    Chklist = Chklist + " and " + ChkAddList.Items[c].Text;
                }
            }
            if (Chklist.Length > 1)
            {
                Chklist = Chklist.Substring(4);
            }
            // BindGvTrngReport(LSTString, Chklist);
        }

        public DataTable DataTableReports(string LSTString, string chklist)
        {
            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
                DataSet ds2 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds2);
                tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                DataSet ds3 = new DataSet();
                da = new SqlDataAdapter(Sql, con);
                da.Fill(ds3);
                LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

                if (ddlOperator.SelectedValue == "6")
                {
                    ViewState["LSTString"] = LSTString;

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + ddlFieldItem.SelectedValue + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;

                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }

                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    ViewState["LSTString"] = LSTString;

                    DataSet ds = new DataSet();
                    if (chklist != "")
                    {
                        ViewState["chklist"] = chklist;
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + "";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (ddlFieldItem.SelectedValue != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;

                    }
                    else if (txtSrchNumber.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtSrchChar.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    else if (txtDate.Text != "")
                    {
                        string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtDate.Text + "' ";
                        da = new SqlDataAdapter(sql, con);
                        da.Fill(ds);

                        Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                        lblCount.Text = Countid;
                    }
                    dt = ds.Tables[0];
                }
                return dt;
            }
            catch
            {
                return dt = null;
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DataTable dtValue = new DataTable();
            try
            {
                SelectAllTextInListBox();
                CommanData();

                dtValue = DataTableReports(LSTString, Chklist);

                string excelFileName = "PollingData.xlsx";

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtValue, "AcExcel");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + excelFileName + "");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                    }
                }
            }
            catch { }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void ddlMstTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();

            sql = "select [ColId],[LblColumnName] from [ItemValueMasterTable] where [ddlfieldBindId]='" + ddlMstTable.SelectedValue + "'";
            DataSet ds4 = new DataSet();
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds4);

            ddlField.DataSource = ds4.Tables[0];
            ddlField.DataTextField = "LblColumnName";
            ddlField.DataValueField = "ColId";
            ddlField.DataBind();
            ddlField.Items.Add("--Select--");
            ddlField.SelectedIndex = ddlField.Items.Count - 1;

            sql = "Select [ColId],[TableColumnName],[LblColumnName] from [ItemValueMasterTable] where [TableId]=" + ddlMstTable.SelectedValue + "";
            DataSet ds5 = new DataSet();
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds5);

            lstbox1.DataSource = ds5.Tables[0];
            lstbox1.DataTextField = "LblColumnName";
            lstbox1.DataValueField = "ColId";
            lstbox1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string LSTString11 = string.Empty;
            try
            {
                LSTString11 = ViewState["LSTString"].ToString();
                //if (ViewState["Chklist"].ToString() == "" || ViewState["Chklist"].ToString() == null)
                //{ }
                //else
                //{
                //    Chklist = ViewState["Chklist"].ToString();
                //}
                GridView1.PageIndex = e.NewPageIndex;
                CommanData1();
                BindGvTrngReport17(LSTString11, Chklist);
            }
            catch
            {
                GridView1.PageIndex = e.NewPageIndex;
                CommanData1();
                BindGvTrngReport17(LSTString11, Chklist);
            }
        }

        int lstbx2cunt = 0;
        protected void btnApproved_Click(object sender, EventArgs e)
        {
            AdminMobNo = Convert.ToString(loginSession());
            try
            {
                //string Sql = "select [TableName] from [TrueVoterDB].[dbo].[ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "" +
                //             "Select [TableColumnName],[TableId],[LblColumnName] from [TrueVoterDB].[dbo].[ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                //DataSet ds2 = new DataSet();
                //da = new SqlDataAdapter(Sql, con);
                //da.Fill(ds2);

                ds2 = BindCommanData();

                tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                //Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [TrueVoterDB].[dbo].[ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                //DataSet ds3 = new DataSet();
                //da = new SqlDataAdapter(Sql, con);
                //da.Fill(ds3);
                LblColName = Convert.ToString(ds2.Tables[1].Rows[0]["TableColumnName"]);

                string SqlQry = string.Empty;
                if (AdminMobNo == "9619460202" || AdminMobNo == "9619460202")
                {
                    SqlQry = "Select TOP 1 [CreatedBy] from " + tableName + " ";
                }
                else
                {
                    SqlQry = "Select top 1 [CreatedBy] from " + tableName + " where [CreatedBy]='" + loginSession() + "'";
                }

                DataSet LgnDs = new DataSet();
                da = new SqlDataAdapter(SqlQry, con);
                da.Fill(LgnDs);
                if (LgnDs.Tables[0].Rows.Count > 0)
                {
                    string GvSno = string.Empty; int res = 0;
                    try
                    {
                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[lstbx2cunt].FindControl("CheckBox1");

                            if (chk != null)
                            {
                                if (chk.Checked == true)
                                {
                                    GvSno += Convert.ToString(GridView1.DataKeys[i].Value) + ",";
                                }
                            }
                            chk.Checked = false;
                        }

                        if (GvSno == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                        }
                        else
                        {
                            if (GvSno != "")
                            {
                                GvSno = GvSno.Substring(0, GvSno.Length - 1);
                            }

                            string SQL = "Select Count(*) From " + tableName + " where " + LblColName + " IN('" + GvSno + "')";
                            DataSet ds12 = new DataSet();
                            da = new SqlDataAdapter(SQL, con);
                            da.Fill(ds12);
                            int Rcunt = Convert.ToInt32(ds12.Tables[0].Rows[0][0]);
                            if (Rcunt > 0)
                            {
                                //ScriptManager.RegisterStartupScript(this, GetType(), "Msg1", "alter('Are you sure you want to " + Rcunt + " record Update??????');", true);
                            }

                            if (ds12.Tables[0].Rows.Count > 0)
                            {
                                // string sql = "Delete From " + tableName + " where " + LblColName + " IN(" + GvSno + ")";
                                string sql = "Update " + tableName + " set [IsActive]='1' where " + LblColName + " IN('" + GvSno + "')";
                                con.Open();
                                cmd = new SqlCommand(sql, con);
                                res = cmd.ExecuteNonQuery();
                                con.Close();

                                sql = "Select * from " + tableName + " where " + LblColName + " IN('" + GvSno + "')";
                                da = new SqlDataAdapter(sql, con);
                                da.Fill(ds);
                                GridView1.DataSource = ds.Tables[0];
                                GridView1.DataBind();
                            }
                            if (res > 0)
                            {
                                //ScriptManager.RegisterStartupScript(this, GetType(), "Msg2", "alter('" + Rcunt + "record Updated successfully');", true);
                                lblTotalUpdated.Visible = true;
                                lblTotalUpdated.Text = +Convert.ToInt32(Rcunt) + " record Approve successfully";
                                lblTotalUpdated.ForeColor = System.Drawing.Color.Green;
                                lbldisplay.Visible = true;
                                lbldisplay.Text = "Record updated successfully";
                                lbldisplay.ForeColor = System.Drawing.Color.LightSkyBlue;
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    lbldisplay.Visible = true;
                    lbldisplay.Text = "Your are not permission to Update record.....";
                    lbldisplay.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                string SqlQry = string.Empty;
                if (AdminMobNo == "9619460202" || AdminMobNo == "9619460202")
                {
                    SqlQry = "Select [InsertBy] from " + tableName + " ";
                }
                else
                {
                    SqlQry = "Select [InsertBy] from " + tableName + " where [InsertBy]='" + loginSession() + "'";
                }
                DataSet LgnDs = new DataSet();
                da = new SqlDataAdapter(SqlQry, con);
                da.Fill(LgnDs);
                if (LgnDs.Tables[0].Rows.Count > 0)
                {
                    string GvSno = string.Empty; int res = 0;
                    try
                    {
                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[lstbx2cunt].FindControl("CheckBox1");

                            if (chk != null)
                            {
                                if (chk.Checked == true)
                                {
                                    GvSno += Convert.ToString(GridView1.DataKeys[i].Value) + ",";
                                }
                            }
                            chk.Checked = false;
                        }

                        if (GvSno == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                        }
                        else
                        {
                            if (GvSno != "")
                            {
                                GvSno = GvSno.Substring(0, GvSno.Length - 1);
                            }

                            string SQL = "Select Count(*) From " + tableName + " where " + LblColName + " IN('" + GvSno + "')";   
                            DataSet ds12 = new DataSet();
                            da = new SqlDataAdapter(SQL, con);
                            da.Fill(ds12);
                            int Rcunt = Convert.ToInt32(ds12.Tables[0].Rows[0][0]);
                            if (Rcunt > 0)
                            {
                                //ScriptManager.RegisterStartupScript(this, GetType(), "Msg1", "alter('Are you sure you want to " + Rcunt + " record Update??????');", true);
                            }

                            if (ds12.Tables[0].Rows.Count > 0)
                            {
                                // string sql = "Delete From " + tableName + " where " + LblColName + " IN(" + GvSno + ")";
                                string sql = "Update " + tableName + " set [IsActive]='1' where " + LblColName + " IN('" + GvSno + "')";
                                con.Open();
                                cmd = new SqlCommand(sql, con);
                                res = cmd.ExecuteNonQuery();
                                con.Close();

                                sql = "Select * from " + tableName + " where " + LblColName + " IN('" + GvSno + "')";
                                da = new SqlDataAdapter(sql, con);
                                da.Fill(ds);
                                GridView1.DataSource = ds.Tables[0];
                                GridView1.DataBind();
                            }
                            if (res > 0)
                            {
                                //ScriptManager.RegisterStartupScript(this, GetType(), "Msg2", "alter('" + Rcunt + "record Updated successfully');", true);
                                lblTotalUpdated.Visible = true;
                                lblTotalUpdated.Text = +Convert.ToInt32(Rcunt) + " record Approve successfully";
                                lblTotalUpdated.ForeColor = System.Drawing.Color.Green;
                                lbldisplay.Visible = true;
                                lbldisplay.Text = "Record updated successfully";
                                lbldisplay.ForeColor = System.Drawing.Color.LightSkyBlue;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        protected void btnDeapproved_Click(object sender, EventArgs e)
        {
            AdminMobNo = Convert.ToString(loginSession());
            string GvSno = string.Empty; int res = 0;

            try
            {
                //string Sql = "select [TableName] from [TrueVoterDB].[dbo].[ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "" +
                //             "Select [TableColumnName],[TableId],[LblColumnName] from [TrueVoterDB].[dbo].[ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                //DataSet ds2 = new DataSet();
                //da = new SqlDataAdapter(Sql, con);
                //da.Fill(ds2);
                DataSet ds2 = BindCommanData();
                tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

                //Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [TrueVoterDB].[dbo].[ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
                //DataSet ds3 = new DataSet();
                //da = new SqlDataAdapter(Sql, con);
                //da.Fill(ds3);
                LblColName = Convert.ToString(ds2.Tables[1].Rows[0]["TableColumnName"]);

                string SqlQry = string.Empty;
                if (AdminMobNo == "9619460202" || AdminMobNo == "9619460202")
                {
                    SqlQry = "Select [CreatedBy] from " + tableName + " ";
                }
                else
                {
                    SqlQry = "Select [CreatedBy] from " + tableName + " where [CreatedBy]='" + loginSession() + "'";
                }
                DataSet lgnds = new DataSet();
                da = new SqlDataAdapter(SqlQry, con);
                da.Fill(lgnds);
                if (lgnds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[lstbx2cunt].FindControl("CheckBox1");

                        if (chk != null)
                        {
                            if (chk.Checked == true)
                            {
                                GvSno += Convert.ToString(GridView1.DataKeys[i].Value) + ",";
                            }
                        }
                        chk.Checked = false;
                    }

                    if (GvSno == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                    }
                    else
                    {
                        if (GvSno != "")
                        {
                            GvSno = GvSno.Substring(0, GvSno.Length - 1);
                        }

                        string SQL = "Select Count(*) From " + tableName + " where " + LblColName + " IN('" + GvSno + "')";
                        DataSet ds12 = new DataSet();
                        da = new SqlDataAdapter(SQL, con);
                        da.Fill(ds12);
                        int Rcunt = Convert.ToInt32(ds12.Tables[0].Rows[0][0]);
                        if (Rcunt > 0)
                        {
                            // ScriptManager.RegisterStartupScript(this, GetType(), "Msg1", "alter('Are you sure you want to " + Rcunt + " record Update??????');", true);
                        }

                        if (ds12.Tables[0].Rows.Count > 0)
                        {
                            // string sql = "Delete From " + tableName + " where " + LblColName + " IN(" + GvSno + ")";
                            string sql = "Update " + tableName + " set [IsActive]='0' where " + LblColName + " IN('" + GvSno + "')";
                            con.Open();
                            cmd = new SqlCommand(sql, con);
                            res = cmd.ExecuteNonQuery();
                            con.Close();

                            sql = "Select * from " + tableName + " where " + LblColName + " IN('" + GvSno + "')";
                            da = new SqlDataAdapter(sql, con);
                            da.Fill(ds);
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }
                        if (res > 0)
                        {
                            //ScriptManager.RegisterStartupScript(this, GetType(), "Msg2", "alter('" + Rcunt + "record Updated successfully');", true);
                            lblTotalUpdated.Visible = true;
                            lblTotalUpdated.Text = +Convert.ToInt32(Rcunt) + " record DisApprove successfully";
                            lblTotalUpdated.ForeColor = System.Drawing.Color.Green;
                            lbldisplay.Visible = true;
                            lbldisplay.Text = "Record updated successfully";
                            lbldisplay.ForeColor = System.Drawing.Color.LightSkyBlue;
                        }
                    }
                }
                else
                {
                    lbldisplay.Visible = true;
                    lbldisplay.Text = "Your are not permission to Update record.....";
                    lbldisplay.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                string SqlQry = string.Empty;
                if (AdminMobNo == "9619460202" || AdminMobNo == "9619460202")
                {
                    SqlQry = "Select [InsertBy] from " + tableName + " ";
                }
                else
                {
                    SqlQry = "Select [InsertBy] from " + tableName + " where [InsertBy]='" + loginSession() + "'";
                }
                DataSet LgnDs = new DataSet();
                da = new SqlDataAdapter(SqlQry, con);
                da.Fill(LgnDs);
                if (LgnDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[lstbx2cunt].FindControl("CheckBox1");

                        if (chk != null)
                        {
                            if (chk.Checked == true)
                            {
                                GvSno += Convert.ToString(GridView1.DataKeys[i].Value) + ",";
                            }
                        }
                        chk.Checked = false;
                    }

                    if (GvSno == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                    }
                    else
                    {
                        //if (GvSno != "")
                        {
                            GvSno = GvSno.Substring(0, GvSno.Length - 1);
                        }

                        string SQL = "Select Count(*) From " + tableName + " where " + LblColName + " IN('" + GvSno + "')";
                        DataSet ds12 = new DataSet();
                        da = new SqlDataAdapter(SQL, con);
                        da.Fill(ds12);
                        int Rcunt = Convert.ToInt32(ds12.Tables[0].Rows[0][0]);
                        if (Rcunt > 0)
                        {
                            //ScriptManager.RegisterStartupScript(this, GetType(), "Msg1", "alter('Are you sure you want to " + Rcunt + " record Update??????');", true);
                        }

                        if (ds12.Tables[0].Rows.Count > 0)
                        {
                            // string sql = "Delete From " + tableName + " where " + LblColName + " IN(" + GvSno + ")";
                            string sql = "Update " + tableName + " set [IsActive]='1' where " + LblColName + " IN('" + GvSno + "')";
                            con.Open();
                            cmd = new SqlCommand(sql, con);
                            res = cmd.ExecuteNonQuery();
                            con.Close();

                            sql = "Select * from " + tableName + " where " + LblColName + " IN('" + GvSno + "')";
                            da = new SqlDataAdapter(sql, con);
                            da.Fill(ds);
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }
                        if (res > 0)
                        {
                            //ScriptManager.RegisterStartupScript(this, GetType(), "Msg2", "alter('" + Rcunt + "record Updated successfully');", true);
                            lblTotalUpdated.Visible = true;
                            lblTotalUpdated.Text = +Convert.ToInt32(Rcunt) + " record DisApprove successfully";
                            lblTotalUpdated.ForeColor = System.Drawing.Color.Green;
                            lbldisplay.Visible = true;
                            lbldisplay.Text = "Record updated successfully";
                            lbldisplay.ForeColor = System.Drawing.Color.LightSkyBlue;
                        }
                    }
                }
                else
                {
                    lbldisplay.Visible = true;
                    lbldisplay.Text = "Your are not permission to Update record.....";
                    lbldisplay.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }

        public DataSet BindCommanData()
        {
            string Sql = "select [TableName] from [TrueVoterDB].[dbo].[ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "" +
                            "Select [TableColumnName],[TableId],[LblColumnName] from [TrueVoterDB].[dbo].[ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
            DataSet ds2 = new DataSet();
            da = new SqlDataAdapter(Sql, con);
            da.Fill(ds2);

            return ds2;
        }
    }
}