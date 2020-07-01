using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.IO;
using System.Text.RegularExpressions;

namespace RepairCenterY.BackManagement
{
    public partial class SubstitutionDetails : System.Web.UI.Page
    {

        Maticsoft.Model.Replacement molr = new Maticsoft.Model.Replacement();
        Maticsoft.BLL.Replacement bllr = new Maticsoft.BLL.Replacement();

        Maticsoft.Model.MachineFatherType molmf = new Maticsoft.Model.MachineFatherType();
        Maticsoft.BLL.MachineFatherType bllmf = new Maticsoft.BLL.MachineFatherType();

        Maticsoft.Model.MachineSonType molms = new Maticsoft.Model.MachineSonType();
        Maticsoft.BLL.MachineSonType bllms = new Maticsoft.BLL.MachineSonType();

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
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Maticsoft.Model.Replacement molr = bllr.GetModel(Request.QueryString["ID"].ToString());//引用id所在行的数据
                    if (molr == null)
                    {
                        Response.Write("<script>window.location.href='~/BackLogin.aspx'</script>");
                    }

                    Maticsoft.Model.MachineFatherType molmf = bllmf.GetModel(molr.MachineFatherID);
                    Maticsoft.Model.MachineSonType molms = bllms.GetModel(molr.MachineSonID);

                    Label1.Text = molr.ReplacementID;
                    Label2.Text = molr.ReplacementModel;
                    Label3.Text = molr.ReplacementName;
                    Label4.Text = molmf.MachineFatherName + "-" + molms.MachineSonName;
                    Label5.Text = molr.ReplacementState;
                    Label6.Text = molr.ReplacementAddTime.ToString();

                    string st = molr.ReplacementPicture;

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
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BackManagement/SubstituteMachine.aspx");
        }

        protected void RadListView1_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            RadListView1.DataSource = ImgList;
        }
    }
}