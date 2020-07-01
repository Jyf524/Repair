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

    public partial class PartsTypeAdd : System.Web.UI.Page
    {
        Maticsoft.BLL.PartType bllPartType = new Maticsoft.BLL.PartType();
        Maticsoft.Model.PartType modelPartType = new Maticsoft.Model.PartType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsersInfo.UserID == "" || UsersInfo.UserRole != "维修中心管理员")
            {
                UsersInfo.UserID = "";
                UsersInfo.UserName = "";
                UsersInfo.UserRole = "";
                Response.Redirect("~/BackLogin.aspx");
                return;
            }
            btnback.Attributes["onclick"] = "GetClose();return false;";
        }
        //添加
        protected void btnadd_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);
            if (PartTypeName.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("配件类别名称不能为空!");
                return;
            }
            if (!rxname.IsMatch(PartTypeName.Text.Trim()) && PartTypeName.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("类别名称不能输入特殊字符!");
                return;
            }
            if (bllPartType.GetList("  PartTypeName='" + PartTypeName.Text + "'  ").Tables[0].Rows.Count != 0)
            {
                RadAjaxManager1.Alert("该类别名称已存在!");
                return;
            }
            modelPartType.PartTypeID = DateTime.Now.ToString("yyyyMMddHHmmss");
            modelPartType.PartTypeName = PartTypeName.Text;
            modelPartType.PartTypeAddTime = DateTime.Now;
            bllPartType.Add(modelPartType);
            RadAjaxManager1.Alert("添加成功!");
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");
        }


    }
}