using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class MaintenanceListLS : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration DeclarationBLL = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration DeclarationModel = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.Replacement ReplacementBLL = new Maticsoft.BLL.Replacement();
        Maticsoft.Model.Replacement ReplacementModel = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.ReplacementRecord ReplacementRecordBLL = new Maticsoft.BLL.ReplacementRecord();
        Maticsoft.Model.ReplacementRecord ReplacementRecordModel = new Maticsoft.Model.ReplacementRecord();
        Maticsoft.BLL.PartUseRecord PartUseRecord_BLL = new Maticsoft.BLL.PartUseRecord();
        Maticsoft.Model.PartUseRecord PartUseRecord_Model = new Maticsoft.Model.PartUseRecord();
        Maticsoft.BLL.PartPutRecord PartPutRecordBLL = new Maticsoft.BLL.PartPutRecord();
        Maticsoft.Model.PartPutRecord PartPutRecordModel = new Maticsoft.Model.PartPutRecord();
        public decimal aaa = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request["id"]))
                {
                    if (!IsPostBack)
                    {
                        RadButton5.Attributes["onclick"] = "OpenAddPro();return false;";//添加
                        DeclarationModel = DeclarationBLL.GetModel(Request["id"].ToString());
                        Label1.Text = DeclarationModel.TeacherName;//老师
                        Label2.Text = DeclarationModel.RepairerName;//学生
                        myEditor.InnerText = DeclarationModel.RepairPlan;//故障诊断
                        RadDatePicker1.SelectedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));//完修时间
                        Label9.Text = "0";
                        if (partsChoice.partsChoiceList.Count <= 5)
                        {
                            RadDataPager1.Visible = false;
                        }
                        else
                        {
                            RadDataPager1.Visible = true;
                        }
                    }


                }
                else
                {
                    RadAjaxManager1.Redirect("RepairListLS.aspx");
                }
                RadListView1.Rebind();
            }
        }

        protected void RadButton3_Click(object sender, EventArgs e)
        {

        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            DeclarationModel=DeclarationBLL.GetModel(Request["id"].ToString());
            int i = 0;
            if (String.IsNullOrEmpty(myEditor.InnerText))
            {
                RadAjaxManager1.Alert("请输入故障诊断及维修方案");
                return;
            }
            else
            {
                DeclarationModel.RepairPlan = myEditor.InnerText;
            }
            DeclarationModel.ResultTime = RadDatePicker1.SelectedDate;
            string search2 = TextBox2.Text;
            string xxdz2 = TextBox2.Text.Trim();
            Regex pattern2 = new Regex("^[0-9]+([.]{1}[0-9]+){0,1}$");
            if (TextBox2.Text == "")
            {
                RadAjaxManager1.Alert("请输入人工费用");
                return;
            }
            else if ((pattern2.IsMatch(xxdz2) == false))
            {
                RadAjaxManager1.Alert("请输入正确的人工费用");//判断输入的人工费是否正确

                return;
            }
            else
            {
                DeclarationModel.PersonMoney = Convert.ToDecimal(TextBox2.Text);
            }

            string search3 = TextBox1.Text;
            string xxdz3 = TextBox1.Text.Trim();
            Regex pattern3 = new Regex("^[0-9]+([.]{1}[0-9]+){0,1}$");
            if (TextBox1.Text == "")
            {
                RadAjaxManager1.Alert("请输入维修费用");
                return;
            }
            else if ((pattern3.IsMatch(xxdz3) == false))
            {
                RadAjaxManager1.Alert("请输入正确的维修费用");//判断维修费是否正确
                return;
            }
            else
            {
                DeclarationModel.RepairPrice = Convert.ToDecimal(TextBox1.Text);
            }
            DeclarationModel.PartPrice = Label5.Text;
            DeclarationModel.Result = "完修";
            if (DeclarationModel.DeclarationState == "维修基地维修中(返修)")
            {
                DeclarationModel.DeclarationState = "维修基地已完修(返修)";
            }
            else{
            DeclarationModel.DeclarationState = "维修基地已完修";
            }//根据状态的不同来改变不同的维修状态

            DeclarationBLL.Update(DeclarationModel);
            foreach (var item in partsChoice.partsChoiceList)//循环传值
            {
                PartPutRecordModel = PartPutRecordBLL.GetModel(item.PartPutRecordID);
                PartPutRecordModel.PartPutNumber = PartPutRecordModel.PartPutNumber - Convert.ToInt32(item.PartUseNumber);//减掉库存数量
                PartPutRecordBLL.Update(PartPutRecordModel);//update更新
                PartUseRecord_Model.PartUseRecordID = DateTime.Now.ToString("yyyyMMddhhmmss") + i.ToString();//ID
                PartUseRecord_Model.UserID = DeclarationModel.UserID;//用户
                PartUseRecord_Model.Partmoney = Convert.ToDecimal(item.Partmoney);//金额
                PartUseRecord_Model.RepairID = Request["id"].ToString();//维修单ID
                PartUseRecord_Model.PartUseNumber = Convert.ToInt32(item.PartUseNumber);//数量
                PartUseRecord_Model.PartID = item.PartID;//配件类别ID
                PartUseRecord_Model.tt2 = item.PartPutRecordID;//配件ID
                PartUseRecord_Model.PartUseTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));//时间
                i++;//在配件使用上加入数据
                PartUseRecord_BLL.Add(PartUseRecord_Model);
            }
            partsChoice.partsChoiceList.Clear();//清空list
            Response.Redirect("RepairListLS.aspx");//跳转
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            partsChoice.partsChoiceList.Clear();
            Response.Redirect("RepairListLS.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string search2 = TextBox2.Text;
            string xxdz2 = TextBox2.Text.Trim();
            Regex pattern2 = new Regex("^[0-9]+([.]{1}[0-9]+){0,1}$");
            if (pattern2.IsMatch(xxdz2) == false)
            {
                RadAjaxManager1.Alert("请输入人工费用");//判断数据是否正确
                return;
            }
            else
            {
                TextBox1.Text = Convert.ToString(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text));
                Label9.Text = Convert.ToString(Convert.ToDouble(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text)) * 0.95);//根据人工费的变化来改变其他数据
            }
        }

        protected void RadListView1_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {

            RadListView1.DataSource = partsChoice.partsChoiceList.OrderBy(x => x.PartID);//绑值
            foreach (var item in partsChoice.partsChoiceList)
            {
                aaa += Convert.ToDecimal(item.Partmoney);
            }
            if (partsChoice.partsChoiceList.Count <= 5)
            {
                RadDataPager1.Visible = false;
            }
            else
            {
                RadDataPager1.Visible = true;
            }
            Label5.Text = aaa.ToString();//合计
            TextBox1.Text = Convert.ToString(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text));
            Label9.Text = Convert.ToString(Convert.ToDouble(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text)) * 0.95);//计算值

        }

        protected void RadListView1_PageIndexChanged(object sender, Telerik.Web.UI.RadListViewPageChangedEventArgs e)
        {

        }

        protected void RadListView1_PageSizeChanged(object sender, Telerik.Web.UI.RadListViewPageSizeChangedEventArgs e)
        {

        }

        protected void RadListView1_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            partsCost si = new partsCost();//list赋值
            if (e.CommandName == "Delete")
            {
                string i = e.CommandArgument.ToString();
                si = partsChoice.partsChoiceList.Where(x => x.PartPutRecordID == i).SingleOrDefault();
                partsChoice.partsChoiceList.Remove(partsChoice.partsChoiceList.Where(x => x.PartPutRecordID == i).SingleOrDefault());//删值
                //if (ShoppingCar.ShoppingList.Count() < 5)
                //{
                //    RadDataPager1.Visible = false;
                //}
                //else
                //{
                //    RadDataPager1.Visible = true;
                //}
                if (partsChoice.partsChoiceList.Count <= 5)
                {
                    RadDataPager1.Visible = false;
                }
                else
                {
                    RadDataPager1.Visible = true;
                }
                RadListView1.Rebind();//刷新
            }
            if (e.CommandName == "add")
            {
                string id = e.CommandArgument.ToString();
                si = partsChoice.partsChoiceList.Where(x => x.PartPutRecordID == id).SingleOrDefault();//找到数据
                //CommodityModel = CommodityBLL.GetModel(si.GoodsID);
                if (Convert.ToInt32(si.PartUseNumber) + 1 <= Convert.ToInt32(si.PartPutNumber))//数量+1是否超过库存
                {
                    int a = Convert.ToInt32(si.PartUseNumber) + 1;
                    si.PartUseNumber = a.ToString();//赋值
                    si.Partmoney = Convert.ToString(Convert.ToDecimal(si.PartPrice) * Convert.ToDecimal(si.PartUseNumber));
                    partsChoice.partsChoiceList.Remove(partsChoice.partsChoiceList.Where(x => x.PartPutRecordID == id).SingleOrDefault());//删除
                    partsChoice.partsChoiceList.Add(si);//添加
                    RadListView1.Rebind();//刷新

                }
                else
                {
                    RadAjaxManager1.Alert("已经最大了");
                }

            }
            if (e.CommandName == "jian")
            {
                string id = e.CommandArgument.ToString();
                si = partsChoice.partsChoiceList.Where(x => x.PartPutRecordID == id).SingleOrDefault();
                //CommodityModel = CommodityBLL.GetModel(si.GoodsID);
                if (Convert.ToInt32(si.PartUseNumber) - 1 > 0)
                {
                    int a = Convert.ToInt32(si.PartUseNumber) - 1;
                    si.PartUseNumber = a.ToString();
                    si.Partmoney = Convert.ToString(Convert.ToDecimal(si.PartPrice) * Convert.ToDecimal(si.PartUseNumber));
                    partsChoice.partsChoiceList.Remove(partsChoice.partsChoiceList.Where(x => x.PartPutRecordID == id).SingleOrDefault());
                    partsChoice.partsChoiceList.Add(si);
                    RadListView1.Rebind();

                }
                else
                {
                    RadAjaxManager1.Alert("已经最小的");
                }
            }
        }

        protected void RadListView1_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            //Telerik.Web.UI.RadNumericTextBox RadNum = e.Item.FindControl("RadNumericTextBox") as Telerik.Web.UI.RadNumericTextBox;
            //RadNum.Text = PartUseRecord_Model.PartUseNumber.ToString();
        }

        protected void RadButton5_Click(object sender, EventArgs e)
        {
            RadButton5.Attributes["onclick"] = "OpenAddPro();return false;";//添加
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            switch (e.Argument)
            {
                case "Rebind":
                    RadListView1.DataSource = partsChoice.partsChoiceList.OrderBy(x => x.PartID);
                    foreach (var item in partsChoice.partsChoiceList)
                    {
                        aaa += Convert.ToDecimal(item.Partmoney);
                    }
                    if (partsChoice.partsChoiceList.Count <= 5)
                    {
                        RadDataPager1.Visible = false;
                    }
                    else
                    {
                        RadDataPager1.Visible = true;
                    }
                    Label5.Text = aaa.ToString();
                    TextBox1.Text = Convert.ToString(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text));
                    Label9.Text = Convert.ToString(Convert.ToDouble(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text)) * 0.95);
                    RadListView1.Rebind();
                    break;
            }
        }
        
        //protected void RadAjaxManager1_AjaxRequest1(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        //{
        //    switch (e.Argument)
        //    {
        //        case "Rebind":
        //            RadListView1.DataSource = partsChoice.partsChoiceList.OrderBy(x => x.PartID);
        //            RadListView1.DataBind();
        //            foreach (var item in partsChoice.partsChoiceList)
        //            {
        //                aaa += Convert.ToDecimal(item.Partmoney);
        //            }
        //            Label5.Text = aaa.ToString();
        //            TextBox1.Text = Convert.ToString(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text));
        //            Label9.Text = Convert.ToString(Convert.ToDouble(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text)) * 0.95);

        //            break;
        //    }
        //}

        //protected void RadButton3_Click1(object sender, EventArgs e)
        //{
        //    RadListView1.DataSource = partsChoice.partsChoiceList.OrderBy(x => x.PartID);
        //    foreach (var item in partsChoice.partsChoiceList)
        //    {
        //        aaa += Convert.ToDecimal(item.Partmoney);
        //    }
        //    Label5.Text = aaa.ToString();
        //    TextBox1.Text = Convert.ToString(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text));
        //    Label9.Text = Convert.ToString(Convert.ToDouble(Convert.ToDecimal(Label5.Text) + Convert.ToDecimal(TextBox2.Text)) * 0.95);
        //    RadListView1.DataBind();
        //}
    }
}