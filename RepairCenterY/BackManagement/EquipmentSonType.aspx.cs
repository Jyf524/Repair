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
    public partial class EquipmentSonType : System.Web.UI.Page
    {

        Maticsoft.BLL.MachineSonType MachineSonType_bll = new Maticsoft.BLL.MachineSonType();
        Maticsoft.Model.MachineSonType MachineSonType_Model = new Maticsoft.Model.MachineSonType();
        Maticsoft.BLL.Replacement Replacement_bll = new Maticsoft.BLL.Replacement();
        Maticsoft.Model.Replacement Replacement_Model = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.Declaration Declaration_bll = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration Declaration_Model = new Maticsoft.Model.Declaration();
        public string SeachString
        {
            get { return ViewState["_SeachString"] == null ? string.Empty : ViewState["_SeachString"].ToString(); }
            set { ViewState["_SeachString"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UsersInfo.UserID))
            {
                RadButton2.Attributes["onclick"] = "OpenAddPro();return false;";//弹窗
                RadButton3.Attributes["onclick"] = "OpenAddProTwo();return false;";
                if (!IsPostBack)
                {
                    Session["FaID"] = Request.QueryString["ID"].ToString();//查询该父类别底下的子类别
                    //id = Request.QueryString["ID"].ToString();
                }
            }
                RadGrid1.Rebind();//刷新
        }
        public void  select()
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(SeachString))
            {
               
                if (!String.IsNullOrEmpty(strWhere))//判断strwhere是否为空
                {
                    strWhere += " and ";//不为空加and
                }
                strWhere = "MachineSonName like '%" + SeachString + "%'";//加入条件
            }
            if (!String.IsNullOrEmpty(strWhere))//判断strwhere是否为空
            {
                strWhere += " and ";//不为空加and
            }
            strWhere += "MachineFatherID='" + Request.QueryString["ID"] + "'";
            RadGrid1.DataSource = MachineSonType_bll.GetList(0, strWhere, "MachineSonAddTime desc");//按添加时间降序排列 

        } 
        
        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Regex pattern1 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ]");//特殊字符正则判断
            string xxdz1 = RadTxtSearchName.Text.Trim();
            if (pattern1.IsMatch(xxdz1) == true)
            {
                RadAjaxManager1.Alert("请不要输入特殊字符!");
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
                if (Replacement_bll.GetList(" MachineSonID='" + id + " ' ").Tables[0].Rows.Count > 0)//判断是否有这个设备类别的代用机
                {
                    RadAjaxManager1.Alert("删除失败！");
                }
                else if (Declaration_bll.GetList(" MachineSonType='" + id + " ' ").Tables[0].Rows.Count > 0)//判断是否有这个类别的设备订单
                {
                    RadAjaxManager1.Alert("删除失败！");
                }
                else
                {
                    MachineSonType_bll.Delete(id);
                    select();
                    RadGrid1.Rebind();//刷新
                }
            }
        } 
        
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = MachineSonType_bll.GetList(0, "", " MachineSonAddTime desc");//按添加时间降序排列
            select();
        }

       

        protected void RadButton2_Click(object sender, EventArgs e)
        {

        }

        protected void RadButton3_Click(object sender, EventArgs e)
        {

        }
        
        protected void RadButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("./EquipmentType.aspx");//跳转
        }


        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {
                RadGrid1.Rebind();//刷新
            }
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            select();
            RadGrid1.Rebind();//刷新
        }

        protected void RadGrid1_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            select();
            RadGrid1.Rebind();//刷新
        }



    }
}