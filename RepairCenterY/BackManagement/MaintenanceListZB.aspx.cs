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
    public partial class RepairEditZB : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration DeclarationBLL = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration DeclarationModel = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.Replacement ReplacementBLL = new Maticsoft.BLL.Replacement();
        Maticsoft.Model.Replacement ReplacementModel = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.ReplacementRecord ReplacementRecordBLL = new Maticsoft.BLL.ReplacementRecord();
        Maticsoft.Model.ReplacementRecord ReplacementRecordModel = new Maticsoft.Model.ReplacementRecord();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["id"]))
            {
                DeclarationModel = DeclarationBLL.GetModel(Request["id"].ToString());

            }
            else if (UsersInfo.UserRole!="装备中心管理员")
            {
                Response.Redirect("../BackLogin.aspx");
            }
            else
            {
                Response.Redirect("RepairManagementZB.aspx");
            }
            RadDatePicker1.SelectedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")); 
            DeclarationModel = DeclarationBLL.GetModel(Request["id"].ToString());
            Label2.Text = DeclarationModel.RepairerName;
            //Label9.Text = DeclarationModel.ActualMoney.ToString();
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
          
            if (String.IsNullOrEmpty(myEditor.InnerText))
            {
                RadAjaxManager1.Alert("请输入故障诊断及维修方案");
                return;
            }
            else
            {
                DeclarationModel.RepairPlan = myEditor.InnerText;
            }

                DeclarationModel.ResultTime= RadDatePicker1.SelectedDate;

            string search2 = TextBox2.Text;
            string xxdz2 = TextBox2.Text.Trim();
            Regex pattern2 = new Regex("^[0-9]+([.]{1}[0-9]+){0,1}$");
            if (TextBox2.Text == "")
            {
                RadAjaxManager1.Alert("请输入人工费用");
                return;
            }
            else if ((pattern2.IsMatch(xxdz2) == false))
            {
                RadAjaxManager1.Alert("请输入正确的人工费用");

                return;
            }
            else
            {
                DeclarationModel.PersonMoney =Convert.ToDecimal(TextBox2.Text);
            }

            string search3 = TextBox1.Text;
            string xxdz3 = TextBox1.Text.Trim();
            Regex pattern3 = new Regex("^[0-9]+([.]{1}[0-9]+){0,1}$");
            if (TextBox1.Text == "")
            {
                RadAjaxManager1.Alert("请输入维修费用");
                return;
            }
            else if ((pattern3.IsMatch(xxdz3) == false))
            {
                RadAjaxManager1.Alert("请输入正确的维修费用");
                return;
            }
            else
            {
                DeclarationModel.RepairPrice = Convert.ToDecimal(TextBox1.Text);
            }
            DeclarationModel.DeclarationState = "装备中心已完修";
            DeclarationBLL.Update(DeclarationModel);
            //Response.Redirect("RepairManagementZB.aspx");
            RadAjaxManager1.Redirect("RepairManagementZB.aspx");
            //判断每个输入是否正确正确后加入数据库
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("RepairManagementZB.aspx");
            RadAjaxManager1.Redirect("RepairManagementZB.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                TextBox1.Text = "0";
            }
            string search3 = TextBox2.Text;
            string xxdz3 = TextBox2.Text.Trim();
            Regex pattern3 = new Regex("^[0-9]+([.]{1}[0-9]+){0,1}$");
            if ((pattern3.IsMatch(xxdz3) == false))
            {
                RadAjaxManager1.Alert("请输入正确的维修费用");
                return;
            }
            else 
            {
             int aa = Convert.ToInt32(TextBox1.Text) + Convert.ToInt32(TextBox2.Text);
            
            Label9.Text = "￥" + Convert.ToString(aa);
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                TextBox2.Text = "0";
            }
            string search3 = TextBox1.Text;
            string xxdz3 = TextBox1.Text.Trim();
            Regex pattern3 = new Regex("^[0-9]+([.]{1}[0-9]+){0,1}$");
            if ((pattern3.IsMatch(xxdz3) == false))
            {
                RadAjaxManager1.Alert("请输入正确的维修费用");
                return;
            }
            else
            {
             int aa = Convert.ToInt32(TextBox1.Text) + Convert.ToInt32(TextBox2.Text);
                
                Label9.Text = "￥" + Convert.ToString(aa);
            }


        }
    }
}