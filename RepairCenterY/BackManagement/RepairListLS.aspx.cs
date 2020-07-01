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
    public partial class RepairListLS : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration DeclarationBLL = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration DeclarationModel = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.UnitsInfo UnitsInfoBLL = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo UnitsInfoModel = new Maticsoft.Model.UnitsInfo();
        public string SeachString
        {
            get { return ViewState["_SeachString"] == null ? string.Empty : ViewState["_SeachString"].ToString(); }
            set { ViewState["_SeachString"] = value; }
        }
        public string SeachString1
        {
            get { return ViewState["_SeachString1"] == null ? string.Empty : ViewState["_SeachString1"].ToString(); }
            set { ViewState["_SeachString1"] = value; }
        }
        public string SeachString2
        {
            get { return ViewState["_SeachString2"] == null ? string.Empty : ViewState["_SeachString2"].ToString(); }
            set { ViewState["_SeachString2"] = value; }
        }
        public string SeachString3
        {
            get { return ViewState["_SeachString3"] == null ? string.Empty : ViewState["_SeachString3"].ToString(); }
            set { ViewState["_SeachString3"] = value; }
        }
        public string SeachString4
        {
            get { return ViewState["_SeachString4"] == null ? string.Empty : ViewState["_SeachString4"].ToString(); }
            set { ViewState["_SeachString4"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlUnitsInfo.Items.Clear();
                ddlUnitsInfo.Items.Add("全部");
                ddlUnitsInfo.DataSource = UnitsInfoBLL.GetList("");
                ddlUnitsInfo.DataTextField = "UnitName";
                ddlUnitsInfo.DataValueField = "UnitID";
                ddlUnitsInfo.DataBind();//给单位传值

            }
        }
        public void select()
        {
            string ID = Request["id"];
            string OID = "";
            if (!String.IsNullOrEmpty(SeachString))//判断标题是否为空
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += "MachineName like '%" + SeachString + "%' ";//加入条件
            }

            if (!String.IsNullOrEmpty(SeachString1))
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += " DeclarationState = '" + SeachString1 + "'";//加入条件
            }

            if (!String.IsNullOrEmpty(SeachString2))
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += " RepairTime> '" + SeachString2 + "'";//加入条件
            }

            if (!String.IsNullOrEmpty(SeachString3))
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += " RepairTime< '" + SeachString3 + "'";//加入条件
            }

            if (!String.IsNullOrEmpty(SeachString4) && SeachString4 != "全部")
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += " UnitName= '" + SeachString4 + "'";//加入条件
            }
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '未上报' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '申请已撤回' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '装备中心待受理' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '装备中心已受理' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '装备中心维修中' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '装备中心已完修' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '建议报废' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '待上门' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '维修基地待受理' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '维修基地待受理(返修)' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '维修基地已受理(返修)' ";//加入条件
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "DeclarationState  != '维修基地已受理' ";//加入条件
            RadGrid1.DataSource = DeclarationBLL.GetList2(OID);
        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            select();
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "fenpei")
            {
                Response.Redirect("RepairDetailedLS.aspx?id=" + e.CommandArgument.ToString());//跳转分配页面
            }
            if (e.CommandName == "wc")
            {
                Response.Redirect("MaintenanceListLS.aspx?id=" + e.CommandArgument.ToString());//跳转维修信息填写
            }
            if (e.CommandName == "dy")
            {
                Response.Redirect("RepairReport.aspx?ID=" + e.CommandArgument + "");//报表
            
            }

        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }

        protected void RadGrid1_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {

        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            //if (RadGrid1.SelectedItems.Count > 0)
            //{
            //    var selectedItem = RadGrid1.SelectedItems[0];
            //    string ID = RadGrid1.MasterTableView.DataKeyValues[selectedItem.ItemIndex]["DeclarationID"].ToString();
            //    Response.Redirect("RepairDetailedLS.aspx?id=" + ID);
            //}
            //else
            //{
            //    RadAjaxManager1.Alert("请选择一条数据");
            //}
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            string yhm = RadTxtSearchName.Text.Trim();
            Regex pattern = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？]");
            if ((pattern.IsMatch(yhm) == true))
            {
                RadAjaxManager1.Alert("请输入正确搜索条件！");//判断是否有特殊字符
            }
            else
            {
                SeachString = RadTxtSearchName.Text.Trim();
            }
            SeachString1 = ddlPartName.SelectedValue.Trim();
            if (dpstarttime.SelectedDate > dpendtime.SelectedDate)
            {
                RadAjaxManager1.Alert("最小时间不能大于最大时间！");//判断时间
            }
            else
            {
                SeachString2 = dpstarttime.SelectedDate.ToString();
                SeachString3 = dpendtime.SelectedDate.ToString();
            }
            SeachString4 = ddlUnitsInfo.SelectedItem.Text.Trim();
            select();//调用方法查询
            RadGrid1.Rebind();//刷新
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            LinkButton LinkButton1 = e.Item.FindControl("LinkButton1") as LinkButton;
            LinkButton LinkButton2 = e.Item.FindControl("LinkButton2") as LinkButton;
            LinkButton LinkButton3 = e.Item.FindControl("LinkButton3") as LinkButton;
            LinkButton btngive = e.Item.FindControl("btngive") as LinkButton;
            //DeclarationModel = DeclarationBLL.GetModel(LinkButton1.CommandArgument.ToString());
            if (e.Item is GridDataItem)
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                btngive.Visible = false;

                GridDataItem db = e.Item as GridDataItem;
                switch (db["DeclarationState"].Text.Trim())
                {
                    case "装备中心已取回":
                        LinkButton3.Visible = true;
                        break;
                    case "装备中心已取回(返修)":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地已完修":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地已完修(返修)":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地维修中":
                        if (db["RepairerID"].Text == "&nbsp;")
                        {
                            btngive.Visible = true;
                        }
                        else
                        {
                            LinkButton1.Visible = true;
                        }
                        break;
                    case "维修基地维修中(返修)":
                        if (db["RepairerID"].Text == "&nbsp;")
                        {
                            btngive.Visible = true;
                        }
                        else
                        {
                            LinkButton1.Visible = true;
                        }
                        break;
                    case "维修完成":
                        LinkButton2.Visible = true;
                        break;
                    case "返修完成":
                        LinkButton2.Visible = true;
                        break;
                }//根据状态的不同显示不同操作按钮
            }
        }

        protected void btnlook_Click(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedItems.Count > 0)
            {
                var selectedItem = RadGrid1.SelectedItems[0];
                string id = RadGrid1.MasterTableView.DataKeyValues[selectedItem.ItemIndex]["DeclarationID"].ToString();//查看维修信息
                Response.Redirect("MaintenanceListWX.aspx?ID=" + id);
            }
            else
            {
                RadAjaxManager1.Alert("请选择一条数据!");
            }
        }
    }
}