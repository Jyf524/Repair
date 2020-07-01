using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RepairCenterY.BackManagement
{
    public partial class RepairManagementWX : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration bllDeclaration = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration modelDeclaration = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.UnitsInfo bllUnitsInfo = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo modelUnitsInfo = new Maticsoft.Model.UnitsInfo();
        public String MachineName
        {
            get
            { return ViewState["_MachineName"] == null ? string.Empty : ViewState["_MachineName"].ToString(); }
            set
            { ViewState["_MachineName"] = value; }
        }
        public String UnitName
        {
            get
            { return ViewState["_UnitName"] == null ? string.Empty : ViewState["_UnitName"].ToString(); }
            set
            { ViewState["_UnitName"] = value; }
        }
        public String DeclarationState
        {
            get
            { return ViewState["_DeclarationState"] == null ? string.Empty : ViewState["_DeclarationState"].ToString(); }
            set
            { ViewState["_DeclarationState"] = value; }
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

            //绑定下拉框数据源
            if (!IsPostBack)
            {

                ddlUnitName.Items.Clear();
                ddlUnitName.Items.Add("全部");

                ddlUnitName.DataSource = bllUnitsInfo.GetList("");
                ddlUnitName.DataTextField = "UnitName";
                ddlUnitName.DataValueField = "UnitID";
                ddlUnitName.DataBind();

            }
            
        }
        

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            LinkButton btndeal = e.Item.FindControl("btndeal") as LinkButton;//受理
            LinkButton btngive = e.Item.FindControl("btngive") as LinkButton;//分配
            Label lblnone = e.Item.FindControl("lblnone") as Label;//无
            if (e.Item is GridDataItem)
            {
                GridDataItem db = e.Item as GridDataItem;
                if (db["DeclarationState"].Text.Trim() == "维修基地待受理" || db["DeclarationState"].Text.Trim() == "维修基地待受理(返修)")
                {
                    btndeal.Visible = true; return;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地已受理" || db["DeclarationState"].Text.Trim() == "维修基地已受理(返修)")
                {
                    btngive.Visible = true; return;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地维修中" || db["DeclarationState"].Text.Trim() == "维修基地维修中(返修)")
                {
                    lblnone.Visible = true; return;
                }
                else
                {
                    lblnone.Visible = true;
                }
            }

        }
        

        protected void Btnadd_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='RepairDetailedWX.aspx'</script>");
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "deal")//受理
            {
                modelDeclaration = bllDeclaration.GetModel(id);
                if (modelDeclaration.DeclarationState == "维修基地待受理")
                {
                    modelDeclaration.DeclarationState = "维修基地已受理";
                }
                if (modelDeclaration.DeclarationState == "维修基地待受理(返修)")
                {
                    modelDeclaration.DeclarationState = "维修基地已受理(返修)";
                }
                bllDeclaration.Update(modelDeclaration);//更新状态
                DataLoad();
                RadGrid1.Rebind();//重新绑定数据源
            }
            if (e.CommandName == "give")//分配
            {
                Response.Write("<script>window.location.href='RepairDetailedWX.aspx?ID=" + id + "'</script>");
            }

        }
        //绑数据源
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataLoad();
        }
        //分页
        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            DataLoad();
            RadGrid1.Rebind();//重新绑定数据源
        }
        //搜索
        protected void Btn_search_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(txtMachineName.Text.Trim()) && txtMachineName.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("设备名称不能输入特殊字符!");
                return;
            }
            MachineName = txtMachineName.Text.Trim();
            UnitName = ddlUnitName.SelectedItem.Text;
            DeclarationState = ddlDeclarationState.SelectedItem.Text;
            StartTime = dpstarttime.SelectedDate.ToString();
            EndTime = dpendtime.SelectedDate.ToString();
            DataLoad();
            RadGrid1.Rebind();//重新绑定数据源
        }
        protected void DataLoad()
        {
            string sqlselect = " MachineName like '%" + MachineName + "%' and a.DeclarationState in('维修基地待受理','维修基地已受理','维修基地维修中','维修基地已完修','装备中心已取回','维修完成','维修基地待受理(返修)','维修基地已受理(返修)','维修基地维修中(返修)','维修基地已完修(返修)','装备中心已取回(返修)','返修完成')  ";
            if (UnitName != "全部" && UnitName != "")
            {
                sqlselect += " and UnitName = '" + UnitName + "' ";
            }
            if (DeclarationState != "全部" && DeclarationState != "")
            {
                sqlselect += " and DeclarationState = '" + DeclarationState + "' ";
            }
            if (StartTime != "" && EndTime == "")
            {
                sqlselect += " and RepairTime >= '" + StartTime + "' ";
            }
            if (StartTime == "" && EndTime != "")
            {
                sqlselect += " and RepairTime <= '" + EndTime + "' ";
            }
            if (StartTime != "" && EndTime != "")
            {
                sqlselect += " and RepairTime between '" + StartTime + "' and '" + EndTime + "' ";
            }

            RadGrid1.DataSource = bllDeclaration.GetList2(sqlselect);//按时间降序排序
        }

        protected void btnlook_Click(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedItems.Count > 0)//选中一条数据
            {
                var selectedItem = RadGrid1.SelectedItems[0];
                string id = RadGrid1.MasterTableView.DataKeyValues[selectedItem.ItemIndex]["DeclarationID"].ToString();
                Response.Redirect("MaintenanceListWX.aspx?ID=" + id);
            }
            else
            {
                RadAjaxManager1.Alert("请选择一条数据!");
            }
        }




    }
}