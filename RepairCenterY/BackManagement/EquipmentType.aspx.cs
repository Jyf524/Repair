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
    public partial class EquipmentType : System.Web.UI.Page
    {
        Maticsoft.BLL.MachineFatherType MachineFatherType_bll = new Maticsoft.BLL.MachineFatherType();
        Maticsoft.BLL.MachineSonType MachineSonType_bll = new Maticsoft.BLL.MachineSonType();

         public string SeachString
        {
            get { return ViewState["_SeachString"] == null ? string.Empty : ViewState["_SeachString"].ToString(); }
            set { ViewState["_SeachString"] = value; }
        }

                
        protected void Page_Load(object sender, EventArgs e)
        {            

                RadButton2.Attributes["onclick"] = "OpenAddPro();return false;";//弹窗
                RadButton3.Attributes["onclick"] = "OpenAddProTwo();return false;";
                RadButton4.Attributes["onclick"] = "OpenAddProThree();return false;";

             RadGrid1.Rebind();
        }
        public void select()
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(SeachString))
            {

                if (!String.IsNullOrEmpty(strWhere))//判断strwhere是否为空
                {
                    strWhere += " and ";//不为空加and
                }               
            }
            strWhere = "MachineFatherName like '%" + SeachString + "%'";//加入条件
            RadGrid1.DataSource = MachineFatherType_bll.GetList(0, strWhere, "MachineFatherAddTime desc");//按添加时间降序排列
        }


        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Regex pattern1 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ]");//特殊字符正则判断
            string xxdz1 = RadTxtSearchName.Text.Trim();
            if (pattern1.IsMatch(xxdz1) == true)
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
                return;
            }
            else
            {
                SeachString = RadTxtSearchName.Text.Trim();
                select();
            }
            RadGrid1.Rebind(); //刷新
        }        
        
        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Delete")
            {
                if (MachineSonType_bll.GetList(" MachineFatherID='" + id + " ' ").Tables[0].Rows.Count > 0)//判断父类别是否存在子类别
                {
                    RadAjaxManager1.Alert("删除失败！");

                }
                else
                {
                    MachineFatherType_bll.Delete(id);
                    select();
                    RadGrid1.Rebind();//刷新
                }

            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = MachineFatherType_bll.GetList(0, "", " MachineFatherAddTime desc");//按添加时间降序排列
            select();

        }
        
        
        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
           select();
           RadGrid1.Rebind();//刷新
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {

        }

        protected void RadButton3_Click(object sender, EventArgs e)
        {

  

            
        }

        protected void RadButton4_Click(object sender, EventArgs e)
        {

        }

        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {
                RadGrid1.Rebind();//刷新
            }
        }

        protected void RadGrid1_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            select();
            RadGrid1.Rebind();//刷新
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{

        //}

        //protected void Button3_Click(object sender, EventArgs e)
        //{

        //}

        //protected void Button4_Click(object sender, EventArgs e)
        //{

        //}

        //protected void RadButton2_Click(object sender, EventArgs e)
        //{
        //    if (RadGrid1.SelectedItems.Count > 0)
        //    {
        //        var selectedItem = RadGrid1.SelectedItems[0];
        //        string ID = RadGrid1.MasterTableView.DataKeyValues[selectedItem.ItemIndex]["DeclarationID"].ToString();
        //        Response.Redirect("RepairAcceptanceZB.aspx?id=" + ID);
        //    }
        //    else
        //    {
        //        RadAjaxManager1.Alert("请选择一条数据");
        //    }
        //}


    }
}