using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text.RegularExpressions;

namespace RepairCenterY.BackManagement
{
    public partial class TeacherInformation : System.Web.UI.Page
    {
        Maticsoft.BLL.UsersInfo bu = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo mu = new Maticsoft.Model.UsersInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //bianji.Attributes["OnClick"] = "OpenAddPro3();return false;";//添加编辑事件
            //chakan.Attributes["OnClick"] = "OpenAddPro4();return false;";//添加及查看事件
        }

        protected void tianjia_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TeacherAdd.aspx");//跳转
        }
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
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.DataSource = bu.zhidaolaoshi("");//连接数据库
            }
        }

        protected void RadGrid1_ItemCommand1(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            bu.Delete(e.CommandArgument.ToString());//删除
            if (!string.IsNullOrEmpty(select1) && !string.IsNullOrEmpty(select2) && !string.IsNullOrEmpty(select3) && RadTxtSearchName.Text == select1 && RadDatePicker1.InvalidTextBoxValue == select2 && RadDatePicker2.InvalidTextBoxValue == select3)//判断是否点击了查看按钮
            {
                RadGrid1.DataSource = bu.yonghumingjueselaoshi(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString());//同上
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = bu.yonghumingjueselaoshi(select1, select2, select3);//同上
                RadGrid1.DataBind();
            }
        }

        protected void chaxun1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(RadTxtSearchName.Text, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//判断特殊字符
            {
                if (Regex.IsMatch(RadDatePicker1.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                {
                    if (Regex.IsMatch(RadDatePicker2.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                    {
                        if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")//判断是否为空
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);//js提示语句
                        }
                        else
                        {
                            select1 = RadTxtSearchName.Text;//存储用户名
                            select2 = RadDatePicker1.SelectedDate.ToString();//存储时间1
                            select3 = RadDatePicker2.SelectedDate.ToString();//存储时间2
                            RadGrid1.DataSource = bu.yonghumingjueselaoshi(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString());//同上
                            RadGrid1.DataBind();
                        }
                    }
                    else
                    {
                        if (RadDatePicker2.InvalidTextBoxValue != "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);//同上
                        }
                        else
                        {
                            if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")//同上
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);//同上
                            }
                            else
                            {
                                select1 = RadTxtSearchName.Text;//同上
                                select2 = RadDatePicker1.SelectedDate.ToString();//同上
                                select3 = RadDatePicker2.SelectedDate.ToString();//同上
                                RadGrid1.DataSource = bu.yonghumingjueselaoshi(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString());//同上
                                RadGrid1.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    if (RadDatePicker1.InvalidTextBoxValue != "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);//同上
                    }
                    else
                    {
                        if (Regex.IsMatch(RadDatePicker2.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                        {
                            if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")//同上
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);//同上
                            }
                            else
                            {
                                select1 = RadTxtSearchName.Text;//同上
                                select2 = RadDatePicker1.SelectedDate.ToString();//同上
                                select3 = RadDatePicker2.SelectedDate.ToString();
                                RadGrid1.DataSource = bu.yonghumingjueselaoshi(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString());//同上
                                RadGrid1.DataBind();
                            }
                        }
                        else
                        {
                            if (RadDatePicker2.InvalidTextBoxValue != "")//同上
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);//同上
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
                                    select2 = RadDatePicker1.SelectedDate.ToString();//同上
                                    select3 = RadDatePicker2.SelectedDate.ToString();//同上
                                    RadGrid1.DataSource = bu.yonghumingjueselaoshi(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString());
                                    RadGrid1.DataBind();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (RadTxtSearchName.Text != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);//同上
                }
                else
                {
                    if (Regex.IsMatch(RadDatePicker1.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$") || Regex.IsMatch(RadDatePicker2.InvalidTextBoxValue, @"^[\u4e00-\u9fa5a-zA-Z0-9]+$"))//同上
                    {
                        if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);//同上
                        }
                        else
                        {
                            select1 = RadTxtSearchName.Text;//同上
                            select2 = RadDatePicker1.SelectedDate.ToString();//同上
                            select3 = RadDatePicker2.SelectedDate.ToString();//同上
                            RadGrid1.DataSource = bu.yonghumingjueselaoshi(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString());//同上
                            RadGrid1.DataBind();
                        }
                    }
                    else
                    {
                        if (RadDatePicker1.InvalidTextBoxValue != "" || RadDatePicker2.InvalidTextBoxValue != "")//同上
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('请勿输入特殊字符！');", true);//同上
                        }
                        else
                        {
                            if (DateTime.Compare(Convert.ToDateTime(RadDatePicker1.SelectedDate), Convert.ToDateTime(RadDatePicker2.SelectedDate)) >= 0 && RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "")//同上
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('前一个时间不能大于或等于后一个时间！');", true);//同上
                            }
                            else
                            {
                                select1 = RadTxtSearchName.Text;//同上
                                select2 = RadDatePicker1.SelectedDate.ToString();//同上
                                select3 = RadDatePicker2.SelectedDate.ToString();//同上
                                RadGrid1.DataSource = bu.yonghumingjueselaoshi(RadTxtSearchName.Text, RadDatePicker1.SelectedDate.ToString(), RadDatePicker2.SelectedDate.ToString());//同上
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
                Response.Redirect("TeacherEdit.aspx?UserID=" + id);
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
        //        Response.Redirect("TeacherContent.aspx?UserID=" + id);
        //    }
        //    else
        //    {
        //        RadAjaxManager1.Alert("请选择一条数据!");
        //    }
        //}
    }
}