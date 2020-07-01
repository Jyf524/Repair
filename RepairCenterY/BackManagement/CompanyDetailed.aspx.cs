using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class CompanyDetailed : System.Web.UI.Page
    {
         Maticsoft.BLL.UnitsInfo company_bll = new Maticsoft.BLL.UnitsInfo();
        Maticsoft.Model.UnitsInfo company_model = new Maticsoft.Model.UnitsInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //取值用label显示
            if (!IsPostBack)//判断是否是第二次进入
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))//判断ID是否为空
                {
                    company_model = company_bll.GetModel(Request.QueryString["ID"]);//获取相对应ID的值
                    Label1.Text = company_model.UnitCode;
                    Label2.Text = company_model.UnitName;
                    Label3.Text = company_model.UnitPhone;
                    Label4.Text = company_model.UnitUserID;
                    Label5.Text = company_model.Unitprovince + company_model.UnitCity+company_model.UnitAddress;
                }
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Company.aspx");//跳转
        }
    }
}