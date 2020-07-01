using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class MaintenanceListWX : System.Web.UI.Page
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
            //if (UsersInfo.UserID == "" || UsersInfo.UserRole != "维修中心管理员")
            //{
            //    UsersInfo.UserID = "";
            //    UsersInfo.UserName = "";
            //    UsersInfo.UserRole = "";
            //    Response.Redirect("~/BackLogin.aspx");
            //    return;
            //}
            modelDeclaration = bllDeclaration.GetModel(Request.QueryString["ID"]);
            if (modelDeclaration == null)//为空返回列表页面
            {
                Response.Write("<script>window.location.href='RepairManagementWX.aspx'</script>");
                return;
            }
            repair.Visible = false;//隐藏
            baoxiu.Visible = false;//隐藏
            shouli.Visible = false;//隐藏

            baoxiu.Visible = true;
            //报修信息
            lblAssetsID.Text = modelDeclaration.AssetsID;//资产序号
            lblBreakDown.Text = modelDeclaration.BreakDown;//故障现象
            lblContact.Text = modelDeclaration.Contact;//联系人
            lblContactPhone.Text = modelDeclaration.ContactPhone;//联系人电话
            lblDoorServer.Text = modelDeclaration.DoorServer;//是否上门服务

            if ( !String.IsNullOrEmpty(modelDeclaration.ListID))
            {
                lblListID.Text = modelDeclaration.ListID;//单号
            }
            else
            {
                lblListID.Text = "暂无数据";
            }
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
                
                down.HRef = modelDeclaration.OtherPart;//其他附件
            }
            lblMachineFatherName.Text = bllMachineFatherType.GetModel(modelDeclaration.MachineFatherType).MachineFatherName;//设备父类
            lblMachineSonName.Text = bllMachineSonType.GetModel(modelDeclaration.MachineSonType).MachineSonName;//设备子类
            //为这些状态显示受理信息
            if (modelDeclaration.DeclarationState == "维修基地维修中" || modelDeclaration.DeclarationState == "维修基地维修中(返修)" || modelDeclaration.DeclarationState == "装备中心维修中" || modelDeclaration.DeclarationState == "建议报废" || modelDeclaration.DeclarationState == "维修基地已完修" || modelDeclaration.DeclarationState == "装备中心已取回" || modelDeclaration.DeclarationState == "维修完成" || modelDeclaration.DeclarationState == "维修基地已完修(返修)" || modelDeclaration.DeclarationState == "装备中心已取回(返修)" || modelDeclaration.DeclarationState == "返修完成" || modelDeclaration.DeclarationState == "装备中心已完修")
            {
                shouli.Visible = true;
                //受理信息
                lblDeviceDescription.Text = modelDeclaration.DeviceDescription;//赋值
                lblFaultPrediction.Text = modelDeclaration.FaultPrediction;//赋值
                if (!String.IsNullOrEmpty(modelDeclaration.TeacherName))
                {
                lblteacher.Text = modelDeclaration.TeacherName;//赋值
                }
                else
                {
                lblteacher.Text = "暂无数据";//赋值
                }
                
                lblEstimateTime.Text = modelDeclaration.EstimateTime.Value.ToString("yyyy-MM-dd");//赋值
            }
            //为这些状态显示维修信息
            if (modelDeclaration.DeclarationState == "维修基地已完修" || modelDeclaration.DeclarationState == "装备中心已取回" || modelDeclaration.DeclarationState == "维修完成" || modelDeclaration.DeclarationState == "维修基地已完修(返修)" || modelDeclaration.DeclarationState == "装备中心已取回(返修)" || modelDeclaration.DeclarationState == "返修完成" || modelDeclaration.DeclarationState == "装备中心已完修")
            {
                repair.Visible = true;
                //维修信息
                if (!String.IsNullOrEmpty(modelDeclaration.PartPrice))
                {
                lblPartPrice.Text = modelDeclaration.PartPrice;//赋值
                }
                else
                {
                lblPartPrice.Text ="暂无数据";//赋值
                }
                
                lblRepairerName.Text = modelDeclaration.RepairerName;//赋值
                if (!String.IsNullOrEmpty(modelDeclaration.RepairPrice.ToString()))
                {
                lblRepairPrice.Text = modelDeclaration.RepairPrice.ToString();//赋值
                }
                else
                {
                lblRepairPrice.Text = "暂无数据";//赋值
                }
                
                //lblResult.Text = modelDeclaration.Result;//赋值
                lblResultTime.Text = modelDeclaration.ResultTime.Value.ToString("yyyy-MM-dd");//赋值
                
                lblRepairPlan.Text = modelDeclaration.RepairPlan;//赋值
                if (String.IsNullOrEmpty(modelDeclaration.TeacherName))
                {
                    lblTeacherName.Text = "无";
                }
                else
                {
                    lblTeacherName.Text = modelDeclaration.TeacherName;//赋值
                }
            }


        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            if (UsersInfo.UserRole == "装备中心管理员")
            {
                Response.Write("<script>window.location.href='RepairManagementZB.aspx'</script>");
            }
            else if (UsersInfo.UserRole == "指导老师")
            {
                Response.Write("<script>window.location.href='RepairListLS.aspx'</script>");
            }
            else if (UsersInfo.UserRole == "维修中心管理员")
            {
                Response.Write("<script>window.location.href='RepairManagementWX.aspx'</script>");
            }

        }
    }
}