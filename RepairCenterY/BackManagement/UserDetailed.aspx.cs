using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Text.RegularExpressions;
using Telerik.Web.UI;

namespace RepairCenterY.BackManagement
{
    public partial class UserDetailed : System.Web.UI.Page
    {
        Maticsoft.BLL.UsersInfo bu = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo mu = new Maticsoft.Model.UsersInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //bianji.Attributes["OnClick"] = "OpenAddPro3();return false;";//添加编辑事件
            //chakan.Attributes["OnClick"] = "OpenAddPro4();return false;";//添加查看事件
        }

        //protected void RadListView1_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        //{
        //    RadListView1.DataSource = bu.GetList("");
        //}

        //protected void RadListView1_ItemCommand(object sender, RadListViewCommandEventArgs e)
        //{

        //}
        public string select1//存储用户名
        {
            get { return ViewState["_select1"] == null ? string.Empty : ViewState["_select1"].ToString(); }
            set { ViewState["_select1"] = value; }
        }
        public string select2//存储时间1
        {
            get { return ViewState["_select2"] == null ? string.Empty : ViewState["_select2"].ToString(); }
            set { ViewState["_select2"] = value; }
        }
        public string select3//存储时间2
        {
            get { return ViewState["_select3"] == null ? string.Empty : ViewState["_select3"].ToString(); }
            set { ViewState["_select3"] = value; }
        }
        public string select4//存储身份
        {
            get { return ViewState["_select4"] == null ? string.Empty : ViewState["_select4"].ToString(); }
            set { ViewState["_select4"] = value; }
        }
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = bu.yonghudanweilianjie("");//数据库连接
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            bu.Delete(e.CommandArgument.ToString());//删除
            bu.laoshixueshengyiqigundan(e.CommandArgument.ToString());
            if (!string.IsNullOrEmpty(select1) && !string.IsNullOrEmpty(select2) && !string.IsNullOrEmpty(select3) && !string.IsNullOrEmpty(select4) && RadTxtSearchName.Text == select1 && RadDatePicker1.InvalidTextBoxValue == select2 && RadDatePicker2.InvalidTextBoxValue==select3)//翻页不重新连接数据库
            {
                    RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString(), Shenfen.SelectedValue.ToString());
                    RadGrid1.DataBind();
            }
            else
            {
                    RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(select1, select2,select3,select4);//翻页保持原数据库连接
                    RadGrid1.DataBind();
            }
        }

        protected void tianjia_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAdd.aspx");//添加跳转页面
        }

        protected void chaxun_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(RadTxtSearchName.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//判断是否有特殊字符,以下重复不注释
            {
                if (Regex.IsMatch(RadDatePicker1.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))
                {
                    if (Regex.IsMatch(RadDatePicker2.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))
                    {
                        if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")//判断前一个时间是否大于后一个时间
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);
                        }
                        else
                        {
                            select1 = RadTxtSearchName.Text;//存储用户名
                            select2 = RadDatePicker1.SelectedDate.ToString();//存储时间1
                            select3 = RadDatePicker2.SelectedDate.ToString();//存储时间2
                            select4 = Shenfen.SelectedValue.ToString();//存储身份
                            RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString(), Shenfen.SelectedValue);//数据库连接
                            RadGrid1.DataBind();
                        }
                    }
                    else
                    {
                        if (RadDatePicker2.InvalidTextBoxValue != "")//不为空时判断特殊字符
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);
                        }
                        else
                        {
                            if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);
                            }
                            else
                            {
                                select1 = RadTxtSearchName.Text;//同上
                                select2 = RadDatePicker1.SelectedDate.ToString();
                                select3 = RadDatePicker2.SelectedDate.ToString();
                                select4 = Shenfen.SelectedValue.ToString();
                                RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString(), Shenfen.SelectedValue);
                                RadGrid1.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    if (RadDatePicker1.InvalidTextBoxValue != "")//同上
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);
                    }
                    else
                    {
                        if (Regex.IsMatch(RadDatePicker2.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                        {
                            if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);
                            }
                            else
                            {
                                select1 = RadTxtSearchName.Text;//同上
                                select2 = RadDatePicker1.SelectedDate.ToString();
                                select3 = RadDatePicker2.SelectedDate.ToString();
                                select4 = Shenfen.SelectedValue.ToString();
                                RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString(), Shenfen.SelectedValue);
                                RadGrid1.DataBind();
                            }
                        }
                        else
                        {
                            if (RadDatePicker2.InvalidTextBoxValue != "")//同上
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);
                            }
                            else
                            {
                                if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);//同上
                                }
                                else
                                {
                                    select1 = RadTxtSearchName.Text;//同上
                                    select2 = RadDatePicker1.SelectedDate.ToString();
                                    select3 = RadDatePicker2.SelectedDate.ToString();
                                    select4 = Shenfen.SelectedValue.ToString();
                                    RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString(), Shenfen.SelectedValue);
                                    RadGrid1.DataBind();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (RadTxtSearchName.Text != "")//同上
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);
                }
                else
                {
                    if (Regex.IsMatch(RadDatePicker1.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$") || Regex.IsMatch(RadDatePicker2.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                    {
                        if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);
                        }
                        else
                        {
                            select1 = RadTxtSearchName.Text;//同上
                            select2 = RadDatePicker1.SelectedDate.ToString();
                            select3 = RadDatePicker2.SelectedDate.ToString();
                            select4 = Shenfen.SelectedValue.ToString();
                            RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString(), Shenfen.SelectedValue);
                            RadGrid1.DataBind();
                        }
                    }
                    else
                    {
                        if (RadDatePicker1.InvalidTextBoxValue != "" || RadDatePicker2.InvalidTextBoxValue != "")//同上
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);
                        }
                        else
                        {
                            if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);
                            }
                            else
                            {
                                select1 = RadTxtSearchName.Text;//同上
                                select2 = RadDatePicker1.SelectedDate.ToString();
                                select3 = RadDatePicker2.SelectedDate.ToString();
                                select4 = Shenfen.SelectedValue.ToString();
                                RadGrid1.DataSource = bu.yonghumingjuesexitongguanliyuan(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString(), Shenfen.SelectedValue);
                                RadGrid1.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void bianji_Click(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedItems.Count > 0)//选中一条数据
            {
                var selectedItem = RadGrid1.SelectedItems[0];
                string id = RadGrid1.MasterTableView.DataKeyValues[selectedItem.ItemIndex]["UserID"].ToString();
                Response.Redirect("UserEdit.aspx?UserID=" + id);
            }
            else
            {
                RadAjaxManager1.Alert("请选择一条数据!");
            }
        }

        //protected void chakan_Click(object sender, EventArgs e)
        //{
        //    if (RadGrid1.SelectedItems.Count > 0)//选中一条数据
        //    {
        //        var selectedItem = RadGrid1.SelectedItems[0];
        //        string id = RadGrid1.MasterTableView.DataKeyValues[selectedItem.ItemIndex]["UserID"].ToString();
        //        Response.Redirect("UnitUser.aspx?UserID=" + id);
        //    }
        //    else
        //    {
        //        RadAjaxManager1.Alert("请选择一条数据!");
        //    }
        //}
    }
}