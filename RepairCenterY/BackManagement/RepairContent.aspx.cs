using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class RepairContent : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration Declaration_Bll = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration Declaration_Mol = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.MachineFatherType MachineFather_Bll = new Maticsoft.BLL.MachineFatherType();
        Maticsoft.Model.MachineFatherType MachineFather_Mol = new Maticsoft.Model.MachineFatherType();
        Maticsoft.BLL.MachineSonType MachineSon_Bll = new Maticsoft.BLL.MachineSonType();
        Maticsoft.Model.MachineSonType MachineSon_Mol = new Maticsoft.Model.MachineSonType();

        public class ImgModel
        {
            public int ID { get; set; }
            public string imgUrl { get; set; }
        }

        public static List<ImgModel> ImgList = new List<ImgModel>() { };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Maticsoft.Model.Declaration modelDeclaration = Declaration_Bll.GetModel(Request.QueryString["ID"].ToString()); ;//引用id所在行的数据
                    if (modelDeclaration.ReplacementID != "")
                    {
                        Label4.Text = modelDeclaration.ReplacementID;
                        ReplacementID.Visible = true;
                    }
                    else
                    {
                        ReplacementID.Visible = false;
                    
                    }
                    Label14.Text = MachineFather_Bll.GetModel(modelDeclaration.MachineFatherType).MachineFatherName;
                    Label1.Text = modelDeclaration.MachineName;//添加数据
                    Label2.Text = modelDeclaration.AssetsID;//添加数据
                    Label3.Text = modelDeclaration.Model;//添加数据
                    if (modelDeclaration.OtherPart != "")
                    {
                        aDown.HRef = modelDeclaration.OtherPart;//添加数据
                    }
                    else
                    {
                        aDown.InnerText = "暂无";
                    
                    }
                    if (modelDeclaration.ReplacementUse == "是")
                    {
                        Label6.Text = "是";
                    }
                    else
                    {
                        Label6.Text = "否";
                    }
                    Label7.Text = modelDeclaration.UnitName;
                    Label8.Text = modelDeclaration.RepairTime.ToString();
                    Label9.Text = modelDeclaration.Contact;
                    Label10.Text = modelDeclaration.ContactPhone;
                    if (modelDeclaration.DoorServer == "是")
                    {
                        Label11.Text = "是";
                    }
                    else
                    {
                        Label11.Text = "否";
                    }
                    if (modelDeclaration.RepairerName == "")
                    {
                        RepairID.Visible = false;
                    }
                    else
                    {
                        Label12.Text = modelDeclaration.RepairerName;
                    }
                    Label13.Text = modelDeclaration.DeclarationState;
                    Label5.Text = modelDeclaration.BreakDown;
                    string st = modelDeclaration.CCC5;

                    string[] sop = st.Split(';');

                    ImgList.Clear();

                    for (int i = 0; i < sop.Length - 1; i++)
                    {
                        ImgModel img = new ImgModel();
                        img.ID = ImgList.Count + 1;
                        img.imgUrl = sop[i];
                        ImgList.Add(img);
                        RadListView1.Rebind();
                    }
                }
                else
                {
                    Response.Redirect("RepairBX.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepairBX.aspx");
        }

        protected void RadListView1_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            RadListView1.DataSource = ImgList;
        }
    }
}