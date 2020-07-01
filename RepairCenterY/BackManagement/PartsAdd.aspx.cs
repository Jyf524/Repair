﻿using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class PartsAdd : System.Web.UI.Page
    {
        Maticsoft.BLL.Part bllPart = new Maticsoft.BLL.Part();
        Maticsoft.Model.Part modelPart = new Maticsoft.Model.Part();
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

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);
            
            if (PartName.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("配件名称不能为空!");
                return;
            }
            if (!rxname.IsMatch(PartName.Text.Trim()) && PartName.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("配件名称不能输入特殊字符!");
                return;
            }
            if (bllPart.GetList("  PartName='" + PartName.Text + "'  ").Tables[0].Rows.Count != 0)
            {
                RadAjaxManager1.Alert("该名称已存在!");
                return;
            }
            modelPart.PartID = DateTime.Now.ToString("yyyyMMddHHmmss");
            modelPart.PartTypeID = Session["PartTypeID"].ToString();
            modelPart.PartName = PartName.Text;
            modelPart.PartAddTime = DateTime.Now;
            bllPart.Add(modelPart);
            RadAjaxManager1.Alert("添加成功!");
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");
        }
    }
}