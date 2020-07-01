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
    public partial class StudentAdd : System.Web.UI.Page
    {
        Maticsoft.Model.UsersInfo mu = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.UsersInfo bu = new Maticsoft.BLL.UsersInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Tianjia_Click(object sender, EventArgs e)
        {
            mu.UserID = DateTime.Now.ToString("yyyyMMddHHmmssff");//赋值
            if (Yonghuming.Text == "")
            {
                Response.Write("<script>alert('请输入用户名');</script>");//同上
            }
            else
            {
                if (Regex.IsMatch(Yonghuming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//判断是否有特殊字符
                {
                    if (bu.yonghumingchongfu(Yonghuming.Text))
                    {
                        Response.Write("<script>alert('用户名重复');</script>");//提示
                    }
                    else
                    {
                        mu.UserName = Yonghuming.Text;
                        if (Zhenshixingming.Text == "")
                        {
                            Response.Write("<script>alert('请输入真实姓名');</script>");//同上
                        }
                        else
                        {
                            if (Regex.IsMatch(Zhenshixingming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                            {
                                mu.UserRealName = Zhenshixingming.Text;
                                //if (Mima.Text == "")
                                //{
                                //    Response.Write("<script>alert('请输入密码');</script>");//同上
                                //}
                                //else
                                //{
                                //    if (Regex.IsMatch(Mima.Text, @"^[A-Za-z0-9]+$") && Mima.Text.Length >= 6)//同上
                                //    {
                                //        mu.UserPassword = Mima.Text;
                                //        if (querenmima.Text == "")
                                //        {
                                //            Response.Write("<script>alert('请输入确认密码');</script>");//同上
                                //        }
                                //        else
                                //        {
                                //            if (Regex.IsMatch(querenmima.Text, @"^[A-Za-z0-9]+$"))//同上
                                //            {
                                //                if (Mima.Text != querenmima.Text)
                                //                {
                                //                    Response.Write("<script>alert('确认密码和密码不一致');</script>");//同上
                                //                }
                                //                else
                                //                {
                                //                    if (xingbeinan.Checked)//同上
                                //                    {
                                //                        mu.UserSex = "男";
                                //                    }
                                //                    if (xingbienv.Checked)
                                //                    {
                                //                        mu.UserSex = "女";
                                //                    }
                                //                    if (Youxiang.Text == "")
                                //                    {
                                //                        Response.Write("<script>alert('请输入邮箱');</script>");//同上
                                //                    }
                                //                    else
                                //                    {
                                //                        if (Regex.IsMatch(Youxiang.Text, @"^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$"))//同上
                                //                        {
                                //                            mu.UserEmail = Youxiang.Text;
                                //                            if (Lianxidianhua.Text == "")
                                //                            {
                                //                                Response.Write("<script>alert('请输入联系电话');</script>");//同上
                                //                            }
                                //                            else
                                //                            {
                                //                                if (Regex.IsMatch(Lianxidianhua.Text, @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$"))//同上
                                //                                {
                                //                                    mu.UserPhone = Lianxidianhua.Text;
                                //                                    if (Chushengriqi.DbSelectedDate == null)//同上
                                //                                    {
                                //                                        Response.Write("<script>alert('请选择出生日期');</script>");//同上
                                //                                    }
                                //                                    else
                                //                                    {
                                //                                        if (Chushengriqi.SelectedDate < DateTime.Now)//判断是否小于当前日期
                                //                                        {
                                //                                            mu.UserBirthday = Chushengriqi.SelectedDate.ToString();//同上
                                //                                            if (Suoshusheng.SelectedValue == "")//同上
                                //                                            {
                                //                                                Response.Write("<script>alert('请选择所属省');</script>");//同上
                                //                                            }
                                //                                            else
                                //                                            {
                                //                                                mu.UserProvince = Suoshusheng.SelectedValue;//同上
                                //                                                if (Suoshushi.SelectedValue == "")//同上
                                //                                                {
                                //                                                    Response.Write("<script>alert('请选择所属市');</script>");//同上
                                //                                                }
                                //                                                else
                                //                                                {
                                //                                                    mu.UserCity = Suoshushi.SelectedValue;//同上
                                //                                                    if (Xiangxidizhi.Text == "")//同上
                                //                                                    {
                                //                                                        Response.Write("<script>alert('请输入详细地址');</script>");//同上
                                //                                                    }
                                //                                                    else
                                //                                                    {
                                //                                                        if (Regex.IsMatch(Xiangxidizhi.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                                //                                                        {
                                //                                                            mu.UserAddress = Xiangxidizhi.Text;//同上
                                                                                            mu.UserAddTime = DateTime.Now.ToLocalTime().ToString();//同上
                                                                                            if (qiyong.Checked)//同上
                                                                                            {
                                                                                                mu.Enabled = "启用";
                                                                                            }
                                                                                            if (weiqiyong.Checked)
                                                                                            {
                                                                                                mu.Enabled = "未启用";
                                                                                            }
                                                                                            mu.HeadPortrait = "/UpLoad/2019520/2019052016514054.png";//同上
                                                                                            mu.UserIdentity = "学生";
                                                                                            mu.AAA4=bu.suoshulaoshixingming(Session["yonghuming"].ToString());
                                                                                            bu.Add(mu);//添加
                                                                                            Response.Write("<script>alert('添加成功');window.location.href='StudentInformation.aspx';</script>");//提示跳转
                                                                                        }
                            //                                                            else
                            //                                                            {
                            //                                                                Response.Write("<script>alert('请输入正确的详细地址');</script>");//提示
                            //                                                            }
                            //                                                        }
                            //                                                    }
                            //                                                }
                            //                                            }

                            //                                            else
                            //                                            {
                            //                                                Response.Write("<script>alert('请输入正确的出生日期');</script>");//同上
                            //                                            }
                            //                                        }
                            //                                    }
                            //                                    else
                            //                                    {
                            //                                        Response.Write("<script>alert('请输入正确的联系电话');</script>");//同上
                            //                                    }
                            //                                }
                            //                            }
                            //                            else
                            //                            {
                            //                                Response.Write("<script>alert('请输入正确的邮箱');</script>");//同上
                            //                            }
                            //                        }
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    Response.Write("<script>alert('请输入正确的确认密码');</script>");//同上
                            //                }
                            //            }
                            //        }
                            //        else
                            //        {
                            //            Response.Write("<script>alert('请输入正确的密码');</script>");//同上
                            //        }
                            //    }
                            //}
                            else
                            {
                                Response.Write("<script>alert('请输入正确的真实姓名');</script>");//同上
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('请输入正确的用户名');</script>");//同上
                }
            }
            //string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";
            //string sql = "select Max(Convert(int,userid+1)) from usersinfo";
            //SqlConnection conn = new SqlConnection(constr);
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //mu.UserID = cmd.ExecuteScalar().ToString();
            //mu.UserName = Yonghuming.Text;
            //mu.UserRealName = Zhenshixingming.Text;
            //mu.UserPassword = Mima.Text;
            //mu.UserIdentity = "学生";
            //mu.UnitID = Danwei.SelectedValue;
            //mu.UserSex = Xingbie.SelectedValue;
            //mu.UserEmail = Youxiang.Text;
            //mu.UserPhone = Lianxidianhua.Text;
            //mu.UserBirthday = Chushengriqi.SelectedDate.ToString();
            //mu.UserProvince = Suoshusheng.SelectedValue;
            //mu.UserCity = Suoshushi.SelectedValue;
            //mu.UserAddress = Xiangxidizhi.Text;
            //mu.UserAddTime = DateTime.Now.ToLocalTime().ToString();
            //bu.Add(mu);
            //Response.Write("<script>alert('添加成功');window.location.href='StudentInformation.aspx';</script>");
        }



        //protected void Suoshusheng_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        Suoshusheng.Items.Clear();//清空所属省
        //        Suoshushi.Items.Clear();//清空所属市
        //        Suoshusheng.Items.Add(new ListItem("请选择", ""));//添加请选择
        //        Suoshushi.Items.Add(new ListItem("请选择", ""));//添加请选择
        //        DataSet ds = new DataSet();
        //        ds.ReadXml(Server.MapPath("~/pc.xml"));//地址
        //        Suoshusheng.DataTextField = "name";//id
        //        Suoshusheng.DataValueField = "cname";
        //        foreach (DataRow dr in ds.Tables[0].Rows)//循环赋值
        //        {
        //            Suoshusheng.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
        //        }
        //    }
            //if (!IsPostBack)
            //{
            //    Suoshusheng.Items.Clear();
            //    Suoshushi.Items.Clear();
            //    Suoshusheng.Items.Add(new ListItem("请选择", ""));
            //    Suoshushi.Items.Add(new ListItem("请选择", ""));
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
        //    Suoshushi.Items.Clear();
        //    Suoshushi.Items.Add(new ListItem("请选择", ""));//同上
        //    Suoshushi.DataTextField = "cname";//同上
        //    Suoshushi.DataValueField = "cname";
        //    XmlDataSource xds = new XmlDataSource();
        //    xds.DataFile = Server.MapPath("~/pc.xml");//同上
        //    xds.XPath = "//province[@name='" + Suoshusheng.SelectedValue + "']/city";//同上
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

        protected void fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentInformation.aspx");//跳转
        }
    }
}