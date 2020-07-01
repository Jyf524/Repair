using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class RepairAddZB : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration DeclarationBLL = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration DeclarationModel = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.Replacement ReplacementBLL = new Maticsoft.BLL.Replacement();
        Maticsoft.Model.Replacement ReplacementModel = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.ReplacementRecord ReplacementRecordBLL = new Maticsoft.BLL.ReplacementRecord();
        Maticsoft.Model.ReplacementRecord ReplacementRecordModel = new Maticsoft.Model.ReplacementRecord();
        Maticsoft.BLL.UnitsInfo UnitsInfoBLL = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo UnitsInfoModel = new Maticsoft.Model.UnitsInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["id"]))//判断ID是否为空
            {
                DeclarationModel = DeclarationBLL.GetModel(Request["id"].ToString());//获取相对应ID的值
                Label1.Text = DeclarationModel.ListID;//添加单号
                Label2.Text = DeclarationModel.Contact;
                Label3.Text = DeclarationModel.ContactPhone;
                Label4.Text = DeclarationModel.MachineName;
                Label5.Text = DeclarationModel.AssetsID;
                lblBreakDown.Text = DeclarationModel.BreakDown;
                Label6.Text = DeclarationModel.DoorServer;
                Label7.Text = DeclarationModel.Model;
                if (DeclarationModel.OtherPart == "")
                {
                    Label9.Text = "暂无数据";
                }
                else
                {

                    down.HRef = DeclarationModel.OtherPart;//其他附件
                }
                Label10.Text = DeclarationModel.ReplacementUse;

            }
            else
            {
                Response.Redirect("../BackLogin.aspx");
            }
            if (!IsPostBack)//判断是否是第二次进入
            {
                RadioButton1.Checked = true;
                sbms.Visible = false;//控件隐藏
                gzyp.Visible = false;
                time.Visible = false;
                bianhao.Visible = false;
                DropDownList1.Items.Clear();//清空
                DropDownList1.Items.Add("全部");
                DropDownList1.DataSource = ReplacementBLL.GetList("");
                DropDownList1.DataTextField = "ReplacementName";
                DropDownList1.DataValueField = "ReplacementID";
                DropDownList1.DataBind();
                if (Label10.Text == "是")//如果申请使用代用机
                {
                    bianhao.Visible = true;//按钮显示，不隐藏
                }
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            DeclarationModel = DeclarationBLL.GetModel(Request["id"].ToString());//获取相对应ID的值
            ReplacementModel = ReplacementBLL.GetModel(DropDownList1.SelectedValue);
            string search1 = TextBox2.Text;
            string xxdz1 = TextBox2.Text.Trim();//删除空格
            Regex pattern1 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ]");//判断特殊字符

            if (Label10.Text == "是")//如果申请使用代用机
            {
                if (RadioButton2.Checked == true)//如果为装备中心修理
                {
                    //判断是否为空，是否含有特殊字符
                    if (String.IsNullOrEmpty(DropDownList1.SelectedItem.Text.Trim()))
                    {
                        RadAjaxManager1.Alert("请输入代用机编号");
                    }
                    else if (String.IsNullOrEmpty(TextBox2.Text))
                    {
                        RadAjaxManager1.Alert("请输入设备描述");
                    }
                    else if (String.IsNullOrEmpty(TextBox3.Text))
                    {
                        RadAjaxManager1.Alert("请输入故障预判");
                    }
                    else if (String.IsNullOrEmpty(RadDatePicker1.SelectedDate.ToString()))
                    {
                        RadAjaxManager1.Alert("请输入完修时间");
                    }
                    else if ((pattern1.IsMatch(xxdz1) == true))
                    {
                        RadAjaxManager1.Alert("请不要输入特殊字符");
                    }
                    else if (RadDatePicker1.SelectedDate < DateTime.Now)
                    {
                        RadAjaxManager1.Alert("完修时间不能小于当前时间");
                    }

                    //还少判断设备描述的特殊字符、完修时间不能小于当前时间
                    else
                    {
                        //将输入框的值传入数据库并进行跳转
                        DeclarationModel.ReplacementID = DropDownList1.SelectedValue;

                        DeclarationModel.DeviceDescription = TextBox2.Text;
                        DeclarationModel.FaultPrediction = TextBox3.Text;
                        DeclarationModel.EstimateTime = RadDatePicker1.SelectedDate;
                        DeclarationModel.DeclarationState = "装备中心维修中";
                        DeclarationModel.ListID = Label1.Text;
                        DeclarationModel.RepairerName = UsersInfo.UserName;
                        DeclarationModel.RepairerID = UsersInfo.UserID;
                        DeclarationBLL.Update(DeclarationModel);
                        //这边add上面的四个内容
                        ReplacementRecordModel.UserID = DeclarationModel.UserID;
                        ReplacementRecordModel.ReplacementLendTime = DateTime.Now;
                        ReplacementRecordModel.ReplacementID = ReplacementModel.ReplacementID;
                        ReplacementRecordModel.ReplacementRecordID = DateTime.Now.ToString("yyyyMMddHHmmssms");
                        ReplacementRecordModel.ReplacementName = ReplacementModel.ReplacementName;
                        ReplacementRecordBLL.Add(ReplacementRecordModel);

                        ReplacementModel.ReplacementState = "已借出";
                        ReplacementBLL.Update(ReplacementModel);
                        //add代用机使用记录添加用户，使用时间
                        //代用机状态为已借出
                        RadAjaxManager1.Redirect("RepairManagementZB.aspx");
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(DropDownList1.SelectedItem.Text.Trim()))
                    {
                        RadAjaxManager1.Alert("请输入代用机编号");
                    }
                    else if (RadioButton1.Checked == true)//如果是建议报废
                    {
                        DeclarationModel.DeclarationState = "建议报废";
                        DeclarationModel.RepairerName = UsersInfo.UserName;
                        DeclarationModel.RepairerID = UsersInfo.UserID;
                        DeclarationModel.ListID = Label1.Text;//填写故障现象
                        DeclarationBLL.Update(DeclarationModel);//更新数据
                        RadAjaxManager1.Redirect("RepairManagementZB.aspx");
                        //update状态为建议报废
                    }
                    else if (RadioButton3.Checked == true)//如果是维修基地修理
                    {
                        DeclarationModel.DeclarationState = "维修基地待受理";
                        DeclarationModel.ListID = Label1.Text;//填写故障现象
                        DeclarationBLL.Update(DeclarationModel);//更新数据
                        ReplacementRecordModel.UserID = DeclarationModel.UserID;
                        ReplacementRecordModel.ReplacementLendTime = DateTime.Now;
                        ReplacementRecordModel.ReplacementID = ReplacementModel.ReplacementID;
                        ReplacementRecordModel.ReplacementRecordID = DateTime.Now.ToString("yyyyMMddHHmmssms");
                        ReplacementRecordModel.ReplacementName = ReplacementModel.ReplacementName;
                        ReplacementRecordBLL.Add(ReplacementRecordModel);

                        ReplacementModel.ReplacementState = "已借出";
                        ReplacementBLL.Update(ReplacementModel);
                        RadAjaxManager1.Redirect("RepairManagementZB.aspx");
                        //update状态为维修中心待受理
                    }
                }
            }
            else
            {
                if (RadioButton2.Checked == true)//如果为装备中心修理
                {
                    //判断输入框是否为空，含有特殊字符

                    if (String.IsNullOrEmpty(TextBox2.Text))
                    {
                        RadAjaxManager1.Alert("请输入设备描述");
                    }
                    else if (String.IsNullOrEmpty(TextBox3.Text))
                    {
                        RadAjaxManager1.Alert("请输入故障预判");
                    }
                    else if (String.IsNullOrEmpty(RadDatePicker1.SelectedDate.ToString()))
                    {
                        RadAjaxManager1.Alert("请输入完修时间");
                    }
                    else if ((pattern1.IsMatch(xxdz1) == true))
                    {
                        RadAjaxManager1.Alert("请不要输入特殊字符");
                    }
                    else if (Convert.ToDateTime(RadDatePicker1.SelectedDate.Value.ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        RadAjaxManager1.Alert("完修时间不能小于当前时间");
                    }
                    //还少判断设备描述的特殊字符、完修时间不能小于当前时间
                    else
                    {
                        //将输入框的数据添加到数据库
                        DeclarationModel.DeviceDescription = TextBox2.Text;
                        DeclarationModel.FaultPrediction = TextBox3.Text;
                        DeclarationModel.EstimateTime = RadDatePicker1.SelectedDate;
                        DeclarationModel.DeclarationState = "装备中心维修中";
                        DeclarationModel.ListID = Label1.Text;
                        DeclarationModel.RepairerName = UsersInfo.UserName;
                        DeclarationModel.RepairerID = UsersInfo.UserID;
                        DeclarationBLL.Update(DeclarationModel);//更新数据
                        //这边add上面的四个内容
                       
                        RadAjaxManager1.Redirect("RepairManagementZB.aspx");//跳转页面
                    }
                }
                else
                {
                    if (RadioButton1.Checked == true)//如果是建议报废
                    {
                        DeclarationModel.DeclarationState = "建议报废";
                        DeclarationModel.RepairerName = UsersInfo.UserName;
                        DeclarationModel.ListID = Label1.Text;//填写故障现象
                        DeclarationModel.RepairerID = UsersInfo.UserID;
                        DeclarationBLL.Update(DeclarationModel);//更新数据
                        RadAjaxManager1.Redirect("RepairManagementZB.aspx");//跳转页面
                        //update状态为建议报废
                    }
                    else if (RadioButton3.Checked == true)//如果是维修基地修理
                    {
                        DeclarationModel.DeclarationState = "维修基地待受理";
                        DeclarationModel.ListID = Label1.Text;//填写单号
                        DeclarationBLL.Update(DeclarationModel);//更新数据
                        RadAjaxManager1.Redirect("RepairManagementZB.aspx");//跳转页面
                        //update状态为维修中心待受理
                    }

                }
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepairManagementZB.aspx");
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                sbms.Visible = true;
                gzyp.Visible = true;
                time.Visible = true;
            }
            else if (RadioButton1.Checked == true)
            {
                sbms.Visible = false;
                gzyp.Visible = false;
                time.Visible = false;
            }
            else
            {
                sbms.Visible = false;
                gzyp.Visible = false;
                time.Visible = false;
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                sbms.Visible = true;
                gzyp.Visible = true;
                time.Visible = true;
            }
            else if (RadioButton1.Checked == true)
            {
                sbms.Visible = false;
                gzyp.Visible = false;
                time.Visible = false;
            }
            else
            {
                sbms.Visible = false;
                gzyp.Visible = false;
                time.Visible = false;
            }
        }

        protected void RadioButton3_CheckedChanged1(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                sbms.Visible = true;
                gzyp.Visible = true;
                time.Visible = true;
            }
            else if (RadioButton1.Checked == true)
            {
                sbms.Visible = false;
                gzyp.Visible = false;
                time.Visible = false;
            }
            else
            {
                sbms.Visible = false;
                gzyp.Visible = false;
                time.Visible = false;
            }
        }

    }
}