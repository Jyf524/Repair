using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.IO;

namespace RepairCenterY.BackManagement
{
    public partial class SubstitutionHistory : System.Web.UI.Page
    {
        Maticsoft.Model.Replacement molr = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.Replacement bllr = new Maticsoft.BLL.Replacement();

        Maticsoft.BLL.ReplacementRecord bllpur = new Maticsoft.BLL.ReplacementRecord();
        Maticsoft.Model.ReplacementRecord molpur = new Maticsoft.Model.ReplacementRecord();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Maticsoft.Model.Replacement molr = bllr.GetModel(Request.QueryString["ID"].ToString());//引用id所在行的数据
                    if (molr == null)
                    {
                        Response.Write("<script>window.location.href='../BackLogin.aspx'</script>");
                    }
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BackManagement/SubstituteMachine.aspx");
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataLoad();
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            Maticsoft.Model.ReplacementRecord molpur = bllpur.GetModel(Request.QueryString["ID"].ToString());//引用id所在行的数据
            if (molpur != null)
            {
                Maticsoft.Model.ReplacementRecord molpur1 = bllpur.GetModel1(molpur.ReplacementRecordID);//引用id所在行的数据
                Maticsoft.BLL.ReplacementRecord bllpur1 = new Maticsoft.BLL.ReplacementRecord();
                RadGrid1.Rebind();
            }
        }

        protected void btnselect_Click(object sender, EventArgs e)
        {
            //ReplacementName = txtPartName.Text;
            ReplacementLendTime = GOTIME.SelectedDate.ToString();
            ReplacementBackTime = ENDTIME.SelectedDate.ToString();

            ReplacementLendTime2 = GOTIME2.SelectedDate.ToString();
            ReplacementBackTime2 = ENDTIME2.SelectedDate.ToString();


            //if (Convert.ToInt32(ReplacementLendTime) < Convert.ToInt32(ReplacementBackTime))
            //{
            //    Response.Write("<script>alert('归还时间不能早于借出时间！')</script>");
            //    return;
            //}
            DataLoad();
            RadGrid1.Rebind();
        }

        protected void DataLoad()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                //Maticsoft.Model.ReplacementRecord molpur = bllpur.GetModel(Request.QueryString["ID"].ToString());//引用id所在行的数据
                //if (molpur != null)
                //{
                //    Maticsoft.Model.ReplacementRecord molpur1 = bllpur.GetModel1(molpur.ReplacementRecordID);//引用id所在行的数据

                //    string sqlselect = " ReplacementID = '" + molpur1.ReplacementID + "' and  ReplacementName like '%" + ReplacementName + "%' ";
                //    if (ReplacementLendTime != "" && ReplacementBackTime == "")
                //    {
                //        sqlselect += " and ReplacementLendTime > '" + ReplacementLendTime + "' ";
                //    }
                //    if (ReplacementLendTime == "" && ReplacementBackTime != "")
                //    {
                //        sqlselect += " and ReplacementBackTime < '" + ReplacementBackTime + "' ";
                //    }
                //    if (ReplacementLendTime != "" && ReplacementBackTime != "")
                //    {
                //        sqlselect += " and PartPutTime between '" + ReplacementLendTime + "' and '" + ReplacementBackTime + "' ";
                //    }
                //    RadGrid1.DataSource = bllpur.GetList1(0, sqlselect, " ReplacementRecordID desc ");
                //    //Response.Write("<script>alert('暂无数据！');window.location.href='SubstituteMachine.aspx'</script>");
                //    //return;
                //}
                //else
                //{
                //    RadGrid1.DataSource = bllpur.GetList1(0, " ReplacementID is NULL ", " ReplacementRecordID desc ");
                //}
                string sqlselect = " ReplacementID = '" + Request.QueryString["ID"].ToString() + "' ";


                if (GOTIME.SelectedDate.ToString() != "" && ENDTIME.SelectedDate.ToString() == "")
                {
                    sqlselect += " and ReplacementLendTime >= '" + GOTIME.SelectedDate.ToString() + "' ";
                }
                if (GOTIME.SelectedDate.ToString() == "" && ENDTIME.SelectedDate.ToString() != "")
                {
                    sqlselect += " and ReplacementLendTime <= '" + ENDTIME.SelectedDate.ToString() + "' ";
                }
                if (GOTIME.SelectedDate.ToString() != "" && ENDTIME.SelectedDate.ToString() != "")
                {
                    sqlselect += " and ReplacementLendTime between '" + GOTIME.SelectedDate.ToString() + "' and '" + ENDTIME.SelectedDate.ToString() + "' ";
                }

                if (GOTIME2.SelectedDate.ToString() != "" && ENDTIME2.SelectedDate.ToString() == "")
                {
                    sqlselect += " and ReplacementBackTime >= '" + GOTIME2.SelectedDate.ToString() + "' ";
                }
                if (GOTIME2.SelectedDate.ToString() == "" && ENDTIME2.SelectedDate.ToString() != "")
                {
                    sqlselect += " and ReplacementBackTime <= '" + ENDTIME.SelectedDate.ToString() + "' ";
                }
                if (GOTIME2.SelectedDate.ToString() != "" && ENDTIME2.SelectedDate.ToString() != "")
                {
                    sqlselect += " and ReplacementBackTime between '" + GOTIME2.SelectedDate.ToString() + "' and '" + ENDTIME2.SelectedDate.ToString() + "' ";
                }


                RadGrid1.DataSource = bllpur.GetList1(0, sqlselect, " ReplacementRecordID desc ");
            }
        }

        //public String ReplacementName
        //{
        //    get
        //    { return ViewState["_ReplacementName"] == null ? string.Empty : ViewState["_ReplacementName"].ToString(); }
        //    set
        //    { ViewState["_ReplacementName"] = value; }
        //}
        public String ReplacementLendTime
        {
            get
            { return ViewState["_ReplacementLendTime"] == null ? string.Empty : ViewState["_ReplacementLendTime"].ToString(); }
            set
            { ViewState["_ReplacementLendTime"] = value; }
        }
        public String ReplacementBackTime
        {
            get
            { return ViewState["_ReplacementBackTime"] == null ? string.Empty : ViewState["_ReplacementBackTime"].ToString(); }
            set
            { ViewState["_ReplacementBackTime"] = value; }
        }

        public String ReplacementLendTime2
        {
            get
            { return ViewState["_ReplacementLendTime"] == null ? string.Empty : ViewState["_ReplacementLendTime"].ToString(); }
            set
            { ViewState["_ReplacementLendTime"] = value; }
        }
        public String ReplacementBackTime2
        {
            get
            { return ViewState["_ReplacementBackTime"] == null ? string.Empty : ViewState["_ReplacementBackTime"].ToString(); }
            set
            { ViewState["_ReplacementBackTime"] = value; }
        }


    }
}