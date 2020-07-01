using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavigationPlatformWeb.util;

namespace RepairCenterY
{
    public partial class RepairCenter : System.Web.UI.MasterPage
    {
        Maticsoft.BLL.UsersInfo bllui = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo molui = new Maticsoft.Model.UsersInfo();

        /* 系统管理员 */string sysPower = "PersonalIinformationCompanyEquipmentTypeUserDetailedInformationEditCompanyAddCompanyDetailedCompanyEditEquipmentSonTypeEquipmentSonTypeUserAddUserEditUnitUser";
        /* 报修单位用户 */string bxdwyh = "PersonalIinformationRepairBXRepairAddRepairEditRepairContentInformationEditInformationEdit";
        /* 装备中心管理员 */string zbzxgly = "PersonalIinformationSubstituteMachineSubstituteMachineAddSubstituteMachinfileNameditRepairManagementZBSubstitutionDetailsSubstitutionHistoryInformationEditRepairAcceptanceZBMaintenanceListZBSubstituteMachineEditMaintenanceListWX";
        /* 维修中心管理员 */string wxzxglr = "PersonalIinformationInformationEditTeacherContentTeacherEditTeacherAddTeacherInformationWarehousingDetailsRepairManagementWXRepairDetailedWXPartsWarehousingPartsTypePartsHistoryPartsRepairDetailedWXMaintenanceListWX";
        /* 指导老师 */string zdls = "PersonalIinformationInformationEditRepairListLSStudentInformationMaintenanceListLSRepairDetailedLSMaintenanceListWXRepairReportStudentDetailedStudentAddStudentEdit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (UsersInfo.UserID == "")
                {
                    Response.Write("<script>window.location.href='../BackLogin.aspx'</script>");
                    return;
                }
                string url = Request.PhysicalPath;
                string fileName = Path.GetFileNameWithoutExtension(url);
                switch (UsersInfo.UserRole)
                {
                    case "系统管理员":
                        if (!sysPower.Contains(fileName)) Response.Write("<script>window.location.href='PersonalIinformation.aspx'</script>");break;
                    case "报修单位用户":
                        if (!bxdwyh.Contains(fileName)) Response.Write("<script>window.location.href='PersonalIinformation.aspx'</script>"); break;
                    case "装备中心管理员":
                        if (!zbzxgly.Contains(fileName)) Response.Write("<script>window.location.href='PersonalIinformation.aspx'</script>"); break;
                    case "维修中心管理员":
                        if (!wxzxglr.Contains(fileName)) Response.Write("<script>window.location.href='PersonalIinformation.aspx'</script>"); break;
                    case "指导老师":
                        if (!zdls.Contains(fileName)) Response.Write("<script>window.location.href='PersonalIinformation.aspx'</script>"); break;
                }


                Maticsoft.Model.UsersInfo molui = bllui.GetModel(UsersInfo.UserID);//引用id所在行的数据

                lbUserName.Text = UsersInfo.UserName;
                if (UsersInfo.UserRole == "系统管理员")
                {
                    PersonalIinformation.Visible = true;//个人中心
                    Company.Visible = true;//报修单位管理
                    EquipmentType.Visible = true;//设备类别管理
                    UserDetailed.Visible = true;//单位用户管理

                    if (fileName == "PersonalIinformation")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "InformationEdit")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }

                    if (fileName == "Company" || fileName == "CompanyEdit" || fileName == "CompanyAdd" || fileName == "CompanyDetailed")
                    {
                        Company1.Attributes["class"] = "active";
                    }
                    if (fileName == "EquipmentType")
                    {
                        
                        EquipmentType1.Attributes["class"] = "active";
                    }
                    if (fileName == "UserDetailed" || fileName == "UserEdit" || fileName == "UserAdd" || fileName == "UnitUser")
                    {
                        
                        UserDetailed1.Attributes["class"] = "active";
                    }

                }
              
                if (UsersInfo.UserRole == "报修单位用户")
                {
                    PersonalIinformation.Visible = true;//个人中心
                    RepairBX.Visible = true;//我的报修

                    if (fileName == "PersonalIinformation")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "InformationEdit")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }

                    if (fileName == "RepairBX")
                    {
                        RepairBX1.Attributes["class"] = "active";
                    }
                    if (fileName == "RepairAdd")
                    {
                        
                        RepairBX1.Attributes["class"] = "active";
                    }
                    if (fileName == "RepairEdit")
                    {
                        
                        RepairBX1.Attributes["class"] = "active";
                    }
                    if (fileName == "RepairContent")
                    {
                        
                        RepairBX1.Attributes["class"] = "active";
                    }

                }

                if (UsersInfo.UserRole == "装备中心管理员")
                {
                    PersonalIinformation.Visible = true;//个人中心
                    SubstituteMachine.Visible = true;//代用机管理
                    RepairManagementZB.Visible = true;//维修管理-装备

                    if (fileName == "PersonalIinformation")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "InformationEdit")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }

                    if (fileName == "SubstituteMachine")
                    {
                        SubstituteMachine1.Attributes["class"] = "active";
                    }
                    if (fileName == "RepairManagementZB")
                    {
                        RepairManagementZB1.Attributes["class"] = "active";
                    }
                    if (fileName == "SubstituteMachineAdd")
                    {
                        SubstituteMachine1.Attributes["class"] = "active";
                    }
                    if (fileName == "SubstituteMachineEdit")
                    {
                        SubstituteMachine1.Attributes["class"] = "active";
                    }
                    if (fileName == "SubstitutionDetails")
                    {
                        SubstituteMachine1.Attributes["class"] = "active";
                    }
                    if (fileName == "SubstitutionHistory")
                    {
                        SubstituteMachine1.Attributes["class"] = "active";
                    }

                }

                if (UsersInfo.UserRole == "维修中心管理员")
                {
                    

                    PersonalIinformation.Visible = true;//个人中心-
                    TeacherInformation.Visible = true;//用户管理-维修-
                    Parts.Visible = true;//配件管理-
                    WarehousingDetails.Visible = true;//配件入库管理-
                    RepairManagementWX.Visible = true;//维修管理-维修-

                    if (fileName == "PersonalIinformation")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "InformationEdit")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }

                    if (fileName == "TeacherInformation")
                    {

                        TeacherInformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "TeacherAdd")
                    {
                        
                        TeacherInformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "TeacherEdit")
                    {
                        
                        TeacherInformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "TeacherContent")
                    {
                        
                        TeacherInformation1.Attributes["class"] = "active";
                    }

                    if (fileName == "Parts")
                    {
                        
                        Parts1.Attributes["class"] = "active";
                    }
                    if (fileName == "PartsHistory")
                    {
                        
                        Parts1.Attributes["class"] = "active";
                    }
                    if (fileName == "PartsType")
                    {
                        
                        Parts1.Attributes["class"] = "active";
                    }
                    if (fileName == "PartsWarehousing")
                    {

                        WarehousingDetails1.Attributes["class"] = "active";
                    }

                    if (fileName == "WarehousingDetails")
                    {
                        
                        WarehousingDetails1.Attributes["class"] = "active";
                    }

                    if (fileName == "RepairManagementWX")
                    {
                        RepairManagementWX1.Attributes["class"] = "active";
                    }
                    if (fileName == "RepairDetailedWX")
                    {

                        RepairManagementWX1.Attributes["class"] = "active";
                    }
                    if (fileName == "MaintenanceListWX")
                    {
                        RepairManagementWX1.Attributes["class"] = "active";
                    }
                    if (fileName == "MaintenanceListWX")
                    {

                        RepairManagementWX1.Attributes["class"] = "active";
                    }
                    if (fileName == "RepairManagementWX")
                    {

                        RepairManagementWX1.Attributes["class"] = "active";
                    }
                    
                    
                }

                if (UsersInfo.UserRole == "指导老师")
                {
                    PersonalIinformation.Visible = true;//个人中心
                    RepairListLS.Visible = true;//维修管理-老师
                    StudentInformation.Visible = true;//用户管理-老师

                    if (fileName == "PersonalIinformation")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "InformationEdit")
                    {
                        PersonalIinformation1.Attributes["class"] = "active";
                    }

                    if (fileName == "RepairListLS")
                    {
                        RepairListLS1.Attributes["class"] = "active";
                    }
                    if (fileName == "MaintenanceListLS")
                    {
                        RepairListLS1.Attributes["class"] = "active";
                    }
                    if (fileName == "RepairDetailedLS")
                    {
                        RepairListLS1.Attributes["class"] = "active";
                    }
                    if (fileName == "StudentInformation")
                    {
                        StudentInformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "StudentAdd")
                    {
                        StudentInformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "StudentDetailed")
                    {
                        StudentInformation1.Attributes["class"] = "active";
                    }
                    if (fileName == "StudentEdit")
                    {
                        StudentInformation1.Attributes["class"] = "active";
                    }

                }

                tx.Src = molui.HeadPortrait;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UsersInfo.UserID = "";
            UsersInfo.UserName = "";
            UsersInfo.UserRole = "";
            lbUserName.Text = "";
            Response.Redirect("~/BackLogin.aspx");
        }
    }
}