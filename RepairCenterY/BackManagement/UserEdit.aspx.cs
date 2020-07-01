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
    public partial class UserEdit : System.Web.UI.Page
    {
        Maticsoft.Model.UsersInfo mu = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.UsersInfo bu = new Maticsoft.BLL.UsersInfo();
        //string a;
        //string b;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//判断是否第一次
            {
                //string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";//连接数据库语句
                //string sql = "select username from UsersInfo where userid = " + Request.QueryString["UserID"];//sql语句
                //SqlConnection conn = new SqlConnection(constr);//执行连接数据库语句
                //conn.Open();//打开数据库连接
                //SqlCommand cmd = new SqlCommand(sql, conn);//执行sql语句
                mu = bu.GetModel(Request.QueryString["UserID"]);
                Yonghuming.Text = mu.UserName;//用户名赋值
                Zhenshixingming.Text = mu.UserRealName;
                if (mu.UserIdentity == "报修单位用户")//判断身份
                {
                    xingbiehoutai.Visible = false;
                    youxianghoutai.Visible = false;
                    chushengriqihoutai.Visible = false;
                    lianxifangshihoutai.Visible = false;
                    jiatingzhuzhihoutai.Visible = false;
                    xiangxidizhihoutai.Visible = false;
                    bxdwyh.Checked=true; //选项
                }
                else if (mu.UserIdentity == "装备中心管理员")
                {
                    mu = bu.GetModel(Request.QueryString["UserID"]);
                    if (mu.UserSex == "男")
                    {
                        xingbienan.Checked = true;
                    }
                    else
                    {
                        xingbienv.Checked = true;
                    }
                    Youxiang.Text = mu.UserEmail;
                    Chushengriqi.SelectedDate = Convert.ToDateTime(mu.UserBirthday);
                    Lianxidianhua.Text = mu.UserPhone;
                    Xiangxidizhi.Text = mu.UserAddress;
                    jiatingzhuzhihoutai.Visible = true;
                    zbzxgly.Checked=true;
                }
                else if (mu.UserIdentity == "维修中心管理员")
                {
                    mu = bu.GetModel(Request.QueryString["UserID"]);
                    if (mu.UserSex == "男")
                    {
                        xingbienan.Checked = true;
                    }
                    else
                    {
                        xingbienv.Checked = true;
                    }
                    Youxiang.Text = mu.UserEmail;
                    Chushengriqi.SelectedDate = Convert.ToDateTime(mu.UserBirthday);
                    Lianxidianhua.Text = mu.UserPhone;
                    Xiangxidizhi.Text = mu.UserAddress;
                    jiatingzhuzhihoutai.Visible = true;
                    wxzxgly.Checked=true;
                }
                else if (mu.UserIdentity == "指导老师")
                {
                    mu = bu.GetModel(Request.QueryString["UserID"]);
                    if (mu.UserSex == "男")
                    {
                        xingbienan.Checked = true;
                    }
                    else
                    {
                        xingbienv.Checked = true;
                    }
                    Youxiang.Text = mu.UserEmail;
                    Chushengriqi.SelectedDate = Convert.ToDateTime(mu.UserBirthday);
                    Lianxidianhua.Text = mu.UserPhone;
                    Xiangxidizhi.Text = mu.UserAddress;
                    danweihoutai.Visible = false;
                    zdls.Checked=true;
                }
                else
                {
                    danweihoutai.Visible = false;
                    suoshulaoshihoutai.Visible = true;
                    xingbiehoutai.Visible = false;
                    youxianghoutai.Visible = false;
                    chushengriqihoutai.Visible = false;
                    lianxifangshihoutai.Visible = false;
                    jiatingzhuzhihoutai.Visible = false;
                    xiangxidizhihoutai.Visible = false;
                    mu = bu.GetModel(Request.QueryString["UserID"]);
                    suoshulaoshi.SelectedValue = bu.suoshulaoshiid(mu.AAA4);
                    xs.Checked=true;
                }
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
                //Chushengriqi.SelectedDate = Convert.ToDateTime(mu.UserBirthday);//同上
                //Suoshushi.Items.FindByValue(cmd.ExecuteScalar().ToString()).Selected = true;
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
                //////}
                ////Xiangxidizhi.Text = mu.UserAddress;//同上
                tianjiashijian.Text = Convert.ToDateTime(mu.UserAddTime).ToShortDateString();//同上
                if (mu.Enabled == "启用")//同上
                {
                    qiyong.Checked = true;
                    weiqiyong.Checked = false;//同上
                }
                else
                {
                    qiyong.Checked = false;//同上
                    weiqiyong.Checked = true;
                }
                if (zbzxgly.Checked || wxzxgly.Checked || zdls.Checked)
                {
                    yingcangzhi.Text = "0";
                }
            }
        }

        protected void Suoshusheng_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    //Suoshusheng.Items.Clear();
                    //Suoshushi.Items.Clear();
                    Suoshusheng.Items.Add(new ListItem("请选择", ""));//添加请选择
                    Suoshushi.Items.Add(new ListItem("请选择", ""));
                    //string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";//同上
                    //string sql = "select username from UsersInfo where userid = " + Request.QueryString["UserID"];//同上
                    //SqlConnection conn = new SqlConnection(constr);
                    //conn.Open();//同上
                    //SqlCommand cmd = new SqlCommand(sql, conn);//同上
                    //sql = "select UserProvince from UsersInfo where userid = " + Request.QueryString["UserID"];//同上
                    //cmd = new SqlCommand(sql, conn);
                    DataSet ds = new DataSet();//同上
                    ds.ReadXml(Server.MapPath("~/pc.xml"));//地址pc.xml
                    Suoshusheng.DataTextField = "name";//id
                    Suoshusheng.DataValueField = "name";
                    foreach (DataRow dr in ds.Tables[0].Rows)//循环赋值
                    {
                        Suoshusheng.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
                    }
                    mu = bu.GetModel(Request.QueryString["UserID"]);
                    Suoshusheng.Items.FindByValue(mu.UserProvince).Selected = true;
            }
        }

        protected void xiugai_Click(object sender, EventArgs e)
        {
            mu = bu.GetModel(Request.QueryString["UserID"]);
            mu.UserID = Request.QueryString["UserID"];
            if (Yonghuming.Text == "")//判断同户名是否为空
            {
                Response.Write("<script>alert('请输入用户名');</script>");//提示语句
            }
            else
            {
                if (Regex.IsMatch(Yonghuming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//判断是否有特殊字符
                {
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
                                    bu.Update(mu);//添加
                                    Response.Write("<script>alert('修改成功');window.location.href='UserDetailed.aspx';</script>");//同上
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
                                        bu.Update(mu);//添加
                                        Response.Write("<script>alert('修改成功');window.location.href='UserDetailed.aspx';</script>");//同上
                                    }
                                    else
                                    {
                                        if (xingbienan.Checked)//判断性别男是否选择
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
                                                                                if (qiyong.Checked)
                                                                                {//同上
                                                                                    mu.Enabled = "启用";//同上
                                                                                }
                                                                                if (weiqiyong.Checked)//同上
                                                                                {
                                                                                    mu.Enabled = "未启用";//同上
                                                                                }
                                                                                bu.Update(mu);//添加
                                                                                Response.Write("<script>alert('修改成功');window.location.href='UserDetailed.aspx';</script>");//同上
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
                                Response.Write("<script>alert('请输入正确的真实姓名');</script>");//同上
                            }
                        }
                    }
                
                else
                {
                    Response.Write("<script>alert('请输入正确的用户名');</script>");//同上
                }
            }
            ////string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";//同上
            ////string sql = "select Max(Convert(int,userid+1)) from usersinfo";//同上
            ////SqlConnection conn = new SqlConnection(constr);
            ////conn.Open();
            ////SqlCommand cmd = new SqlCommand(sql, conn);//同上
            //mu = bu.GetModel(Request.QueryString["UserID"]);//同上
            //mu.UserID = Request.QueryString["UserID"];//同上
            ////sql = "select username from UsersInfo where username = '" + Yonghuming.Text + "'";//同上
            ////cmd = new SqlCommand(sql, conn);
            ////SqlDataReader sr = cmd.ExecuteReader();//同上
            ////if (Yonghuming.Text == "")
            ////{
            ////    Response.Write("<script>alert('用户名不能为空');</script>");
            ////}
            ////else
            ////{
            ////    if (Regex.IsMatch(Yonghuming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))
            ////    {
            ////        if (sr.Read())
            ////        {
            ////            conn.Close();
            ////            string sql1 = "select username from UsersInfo where userid = " + Request.QueryString["UserID"];
            ////            SqlConnection conn1 = new SqlConnection(constr);
            ////            conn.Open();
            ////            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            ////            a = cmd1.ExecuteScalar().ToString();
            ////            b = "0";
            ////        }
            ////        if (a != Yonghuming.Text && b == "0")
            ////        {
            ////            Response.Write("<script>alert('用户名重复');</script>");
            ////        }
            ////        else
            ////        {
            ////            mu.UserName = Yonghuming.Text;
            //            if (Zhenshixingming.Text == "")
            //            {
            //                Response.Write("<script>alert('请输入真实姓名');</script>");//同上
            //            }
            //            else
            //            {
            //                if (Regex.IsMatch(Zhenshixingming.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
            //                {
            //                    mu.UserRealName = Zhenshixingming.Text;
            //                    if (bxdwyh.Checked)
            //                    {
            //                        mu.UserIdentity = "报修单位用户";
            //                    }
            //                    else if (zbzxgly.Checked)
            //                    {
            //                        mu.UserIdentity = "装备中心管理员";
            //                    }
            //                    else if (wxzxgly.Checked)
            //                    {
            //                        mu.UserIdentity = "维修中心管理员";
            //                    }
            //                    else if (zdls.Checked)
            //                    {
            //                        mu.UserIdentity = "指导老师";
            //                    }
            //                    else
            //                    {
            //                        mu.UserIdentity = "学生";
            //                    }
            //                    //mu.UserIdentity = Shenfen.SelectedValue;//同上
            //                        //conn.Close();
            //                        //conn.Open();
            //                        //sql = "select unitid from unitsinfo where unitname = '" + Danwei.SelectedValue + "'";//同上
            //                        //cmd = new SqlCommand(sql, conn);
            //                    if (xs.Checked || zdls.Checked)
            //                    {
            //                        mu.UnitID = "";
            //                    }
            //                    else
            //                    {
            //                        mu.UnitID = bu.danweiid(Danwei.SelectedValue);
            //                    }
            //                        //if (xingbienan.Checked)
            //                        //{//同上
            //                        //    mu.UserSex = "男";
            //                        //}
            //                        //if (xingbienv.Checked)//同上
            //                        //{
            //                        //    mu.UserSex = "女";
            //                        //}//同上
            //                        //if (Youxiang.Text == "")
            //                        //{
            //                        //    Response.Write("<script>alert('请输入邮箱');</script>");//同上
            //                        //}
            //                        //else
            //                        //{
            //                        //    if (Regex.IsMatch(Youxiang.Text, @"^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$"))//同上
            //                        //    {
            //                        //        mu.UserEmail = Youxiang.Text;
            //                        //        if (Lianxidianhua.Text == "")
            //                        //        {//同上
            //                        //            Response.Write("<script>alert('请输入联系电话');</script>");//同上
            //                        //        }
            //                        //        else
            //                        //        {
            //                        //            if (Regex.IsMatch(Lianxidianhua.Text, @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$"))//同上
            //                        //            {
            //                        //                mu.UserPhone = Lianxidianhua.Text;
            //                        //                if (Chushengriqi.DbSelectedDate == null)//同上
            //                        //                {
            //                        //                    Response.Write("<script>alert('请选择出生日期');</script>");//同上
            //                        //                }
            //                        //                else
            //                        //                {
            //                        //                    if (Chushengriqi.SelectedDate < DateTime.Now)//判断是否小于当前日期
            //                        //                    {
            //                        //                            mu.UserBirthday = Chushengriqi.SelectedDate.ToString();//同上
            //                        //                            if (Suoshusheng.SelectedValue == "")
            //                        //                            {
            //                        //                                Response.Write("<script>alert('请选择所属省');</script>");//同上
            //                        //                            }
            //                        //                            else
            //                        //                            {
            //                        //                                mu.UserProvince = Suoshusheng.SelectedValue;
            //                        //                                if (Suoshushi.SelectedValue == "")
            //                        //                                {
            //                        //                                    Response.Write("<script>alert('请选择所属市');</script>");//同上
            //                        //                                }
            //                        //                                else
            //                        //                                {
            //                        //                                    mu.UserCity = Suoshushi.SelectedValue;
            //                        //                                    if (Xiangxidizhi.Text == "")
            //                        //                                    {
            //                        //                                        Response.Write("<script>alert('请输入详细地址');</script>");//同上
            //                        //                                    }
            //                        //                                    else
            //                        //                                    {
            //                        //                                        if (Regex.IsMatch(Xiangxidizhi.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
            //                        //                                        {
            //                        //                                            mu.UserAddress = Xiangxidizhi.Text;//同上
            //                                                                    if (qiyong.Checked == true)//同上
            //                                                                    {
            //                                                                        mu.Enabled = "启用";
            //                                                                    }
            //                                                                    if (weiqiyong.Checked == true)//同上
            //                                                                    {
            //                                                                        mu.Enabled = "未启用";
            //                                                                    }
            //                                                                    if (xs.Checked)
            //                                                                    {
            //                                                                        mu.AAA4 = bu.suoshulaoshixingming(suoshulaoshi.SelectedValue);
            //                                                                    }
            //                                                                    else
            //                                                                    {
            //                                                                        mu.AAA4 = "";
            //                                                                    }
            //                                                                    bu.Update(mu);
            //                                                                    Response.Write("<script>alert('修改成功');window.location.href='UserDetailed.aspx'</script>");//同上
            //                                                                }
            //                                                            //    else
            //                                                            //    {
            //                                                            //        Response.Write("<script>alert('请输入详细地址');</script>");//同上
            //                                                            //    }
            //                                                            //}
            //                                                        //}
            //                                                //    }
            //                                                //}
                                                        
            //                            //                else
            //                            //                {
            //                            //                    Response.Write("<script>alert('请输入正确的出生日期');</script>");//同上
            //                            //                }
            //                            //            }
            //                            //        }
            //                            //        else
            //                            //        {
            //                            //            Response.Write("<script>alert('请输入正确的联系电话');</script>");//同上
            //                            //        }
            //                            //    }
            //                            //}
            //                            //else
            //                            //{
            //                            //    Response.Write("<script>alert('请输入正确的邮箱格式');</script>");//同上
            //                            //}
            //                    //    }
            //                    //}
                            
            //                else
            //                {
            //                    Response.Write("<script>alert('请输入正确的真实姓名');</script>");//同上
            //                }
            //            }
                    //}
                //}
            //    else
            //    {
            //        Response.Write("<script>alert('用户名格式错误');</script>");
            //    }
            //queding.Attributes["onclick"] = "alert('修改成功');window.location.href=;'TeacherInformation.aspx'";
            //}
        }
        protected void suoshulaoshi_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                suoshulaoshi.DataSource = bu.shujukulaoshilianjie(); ;//同上
                suoshulaoshi.DataTextField = "username";
                suoshulaoshi.DataBind();//同上
            }
        }
        protected void Suoshusheng_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Suoshushi.Items.Clear();//同上
            Suoshushi.Items.Add(new ListItem("请选择", ""));//同上
            Suoshushi.DataTextField = "cname";
            Suoshushi.DataValueField = "cname";//同上
            XmlDataSource xds = new XmlDataSource();
            xds.DataFile = Server.MapPath("~/pc.xml");//同上
            xds.XPath = "//province[@name='" + Suoshusheng.SelectedValue + "']/city";//同上
            Suoshushi.DataSource = xds;
            Suoshushi.DataTextField = "cname";//同上
            Suoshushi.DataValueField = "cname";//同上
            Suoshushi.DataBind();
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
        }

        protected void fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetailed.aspx");//跳转
        }

        protected void Suoshushi_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    Suoshushi.Items.Clear();
                    Suoshushi.Items.Add(new ListItem("请选择", ""));//同上
                    Suoshushi.DataTextField = "cname";//同上
                    Suoshushi.DataValueField = "cname";//同上
                    XmlDataSource xds = new XmlDataSource();//同上
                    xds.DataFile = Server.MapPath("~/pc.xml");
                    xds.XPath = "//province[@name='" + Suoshusheng.SelectedValue + "']/city";//同上
                    Suoshushi.DataSource = xds;
                    Suoshushi.DataTextField = "cname";
                    Suoshushi.DataValueField = "cname";
                    Suoshushi.DataBind();
                    mu = bu.GetModel(Request.QueryString["UserID"]);
                    Suoshushi.Items.FindByValue(mu.UserCity).Selected = true;//同上
            }
        }

        protected void Danwei_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (zdls.Checked || xs.Checked)
                { danweihoutai.Visible = false; }
                else
                {
                    if (bu.danweimingchengpanduan(Request.QueryString["UserID"]) == "学生" || bu.danweimingchengpanduan(Request.QueryString["UserID"]) == "指导老师")
                    {
                        danweihoutai.Visible = false;
                    }
                    else
                    {
                        Danwei.DataSource = bu.shujukudanweilianjie();
                        Danwei.DataTextField = "unitname";
                        Danwei.SelectedValue = bu.danweimingcheng(Request.QueryString["UserID"]);
                        Danwei.DataBind();//同上
                    }
                }
            }
        }

        ////protected void Shenfen_SelectedIndexChanged1(object sender, EventArgs e)
        ////{
        ////    if (xs.Checked || zdls.Checked)
        ////    {
        ////        danweihoutai.Visible = false;
        ////        if (xs.Checked)
        ////        {
        ////            suoshulaoshihoutai.Visible = true;
        ////            suoshulaoshi.DataSource = bu.shujukulaoshilianjie();
        ////            suoshulaoshi.DataTextField = "username";
        ////            suoshulaoshi.DataBind();//同上 
        ////        }
        ////        else
        ////        {
        ////            suoshulaoshihoutai.Visible = false;
        ////        }
        ////    }
        ////    else
        ////    {
        ////        if (xs.Checked)
        ////        {
        ////            suoshulaoshihoutai.Visible = true;
        ////        }
        ////        else
        ////        {
        ////            suoshulaoshihoutai.Visible = false;
        ////        }
        ////        danweihoutai.Visible = true;
        ////        Danwei.DataSource = bu.shujukudanweilianjie();
        ////        Danwei.DataTextField = "unitname";
        ////        Danwei.DataBind();//同上 
        ////    }
        ////}

        //protected void suoshulaoshi_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (mu.UserIdentity == "学生")
        //        {
        //            suoshulaoshihoutai.Visible = true;
        //            mu = bu.GetModel(Request.QueryString["UserID"]);
        //            suoshulaoshihoutai.Visible = true;
        //            suoshulaoshi.DataSource = bu.shujukulaoshilianjie();
        //            suoshulaoshi.DataTextField = "username";
        //            suoshulaoshi.SelectedValue = bu.suoshulaoshiid(mu.AAA4);
        //            suoshulaoshi.DataBind();//同上 
        //        }
        //    }
        //}

        protected void zbzxgly_CheckedChanged(object sender, EventArgs e)
        {
            if (yingcangzhi.Text == "1")
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


        //protected void Suoshushi_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (bxdwyh.Checked || xs.Checked)
        //        { }
        //        else
        //        {
        //            //Suoshusheng.Items.Clear();
        //            //Suoshushi.Items.Clear();
        //            string constr = "Data Source=172.16.12.59;Initial Catalog=RepairCenterY;User ID=sa;Password=123456";
        //            string sql = "select username from UsersInfo where userid = " + Request.QueryString["UserID"];
        //            SqlConnection conn = new SqlConnection(constr);
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            sql = "select UserProvince from UsersInfo where userid = " + Request.QueryString["UserID"];
        //            cmd = new SqlCommand(sql, conn);
        //            DataSet ds = new DataSet();
        //            ds.ReadXml(Server.MapPath("~/pc.xml"));
        //            Suoshusheng.DataTextField = "name";
        //            Suoshusheng.DataValueField = "cname";
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                Suoshusheng.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
        //            }
        //            Suoshusheng.Items.FindByValue(cmd.ExecuteScalar().ToString()).Selected = true;
        //        }
        //    }
        //}

    }
}