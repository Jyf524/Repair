using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class RepairReport : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration bllDeclaration = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration modelDeclaration = new Maticsoft.Model.Declaration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["ID"]))
            {
                
                modelDeclaration = bllDeclaration.GetModel(Request["ID"]);
                
                Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
                char[] stringChar = modelDeclaration.BreakDown.ToCharArray();
                StringBuilder sb = new StringBuilder();
                int nLength = 0;
                for (int i = 0; i < stringChar.Length; i++)
                {
                    if (regex.IsMatch((stringChar[i]).ToString()))
                    {
                        sb.Append(stringChar[i]);
                        nLength += 1;
                    }
                    if (nLength > modelDeclaration.BreakDown.Length)
                    {
                        break;
                    }
                }
                modelDeclaration.Result = sb.ToString();
                if (modelDeclaration.Result == "")
                {
                    modelDeclaration.Result = "暂无";
                }
                if (modelDeclaration.RepairTreatment == "")
                {
                    modelDeclaration.RepairTreatment = "无";
                }
                if (modelDeclaration.ReplacementID == "")
                {
                    modelDeclaration.ReplacementID = "无";
                }
                bllDeclaration.Update(modelDeclaration);

            var instanceReportSource = new Telerik.Reporting.InstanceReportSource();//声明一个Telerik.Reporting对象
            instanceReportSource.ReportDocument = new Reports.RepairReport();//将创建好的页面赋值给变量
            ReportViewer1.ReportSource = instanceReportSource;//给页面空间绑定数据源
            //ReportViewer1.ReportSource.Parameters.Add("Parameter1", "1");//给报表添加查询条件，只查询一条数据，此处的1可以设置成动态数据
            ReportViewer1.ReportSource.Parameters.Add("Parameter1", Request["ID"]);//给报表添加查询条件，只查询一条数据，此处的1可以设置成动态数据
            }
            else
            {
                Response.Redirect("~/BackLogin.aspx");
            }
        }
    }
}