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
    public partial class Parts : System.Web.UI.Page
    {
        Maticsoft.BLL.Part bllPart = new Maticsoft.BLL.Part();
        Maticsoft.Model.Part modelPart = new Maticsoft.Model.Part();
        Maticsoft.BLL.PartType bllPartType = new Maticsoft.BLL.PartType();
        Maticsoft.Model.PartType modelPartType = new Maticsoft.Model.PartType();
        Maticsoft.BLL.PartPutRecord bllPartPutRecord = new Maticsoft.BLL.PartPutRecord();
        Maticsoft.Model.PartPutRecord modelPartPutRecord = new Maticsoft.Model.PartPutRecord();
        Maticsoft.BLL.PartUseRecord bllPartUseRecord = new Maticsoft.BLL.PartUseRecord();
        Maticsoft.Model.PartUseRecord modelPartUseRecord = new Maticsoft.Model.PartUseRecord();

        public String PartName
        {
            get
            { return ViewState["_PartName"] == null ? string.Empty : ViewState["_PartName"].ToString(); }
            set
            { ViewState["_PartName"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            RadGrid1.Rebind();//重绑数据源
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    
                    Response.Write("<script>window.location.href='PartsType.aspx'</script>");//跳转
                    return;
                }
                if (bllPartType.GetModel(Request.QueryString["ID"]) == null)
                {
                    Response.Write("<script>window.location.href='PartsType.aspx'</script>");//跳转
                    return;
                }
                Session["PartTypeID"] = Request.QueryString["ID"].ToString();//父类页面跳转子类页面传的ID，保存在session内

            }
            btnadd.Attributes["onclick"] = "OpenAddPro();return false;";//添加
            btnxg.Attributes["onclick"] = "Openxg();return false;";//修改
            btnlook.Attributes["onclick"] = "OpenHistoryLook();return false;";//查看使用记录
            
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();//获取PartID
            if (e.CommandName == "Delete")
            {
                if (bllPartPutRecord.GetRecordCount(" PartID = '" + id + "' ") != 0 || bllPartUseRecord.GetRecordCount(" PartID = '" + id + "' ") != 0)//存在记录
                {
                    RadAjaxManager1.Alert("删除失败!");//不能删除
                }
                else
                {
                    bllPart.DeleteList(id);//删除数据
                    
                    DataLoad();//绑定数据源方法
                    RadGrid1.Rebind();//重绑数据源
                    
                }
                //Response.Write("<script type='text/javascript'>function del(){ id = -1 }</script>");
            }
        }
        //数据源
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataLoad();//绑定数据源方法
        }
        //分页
        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            RadGrid1.Rebind();//重绑数据源
        }
        //绑定数据源方法
        protected void DataLoad()
        {
            string sqlselect = " and PartName like '%" + PartName + "%' and a.PartTypeID = '" + Request.QueryString["ID"] + "' ";
            RadGrid1.DataSource = bllPart.GetListw1(0, sqlselect, " PartAddTime desc ");//按时间降序排序
        }
        //搜索按钮
        protected void btnselect_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(txtPartName.Text.Trim()) && txtPartName.Text.Trim() != "")//是否有特殊字符
            {
                RadAjaxManager1.Alert("类别名称不能输入特殊字符!");//提示语句
                return;
            }
            PartName = txtPartName.Text.Trim();
            DataLoad();//绑定数据源方法
            RadGrid1.Rebind();//重绑数据源
        }
        //返回
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='PartsType.aspx'</script>");//弹窗添加成功并跳转BooksManage页面
        }

    }
}