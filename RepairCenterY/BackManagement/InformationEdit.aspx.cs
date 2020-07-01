using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RepairCenterY.BackManagement
{
    public partial class InformationEdit : System.Web.UI.Page
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
                        UsersInfo_Model = UsersInfo_Bll.GetModel(UsersInfo.UserID);//引用id所在行的数据
                        imgPic.ImageUrl = UsersInfo_Model.HeadPortrait;//添加数据
                        Label1.Text = UsersInfo_Model.UserName;//添加数据
                        TextBox2.Text = UsersInfo_Model.UserRealName;//添加数据
                        TextBox3.Text = UsersInfo_Model.UserPhone;//添加数据
                        TextBox5.Text = UsersInfo_Model.UserEmail;//添加数据
                        
                        RadDatePicker1.SelectedDate = Convert.ToDateTime(UsersInfo_Model.UserBirthday);//添加数据
                        TextBox4.Text = UsersInfo_Model.UserAddress;//添加数据
                        if (UsersInfo_Model.UserSex == "男")
                        {
                            RadioButton1.Checked = true;
                        }
                        else
                        {
                            RadioButton2.Checked = true;
                        }//添加数据
                    DropDownList1.Items.Clear();//清空省下拉框项目
                    DropDownList2.Items.Clear();//清空市下拉框项目
                    DropDownList1.Items.Add(new ListItem("请选择", ""));//给省下拉框添加请选择
                    //RadDropDownList2.Items.Add(new DropDownListItem("请选择", ""));//给市下拉框添加请选择
                    DataSet ProvinceDS = new DataSet();//声明数据库
                    ProvinceDS.ReadXml(Server.MapPath("~/pc.xml"));//读取pc文件
                    foreach (DataRow dr in ProvinceDS.Tables[0].Rows)//声明dr,数据库循环
                    {
                        //逐条向dr添加,文本为dr的name列,值为dr的name列
                        DropDownList1.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
                    }
                    DropDownList1.SelectedValue = UsersInfo_Model.UserProvince;

                    XmlDataSource xds = new XmlDataSource();//声明xml数据源
                    xds.DataFile = Server.MapPath("~/pc.xml");//读取pc文件
                    xds.XPath = "//province[@name='" + DropDownList1.SelectedValue + "']/city";//sql语句
                    this.DropDownList2.DataSource = xds;//绑定数据源
                    this.DropDownList2.DataTextField = "cname";//设置文本字段
                    this.DropDownList2.DataValueField = "cname";//设置值字段
                    this.DropDownList2.DataBind();//绑定数据源
                    DropDownList2.Items.Add(new ListItem("请选择", ""));//给市下拉框添加请选择
                    DropDownList2.SelectedValue = UsersInfo_Model.UserCity;
             
                if (UsersInfo.UserRole == "报修单位用户")
                {
                    UnitsInfo_Model = UnitsInfo_Bll.GetModel(UsersInfo_Model.UnitID);
                    Label7.Text = UnitsInfo_Model.UnitName;
                    XB.Visible = false;
                    LXDH.Visible = false;
                    YX.Visible = false;
                    CSRQ.Visible = false;
                    JTZZ.Visible = false;
                    XXDZ.Visible = false;
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
                if (Label7.Text == "")
                {
                    Label7.Text = "暂无数据";
                }
                    }
                }
        }

        protected void RadButton1_Click1(object sender, EventArgs e)
        {
            string search2 = TextBox2.Text;
            string xxdz2 = TextBox2.Text.Trim();
            Regex pattern2 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\]<>/?~！#￥……&*（）——|{}【】‘；：”“'。，、？ ']");//特殊字符正则判断
            if ((pattern2.IsMatch(xxdz2) == true))
            {
                Response.Write("<script>alert('请输入正确的姓名！')</script>");
                return;
            }

            string search3 = TextBox3.Text;
            string xxdz3 = TextBox3.Text.Trim();
            Regex pattern3 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\]<>/?~！#￥……&*（）——|{}【】‘；：”“'。，、？' ]");//特殊字符正则判断
            if ((pattern2.IsMatch(xxdz3) == true))
            {
                Response.Write("<script>alert('请输入正确的联系号码！')</script>");
                return;
            }
            string search4 = TextBox4.Text;
            string xxdz4 = TextBox4.Text.Trim();
            Regex pattern4 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\]<>/?~！#￥……&*（）——|{}【】‘；：”“'。，、？' ]");//特殊字符正则判断
            if ((pattern2.IsMatch(xxdz4) == true))
            {
                Response.Write("<script>alert('请输入正确的详细地址！')</script>");
                return;
            }
            string stt = TextBox3.Text;//判断联系方式是否正确
            bool isNum1 = System.Text.RegularExpressions.Regex.IsMatch(stt, @"(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$");
            if (isNum1)
            { }
            else
            {
                RadAjaxManager1.Alert("请输入正确的联系方式!");
                return;
            }
            if (TextBox3.Text.Length != 11)//判断联系方式的号码位数是否正确
            {
                Response.Write("<script>alert(\"请输入正确的联系方式\")</script>");
                return;
            }
            string youxiang = @"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";//邮箱正则判断
            Regex regexYX = new Regex(youxiang);
            if (TextBox2.Text == "")//判断输入框是否为空
            {
                Response.Write("<script>alert(\"请输入姓名\")</script>");
            }
            else if (TextBox5.Text == "")//判断输入框是否为空
            {
                Response.Write("<script>alert(\"请输入邮箱\")</script>");
            }
            else if (TextBox4.Text == "")//判断输入框是否为空
            {
                Response.Write("<script>alert(\"请输入详细地址\")</script>");
            }
            else if (regexYX.IsMatch(TextBox5.Text) == false)//判断邮箱格式是否正确
            {
                Response.Write("<script>alert(\"请输入正确的邮箱\")</script>");
                return;
            }
            else if (RadDatePicker1.SelectedDate == null)//判断出生日期是否为空
            {
                Response.Write("<script>alert(\"请输入出生日期\")</script>");
                return;
            }
            else if (RadDatePicker1.SelectedDate > DateTime.Now)//判断填写日期是否大于当前日期
            {
                Response.Write("<script>alert(\"请输入正确的出生日期\")</script>");
                return;
            }
            else if (DropDownList1.SelectedItem.Text == "请选择")//判断下拉框是否进行选择
            {
                Response.Write("<script>alert(\"请输入地址\")</script>");
                return;
            }
            else if (DropDownList2.SelectedItem.Text == "请选择")//判断下拉框是否进行选择
            {
                Response.Write("<script>alert(\"请输入地址\")</script>");
                return;
            }
            else
            {
                Maticsoft.Model.UsersInfo UsersInfo_Model = UsersInfo_Bll.GetModel(UsersInfo.UserID);//引用id所在行的数据
                UsersInfo_Model = UsersInfo_Bll.GetModel(UsersInfo.UserID);
                UsersInfo_Model.UserRealName = TextBox2.Text;//添加数据
                UsersInfo_Model.UserPhone = TextBox3.Text;//添加数据
                UsersInfo_Model.UserEmail = TextBox5.Text;//添加数据
                UsersInfo_Model.UserBirthday =RadDatePicker1.SelectedDate.ToString();//添加数据
                UsersInfo_Model.UserProvince = DropDownList1.SelectedValue;//添加数据
                UsersInfo_Model.UserCity = DropDownList2.SelectedValue;//添加数据
                UsersInfo_Model.UserSex = RadioButton1.Checked.ToString();//添加数据
                UsersInfo_Model.UserAddress = TextBox4.Text;//添加数据
                UsersInfo_Model.HeadPortrait = imgPic.ImageUrl;//添加数据
                if (RadioButton1.Checked == true)
                {
                    UsersInfo_Model.UserSex = "男";
                }
                else
                {
                    UsersInfo_Model.UserSex = "女";
                }
                UsersInfo_Bll.Update(UsersInfo_Model);//更新数据库
                Response.Write("<script>alert('修改成功!');window.location.href='./PersonalIinformation.aspx'</script>");//提示并跳转页面
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./PersonalIinformation.aspx");//跳转页面
        }

        protected void rauFiles_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            string filepath = "";
            if (rauFiles.UploadedFiles.Count > 0)//判断是否有图片
            {
                UploadedFile file = rauFiles.UploadedFiles[0];
                string uploadPath = "/UpLoad/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "/";//上传路径
                if (!Directory.Exists(uploadPath))//判断该路径是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(uploadPath));//在指定路径中创建所有目录
                }
                string name = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".png";//图片命名
                filepath = Server.MapPath(uploadPath) + name;
                file.SaveAs(filepath);//保存图片
                imgPic.ImageUrl = uploadPath + name;
            }
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();//清空市下拉框项目
            XmlDataSource xds = new XmlDataSource();//声明xml数据源
            xds.DataFile = Server.MapPath("~/pc.xml");//读取pc文件
            xds.XPath = "//province[@name='" + DropDownList1.SelectedValue + "']/city";//sql语句
            this.DropDownList2.DataSource = xds;//绑定数据源
            this.DropDownList2.DataTextField = "cname";//设置文本字段
            this.DropDownList2.DataValueField = "cname";//设置值字段
            this.DropDownList2.DataBind();//绑定数据源
            DropDownList2.Items.Add(new ListItem("请选择", ""));//给市下拉框添加请选择
            //DropDownList2.Text = "请选择";//设置初始值

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {

        }
    }
}

