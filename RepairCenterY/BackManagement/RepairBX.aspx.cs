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
    public partial class RepairBX : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration Declaration_Bll = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration Declaration_Mol = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.Replacement Replacement_Bll = new Maticsoft.BLL.Replacement();
        Maticsoft.Model.Replacement Replacement_Mol = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.ReplacementRecord ReplacementRecord_Bll = new Maticsoft.BLL.ReplacementRecord();
        Maticsoft.Model.ReplacementRecord ReplacementRecord_Mol = new Maticsoft.Model.ReplacementRecord();
        public static string xx1;
        public String State
        {
            get
            { return ViewState["_State"] == null ? string.Empty : ViewState["_State"].ToString(); }
            set
            { ViewState["_State"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_check.Attributes["onclick"] = "OpenEdit();return false;";
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataLoad();//调用函数
        }

        protected void DataLoad()
        {
            string sqlselect = " MachineName like '%" + RadTxtSearchName.Text.Trim() + "%' ";
            if (RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() == "")
            {
                sqlselect += " and RepairTime >= '" + RadDatePicker1.SelectedDate.ToString() + "' ";
            }
            if (RadDatePicker1.SelectedDate.ToString() == "" && RadDatePicker2.SelectedDate.ToString() != "")
            {
                sqlselect += " and RepairTime <= '" + RadDatePicker2.SelectedDate.ToString() + "' ";
            }
            if (RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")
            {
                sqlselect += " and RepairTime between '" + RadDatePicker1.SelectedDate.ToString() + "' and '" + RadDatePicker2.SelectedDate.ToString() + "' ";
            }
            if (State != "")
            {
                sqlselect += " and DeclarationState = '" + State + "' ";
            }
            sqlselect += " and UserID='" + UsersInfo.UserID + "' ";
            RadGrid1.DataSource = Declaration_Bll.GetList2( sqlselect );//绑定数据源
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //String id = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DeclarationID"].ToString();//获取主键值
            LinkButton LinkBtn_CheckOK = e.Item.FindControl("LinkBtn_CheckOK") as LinkButton;
            Label Lbl_None = e.Item.FindControl("Lbl_None") as Label;
            //LinkButton Lbl_None = e.Item.FindControl("Lbl_None") as LinkButton;
            LinkButton LinkBtn_Return = e.Item.FindControl("LinkBtn_Return") as LinkButton;
            LinkButton LinkBtn_CheckBack = e.Item.FindControl("LinkBtn_CheckBack") as LinkButton;
            LinkButton LinBtn_Chanel = e.Item.FindControl("LinBtn_Chanel") as LinkButton;
            LinkButton LinBtn_Repair2 = e.Item.FindControl("LinBtn_Repair2") as LinkButton;
            LinkButton LinkBtn_CheckRepair2Back = e.Item.FindControl("LinkBtn_CheckRepair2Back") as LinkButton;
            LinkButton LinkBtn_CheckRepair2OK = e.Item.FindControl("LinkBtn_CheckRepair2OK") as LinkButton;
            LinkButton LinBtn_UP = e.Item.FindControl("LinBtn_UP") as LinkButton;
            LinkButton LinkBtn_Down = e.Item.FindControl("LinkBtn_Down") as LinkButton;
            if (e.Item is GridDataItem)
            {
                GridDataItem db = e.Item as GridDataItem;
                if (db["DeclarationState"].Text.Trim() == "未上报")
                {
                    LinBtn_Chanel.Visible = true;
                    LinBtn_UP.Visible = true;
                }
                //if (db["DeclarationState"].Text.Trim() == "申请已撤回")
                //{
                //    Lbl_None.Visible = true;
                //}
                if (db["DeclarationState"].Text.Trim() == "待上门")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "装备中心待受理")
                {
                    LinkBtn_Return.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "装备中心已受理")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "装备中心维修中")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "装备中心已完修")
                {
                    LinkBtn_CheckBack.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地待受理")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地已受理")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地维修中")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地已完修")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "建议报废")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "装备中心已取回")
                {
                    LinkBtn_CheckBack.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "报修单位已取回")
                {
                    LinBtn_Repair2.Visible = true;
                    LinkBtn_CheckOK.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "报修单位已取回(返修)")
                {
                    LinkBtn_CheckRepair2OK.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地待受理(返修)")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地已受理(返修)")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地维修中(返修)")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修基地已完修(返修)")
                {
                    Lbl_None.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "装备中心已取回(返修)")
                {
                    LinkBtn_CheckRepair2Back.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "维修完成")
                {
                    LinkBtn_Down.Visible = true;
                }
                if (db["DeclarationState"].Text.Trim() == "返修完成")
                {
                    LinkBtn_Down.Visible = true;
                }
            }
        }

        protected void Btn_search_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(RadTxtSearchName.Text.Trim()) && RadTxtSearchName.Text.Trim() != "")
            {
                RadTxtSearchName.Text = "";
                RadAjaxManager1.Alert("报修设备名称错误!");
                return;
            }
            State = DropDownList_zt.SelectedValue;
            DataLoad();
            RadGrid1.Rebind();
        }

        protected void Btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepairAdd.aspx");
        }

        protected void Btn_check_Click1(object sender, EventArgs e)
        {
            Response.Redirect("RepairContent.aspx");
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Chanel")
            {
                Response.Redirect("RepairEdit.aspx?ID=" + e.CommandArgument + "");//跳转修改页面
            }
            if (e.CommandName == "UP")
            {
                Declaration_Mol = Declaration_Bll.GetModel(e.CommandArgument.ToString());
                Declaration_Mol.DeclarationState = "装备中心待受理";
                Declaration_Bll.Update(Declaration_Mol);
                DataLoad();
                RadGrid1.Rebind();
            }
            if (e.CommandName == "Return")
            {
                Declaration_Mol = Declaration_Bll.GetModel(e.CommandArgument.ToString());
                Declaration_Mol.DeclarationState = "未上报";
                Declaration_Bll.Update(Declaration_Mol);
                DataLoad();
                RadGrid1.Rebind();
            }
            if (e.CommandName == "CheckOK")
            {
                Declaration_Mol = Declaration_Bll.GetModel(e.CommandArgument.ToString());
                Declaration_Mol.DeclarationState = "维修完成";
                Declaration_Bll.Update(Declaration_Mol);
                DataLoad();
                RadGrid1.Rebind();
            }
            if (e.CommandName == "CheckBack")
            {
                Declaration_Mol = Declaration_Bll.GetModel(e.CommandArgument.ToString());
                Replacement_Mol = Replacement_Bll.GetModelJYF(Declaration_Mol.ReplacementID);
                if (Declaration_Mol.ReplacementUse != "否")
                {
                    Replacement_Mol.ReplacementState = "未借出";
                    Replacement_Bll.Update(Replacement_Mol);
                    ReplacementRecord_Mol = ReplacementRecord_Bll.GetModelJYF2(Declaration_Mol.ReplacementID);
                    ReplacementRecord_Mol.ReplacementBackTime = DateTime.Now;
                    ReplacementRecord_Bll.Update(ReplacementRecord_Mol);
                }
                
                
                Declaration_Mol.DeclarationState = "报修单位已取回";
                Declaration_Bll.Update(Declaration_Mol);
                DataLoad();
                RadGrid1.Rebind();
            }
            if (e.CommandName == "Repair2")
            {
                Lable_xxx.Text = e.CommandArgument.ToString();
                //Response.Redirect("RepairBackAdd.aspx?ID=" + e.CommandArgument + "");
            }
            if (e.CommandName == "CheckRepair2Back")
            {
                Declaration_Mol = Declaration_Bll.GetModel(e.CommandArgument.ToString());
                Replacement_Mol = Replacement_Bll.GetModelJYF(Declaration_Mol.ReplacementID);
                if (Declaration_Mol.ReplacementUse != "否")
                {
                    Replacement_Mol.ReplacementState = "未借出";
                    Replacement_Bll.Update(Replacement_Mol);
                    ReplacementRecord_Mol.ReplacementBackTime = DateTime.Now;
                    ReplacementRecord_Bll.Update(ReplacementRecord_Mol);
                }
                Declaration_Mol.DeclarationState = "报修单位已取回(返修)";
                Declaration_Bll.Update(Declaration_Mol);
                DataLoad();
                RadGrid1.Rebind();
            }
            if (e.CommandName == "CheckRepair2OK")
            {
                Declaration_Mol = Declaration_Bll.GetModel(e.CommandArgument.ToString());
                Declaration_Mol.DeclarationState = "返修完成";
                Declaration_Bll.Update(Declaration_Mol);
                DataLoad();
                RadGrid1.Rebind();
            }
            if (e.CommandName == "Down")
            {
                Response.Redirect("RepairReport.aspx?ID=" + e.CommandArgument + "");//跳转报表页面
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Declaration_Mol = Declaration_Bll.GetModel(Lable_xxx.Text);
            Declaration_Mol.ReworkInstructions = fxsm.Text;
            Declaration_Mol.DeclarationState = "维修基地待受理(返修)";//修改状态
            Declaration_Mol.RepairerID = "";
            Declaration_Mol.RepairerName = "";
            Declaration_Mol.TeacherID = "";
            Declaration_Mol.TeacherName = "";
            Declaration_Bll.Update(Declaration_Mol);
            DataLoad();
            RadGrid1.Rebind();
        }
    }
}