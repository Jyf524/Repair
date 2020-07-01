using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RepairCenterY.BackManagement
{
    public partial class RepairDetailedLS : System.Web.UI.Page
    {
        Maticsoft.BLL.UsersInfo bllUsersInfo = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo modelUsersInfo = new Maticsoft.Model.UsersInfo();
        Maticsoft.BLL.Declaration bllDeclaration = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration modelDeclaration = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.MachineFatherType bllMachineFatherType = new Maticsoft.BLL.MachineFatherType();
        Maticsoft.Model.MachineFatherType modelMachineFatherType = new Maticsoft.Model.MachineFatherType();
        Maticsoft.BLL.MachineSonType bllMachineSonType = new Maticsoft.BLL.MachineSonType();
        Maticsoft.Model.MachineSonType modelMachineSonType = new Maticsoft.Model.MachineSonType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                modelDeclaration = bllDeclaration.GetModel(Request.QueryString["ID"]);
                Label1.Text = modelDeclaration.ListID;
                Label5.Text = modelDeclaration.AssetsID;//资产序号
                Label13.Text = modelDeclaration.BreakDown;//故障现象
                Label2.Text = modelDeclaration.Contact;//联系人
                Label3.Text = modelDeclaration.ContactPhone;//联系人电话
                Label6.Text = modelDeclaration.DoorServer;//是否上门服务

                Label4.Text = modelDeclaration.MachineName;//设备名称
                Label7.Text = modelDeclaration.Model;//型号参数
                //lblUnitName.Text = modelDeclaration.UnitName;//报修单位
                if (modelDeclaration.OtherPart == "")
                {
                    Label9.Text = "无";
                }
                else
                {
                    Label9.Text = modelDeclaration.OtherPart;//其他附件
                    down.HRef = modelDeclaration.OtherPart;//其他附件
                }
                Label11.Text=modelDeclaration.DeviceDescription;
                Label12.Text=modelDeclaration.FaultPrediction;
                Label8.Text = modelDeclaration.EstimateTime.Value.ToString("yyyy-MM-dd");

                string yh = "UserIdentity='学生'";
                DataSet ds = bllUsersInfo.GetList(yh);
                RadListBox1.Items.Clear();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    RadListBoxItem liitem = new RadListBoxItem(item["UserRealName"].ToString(), item["UserID"].ToString());
                    RadListBox1.Items.Add(liitem);
                }

            }
            else
            {
                Response.Redirect("RepairListLS.aspx");
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            string a="", b="";
            modelDeclaration = bllDeclaration.GetModel(Request.QueryString["ID"]);
            foreach (RadListBoxItem item in RadListBox2.Items)
            {
                if (!String.IsNullOrEmpty(a))//判断是否为空不为空就加，分割
                {
                    a+= ",";
                }
                a += item.Value;
                modelDeclaration.RepairerID = a;
                if (!String.IsNullOrEmpty(b))
                {
                   b += ",";
                }
                b += item.Text;
                modelDeclaration.RepairerName=b;
            }
            bllDeclaration.Update(modelDeclaration);//分配赋值
            Response.Redirect("RepairListLS.aspx");
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepairListLS.aspx");
        }

    }
}