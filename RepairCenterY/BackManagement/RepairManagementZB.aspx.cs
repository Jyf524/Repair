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
    public partial class RepairManagement : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration DeclarationBLL = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration DeclarationModel = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.UnitsInfo UnitsInfoBLL = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo UnitsInfoModel = new Maticsoft.Model.UnitsInfo();
        //定义五个公共函数
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
        public void select()// 定义一个select方法
        {
            string ID = Request["id"];//获取ID
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

            if (!String.IsNullOrEmpty(SeachString3) )
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += " RepairTime< '" + SeachString3 + "'";//加入条件
            }

            if (!String.IsNullOrEmpty(SeachString4) && SeachString4!="全部")
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
            RadGrid1.DataSource = DeclarationBLL.GetList2(OID);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//判断是否为第二次进入
            {
                ddlUnitsInfo.Items.Clear();//清空
                ddlUnitsInfo.Items.Add("全部");
                ddlUnitsInfo.DataSource = UnitsInfoBLL.GetList("");
                ddlUnitsInfo.DataTextField = "UnitName";
                ddlUnitsInfo.DataValueField = "UnitID";
                ddlUnitsInfo.DataBind();

            }

        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            select();//调用select方法
        }

        protected void RadGrid1_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "sholi")//点击受理
            {
                DeclarationModel=DeclarationBLL.GetModel(e.CommandArgument.ToString());
                if (DeclarationModel.DoorServer=="是")
                {
                    DeclarationModel.DeclarationState = "待上门";
                }
                else
                {
                DeclarationModel.DeclarationState = "装备中心已受理";
                }
                UnitsInfoModel = UnitsInfoBLL.GetModelyyy(DeclarationModel.UnitName);
                string aa = DeclarationModel.RepairTime.Value.ToString("yyyy-MM-dd");//定义一个变量为aa,存储为年月日
                int a = DeclarationBLL.GetRecordCount("Acceptancetime >= '" + aa + "' and  Acceptancetime >= '" + aa + "'  and DeclarationState= '装备中心已受理' or DeclarationState= '待上门' ")+1;
                string b = "";//定义一个变量b
                switch (Convert.ToString(a).Length)//判断变量a的长度
                {
                    case 1: b = "00" + a.ToString(); break;//为1 单号加00
                    case 2: b = "0" + a.ToString(); break;//为2 单号加0
                    case 3: b = a.ToString(); break;//为3  不变化
                }
                DeclarationModel.ListID = DateTime.Now.ToString("yyyyMMdd") + UnitsInfoModel.UnitCode + b;//添加单号
                DeclarationModel.Acceptancetime = DateTime.Now;
                DeclarationBLL.Update(DeclarationModel);//更新数据
                RadGrid1.Rebind();//刷新
            }
            if (e.CommandName == "fenpei")//点击分配
            {
                Response.Redirect("RepairAcceptanceZB.aspx?id=" + e.CommandArgument.ToString());//跳转页面并传相对应的ID
            }
            if (e.CommandName == "wc")//点击完成
            {
                Response.Redirect("MaintenanceListZB.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "dy")//点击打印
            {
                Response.Redirect("RepairReport.aspx?ID=" + e.CommandArgument + "");
            }
            if (e.CommandName == "qh")//点击确认取回
            {
                DeclarationModel = DeclarationBLL.GetModel(e.CommandArgument.ToString());
                DeclarationModel.DeclarationState = "装备中心已取回";
                DeclarationBLL.Update(DeclarationModel);//更新数据
                RadGrid1.Rebind();//刷新
            }
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            select();
            RadGrid1.Rebind();//刷新
        }

        protected void RadGrid1_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            select();
            RadGrid1.Rebind();//刷新
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
           
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            //判断是否含有特殊字符
            string yhm = RadTxtSearchName.Text.Trim();
            Regex pattern = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？]");
            if ((pattern.IsMatch(yhm) == true))
            {
                RadAjaxManager1.Alert("请输入正确搜索条件！");
            }
            else
            {
                SeachString = RadTxtSearchName.Text.Trim();//删除空格
            }
            SeachString1 = ddlPartName.SelectedValue.Trim();
            if (dpstarttime.SelectedDate > dpendtime.SelectedDate)
            {
                RadAjaxManager1.Alert("最小时间不能大于最大时间！");
            }
            else
            {
                SeachString2 = dpstarttime.SelectedDate.ToString();
                SeachString3 = dpendtime.SelectedDate.ToString();
            }
            SeachString4 = ddlUnitsInfo.SelectedItem.Text.Trim();//删除空格
            select();
            RadGrid1.Rebind();//刷新
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //状态的不同，按钮的变化
            LinkButton LinkButton1 = e.Item.FindControl("LinkButton1") as LinkButton;
            LinkButton LinkButton2 = e.Item.FindControl("LinkButton2") as LinkButton;
            LinkButton LinkButton3 = e.Item.FindControl("LinkButton3") as LinkButton;
            LinkButton LinkButton4 = e.Item.FindControl("LinkButton4") as LinkButton;
            LinkButton btndeal = e.Item.FindControl("btndeal") as LinkButton;
            LinkButton btngive = e.Item.FindControl("btngive") as LinkButton;
            if (e.Item is GridDataItem)
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                LinkButton4.Visible = false;
                btndeal.Visible = false;
                btngive.Visible = false;
                GridDataItem db = e.Item as GridDataItem;
                switch (db["DeclarationState"].Text.Trim())
                {
                    case "维修申请":
                        btndeal.Visible = true;
                        break;
                    case "装备中心已取回":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地已完修":
                        LinkButton4.Visible = true;
                        break;
                    case "维修基地已完修(返修)":
                        LinkButton4.Visible = true;
                        break;
                    case "装备中心已取回(返修)":
                        LinkButton3.Visible = true;
                        break;
                    case "装备中心待受理":
                        btndeal.Visible = true;
                        break;
                    case "装备中心已受理":
                        btngive.Visible = true;
                        break;
                    case "待上门":
                        btngive.Visible = true;
                        break;
                    case "装备中心维修中":
                        LinkButton1.Visible = true;
                        break;
                    case "装备中心已完修":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地维修中":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地已受理(返修)":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地已受理":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地维修中(返修)":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地待受理(返修)":
                        LinkButton3.Visible = true;
                        break;
                    case "维修基地待受理":
                        LinkButton3.Visible = true;
                        break;
                    case "维修完成":
                        LinkButton2.Visible = true;
                        break;
                    case "返修完成":
                        LinkButton2.Visible = true;
                        break;
                    case "建议报废":
                        LinkButton3.Visible = true;
                        break;

                }
            }
        }

        protected void btnlook_Click(object sender, EventArgs e)
        {
            //选中一条数据进行跳转
            if (RadGrid1.SelectedItems.Count > 0)//判断有无选中数据
            {
                var selectedItem = RadGrid1.SelectedItems[0];
                string id = RadGrid1.MasterTableView.DataKeyValues[selectedItem.ItemIndex]["DeclarationID"].ToString();//获取DeclarationID相对应的值
                Response.Redirect("MaintenanceListWX.aspx?ID=" + id);//跳转页面
            }
            else
            {
                RadAjaxManager1.Alert("请选择一条数据!");
            }
        }
    }
}