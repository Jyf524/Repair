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
    public partial class SubstituteMachineEdit : System.Web.UI.Page
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

                    if (molr.ReplacementState == "已借出")
                    {
                        Response.Write("<script>alert('已借出，无法修改!');window.location.href='SubstituteMachine.aspx'</script>");
                        return;
                    }
                    if (molr.ReplacementState == "已报废")
                    {
                        Response.Write("<script>alert('已报废，无法修改!');window.location.href='SubstituteMachine.aspx'</script>");
                        return;
                    }

                    if (molr == null)
                    {
                        Response.Write("<script>window.location.href='~/BackLogin.aspx'</script>");
                    }

                    MachineFather.Items.Clear();
                    MachineSon.Items.Clear();
                    MachineFather.Items.Add("请选择...");
                    MachineSon.Items.Add("请选择...");

                    MachineFather.DataSource = bllmf.GetList("");
                    MachineFather.DataTextField = "MachineFatherName";
                    MachineFather.DataValueField = "MachineFatherID";
                    MachineFather.DataBind();

                    MachineSon.DataSource = bllms.GetList(" MachineFatherID ='" + MachineFather.SelectedValue + "'  ");
                    MachineSon.DataTextField = "MachineSonName";
                    MachineSon.DataValueField = "MachineSonID";
                    MachineSon.DataBind();

                    Maticsoft.Model.MachineFatherType molmf = bllmf.GetModel(molr.MachineFatherID);
                    Maticsoft.Model.MachineSonType molms = bllms.GetModel(molr.MachineSonID);

                    ReplacementName.Text = molr.ReplacementName;
                    ReplacementModel.Text = molr.ReplacementModel;
                    MachineFather.SelectedValue = molmf.MachineFatherID;

                    MachineSon.Items.Clear();//清子类下拉框项目
                    MachineSon.Items.Add("请选择...");//给市下拉框添加请选择
                    MachineSon.DataSource = bllms.GetList(" MachineFatherID ='" + MachineFather.SelectedValue + "'  ");
                    MachineSon.DataTextField = "MachineSonName";
                    MachineSon.DataValueField = "MachineSonID";
                    MachineSon.DataBind();

                    MachineSon.SelectedValue = molms.MachineSonID;
                    //DropDownList1.SelectedValue = molr.ReplacementState;

                    string st = molr.ReplacementPicture;

                    string[] sop = st.Split(';');

                    ImgList.Clear();

                    for (int i = 0; i < sop.Length - 1; i++)        //修改图片显示
                    {
                        ImgModel img = new ImgModel();
                        img.ID = ImgList.Count + 1;
                        img.imgUrl = sop[i];
                        ImgList.Add(img);
                        RadListView1.Rebind();
                    }

                    //imgPic.ImageUrl = molr.ReplacementPicture;
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);

            if (ReplacementName.Text == "")
            {
                Response.Write("<script>alert('请输入名称！')</script>");
                return;
            }
            if ((bllr.GetList("ReplacementName ='" + ReplacementName.Text + "'").Tables[0].Rows.Count) > 1)
            {
                Response.Write("<script>alert('已存在该名称！')</script>");
                return;
            }
            if (ReplacementModel.Text == "")
            {
                Response.Write("<script>alert('请输入型号！')</script>");
                return;
            }
            if (MachineFather.SelectedValue == "请选择")
            {
                Response.Write("<script>alert('请选择父类！')</script>");
                return;
            }
            if (MachineSon.SelectedValue == "请选择")
            {
                Response.Write("<script>alert('请选择子类！')</script>");
                return;
            }
            //if (DropDownList1.SelectedValue == "请选择")
            //{
            //    Response.Write("<script>alert('请选择状态！')</script>");
            //    return;
            //}
            if (!rxname.IsMatch(ReplacementName.Text.Trim()) && ReplacementName.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("不能输入特殊字符!");
                return;
            }
            if (!rxname.IsMatch(ReplacementModel.Text.Trim()) && ReplacementModel.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("不能输入特殊字符!");
                return;
            }
            //if (imgPic.ImageUrl == "")
            //{
            //    Response.Write("<script>alert('请选择图片！')</script>");
            //    return;
            //}
            //if (DropDownList1.SelectedValue == "已报废" && TBBF.Text == "")
            //{
            //    Response.Write("<script>alert('请输入报废原因！')</script>");
            //    return;
            //}
            else
            {
                Maticsoft.Model.Replacement molr = bllr.GetModel(Request.QueryString["ID"].ToString());
                molr.ReplacementName = ReplacementName.Text.Trim();
                molr.ReplacementModel = ReplacementModel.Text.Trim();
                molr.MachineFatherID = MachineFather.SelectedValue;
                molr.MachineSonID = MachineSon.SelectedValue;
                if (YES1.Checked == true)
                {
                    molr.ReplacementState = "已报废";
                }
                else
                {
                    molr.ReplacementState = "未借出";
                }
                //molr.ReplacementState = DropDownList1.SelectedValue;
                //molr.ReplacementPicture = imgPic.ImageUrl;

                //ImgModel img = new ImgModel();

                string aa = "";

                foreach (ImgModel img in ImgList)
                {
                    aa += img.imgUrl + ";";
                }

                molr.ReplacementPicture = aa;

                //if (DropDownList1.SelectedValue == "已报废")
                //{
                //    molr.FFF1 = TBBF.Text;
                //}
                if (YES1.Checked == true)
                {
                    molr.FFF1 = TBBF.Text;
                }

                bllr.Update(molr);
                Response.Write("<script>alert('修改成功!');window.location.href='SubstituteMachine.aspx'</script>");
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BackManagement/SubstituteMachine.aspx");
        }

        protected void rauFiles_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            string filepath = "";
            if (ImgList.Count >= 5)
            {
                RadAjaxManager1.Alert("最多上传5张图！");
                return;
            }
            if (rauFiles.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in rauFiles.UploadedFiles)
                {
                    string uploadPath = "/UpLoad/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "/";
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(Server.MapPath(uploadPath));
                    }
                    string name = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".png";
                    filepath = Server.MapPath(uploadPath) + name;
                    file.SaveAs(filepath);
                    ImgModel img = new ImgModel();
                    img.ID = ImgList.Count + 1;
                    img.imgUrl = uploadPath + name;
                    ImgList.Add(img);
                    RadListView1.Rebind();
                }
                //imgPic.ImageUrl = uploadPath + name;
            }
        }

        protected void MachineFather_SelectedIndexChanged(object sender, EventArgs e)
        {
            MachineSon.Items.Clear();//清子类下拉框项目
            MachineSon.Items.Add("请选择");//给市下拉框添加请选择
            MachineSon.DataSource = bllms.GetList(" MachineFatherID ='" + MachineFather.SelectedValue + "'  ");
            MachineSon.DataTextField = "MachineSonName";
            MachineSon.DataValueField = "MachineSonID";
            MachineSon.DataBind();
        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownList1.SelectedValue == "已报废")
        //    {
        //        Result.Visible = true;
        //    }
        //    else
        //    {
        //        Result.Visible = false;
        //    }
        //}

        protected void RadListView1_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            RadListView1.DataSource = ImgList;
        }

        protected void RadListView1_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "Delete")
            {
                ImgModel img = new ImgModel();
                img = ImgList.Where(x => x.ID == id).SingleOrDefault();
                ImgList.Remove(img);
                RadListView1.Rebind();
            }
        }

        protected void NO1_CheckedChanged1(object sender, EventArgs e)
        {
            Result.Visible = false;
        }

        protected void YES1_CheckedChanged1(object sender, EventArgs e)
        {
            Result.Visible = true;
        }
    }
}