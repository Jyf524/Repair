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
    public partial class CompanyAdd : System.Web.UI.Page
    {
        Maticsoft.BLL.UnitsInfo company_bll = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo company_model = new Maticsoft.Model.UnitsInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (company_bll.GetRecordCount("")>0)
            {
                DataSet asd = company_bll.GetList(1, "", "AddTime desc");
                string aaa =  asd.Tables[0].Rows[0]["UnitCode"].ToString();
                int bb =  Convert.ToInt32(aaa) + 1;
                switch (Convert.ToString(bb).Length)//判断变量a的长度
                {
                    case 1: TextBox5.Text = "00" + bb.ToString(); break;//为1 单号后加00
                    case 2: TextBox5.Text = "0" + bb.ToString(); break;//为2 单号后加0
                    case 3: TextBox5.Text = bb.ToString(); break;//为3  不变化
                       
                }
            }
            else
            {
                TextBox5.Text = "001";
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            //判断有无特殊字符，是否为空
            string search = TextBox1.Text;
            string xxdz = TextBox1.Text.Trim();//删除空格
            Regex pattern = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’ ']");
            if ((pattern.IsMatch(xxdz) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }

            string stt = TextBox2.Text;
            bool isNum1 = System.Text.RegularExpressions.Regex.IsMatch(stt, @"(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$");
            if (isNum1)
            { }
            else
            {
                RadAjaxManager1.Alert("请输入正确的号码!");
                return;
            }
            if (TextBox2.Text.Length != 11)
            {
                RadAjaxManager1.Alert("请输入正确的号码!");
                return;
            }

            string search2 = TextBox2.Text;
            string xxdz2 = TextBox2.Text.Trim();//删除空格
            Regex pattern2 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ‘’ ' ]");
            if ((pattern2.IsMatch(xxdz2) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }

            string search3 = TextBox3.Text;
            string xxdz3 = TextBox3.Text.Trim();//删除空格
            Regex pattern3 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’ ']");
            if ((pattern2.IsMatch(xxdz3) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }

            string search4 = TextBox4.Text;
            string xxdz4 = TextBox4.Text.Trim();//删除空格
            Regex pattern4 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’']");
            if ((pattern2.IsMatch(xxdz4) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }

            string search5 = TextBox5.Text;
            string xxdz5 = TextBox5.Text.Trim();//删除空格
            Regex pattern5 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’ ']");
            if ((pattern5.IsMatch(xxdz5) == true))
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
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

             else if (company_bll.GetRecordCount(" UnitName ='" + TextBox1.Text + "' ") != 0)//判断单位名称是否重复
            {
                RadAjaxManager1.Alert("单位名称不能重复添加");
                return;
            }

             else if (company_bll.GetRecordCount(" UnitCode ='" + TextBox5.Text + "' ") != 0)//判断单位代码是否重复
            {
                RadAjaxManager1.Alert("单位代码不能重复添加");
                return;
            }

            //else if (TextBox5.Text.Length != 3)
            //{
            //    RadAjaxManager1.Alert("单位代码仅可以输入三位!");//判断单位代码长度
            //    return;
            //}

            else
            {
                //将输入框的内容传入数据库，添加数据
                company_model.UnitID = DateTime.Now.ToString("yyyyMMddhhmmss");
                company_model.UnitName = TextBox1.Text;
                company_model.AddTime = DateTime.Now;
                company_model.UnitPhone = TextBox2.Text;
                company_model.UnitUserID = TextBox3.Text;
                company_model.UnitAddress = TextBox4.Text;
                company_model.UnitCode = TextBox5.Text;
                company_model.Unitprovince = DropDownList1.SelectedItem.Text;
                company_model.UnitCity = DropDownList2.SelectedItem.Text;
                company_bll.Add(company_model);//添加数据
                Response.Write("<script>alert('添加成功!');window.location.href='./Company.aspx'</script>");
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
            xds.DataFile = Server.MapPath("/pc.xml");//读取
            DropDownList2.DataSource = xds;//绑定数据源
            DropDownList2.DataTextField = "cname";//设置文本字段
            DropDownList2.DataValueField = "cname";//设置值字段
            xds.XPath = "//province[@name='" + DropDownList1.SelectedValue + "']/city";//存放路径
            DropDownList2.DataBind();
            DropDownList2.Items.Add(new ListItem("请选择", ""));//默认请选择
        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Clear();//清空
                DropDownList2.Items.Clear();//清空
                DropDownList1.Items.Add(new ListItem("请选择", ""));//默认请选择
                DropDownList2.Items.Add(new ListItem("请选择", ""));//默认请选择
                DataSet ds = new DataSet();//实例化
                ds.ReadXml(Server.MapPath("/pc.xml"));//读取
                DropDownList1.DataTextField = "name";//设置文本字段
                DropDownList1.DataValueField = "name";//设置值字段
                foreach (DataRow datarow in ds.Tables[0].Rows)//遍历
                {
                    DropDownList1.Items.Add(new ListItem(datarow["name"].ToString(), datarow["name"].ToString()));//添加省名
                }
                DropDownList1.DataBind();//绑定数据源
            }
        }
    }
}