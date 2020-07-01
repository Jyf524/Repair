using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class PartsChoice : System.Web.UI.Page
    {
        Maticsoft.BLL.PartType PartType_BLL=new Maticsoft.BLL.PartType();
        Maticsoft.Model .PartType PartType_Model=new Maticsoft.Model.PartType();
        Maticsoft.BLL.Part Part_BLL = new Maticsoft.BLL.Part();
        Maticsoft.Model.Part Part_Model= new Maticsoft.Model.Part();
        Maticsoft.BLL.PartPutRecord PartPutRecordBLL = new Maticsoft.BLL.PartPutRecord();
        Maticsoft.Model.PartPutRecord PartPutRecordModel = new Maticsoft.Model.PartPutRecord();
        public string SeachString
        {
            get { return ViewState["_SeachString"] == null ? string.Empty : ViewState["_SeachString"].ToString(); }
            set { ViewState["_SeachString"] = value; }
        }
        public string SeachString1
        {
            get { return ViewState["_SeachString1"] == null ? string.Empty : ViewState["_SeachString1"].ToString(); }
            set { ViewState["_SeachString1"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void select()
        {
            string ID = Request["id"];
            string OID = "";
            if (!String.IsNullOrEmpty(SeachString))//判断标题是否为空
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += "  PartType.PartTypeID= '" + SeachString + "' ";//加入条件
            }

            if (!String.IsNullOrEmpty(SeachString1))
            {
                if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
                {
                    OID += " and ";//不为空加and
                }
                OID += "PartPutRecord.PartID = '" + SeachString1 + "'";//加入条件
            }
            if (!String.IsNullOrEmpty(OID))//判断strwhere是否为空
            {
                OID += " and ";//不为空加and
            }
            OID += "PartPutRecord.PartPutNumber >0 ";//加入条件
            RadListView1.DataSource = PartPutRecordBLL.GetListyyy(0, OID, "PartPutTime");
            if (PartPutRecordBLL.GetListyyy(0, OID, "PartPutTime ").Tables[0].Rows.Count <= 5)
            {
                RadDataPager1.Visible = false;
            }
            else
            {
                RadDataPager1.Visible = true;
            }
        }
        protected void Command(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {

        }
        protected void RadListView2_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            RadListView2.DataSource = PartType_BLL.GetList("(select COUNT(*) from Part where Part.PartTypeID=PartType.PartTypeID)>0");//赋值排除没有子类的父类
        }

        protected void RadListView2_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            string id = e.Item.OwnerListView.DataKeyValues[e.Item.OwnerListView.DataKeyValues.Count - 1]["PartTypeID"].ToString();
            Telerik.Web.UI.RadListView RadListView3 = e.Item.FindControl("RadListView3") as Telerik.Web.UI.RadListView;
            if (RadListView3 != null)
            {
                RadListView3.DataSource = Part_BLL.GetList(" PartTypeID ='" + id + "' ");
                RadListView3.DataBind();
            }//根据父类显示子类
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            SeachString = "";
            SeachString1 = "";//清空查询条件
            select();//调用方法
            RadListView1.Rebind();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            SeachString = "";
            SeachString1 = ((LinkButton)sender).CommandArgument.ToString();//赋值
            select();
            RadListView1.Rebind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SeachString1 = "";
            SeachString = ((LinkButton)sender).CommandArgument.ToString();
            select();
            RadListView1.Rebind();
        }

        protected void RadListView1_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            select();
        }

        protected void RadListView1_PageSizeChanged(object sender, Telerik.Web.UI.RadListViewPageSizeChangedEventArgs e)
        {
            select();
            RadListView1.Rebind();
        }

        protected void RadListView1_PageIndexChanged(object sender, Telerik.Web.UI.RadListViewPageChangedEventArgs e)
        {
            select();
            RadListView1.Rebind();
        }

        protected void RadListView1_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            partsCost si = new partsCost();
            if (e.CommandName == "tian")//判断是不是添加
            {

                PartPutRecordModel = PartPutRecordBLL.GetModelyyy(e.CommandArgument.ToString());
                if ((partsChoice.partsChoiceList.Where(x => x.PartPutRecordID == PartPutRecordModel.PartPutRecordID).Count() == 0))//判断list里面有没有这条数据
                {

                    Part_Model = Part_BLL.GetModel(PartPutRecordModel.PartID);//数据库查找信息
                    si.PartID = PartPutRecordModel.PartID;//配件ID（子）
                    si.Partmoney = PartPutRecordModel.PartPrice.ToString();//价格
                    si.PartName = Part_Model.PartName;//名字
                    si.PartPicture = PartPutRecordModel.PartPicture;//图片
                    si.PartPrice = PartPutRecordModel.PartPrice.ToString();//价格
                    si.PartUseNumber = "1";//数量
                    si.PartPutNumber = PartPutRecordModel.PartPutNumber.ToString();//库存
                    si.PartPutRecordID = PartPutRecordModel.PartPutRecordID;//配件入库ID
                    partsChoice.partsChoiceList.Add(si);//加入list
                    RadAjaxManager1.Alert("添加成功！");
                    //    return;

                }
                else
                {
                    RadAjaxManager1.Alert("已经添加过该配件！");
                }
                 
                }
            
        }

        protected void RadListView1_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {

            
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");
        }

        protected void RadButton3_Click(object sender, EventArgs e)
        {
            partsChoice.partsChoiceList.Clear();
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");
        }
    }
}