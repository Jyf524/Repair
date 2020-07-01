using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class PersonalIinformation : System.Web.UI.Page
    {
        Maticsoft.BLL.UsersInfo UsersInfo_Bll = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo UsersInfo_Model = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.UnitsInfo UnitsInfo_Bll = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo UnitsInfo_Model = new Maticsoft.Model.UnitsInfo();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(UsersInfo.UserID))
                {
                    RadButton2.Attributes["onclick"] = "OpenAddPro();return false;";//弹窗
                    Maticsoft.Model.UsersInfo UsersInfo_Model = UsersInfo_Bll.GetModel(UsersInfo.UserID);//引用id所在行的数据
                    imgPic.ImageUrl = UsersInfo_Model.HeadPortrait;//添加数据
                    Label9.Text = UsersInfo_Model.UserName;//添加数据
                    Label10.Text = UsersInfo_Model.UserRealName;//添加数据
                    Label11.Text = UsersInfo_Model.UserSex;//添加数据
                    Label12.Text = UsersInfo_Model.UserPhone;//添加数据
                    Label13.Text = Convert.ToDateTime(UsersInfo_Model.UserBirthday).ToString("yyyy-MM-dd"); ;//添加数据
                    Label16.Text = UsersInfo_Model.UserEmail;//添加数据
                    Label15.Text = UsersInfo_Model.UserProvince + UsersInfo_Model.UserCity + UsersInfo_Model.UserAddress;//添加数据
               
 
           if (UsersInfo.UserRole == "报修单位用户")
            {
                UnitsInfo_Model = UnitsInfo_Bll.GetModel(UsersInfo_Model.UnitID);
                Label7.Text = UnitsInfo_Model.UnitName;
                XB.Visible = false;
                DH.Visible = false;
                CSRQ.Visible = false;
                JTZZ.Visible = false;
                YX.Visible = false;
            }
           if (UsersInfo.UserRole == "指导老师")
           {
               DW.Visible = false;
           }
           if (UsersInfo.UserRole == "系统管理员")
           {
               DW.Visible = false;
           }
           if (UsersInfo.UserRole == "装备中心管理员")
           {
               DW.Visible = false;
           }
           if (UsersInfo.UserRole == "维修中心管理员")
           {
               DW.Visible = false;
           }
                }
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InformationEdit.aspx");//跳转页面
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {

        }

    }
}