using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class Company : System.Web.UI.Page
    {
        Maticsoft.BLL.UnitsInfo company_bll = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo company_model = new Maticsoft.Model.UnitsInfo();

        Maticsoft.BLL.UsersInfo user_bll = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo user_model = new Maticsoft.Model.UsersInfo();

        //定义两个公共函数
        public string SeachString
        {
            get { return ViewState["_SeachString"] == null ? string.Empty : ViewState["_SeachString"].ToString(); }
            set { ViewState["_SeachString"] = value; }
        }
        public string SeachString1
        {
            get { return ViewState["_SeachString1"] == null ? string.Empty : ViewState["_SeachString1"].ToString(); }
            set { ViewState["_SeachString1"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //选中一条数据进行跳转
            RadButton2.Attributes["onclick"] = "OpenEdit();return false;";
           // RadButton3.Attributes["onclick"] = "OpenAddProThree();return false;";
        }

        public void select()//定义一个查询的方法
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(SeachString))
            {

                if (!String.IsNullOrEmpty(strWhere))//判断strwhere是否为空
                {
                    strWhere += " and ";//不为空加and
                }
                strWhere = "UnitName like '%" + SeachString + "%'";
            }
            if (!String.IsNullOrEmpty(SeachString1))
            {

                if (!String.IsNullOrEmpty(strWhere))//判断strwhere是否为空
                {
                    strWhere += " and ";//不为空加and
                }
                strWhere = "UnitCode like '%" + SeachString1 + "%'";
            }

            RadGrid1.DataSource = company_bll.GetList(0, strWhere, "AddTime desc");//时间倒序显示
        }


        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            select();//调用方法
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            select();
            RadGrid1.Rebind();//调用方法
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            //company_bll.Delete(e.CommandArgument.ToString());//删除
            //RadGrid1.Rebind();


          
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Delete")
            {

                if (user_bll.GetList(" UnitID='" + id + " ' ").Tables[0].Rows.Count > 0)//判断是否有报修单位用户
                {
                    RadAjaxManager1.Alert("报修单位有用户不能删除！");
                }
                else
                {
                    company_bll.Delete(e.CommandArgument.ToString());
                    RadGrid1.Rebind();//重绑
                }

            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./CompanyAdd.aspx");//跳转
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //判断有无特殊字符，是否为空
            Regex pattern = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’ ']");
            string xxdz = RadTextBox1.Text.Trim();//删除空格
            if (pattern.IsMatch(xxdz) == true)
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
            }
            else
            {
                SeachString = RadTextBox1.Text.Trim();
            }

            Regex pattern2 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？  ‘’ ']");
            string xxdz2 = RadTextBox2.Text.Trim();//删除空格
            if (pattern2.IsMatch(xxdz2) == true)
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
            }
            else
            {
                SeachString1 = RadTextBox2.Text.Trim();//删除空格
            }
            select();
            RadGrid1.Rebind();//调用方法
        }

        protected void RadGrid1_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            select();
            RadGrid1.Rebind();//调用方法
        }
    }
}