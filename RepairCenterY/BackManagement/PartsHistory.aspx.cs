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
    public partial class PartsHistory : System.Web.UI.Page
    {
        Maticsoft.BLL.PartUseRecord bllPartUseRecord = new Maticsoft.BLL.PartUseRecord();
        Maticsoft.Model.PartUseRecord modelPartUseRecord = new Maticsoft.Model.PartUseRecord();
        Maticsoft.BLL.Part bllPart = new Maticsoft.BLL.Part();
        Maticsoft.Model.Part modelPart = new Maticsoft.Model.Part();
        public String RepairID
        {
            get
            { return ViewState["_RepairID"] == null ? string.Empty : ViewState["_RepairID"].ToString(); }
            set
            { ViewState["_RepairID"] = value; }
        }
        public String StartTime
        {
            get
            { return ViewState["_StartTime"] == null ? string.Empty : ViewState["_StartTime"].ToString(); }
            set
            { ViewState["_StartTime"] = value; }
        }
        public String EndTime
        {
            get
            { return ViewState["_EndTime"] == null ? string.Empty : ViewState["_EndTime"].ToString(); }
            set
            { ViewState["_EndTime"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["ID"] == null || Request.QueryString["ID"].ToString() == "")//ID为空返回列表页面
            {
                Response.Write("<script>window.location.href='Parts.aspx'</script>");
                return;
            }
            if (bllPart.GetModel(Request.QueryString["ID"]) == null)//ID为空返回列表页面
            {
                Response.Write("<script>window.location.href='Parts.aspx'</script>");
                return;
            }

        }


        //搜索
        protected void btnselect_Click(object sender, EventArgs e)
        {
            string name = "^[0-9]{1,}$";//数字
            Regex rxname = new Regex(name);//正则
            if (!rxname.IsMatch(txtListID.Text.Trim()) && txtListID.Text.Trim() != "")//含有二特殊字符
            {
                RadAjaxManager1.Alert("单号不能输入特殊字符!");//提示
                return;
            }
            RepairID = txtListID.Text.Trim();
            StartTime = dpstarttime.SelectedDate.ToString();
            EndTime = dpendtime.SelectedDate.ToString();
            DataLoad();//绑定数据源方法
            RadGrid1.Rebind();//重绑数据源
        }
        //绑定数据源方法
        protected void DataLoad()
        {
            string sqlselect = " and RepairID like '%" + RepairID + "%' ";
            if (StartTime != "" && EndTime == "")
            {
                sqlselect += " and PartUseTime >= '" + StartTime + "' ";
            }
            if (StartTime == "" && EndTime != "")
            {
                sqlselect += " and PartUseTime <= '" + EndTime + "' ";
            }
            if (StartTime != "" && EndTime != "")
            {
                sqlselect += " and PartUseTime between '" + StartTime + "' and '" + EndTime + "' ";
            }
            sqlselect += " and PartID = '" + Request.QueryString["ID"] + "' ";
            RadGrid1.DataSource = bllPartUseRecord.GetListw1(0, sqlselect, " PartUseTime desc ");//按时间降序排序
        }

        

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Delete")
            {
                //if (bllFathertype.GetRecordCount(" GoodsFatherID ='" + id + "' ") != 0 && bllSonType.GetRecordCount(" GoodsFatherID ='" + id + "' ") != 0)
                //{
                //    RadAjaxManager1.Alert("删除失败!");
                //}
                //else
                //{
                //    bllFathertype.Delete(id);
                //    RadGrid1.Rebind();
                //}
                bllPartUseRecord.Delete(id);//删除
                DataLoad();//绑定数据源方法
                RadGrid1.Rebind();//重绑数据源
            }
        }

        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataLoad();//绑定数据源方法
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            DataLoad();//绑定数据源方法
            RadGrid1.Rebind();//重绑数据源
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='Parts.aspx'</script>");
        }
        
    }
}