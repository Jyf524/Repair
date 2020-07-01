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
    public partial class RepairDetailedWX : System.Web.UI.Page
    {
        Maticsoft.BLL.UsersInfo bllUsersInfo = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo modelUsersInfo = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.Declaration bllDeclaration = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration modelDeclaration = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.MachineFatherType bllMachineFatherType = new Maticsoft.BLL.MachineFatherType();
        Maticsoft.Model.MachineFatherType modelMachineFatherType = new Maticsoft.Model.MachineFatherType();
        Maticsoft.BLL.MachineSonType bllMachineSonType = new Maticsoft.BLL.MachineSonType();
        Maticsoft.Model.MachineSonType modelMachineSonType = new Maticsoft.Model.MachineSonType();
        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定下拉框数据源
            if (!IsPostBack)
            {
                ddlteacher.Items.Clear();
                ddlteacher.Items.Add("请选择");

                ddlteacher.DataSource = bllUsersInfo.GetList(" UserIdentity = '指导老师' ");
                ddlteacher.DataTextField = "UserRealName";
                ddlteacher.DataValueField = "UserID";
                ddlteacher.DataBind();
            }
            modelDeclaration = bllDeclaration.GetModel(Request.QueryString["ID"]);
            if (modelDeclaration == null)//为空返回
            {
                Response.Write("<script>window.location.href='RepairManagementWX.aspx'</script>");
                return;
            }
            if (modelDeclaration.TeacherID != "")//已分配的
            {
                Response.Write("<script>alert('该报修已分配');window.location.href='RepairManagementWX.aspx'</script>");
                if (modelDeclaration.DeclarationState == "维修基地已受理")
                    modelDeclaration.DeclarationState = "维修基地维修中";
                if (modelDeclaration.DeclarationState == "维修基地已受理(返修)")
                    modelDeclaration.DeclarationState = "维修基地维修中(返修)";
                return;
            }
            lblAssetsID.Text = modelDeclaration.AssetsID;//资产序号
            lblBreakDown.Text = modelDeclaration.BreakDown;//故障现象
            lblContact.Text = modelDeclaration.Contact;//联系人
            lblContactPhone.Text = modelDeclaration.ContactPhone;//联系人电话
            lblDoorServer.Text = modelDeclaration.DoorServer;//是否上门服务
            lblListID.Text = modelDeclaration.ListID;//单号
            lblMachineName.Text = modelDeclaration.MachineName;//设备名称
            lblModel.Text = modelDeclaration.Model;//型号参数
            lblUnitName.Text = modelDeclaration.UnitName;//报修单位
            if (modelDeclaration.OtherPart == "")
            {
                lblOtherPart.Text = "无";
                down.Target = "";
                down.HRef = "";
            }
            else 
            {
                lblOtherPart.Text = "下载文件";//其他附件
                down.HRef = modelDeclaration.OtherPart;//其他附件
            }
            lblMachineFatherName.Text = bllMachineFatherType.GetModel(modelDeclaration.MachineFatherType).MachineFatherName;//设备父类
            lblMachineSonName.Text = bllMachineSonType.GetModel(modelDeclaration.MachineSonType).MachineSonName;//设备子类



        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5，。]{1,}$";//字母数字汉字逗号句号
            Regex rxname = new Regex(name);
            
            if (txtDeviceDescription.Text.Trim() == "")//设备描述
            {
                RadAjaxManager1.Alert("请输入设备描述!");
                return;
            }
            if (txtFaultPrediction.Text.Trim() == "")//故障预判
            {
                RadAjaxManager1.Alert("请输入故障预判!");
                return;
            }
            if (ddlteacher.SelectedItem.Text == "请选择")
            {
                RadAjaxManager1.Alert("请选择分配老师!");
                return;
            }
            if (dpEstimateTime.SelectedDate.ToString() == "")
            {
                RadAjaxManager1.Alert("请输入预计完修时间!");
                return;
            }
            if (!rxname.IsMatch(txtDeviceDescription.Text.Trim()) && txtDeviceDescription.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("设备描述不能输入特殊字符!");
                return;
            }
            if (!rxname.IsMatch(txtFaultPrediction.Text.Trim()) && txtFaultPrediction.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("故障预判不能输入特殊字符!");
                return;
            }
            if (dpEstimateTime.SelectedDate.Value.AddDays(1) < DateTime.Now)
            {
                RadAjaxManager1.Alert("预计完修时间不能小于当前时间!");
                return;
            }
            if (modelDeclaration.TeacherID != "")
            {
                Response.Write("<script>alert('该报修已受理');window.location.href='RepairManagementWX.aspx'</script>");
                return;
            }

            modelDeclaration.DeclarationID = modelDeclaration.DeclarationID;
            modelDeclaration.DeviceDescription = txtDeviceDescription.Text.Trim();
            modelDeclaration.FaultPrediction = txtFaultPrediction.Text.Trim();
            modelDeclaration.TeacherID = ddlteacher.SelectedValue;
            modelDeclaration.TeacherName = ddlteacher.SelectedItem.Text;
            modelDeclaration.EstimateTime = dpEstimateTime.SelectedDate;
            if (modelDeclaration.DeclarationState == "维修基地已受理")
            {
                modelDeclaration.DeclarationState = "维修基地维修中";
            }
            else
            {
                modelDeclaration.DeclarationState = "维修基地维修中(返修)";
            }
            bllDeclaration.Update(modelDeclaration);//更新
            Response.Write("<script>alert('保存成功');window.location.href='RepairManagementWX.aspx'</script>");

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='RepairManagementWX.aspx'</script>");
        }


    }
}