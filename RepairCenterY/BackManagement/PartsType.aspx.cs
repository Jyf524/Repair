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
    public partial class PartsType : System.Web.UI.Page
    {
        Maticsoft.BLL.PartType bllPartType = new Maticsoft.BLL.PartType();
        Maticsoft.Model.PartType modelPartType = new Maticsoft.Model.PartType();
        Maticsoft.BLL.Part bllPart = new Maticsoft.BLL.Part();
        Maticsoft.Model.Part modelPart = new Maticsoft.Model.Part();
        public String PartTypeName
        {
            get
            { return ViewState["_PartTypeName"] == null ? string.Empty : ViewState["_PartTypeName"].ToString(); }
            set
            { ViewState["_PartTypeName"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            btnadd.Attributes["onclick"] = "OpenAddPro();return false;";//添加
            btnxg.Attributes["onclick"] = "Openxg();return false;";//修改
            btnlook.Attributes["onclick"] = "OpenAddProLook();return false;";//查看
            RadGrid1.Rebind();//重绑数据源
        }
        //删除
        protected void RadGrid1_ItemCommand1(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Delete")
            {
                if (bllPart.GetRecordCount(" PartTypeID ='" + id + "' ") != 0)//存在配件，不能删除
                {
                    RadAjaxManager1.Alert("删除失败!");
                }
                else
                {
                    bllPartType.Delete(id);
                    RadGrid1.DataSource = bllPartType.GetList(" PartTypeName like '%" + PartTypeName + "%' order by PartTypeAddTime desc ");
                    RadGrid1.Rebind();//重绑数据源
                }
            }
        }
        //数据源
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = bllPartType.GetList(" PartTypeName like '%" + PartTypeName + "%' order by PartTypeAddTime desc ");
        }
        //分页
        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            RadGrid1.DataSource = bllPartType.GetList(" PartTypeName like '%" + PartTypeName + "%' order by PartTypeAddTime desc ");
            RadGrid1.Rebind();//重绑数据源
        }
        //搜索
        protected void btnselect_Click1(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(txtPartTypeName.Text.Trim()) && txtPartTypeName.Text.Trim() != "")//是否含有特殊字符
            {
                RadAjaxManager1.Alert("类别名称不能输入特殊字符!");//提示语句
                return;
            }
            PartTypeName = txtPartTypeName.Text.Trim();
            RadGrid1.DataSource = bllPartType.GetList(" PartTypeName like '%" + PartTypeName + "%' order by PartTypeAddTime desc ");
            RadGrid1.Rebind();//重绑数据源
        }





    }
}