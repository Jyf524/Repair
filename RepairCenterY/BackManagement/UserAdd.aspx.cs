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
    public partial class UserAdd : System.Web.UI.Page
    {
        Maticsoft.Model.UsersInfo mu = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.UsersInfo bu = new Maticsoft.BLL.UsersInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                xingbiehoutai.Visible = false;
                youxianghoutai.Visible = false;
                chushengriqihoutai.Visible = false;
                lianxifangshihoutai.Visible = false;
                jiatingzhuzhihoutai.Visible = false;
                xiangxidizhihoutai.Visible = false;
            }
        }

        //protected void Suoshushi_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        XmlDataSource xds = new XmlDataSource();
        //        xds.DataFile = Server.MapPath("~/pc.xml");
        //        xds.XPath = "//Province[@name1='" + Suoshusheng.SelectedValue + "']/City";
        //        Suoshushi.DataSource = xds;
        //        Suoshushi.DataTextField = "cname";
        //        Suoshushi.DataValueField = "cname";
        //        Suoshushi.SelectedValue = mu.UserCity;
        //        Suoshushi.DataBind();
        //    }
        //}

        protected void Tianjia_Click(object sender, EventArgs e)
        {
                //string sql = "select Max(Convert(int,userid+1)) from usersinfo";//sql语句
            mu.UserID = DateTime.Now.ToString("yyyyMMddHHmmssff");
                //string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";//连接数据库
                //SqlConnection conn = new SqlConnection(constr);//执行连接数据库语句
                //conn.Open();//打开数据库连接
                //string sql = "select username from UsersInfo where username = '" + Yonghuming.Text + "'";//同上
                //SqlCommand cmd = new SqlCommand(sql, conn);//执行sql语句
                //cmd = new SqlCommand(sql, conn);//同上
                //SqlDataReader sr = cmd.ExecuteReader();//同上
                if (Yonghuming.Text == "")//判断同户名是否为空
                {
                    Response.Write("<script>alert('请输入用户名');</script>");//提示语句
                }
                else
                {
                    if (Regex.IsMatch(Yonghuming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//判断是否有特殊字符
                    {
                        if (bu.yonghumingchongfu(Yonghuming.Text))
                        {
                            Response.Write("<script>alert('用户名重复');</script>");//同上
                        }
                        else
                        {
                            mu.UserName = Yonghuming.Text;//将值存入model
                            if (Zhenshixingming.Text == "")//同上
                            {
                                Response.Write("<script>alert('请输入真实姓名');</script>");//同上
                            }
                            else
                            {
                                if (Regex.IsMatch(Zhenshixingming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                                {
                                    mu.UserRealName = Zhenshixingming.Text;//同上
                                    if (xs.Checked)
                                    {
                                        mu.UserIdentity = "学生";
                                        mu.AAA4 = bu.suoshulaoshixingming(suoshulaoshi.SelectedValue);
                                        if (qiyong.Checked)
                                        {//同上
                                            mu.Enabled = "启用";//同上
                                        }
                                        if (weiqiyong.Checked)//同上
                                        {
                                            mu.Enabled = "未启用";//同上
                                        }
                                        mu.UserAddTime = DateTime.Now.ToLocalTime().ToString();//同上
                                        mu.HeadPortrait = "/UpLoad/2019520/2019052016514054.png";//默认头像
                                        bu.Add(mu);//添加
                                        Response.Write("<script>alert('添加成功');window.location.href='UserDetailed.aspx';</script>");//同上
                                    }
                                    else
                                    {
                                        if (Mima.Text == "")//同上
                                        {
                                            Response.Write("<script>alert('请输入密码');</script>");//同上
                                        }
                                        else
                                        {
                                            if (Regex.IsMatch(Mima.Text, @"^[A-Za-z0-9]+$") && Mima.Text.Length >= 6)//同上
                                            {
                                                mu.UserPassword = Mima.Text;//同上
                                                if (querenmima.Text == "")
                                                {
                                                    Response.Write("<script>alert('请输入确认密码');</script>");//同上
                                                }
                                                else
                                                {
                                                    if (Regex.IsMatch(querenmima.Text, @"^[A-Za-z0-9]+$"))//同上
                                                    {
                                                        if (Mima.Text != querenmima.Text)//同上
                                                        {
                                                            Response.Write("<script>alert('确认密码和密码不一致');</script>");//同上
                                                        }
                                                        else
                                                        {
                                                            if (bxdwyh.Checked)
                                                            {
                                                                mu.UserIdentity = "报修单位用户";
                                                            }
                                                            else if (zbzxgly.Checked)
                                                            {
                                                                mu.UserIdentity = "装备中心管理员";
                                                            }
                                                            else if (wxzxgly.Checked)
                                                            {
                                                                mu.UserIdentity = "维修中心管理员";//同上
                                                            }
                                                            else if (zdls.Checked)
                                                            {
                                                                mu.UserIdentity = "指导老师";
                                                            }
                                                            else
                                                            {
                                                                mu.UserIdentity = "学生";
                                                            }
                                                            if (zdls.Checked)
                                                            {
                                                            }
                                                            else
                                                            {
                                                                mu.UnitID = bu.danweiid(Danwei.SelectedValue);//同上
                                                            }
                                                            if (bxdwyh.Checked)
                                                            {
                                                                if (qiyong.Checked)
                                                                {//同上
                                                                    mu.Enabled = "启用";//同上
                                                                }
                                                                if (weiqiyong.Checked)//同上
                                                                {
                                                                    mu.Enabled = "未启用";//同上
                                                                }
                                                                mu.UserAddTime = DateTime.Now.ToLocalTime().ToString();//同上
                                                                mu.HeadPortrait = "/UpLoad/2019520/2019052016514054.png";//默认头像
                                                                bu.Add(mu);//添加
                                                                Response.Write("<script>alert('添加成功');window.location.href='UserDetailed.aspx';</script>");//同上
                                                            }
                                                            else
                                                            {
                                                                if (xingbeinan.Checked)//判断性别男是否选择
                                                                {
                                                                    mu.UserSex = "男";//同上
                                                                }
                                                                if (xingbienv.Checked)//判断性别女是否选择
                                                                {
                                                                    mu.UserSex = "女";//同上
                                                                }
                                                                if (Youxiang.Text == "")//同上
                                                                {
                                                                    Response.Write("<script>alert('请输入邮箱');</script>");//同上
                                                                }
                                                                else
                                                                {
                                                                    if (Regex.IsMatch(Youxiang.Text, @"^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$"))//同上
                                                                    {
                                                                        mu.UserEmail = Youxiang.Text;//同上
                                                                        if (Lianxidianhua.Text == "")//同上
                                                                        {
                                                                            Response.Write("<script>alert('请输入联系电话');</script>");//同上
                                                                        }
                                                                        else
                                                                        {
                                                                            if (Regex.IsMatch(Lianxidianhua.Text, @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$"))//同上
                                                                            {
                                                                                mu.UserPhone = Lianxidianhua.Text;//同上
                                                                                if (Chushengriqi.DbSelectedDate == null)//同上
                                                                                {
                                                                                    Response.Write("<script>alert('请选择出生日期');</script>");//同上
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (Chushengriqi.SelectedDate < DateTime.Now)//判断是否小于当前日期
                                                                                    {
                                                                                        mu.UserBirthday = Chushengriqi.SelectedDate.ToString();//同上
                                                                                        if (Suoshusheng.SelectedValue == "")//同上
                                                                                        {
                                                                                            Response.Write("<script>alert('请选择所属省');</script>");//同上
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            mu.UserProvince = Suoshusheng.SelectedValue;//同上
                                                                                            if (Suoshushi.SelectedValue == "")
                                                                                            {
                                                                                                Response.Write("<script>alert('请选择所属市');</script>");//同上
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                mu.UserCity = Suoshushi.SelectedValue;//同上
                                                                                                if (Xiangxidizhi.Text == "")//同上
                                                                                                {
                                                                                                    Response.Write("<script>alert('请输入详细地址');</script>");//同上
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (Regex.IsMatch(Xiangxidizhi.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                                                                                                    {
                                                                                                        mu.UserAddress = Xiangxidizhi.Text;//同上
                                                                                                        mu.UserAddTime = DateTime.Now.ToLocalTime().ToString();//同上
                                                                                                        if (qiyong.Checked)
                                                                                                        {//同上
                                                                                                            mu.Enabled = "启用";//同上
                                                                                                        }
                                                                                                        if (weiqiyong.Checked)//同上
                                                                                                        {
                                                                                                            mu.Enabled = "未启用";//同上
                                                                                                        }
                                                                                                        mu.HeadPortrait = "/UpLoad/2019520/2019052016514054.png";//默认头像
                                                                                                        bu.Add(mu);//添加
                                                                                                        Response.Write("<script>alert('添加成功');window.location.href='UserDetailed.aspx';</script>");//同上
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        Response.Write("<script>alert('请输入正确的详细地址');</script>");//同上
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Response.Write("<script>alert('请输入正确的出生日期');</script>");//同上
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Response.Write("<script>alert('请输入正确的联系电话');</script>");//同上
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Response.Write("<script>alert('请输入正确的邮箱格式');</script>");//同上
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Response.Write("<script>alert('请输入正确的确认密码');</script>");//同上
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('请输入正确的密码');</script>");//同上
                                            }
                                        }
                                    }
                                }
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
            }

        protected void Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetailed.aspx");//同上
        }

        protected void Suoshusheng_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Suoshushi.Items.Clear();//清空所属市
            Suoshushi.Items.Add(new ListItem("请选择", ""));//添加请选择选项
            Suoshushi.DataTextField = "cname";//所属市赋值
            Suoshushi.DataValueField = "cname";
            XmlDataSource xds = new XmlDataSource();
            xds.DataFile = Server.MapPath("~/pc.xml");//地址
            xds.XPath = "//province[@name='" + Suoshusheng.SelectedValue + "']/city";//地址
            Suoshushi.DataSource = xds;
            Suoshushi.DataTextField = "cname";
            Suoshushi.DataValueField = "cname";
            Suoshushi.DataBind();
            //Suoshushi.SelectedItem.Text = "请选择";
        }

        protected void Suoshusheng_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Suoshusheng.Items.Clear();//所属省清空
                Suoshushi.Items.Clear();//所属市清空
                Suoshusheng.Items.Add(new ListItem("请选择", ""));//同上
                Suoshushi.Items.Add(new ListItem("请选择", ""));//同上
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/pc.xml"));
                Suoshusheng.DataTextField = "name";//同上
                Suoshusheng.DataValueField = "cname";//同上
                foreach (DataRow dr in ds.Tables[0].Rows)//循环添加所属省
                {
                    Suoshusheng.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
                }
            }
            //Suoshusheng.SelectedValue = mu.UserProvince;
            //Suoshusheng.DataBind();
        }

        protected void Danwei_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//判断是否是第一次加载
            {
                Danwei.DataSource = bu.shujukudanweilianjie(); ;//同上
                Danwei.DataTextField = "unitname";
                Danwei.DataBind();//同上
            }
        }

        //protected void Shenfen_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (xs.Checked || zdls.Checked)
        //    {
        //        danweihoutai.Visible = false;
        //        if (xs.Checked)
        //        {
        //            suoshulaoshihoutai.Visible = true;
        //        }
        //        else
        //        {
        //            suoshulaoshihoutai.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        if (xs.Checked)
        //        {
        //            suoshulaoshihoutai.Visible = true;
        //        }
        //        else
        //        {
        //            suoshulaoshihoutai.Visible = false;
        //        }
        //        danweihoutai.Visible = true;
        //        Danwei.DataSource = bu.shujukudanweilianjie();
        //        Danwei.DataTextField = "unitname";
        //        Danwei.DataBind();//同上 
        //    }
        //}

        protected void suoshulaoshi_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                suoshulaoshi.DataSource = bu.shujukulaoshilianjie(); ;//同上
                suoshulaoshi.DataTextField = "username";
                suoshulaoshi.DataBind();//同上
            }
        }

        protected void bxdwyh_CheckedChanged(object sender, EventArgs e)
        {
            if (yingcangzhi.Text=="1")
            {
                yingcangzhi.Text = "0";
            }
            else
            {
                Suoshusheng.SelectedIndex = 0;
                Suoshushi.SelectedIndex = 0;
            }
            if (xs.Checked || zdls.Checked)
            {
                danweihoutai.Visible = false;
                if (xs.Checked)
                {
                    mimahoutai.Visible = false;
                    querenmimahoutai.Visible = false;
                    xingbiehoutai.Visible = false;
                    youxianghoutai.Visible = false;
                    chushengriqihoutai.Visible = false;
                    lianxifangshihoutai.Visible = false;
                    jiatingzhuzhihoutai.Visible = false;
                    xiangxidizhihoutai.Visible = false;
                    suoshulaoshihoutai.Visible = true;
                    suoshulaoshi.DataSource = bu.shujukulaoshilianjie();
                    suoshulaoshi.DataTextField = "username";
                    suoshulaoshi.DataBind();//同上 
                }
                else
                {
                    mimahoutai.Visible = true;
                    querenmimahoutai.Visible = true;
                    xingbiehoutai.Visible = true;
                    youxianghoutai.Visible = true;
                    chushengriqihoutai.Visible = true;
                    lianxifangshihoutai.Visible = true;
                    jiatingzhuzhihoutai.Visible = true;
                    xiangxidizhihoutai.Visible = true;
                    suoshulaoshihoutai.Visible = false;
                }
            }
            else if (bxdwyh.Checked)
            {
                mimahoutai.Visible = true;
                querenmimahoutai.Visible = true;
                danweihoutai.Visible = true;
                suoshulaoshihoutai.Visible = false;
                xingbiehoutai.Visible = false;
                youxianghoutai.Visible = false;
                chushengriqihoutai.Visible = false;
                lianxifangshihoutai.Visible = false;
                jiatingzhuzhihoutai.Visible = false;
                xiangxidizhihoutai.Visible = false;
            }
            else
            {
                if (xs.Checked)
                {
                    suoshulaoshihoutai.Visible = true;
                }
                else
                {
                    suoshulaoshihoutai.Visible = false;
                }
                mimahoutai.Visible = true;
                querenmimahoutai.Visible = true;
                xingbiehoutai.Visible = true;
                youxianghoutai.Visible = true;
                chushengriqihoutai.Visible = true;
                lianxifangshihoutai.Visible = true;
                jiatingzhuzhihoutai.Visible = true;
                xiangxidizhihoutai.Visible = true;
                danweihoutai.Visible = true;
                Danwei.DataSource = bu.shujukudanweilianjie();
                Danwei.DataTextField = "unitname";
                Danwei.DataBind();//同上 
            }
        }
    }
}