using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using NavigationPlatformWeb.util;



namespace RepairCenterY
{
    public partial class BackLogin : System.Web.UI.Page
    {

        Maticsoft.BLL.UsersInfo BllUsers = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo MolUsers = new Maticsoft.Model.UsersInfo();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (signinemail.Value == "")//判断用户名是为空
            {
                FT.Text = "用户名为空";
                return;
            }
            if (signinpassword.Value == "")//判断密码是否为空
            {
                FT.Text = "密码为空";
                return;
            }
            if (Password1.Value == "")//判断验证码是否为空
            {
                FT.Text = "验证码为空";
                return;
            }
            if (BllUsers.GetRecordCount(" UserName='" + signinemail.Value + "' ") == 0)//判断用户名是否存在
            {
                FT.Text = "用户名不存在或错误";
                return;
            }
            if (BllUsers.GetRecordCount(" UserName='" + signinemail.Value + "' and UserPassword='" + signinpassword.Value + "' ") == 0)//判断密码是否正确
            {
                FT.Text = "密码错误";
                return;
            }
            if (Session["CheckCode"].ToString().ToLower() != Password1.Value.ToLower())//判断验证码是否正确
            {
                FT.Text = "验证码错误";
                return;
            }
            DataSet ds = BllUsers.GetList(" UserName='" + signinemail.Value + "' and UserPassword = '" + signinpassword.Value + "' ");
            Maticsoft.Model.UsersInfo molr = BllUsers.GetModel(ds.Tables[0].Rows[0]["UserID"].ToString());
            if (molr.Enabled == "未启用")
            {
                FT.Text = "账号未启用";
                return;
            }
            UsersInfo.UserRole = molr.UserIdentity;
            UsersInfo.UserName = molr.UserName;
            UsersInfo.UserID = molr.UserID;
            if (UsersInfo.UserRole == "学生")
            {
                FT.Text = "学生无法进入该平台";
                return;
            }
            Session["yonghuming"] = signinemail.Value;
            Response.Redirect("~/BackManagement/PersonalIinformation.aspx");
        }
    }
}