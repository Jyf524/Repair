using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class WarehousingDetails : System.Web.UI.Page
    {
        Maticsoft.BLL.PartType bllPartType = new Maticsoft.BLL.PartType();
        Maticsoft.Model.PartType modelPartType = new Maticsoft.Model.PartType();
        Maticsoft.BLL.Part bllPart = new Maticsoft.BLL.Part();
        Maticsoft.Model.Part modelPart = new Maticsoft.Model.Part();
        Maticsoft.BLL.PartPutRecord bllPartPutRecord = new Maticsoft.BLL.PartPutRecord();
        Maticsoft.Model.PartPutRecord modelPartPutRecord = new Maticsoft.Model.PartPutRecord();
        public String PartTypeName
        {
            get
            { return ViewState["_PartTypeName"] == null ? string.Empty : ViewState["_PartTypeName"].ToString(); }
            set
            { ViewState["_PartTypeName"] = value; }
        }
        public String PartName
        {
            get
            { return ViewState["_PartName"] == null ? string.Empty : ViewState["_PartName"].ToString(); }
            set
            { ViewState["_PartName"] = value; }
        }
        public String StartTime
        {
            get
            { return ViewState["_StartTime"] == null ? string.Empty : ViewState["_StartTime"].ToString(); }
            set
            { ViewState["_StartTime"] = value; }
        }
        public String EndTime
        {
            get
            { return ViewState["_EndTime"] == null ? string.Empty : ViewState["_EndTime"].ToString(); }
            set
            { ViewState["_EndTime"] = value; }
        }
        
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)//绑定两个下拉框联动
            {

                ddlPartTypeName.Items.Clear();
                ddlPartName.Items.Clear();
                ddlPartTypeName.Items.Add("全部");
                ddlPartName.Items.Add("全部");

                ddlPartTypeName.DataSource = bllPartType.GetList("");
                ddlPartTypeName.DataTextField = "PartTypeName";
                ddlPartTypeName.DataValueField = "PartTypeID";
                ddlPartTypeName.DataBind();

                ddlPartName.DataSource = bllPart.GetList(" PartTypeID ='" + ddlPartTypeName.SelectedValue + "'  ");
                ddlPartName.DataTextField = "PartName";
                ddlPartName.DataValueField = "PartID";
                ddlPartName.DataBind();
            }
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();//获取id
            if (e.CommandName == "Delete")
            {
                bllPartPutRecord.Delete(id);//删除数据
            }
        }
        
        //配件入库
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='PartsWarehousing.aspx'</script>");
        }

        protected void ddlPartTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlPartTypeName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ddlPartName.Items.Clear();//清子类下拉框项目
            ddlPartName.Items.Add("全部");//给市下拉框添加请选择
            ddlPartName.DataSource = bllPart.GetList(" PartTypeID ='" + ddlPartTypeName.SelectedValue + "'  ");
            ddlPartName.DataTextField = "PartName";
            ddlPartName.DataValueField = "PartID";
            ddlPartName.DataBind();
            ddlPartName.SelectedItem.Text = "全部";
        }
        //数据源
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataLoad();
        }
        //分页
        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            DataLoad();
            RadGrid1.Rebind();
        }
        //搜索按钮
        protected void btnselect_Click(object sender, EventArgs e)
        {
            PartTypeName = ddlPartTypeName.SelectedValue;
            PartName = ddlPartName.SelectedValue;
            StartTime = dpstarttime.SelectedDate.ToString();
            EndTime = dpendtime.SelectedDate.ToString();
            DataLoad();
            RadGrid1.Rebind();
        }
        protected void DataLoad()
        {
            string sqlselect = "";
            if (PartTypeName != "全部" && PartTypeName != "")
            {
                sqlselect += " and c.PartTypeID = '" + PartTypeName + "' ";
            }
            if (PartName != "全部" && PartName != "")
            {
                sqlselect += " and c.PartID = '" + PartName + "' ";
            }
            if (StartTime != "" && EndTime == "")
            {
                sqlselect += " and PartPutTime >= '" + StartTime + "' ";
            }
            if (StartTime == "" && EndTime != "")
            {
                sqlselect += " and PartPutTime <= '" + EndTime + "' ";
            }
            if (StartTime != "" && EndTime != "")
            {
                sqlselect += " and PartPutTime between '" + StartTime + "' and '" + EndTime + "' ";
            }
            RadGrid1.DataSource = bllPartPutRecord.GetListw1(0, sqlselect, " PartPutTime desc ");//按时间降序排序
        }

        
    }
}