using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RepairCenterY.BackManagement
{
    public partial class CompanyEdit : System.Web.UI.Page
    {
        Maticsoft.BLL.UnitsInfo company_bll = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo company_model = new Maticsoft.Model.UnitsInfo();
        public static string name;
        protected void Page_Load(object sender, EventArgs e)
        {
                //将数据库内容传入输入框
                if (!IsPostBack)//判断是否为第二次进入
                {
                    if (!String.IsNullOrEmpty(Request.QueryString["ID"]))//判断ID是否为空
                    {
                        company_model = company_bll.GetModel(Request.QueryString["ID"].ToString());//获取相对应ID的值
                        Label1.Text = company_model.UnitCode;
                        name = TextBox1.Text = company_model.UnitName;
                        TextBox2.Text = company_model.UnitPhone;
                        TextBox3.Text = company_model.UnitUserID;
                        DropDownList1Load(company_model.Unitprovince);
                        DropDownList2.SelectedValue = company_model.UnitCity;
                        TextBox4.Text = company_model.UnitAddress;
                        DropDownList1.SelectedItem.Text = company_model.Unitprovince;
                        DropDownList2.SelectedItem.Text = company_model.UnitCity;
                    }
                }
        }

        protected void DropDownList1Load(string value)
        {

            DataSet ProvinceDS = new DataSet();//声明数据库
            ProvinceDS.ReadXml(Server.MapPath("/pc.xml"));//读取xml文件
            DropDownList1.DataTextField = "name";//设置文本字段
            DropDownList1.DataValueField = "name";//设置值字段
            foreach (DataRow dr in ProvinceDS.Tables[0].Rows)//声明dr,数据库循环
            {
                //逐条向dr添加,文本为dr的name列,值为dr的name列
                DropDownList1.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
            }
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = value;
            XmlDataSource xds = new XmlDataSource();//声明xml数据源
            xds.DataFile = Server.MapPath("/pc.xml");//读取xml文件
            DropDownList2.DataSource = xds;
            DropDownList2.DataTextField = "cname";//设置文本字段
            DropDownList2.DataValueField = "cname";//设置值字段
            xds.XPath = "//province[@name='" + DropDownList1.SelectedValue + "']/city";//将路径存放在表达式中
            DropDownList2.DataBind();//绑定数据源
        }


        protected void RadButton1_Click(object sender, EventArgs e)
        {
            //判断有无特殊字符，是否为空
            string yh = "UnitName='" + TextBox1.Text + "'";
            string search = TextBox1.Text;
            string xxdz = TextBox1.Text.Trim();
            Regex pattern = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’ ']");
            if ((pattern.IsMatch(xxdz) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }
            DataSet ds = company_bll.GetList(yh);

            string search2 = TextBox2.Text;
            string xxdz2 = TextBox2.Text.Trim();
            Regex pattern2 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ‘’ ' ]");
            if ((pattern2.IsMatch(xxdz2) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }

            string search3 = TextBox3.Text;
            string xxdz3 = TextBox3.Text.Trim();
            Regex pattern3 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’ ']");
            if ((pattern2.IsMatch(xxdz3) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }
            string search4 = TextBox4.Text;
            string xxdz4 = TextBox4.Text.Trim();
            Regex pattern4 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’']");
            if ((pattern2.IsMatch(xxdz4) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }


            string stt = TextBox2.Text;//判断联系方式是否正确
            bool isNum1 = System.Text.RegularExpressions.Regex.IsMatch(stt, @"(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$");
            if (isNum1)
            { }
            else
            {
                RadAjaxManager1.Alert("请输入正确的联系方式!");
                return;
            }
            if (TextBox2.Text.Length != 11)
            {
                RadAjaxManager1.Alert("请输入正确的联系方式!");
                return;
            }
          
            if (TextBox1.Text == "")//判断是否为空
            {
                RadAjaxManager1.Alert("请输入单位名称!");
                return;
            }
            else if (TextBox2.Text == "")//判断是否为空
            {
                RadAjaxManager1.Alert("请输入联系方式!");
                return;
            }
            else if (TextBox3.Text == "")//判断是否为空
            {
                RadAjaxManager1.Alert("请输入单位负责人!");
                return;
            }
            else if (TextBox4.Text == "")//判断是否为空
            {
                RadAjaxManager1.Alert("请输入详细地址!");
                return;
            }
            else if (DropDownList1.SelectedItem.Text == "请选择")//判断是否为空
            {
                RadAjaxManager1.Alert("请输入省");
                return;
            }
            else if (DropDownList2.SelectedItem.Text == "请选择")//判断是否为空
            {
                RadAjaxManager1.Alert("请输入市");
                return;
            }
            else if (company_bll.GetRecordCount(" UnitName ='" + TextBox1.Text + "' ") != 0 && TextBox1.Text != name)//判断单位名称是否重复
            {
                RadAjaxManager1.Alert("单位名称不能重复添加!");
                return;
            }
            else
            {
                //将输入框的内容传入数据库
                company_model = company_bll.GetModel(Request.QueryString["ID"].ToString());//获取ID
                company_model.UnitName = TextBox1.Text;
                company_model.AddTime = DateTime.Now;
                company_model.UnitPhone = TextBox2.Text;
                company_model.UnitUserID = TextBox3.Text;
                company_model.Unitprovince = DropDownList1.SelectedItem.Text;
                company_model.UnitCity = DropDownList2.SelectedItem.Text;
                company_model.UnitAddress = TextBox4.Text;
                company_bll.Update(company_model);//更新数据
                Response.Write("<script>alert('修改成功!');window.location.href='./Company.aspx'</script>");
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Company.aspx");//跳转
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();//清空
            XmlDataSource xds = new XmlDataSource();//声明xml数据源
            xds.DataFile = Server.MapPath("/pc.xml");//读取xml
            DropDownList2.DataSource = xds;
            DropDownList2.DataTextField = "cname";//设置文本字段
            DropDownList2.DataValueField = "cname";//设置值字段
            xds.XPath = "//province[@name='" + DropDownList1.SelectedValue + "']/city";//将路径存放在表达式中
            DropDownList2.DataBind();//绑定数据源
        }

    }
}