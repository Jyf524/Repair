﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using Telerik.Web.UI;

namespace RepairCenterY.BackManagement
{
    public partial class UnitUser : System.Web.UI.Page
    {
        Maticsoft.Model.UsersInfo mu = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.UsersInfo bu = new Maticsoft.BLL.UsersInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            mu = bu.GetModel(Request.QueryString["UserID"]);
            yonghuming.Text = mu.UserName;
            zhenshixingming.Text = mu.UserRealName;
            danwei.Text = bu.danweimingcheng(Request.QueryString["UserID"]).ToString();
            xingbie.Text = mu.UserSex;
            youxiang.Text = mu.UserEmail;
            shengri.Text = Convert.ToDateTime(mu.UserBirthday).ToShortDateString();
            lianxifangshi.Text = mu.UserPhone;
            xiangxidizhi.Text = mu.UserProvince + " " + mu.UserCity + " " + mu.UserAddress;
            zhanghaozhuangtai.Text = mu.Enabled;
            tianjiashijian.Text = Convert.ToDateTime(mu.UserAddTime).ToShortDateString();
            //string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";//数据库连接语句
            //SqlConnection conn = new SqlConnection(constr);//执行数据库连接语句
            //conn.Open();//打开数据库连接
            //string sql = "select username from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";//sql语句
            //SqlCommand cmd = new SqlCommand(sql, conn);//执行sql语句
            //yonghuming.Text = cmd.ExecuteScalar().ToString();//用户名赋值                   以下重复不做注释
            //sql = "select userrealname from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql,conn);
            //zhenshixingming.Text = cmd.ExecuteScalar().ToString();
            //sql = "select unitname from UsersInfo,unitsinfo where UserID = '" + Request.QueryString["UserID"] + "' and usersinfo.unitid=unitsinfo.unitid";
            //cmd = new SqlCommand(sql, conn);
            //danwei.Text = cmd.ExecuteScalar().ToString();
            //sql = "select usersex from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //xingbie.Text = cmd.ExecuteScalar().ToString();
            //sql = "select useremail from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //youxiang.Text = cmd.ExecuteScalar().ToString();
            //sql = "select LEFT(userbirthday,CHARINDEX(' ',userbirthday)-1) as userbirthday from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //shengri.Text = cmd.ExecuteScalar().ToString();
            //sql = "select userphone from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //lianxifangshi.Text = cmd.ExecuteScalar().ToString();
            //sql = "select useraddress from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //string a = cmd.ExecuteScalar().ToString();
            //sql = "select userprovince from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //string b = cmd.ExecuteScalar().ToString();
            //sql = "select usercity from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql,conn);
            //string c = cmd.ExecuteScalar().ToString();
            //xiangxidizhi.Text = b + " " + c + " " + a;
            //sql = "select enabled from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //zhanghaozhuangtai.Text = cmd.ExecuteScalar().ToString();
            //sql = "select LEFT(useraddtime,CHARINDEX(' ',useraddtime)-1) as useraddtime from UsersInfo where UserID = '" + Request.QueryString["UserID"] + "'";
            //cmd = new SqlCommand(sql, conn);
            //tianjiashijian.Text = cmd.ExecuteScalar().ToString();
        }

        protected void fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("./UserDetailed.aspx");//跳转
        }
    }
}