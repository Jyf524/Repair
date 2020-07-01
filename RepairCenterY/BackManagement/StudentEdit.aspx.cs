using System;
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
    public partial class StudentEdit : System.Web.UI.Page
    {
        Maticsoft.Model.UsersInfo mu = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.UsersInfo bu = new Maticsoft.BLL.UsersInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//判断是否第一次
            {
                mu=bu.GetModel(Request.QueryString["UserID"]);
                Yonghuming.Text = mu.UserName;//赋值
                Zhenshixingming.Text = mu.UserRealName;//同上
                //if (mu.UserSex == "男")//同上
                //{
                //    xingbienan.Checked = true;
                //}
                //if (mu.UserSex == "女")//同上
                //{
                //    xingbienv.Checked = true;
                //}
                //Youxiang.Text = mu.UserEmail;
                //Lianxidianhua.Text = mu.UserPhone;
                //Chushengriqi.SelectedDate = Convert.ToDateTime(mu.UserBirthday);
                //Xiangxidizhi.Text = mu.UserAddress;
                tianjiashijian.Text = Convert.ToDateTime(mu.UserAddTime).ToShortDateString();
                if (mu.Enabled == "启用")//同上
                {
                    qiyong.Checked = true;
                    weiqiyong.Checked = false;
                }
                else
                {
                    qiyong.Checked = false;
                    weiqiyong.Checked = true;
                }
                //string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";
                //string sql = "select username from UsersInfo where userid = " + Request.QueryString["UserID"];
                //SqlConnection conn = new SqlConnection(constr);
                //conn.Open();
                //SqlCommand cmd = new SqlCommand(sql, conn);
                //Yonghuming.Text = cmd.ExecuteScalar().ToString();
                //sql = "select UserRealName from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //Zhenshixingming.Text = cmd.ExecuteScalar().ToString();
                //sql = "select UserPassword from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //Mima.Attributes.Add("Value", cmd.ExecuteScalar().ToString());
                //sql = "select UserIdentity from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //sql = "select UnitID from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //if (cmd.ExecuteScalar().ToString() == "镇江第一中学")
                //{
                //    Danwei.SelectedIndex = 0;
                //}
                //else if (cmd.ExecuteScalar().ToString() == "镇江第二中学")
                //{
                //    Danwei.SelectedIndex = 1;
                //}
                //else if (cmd.ExecuteScalar().ToString() == "镇江第三中学")
                //{
                //    Danwei.SelectedIndex = 2;
                //}
                //else
                //{
                //    Danwei.SelectedIndex = 3;
                //}
                //sql = "select UserSex from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //if (cmd.ExecuteScalar().ToString() == "男")
                //{
                //    Xingbie.SelectedIndex = 0;
                //}
                //else
                //{
                //    Xingbie.SelectedIndex = 1;
                //}
                //sql = "select UserEmail from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //Youxiang.Text = cmd.ExecuteScalar().ToString();
                //sql = "select UserSex from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //Lianxidianhua.Text = cmd.ExecuteScalar().ToString();
                //sql = "select UserBirthday from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //Chushengriqi.SelectedDate = Convert.ToDateTime(cmd.ExecuteScalar());
                //sql = "select UserProvince from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //if (cmd.ExecuteScalar().ToString() == "江苏省")
                //{
                //    Suoshusheng.SelectedIndex = 0;
                //}
                //else
                //{
                //    Suoshusheng.SelectedIndex = 1;
                //}
                //sql = "select UserCity from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //if (cmd.ExecuteScalar().ToString() == "镇江市")
                //{
                //    Suoshushi.SelectedIndex = 0;
                //}
                //else if (cmd.ExecuteScalar().ToString() == "南京市")
                //{
                //    Suoshushi.SelectedIndex = 1;
                //}
                //else if (cmd.ExecuteScalar().ToString() == "常州市")
                //{
                //    Suoshushi.SelectedIndex = 2;
                //}
                //else if (cmd.ExecuteScalar().ToString() == "福州市")
                //{
                //    Suoshushi.SelectedIndex = 0;
                //}
                //else if (cmd.ExecuteScalar().ToString() == "厦门市")
                //{
                //    Suoshushi.SelectedIndex = 1;
                //}
                //else
                //{
                //    Suoshushi.SelectedIndex = 2;
                //}
                //sql = "select UserAddress from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //Xiangxidizhi.Text = cmd.ExecuteScalar().ToString();
                //sql = "select UserAddTime from UsersInfo where userid = " + Request.QueryString["UserID"];
                //cmd = new SqlCommand(sql, conn);
                //tianjiashijian.Text = cmd.ExecuteScalar().ToString();
                //conn.Close();
            }
        }

        protected void xiugai_Click(object sender, EventArgs e)
        {
            mu = bu.GetModel(Request.QueryString["UserID"]);//同上
            mu.UserID = Request.QueryString["UserID"];//同上
            if (Zhenshixingming.Text == "")
            {
                Response.Write("<script>alert('请输入真实姓名');</script>");//同上
            }
            else
            {
                if (Regex.IsMatch(Zhenshixingming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                {
                    mu.UserRealName = Zhenshixingming.Text;//同上
                    //if (xingbienan.Checked)//同上
                    //    {
                    //        mu.UserSex = "男";
                    //    }
                    //if (xingbienv.Checked)//同上
                    //    {
                    //        mu.UserSex = "女";
                    //    }
                    //if (Youxiang.Text == "")//同上
                    //    {
                    //        Response.Write("<script>alert('请输入邮箱');</script>");//同上
                    //    }
                    //    else
                    //    {
                    //        if (Regex.IsMatch(Youxiang.Text, @"^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$"))//同上
                    //        {
                    //            mu.UserEmail = Youxiang.Text;
                    //            if (Lianxidianhua.Text == "")//同上
                    //            {
                    //                Response.Write("<script>alert('请输入联系电话');</script>");//同上
                    //            }
                    //            else
                    //            {
                    //                if (Regex.IsMatch(Lianxidianhua.Text, @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$"))//同上
                    //                {
                    //                    mu.UserPhone = Lianxidianhua.Text;
                    //                    if (Chushengriqi.DbSelectedDate == null)//同上
                    //                    {
                    //                        Response.Write("<script>alert('请选择出生日期');</script>");//同上
                    //                    }
                    //                    else
                    //                    {
                    //                        if (Chushengriqi.SelectedDate < DateTime.Now)//判断是否小于当前日期
                    //                        {
                    //                            mu.UserBirthday = Chushengriqi.SelectedDate.ToString();//同上
                    //                            if (Suoshusheng.SelectedValue == "")//同上
                    //                            {
                    //                                Response.Write("<script>alert('请选择所属省');</script>");//同上
                    //                            }
                    //                            else
                    //                            {
                    //                                mu.UserProvince = Suoshusheng.SelectedValue;//同上
                    //                                if (Suoshushi.SelectedValue == "")
                    //                                {//同上
                    //                                    Response.Write("<script>alert('请选择所属市');</script>");//同上
                    //                                }
                    //                                else
                    //                                {
                    //                                    mu.UserCity = Suoshushi.SelectedValue;
                    //                                    if (Xiangxidizhi.Text == "")//同上
                    //                                    {
                    //                                        Response.Write("<script>alert('请选择详细地址');</script>");//同上
                    //                                    }
                    //                                    else
                    //                                    {
                    //                                        if (Regex.IsMatch(Xiangxidizhi.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                    //                                        {
                    //                                            mu.UserAddress = Xiangxidizhi.Text;//同上
                                                                if (qiyong.Checked == true)//同上
                                                                {
                                                                    mu.Enabled = "启用";
                                                                }
                                                                if (weiqiyong.Checked == true)//同上
                                                                {
                                                                    mu.Enabled = "未启用";
                                                                }
                                                                mu.UserIdentity = "学生";
                                                                bu.Update(mu);
                                                                Response.Write("<script>alert('修改成功');window.location.href='StudentInformation.aspx'</script>");//提示跳转
                                                            }
                    //                                        else
                    //                                        {
                    //                                            Response.Write("<script>alert('请输入正确的详细地址');</script>");//提示
                    //                                        }
                    //                                    }
                    //                                }
                    //                            }
                    //                        }

                    //                        else
                    //                        {
                    //                            Response.Write("<script>alert('请输入正确的出生日期');</script>");//同上
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    Response.Write("<script>alert('请输入正确的联系电话');</script>");//同上
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Response.Write("<script>alert('请输入正确的邮箱');</script>");//同上
                    //        }
                    //    }
                    //}
                
                else
                {
                    Response.Write("<script>alert('请输入正确的真实姓名');</script>");//同上
                }
            }
            //string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";
            //string sql = "select Max(Convert(int,userid+1)) from usersinfo";
            //SqlConnection conn = new SqlConnection(constr);
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //mu = bu.GetModel(Request.QueryString["UserID"].ToString());
            //mu.UserID = cmd.ExecuteScalar().ToString();
            //mu.UserName = Yonghuming.Text;
            //mu.UserRealName = Zhenshixingming.Text;
            //mu.UserPassword = Mima.Text;
            //mu.UnitID = Danwei.SelectedValue;
            //mu.UserSex = Xingbie.SelectedValue;
            //mu.UserEmail = Youxiang.Text;
            //mu.UserPhone = Lianxidianhua.Text;
            //mu.UserBirthday = Chushengriqi.SelectedDate.ToString();
            //mu.UserProvince = Suoshusheng.SelectedValue;
            //mu.UserCity = Suoshushi.SelectedValue;
            //mu.UserAddress = Xiangxidizhi.Text;
            //mu.UserAddTime = DateTime.Now.ToLocalTime().ToString();
            //bu.Update(mu);
            //Response.Write("<script>alert('修改成功');window.location.href='StudentInformation.aspx'</script>");
        }

        protected void fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentInformation.aspx");//跳转
        }

        //protected void Suoshusheng_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        //Suoshusheng.Items.Clear();
        //        //Suoshushi.Items.Clear();
        //        Suoshusheng.Items.Add(new ListItem("请选择", ""));//所属省添加请选择
        //        Suoshushi.Items.Add(new ListItem("请选择", ""));//所属市添加请选择
        //        DataSet ds = new DataSet();
        //        ds.ReadXml(Server.MapPath("~/pc.xml"));//同上
        //        Suoshusheng.DataTextField = "name";//同上
        //        Suoshusheng.DataValueField = "name";
        //        foreach (DataRow dr in ds.Tables[0].Rows)//循环赋值
        //        {
        //            Suoshusheng.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
        //        }
        //        mu = bu.GetModel(Request.QueryString["UserID"]); 
        //        Suoshusheng.Items.FindByValue(mu.UserProvince).Selected = true;
        //    }
            //if (!IsPostBack)
            //{
            //    DataSet ds = new DataSet();
            //    ds.ReadXml(Server.MapPath("~/new.xml"));
            //    Suoshusheng.DataTextField = "name1";
            //    Suoshusheng.DataValueField = "name1";
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        Suoshusheng.Items.Add(new ListItem(dr["name1"].ToString(), dr["name1"].ToString()));
            //    }
            //}
            //Suoshusheng.SelectedValue = mu.UserProvince;
            //Suoshusheng.DataBind();
        //}

        //protected void Suoshusheng_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Suoshushi.Items.Clear();//同上
        //    Suoshushi.Items.Add(new ListItem("请选择", ""));//同上
        //    Suoshushi.DataTextField = "cname";//同上
        //    Suoshushi.DataValueField = "cname";//同上
        //    XmlDataSource xds = new XmlDataSource();
        //    xds.DataFile = Server.MapPath("~/pc.xml");//同上
        //    xds.XPath = "//province[@name='" + Suoshusheng.SelectedValue + "']/city";
        //    Suoshushi.DataSource = xds;
        //    Suoshushi.DataTextField = "cname";//同上
        //    Suoshushi.DataValueField = "cname";
        //    Suoshushi.DataBind();
            //Suoshushi.Items.Clear();
            //Suoshushi.Items.Add(new ListItem("请选择", ""));
            //Suoshushi.DataTextField = "name2";
            //Suoshushi.DataValueField = "name2";
            //XmlDataSource xds = new XmlDataSource();
            //xds.DataFile = Server.MapPath("~/new.xml");
            //xds.XPath = "//Province[@name1='" + Suoshusheng.SelectedValue + "']/City";
            //Suoshushi.DataSource = xds;
            //Suoshushi.DataTextField = "name2";
            //Suoshushi.DataValueField = "name2";
            //Suoshushi.DataBind();
            //Suoshushi.SelectedValue = "请选择";
        //}

        //protected void Suoshushi_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        Suoshushi.Items.Clear();
        //        Suoshushi.Items.Add(new ListItem("请选择", ""));//同上
        //        Suoshushi.DataTextField = "cname";
        //        Suoshushi.DataValueField = "cname";//同上
        //        XmlDataSource xds = new XmlDataSource();//同上
        //        xds.DataFile = Server.MapPath("~/pc.xml");
        //        xds.XPath = "//province[@name='" + Suoshusheng.SelectedValue + "']/city";//同上
        //        Suoshushi.DataSource = xds;
        //        Suoshushi.DataTextField = "cname";
        //        Suoshushi.DataValueField = "cname";
        //        Suoshushi.DataBind();//同上
        //        mu = bu.GetModel(Request.QueryString["UserID"]);
        //        Suoshushi.Items.FindByValue(mu.UserCity).Selected = true;
        //    }
            //if (!IsPostBack)
            //{
            //    XmlDataSource xds = new XmlDataSource();
            //    xds.DataFile = Server.MapPath("~/new.xml");
            //    xds.XPath = "//Province[@name1='" + Suoshusheng.SelectedValue + "']/City";
            //    Suoshushi.DataSource = xds;
            //    Suoshushi.DataTextField = "name2";
            //    Suoshushi.DataValueField = "name2";
            //    Suoshushi.SelectedValue = mu.UserCity;
            //    Suoshushi.DataBind();
            //}
        //}

    }
}