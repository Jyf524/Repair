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
    public partial class SubstituteMachine : System.Web.UI.Page
    {
        Maticsoft.Model.Replacement molr = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.Replacement bllr = new Maticsoft.BLL.Replacement();

        Maticsoft.Model.MachineFatherType molmf = new Maticsoft.Model.MachineFatherType();
        Maticsoft.BLL.MachineFatherType bllmf = new Maticsoft.BLL.MachineFatherType();

        Maticsoft.Model.MachineSonType molms = new Maticsoft.Model.MachineSonType();
        Maticsoft.BLL.MachineSonType bllms = new Maticsoft.BLL.MachineSonType();

        Maticsoft.Model.ReplacementRecord molrr = new Maticsoft.Model.ReplacementRecord();
        Maticsoft.BLL.ReplacementRecord bllrr = new Maticsoft.BLL.ReplacementRecord();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnadd.Attributes["onclick"] = "OpenAddPro();return false;";//添加
            btnxg.Attributes["onclick"] = "OpenAddProTwo();return false;";//修改
            btnls.Attributes["onclick"] = "OpenAddProFour();return false;";//历史

            if (!IsPostBack)
            {
                MachineFather.Items.Clear();
                MachineSon.Items.Clear();
                MachineFather.Items.Add("请选择");
                MachineSon.Items.Add("请选择");

                MachineFather.DataSource = bllmf.GetList("");
                MachineFather.DataTextField = "MachineFatherName";
                MachineFather.DataValueField = "MachineFatherID";
                MachineFather.DataBind();

                MachineSon.DataSource = bllms.GetList(" MachineFatherID ='" + MachineFather.SelectedValue + "'  ");
                MachineSon.DataTextField = "MachineSonName";
                MachineSon.DataValueField = "MachineSonID";
                MachineSon.DataBind();

            }

        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataLoad();
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            Maticsoft.Model.Replacement molr = bllr.GetModel(id);


            if (e.CommandName.ToString() == "Delete")
            {
                if (molr.ReplacementState == "已借出")
                {
                    RadAjaxManager1.Alert("已借出状态下不可删除！");
                    return;
                }
                if (bllrr.GetRecordCount(" ReplacementID =  '" + id + "' ") != 0)
                {
                    RadAjaxManager1.Alert("已存在借出历史，不可删除！");
                    return;
                }
                if (molr.ReplacementState == "未借出" || molr.ReplacementState == "已报废")
                {
                    bllr.Delete(id);
                    RadGrid1.Rebind();
                }
            }

            if (e.CommandName.ToString() == "GOGO")
            {
                Response.Redirect("SubstitutionDetails.aspx?ID=" + e.CommandArgument + "");//跳转页面
            }
        }

        protected void MachineFather_SelectedIndexChanged(object sender, EventArgs e)
        {
            MachineSon.Items.Clear();//清子类下拉框项目
            MachineSon.Items.Add("请选择...");//给市下拉框添加请选择
            MachineSon.DataSource = bllms.GetList(" MachineFatherID ='" + MachineFather.SelectedValue + "'  ");
            MachineSon.DataTextField = "MachineSonName";
            MachineSon.DataValueField = "MachineSonID";
            MachineSon.DataBind();
        }

        protected void btnselect_Click(object sender, EventArgs e)
        {
            ReplacementName = txtPartName.Text;
            MachineFatherID = MachineFather.SelectedValue;
            MachineSonID = MachineSon.SelectedValue;
            ReplacementState = DDLZ.SelectedValue;
            DataLoad();
            RadGrid1.Rebind();
        }

        protected void DataLoad()
        {
            string sqlselect = "  ReplacementName like '%" + ReplacementName + "%' ";
            if (MachineFatherID != "请选择" && MachineFatherID != "")
            {
                sqlselect += " and b.MachineFatherID = '" + MachineFatherID + "' ";
            }
            if (MachineSonID != "请选择" && MachineSonID != "")
            {
                sqlselect += " and c.MachineSonID = '" + MachineSonID + "' ";
            }
            if (ReplacementState != "请选择" && ReplacementState != "")
            {
                sqlselect += " and ReplacementState = '" + ReplacementState + "' ";
            }
            RadGrid1.DataSource = bllr.GetList1(0, sqlselect, " ReplacementAddTime desc ");
        }

        public String ReplacementName
        {
            get
            { return ViewState["_ReplacementName"] == null ? string.Empty : ViewState["_ReplacementName"].ToString(); }
            set
            { ViewState["_ReplacementName"] = value; }
        }
        public String MachineFatherID
        {
            get
            { return ViewState["_MachineFatherID"] == null ? string.Empty : ViewState["_MachineFatherID"].ToString(); }
            set
            { ViewState["_MachineFatherID"] = value; }
        }
        public String MachineSonID
        {
            get
            { return ViewState["_MachineSonID"] == null ? string.Empty : ViewState["_MachineSonID"].ToString(); }
            set
            { ViewState["_MachineSonID"] = value; }
        }
        public String ReplacementState
        {
            get
            { return ViewState["_ReplacementState"] == null ? string.Empty : ViewState["_ReplacementState"].ToString(); }
            set
            { ViewState["_ReplacementState"] = value; }
        }

        protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
    }
}