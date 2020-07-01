using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class ReapirBackAdd : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration Declaration_Bll = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration Declaration_Mol = new Maticsoft.Model.Declaration();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnback.Attributes["onclick"] = "GetClose();return false;";
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);
            
            if (RadRepairBack.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("返修说明不能为空!");
                return;
            }
            if (!rxname.IsMatch(RadRepairBack.Text.Trim()) && RadRepairBack.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("返修说明不能输入特殊字符!");
                return;
            }
            Declaration_Mol = Declaration_Bll.GetModel(Request.QueryString["ID"].ToString());
            Declaration_Mol.ReworkInstructions = RadRepairBack.Text;
            Declaration_Mol.DeclarationState = "维修基地待受理(返修)";
            Declaration_Bll.Update(Declaration_Mol);
            RadAjaxManager1.Alert("返修成功!");
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");
        }
    }
}