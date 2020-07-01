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
    public partial class RepairEdit : System.Web.UI.Page
    {
        Maticsoft.BLL.Declaration Declaration_Bll = new Maticsoft.BLL.Declaration();
        Maticsoft.Model.Declaration Declaration_Mol = new Maticsoft.Model.Declaration();
        Maticsoft.BLL.MachineFatherType MachineFather_Bll = new Maticsoft.BLL.MachineFatherType();
        Maticsoft.BLL.MachineSonType MachineSon_Bll = new Maticsoft.BLL.MachineSonType();
        Maticsoft.BLL.UnitsInfo UnitsInfo_Bll = new Maticsoft.BLL.UnitsInfo();

        public class ImgModel
        {
            public int ID { get; set; }
            public string imgUrl { get; set; }
        }

        public static List<ImgModel> ImgList = new List<ImgModel>() { };

        public static string path111;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Maticsoft.Model.Declaration modelDeclaration = Declaration_Bll.GetModel(Request.QueryString["ID"].ToString()); ;//引用id所在行的数据

                    DDMachineFather.Items.Clear();
                    DDMachineSon.Items.Clear();
                    DDMachineFather.Items.Add("请选择");
                    DDMachineSon.Items.Add("请选择");

                    DDMachineFather.DataSource = MachineFather_Bll.GetList("");
                    DDMachineFather.DataTextField = "MachineFatherName";
                    DDMachineFather.DataValueField = "MachineFatherID";
                    DDMachineFather.DataBind();
                    DDMachineFather.SelectedValue = modelDeclaration.MachineFatherType;

                    DDMachineSon.DataSource = MachineSon_Bll.GetList(" MachineFatherID ='" + DDMachineFather.SelectedValue + "'  ");
                    DDMachineSon.DataTextField = "MachineSonName";
                    DDMachineSon.DataValueField = "MachineSonID";
                    DDMachineSon.DataBind();
                    DDMachineSon.SelectedValue = modelDeclaration.MachineSonType;

                    TextBox1.Text = modelDeclaration.MachineName;//添加数据
                    TextBox2.Text = modelDeclaration.AssetsID;//添加数据
                    TextBox3.Text = modelDeclaration.Model;
                    if (modelDeclaration.OtherPart!="")
                    {
                        aDown.Visible = true;
                        aDown.HRef = modelDeclaration.OtherPart;//添加数据
                    }
                    if (modelDeclaration.ReplacementUse == "是")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }
                    //DDUnitName.DataSource = UnitsInfo_Bll.GetList("");
                    //DDUnitName.DataTextField = "UnitName";
                    //DDUnitName.DataValueField = "UnitID";
                    //DDUnitName.DataBind();
                    //DDUnitName.SelectedItem.Text = modelDeclaration.UnitName;
                    TextBox5.Text = modelDeclaration.Contact;
                    TextBox6.Text = modelDeclaration.ContactPhone;
                    if (modelDeclaration.DoorServer == "是")
                    {
                        RadioButton3.Checked = true;
                    }
                    else
                    {
                        RadioButton4.Checked = true;
                    }
                    myEditor.Value = modelDeclaration.BreakDown;


                    string st = modelDeclaration.CCC5;

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
                }
                else
                {
                    Response.Redirect("RepairBX.aspx");
                }
            }
        }

        protected void DDMachineFather_Load(object sender, EventArgs e)
        {
           
        }

        protected void DDMachineFather_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDMachineSon.Items.Clear();//清子类下拉框项目
            DDMachineSon.Items.Add("请选择");//给市下拉框添加请选择
            DDMachineSon.DataSource = MachineSon_Bll.GetList(" MachineFatherID ='" + DDMachineFather.SelectedValue + "'  ");
            DDMachineSon.DataTextField = "MachineSonName";
            DDMachineSon.DataValueField = "MachineSonID";
            DDMachineSon.DataBind();
            DDMachineSon.SelectedItem.Text = "请选择";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5-]{1,}$";//字母数字汉字-
            Regex rxname = new Regex(name);
            string phone = "^((13[0-9])|(14[5,7])|(15[0-3,5-9])|(17[0,3,5-8])|(18[0-9])|166|198|199|(147))\\d{8}$";
            Regex rxphone = new Regex(phone);
            if (DDMachineFather.SelectedValue == "请选择")
            {
                RadAjaxManager1.Alert("请选择设备类别!");
                return;
            }
            else if (DDMachineSon.SelectedValue == "请选择")
            {
                RadAjaxManager1.Alert("请选择设备子类别!");
                return;
            }
            else if (TextBox1.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入设备名称!");
                return;
            }
            else if (!rxname.IsMatch(TextBox1.Text))
            {
                RadAjaxManager1.Alert("设备名称错误!");
                return;
            }
            else if (TextBox2.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入资产序号!");
                return;
            }
            else if (!rxname.IsMatch(TextBox2.Text))
            {
                RadAjaxManager1.Alert("资产序号格式错误!");
                return;
            }
            else if (TextBox3.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入型号参数!");
                return;
            }
            else if (!rxname.IsMatch(TextBox3.Text))
            {
                RadAjaxManager1.Alert("型号参数格式错误!");
                return;
            }
            else if (RadioButton1.Checked == false && RadioButton2.Checked == false)
            {
                RadAjaxManager1.Alert("请选择是否使用代用机!");
                return;
            }
            //else if (DDUnitName.SelectedValue == "")
            //{
            //    RadAjaxManager1.Alert("请输入报修单位!");
            //    return;
            //}
            else if (TextBox5.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入联系人!");
                return;
            }
            else if (!rxname.IsMatch(TextBox5.Text))
            {
                RadAjaxManager1.Alert("联系人格式错误!");
                return;
            }
            else if (TextBox6.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入联系电话!");
                return;
            }
            else if (!rxname.IsMatch(TextBox6.Text))
            {
                RadAjaxManager1.Alert("联系电话格式错误!");
                return;
            }
            else if (RadioButton3.Checked == false && RadioButton4.Checked == false)
            {
                RadAjaxManager1.Alert("请选择是否需要上门服务!");
                return;
            }
            //else if (RadAsyncUpload1.FileFilters.ToString() == "")
            //{
            //    RadAjaxManager1.Alert("请添加其他附件!");
            //    return;
            //}
            else if (myEditor.Value == "")
            {
                RadAjaxManager1.Alert("请添加故障现象!");
                return;
            }

            if (!rxphone.IsMatch(TextBox6.Text))
            {
                RadAjaxManager1.Alert("手机格式错误!");
                return;
            }
            else
            {
                Declaration_Mol = Declaration_Bll.GetModel(Request.QueryString["ID"].ToString());
                Declaration_Mol.MachineFatherType = DDMachineFather.SelectedValue;
                Declaration_Mol.MachineSonType = DDMachineSon.SelectedValue;
                Declaration_Mol.MachineName = TextBox1.Text;
                Declaration_Mol.AssetsID = TextBox2.Text;
                Declaration_Mol.Model = TextBox3.Text;

                if (RadioButton1.Checked == true)
                {
                    Declaration_Mol.ReplacementUse = "是";
                }
                if (RadioButton2.Checked == true)
                {
                    Declaration_Mol.ReplacementUse = "否";
                }
                //Declaration_Mol.UnitName = UnitsInfo_Bll.GetModel(UsersInfo_Bll.GetModel(UsersInfo.UserID).UnitID).UnitName;
                Declaration_Mol.RepairTime = DateTime.Now;
                Declaration_Mol.Contact = TextBox5.Text;
                Declaration_Mol.ContactPhone = TextBox6.Text;
                if (RadioButton3.Checked == true)
                {
                    Declaration_Mol.ReplacementUse = "是";
                }
                if (RadioButton4.Checked == true)
                {
                    Declaration_Mol.ReplacementUse = "否";
                }
                Declaration_Mol.DeclarationState = "未上报";
                if (RadAsyncUpload1.FileFilters.Count > 0)//判断上传控件内的数量
                {
                    try
                    {
                        UploadedFile file = RadAsyncUpload1.UploadedFiles[0];
                        string path = "~/upload/" + file.FileName;
                        string paths = Server.MapPath(path);
                        path111 = path;
                        file.SaveAs(paths);
                        //RadAjaxManager1.Alert("添加成功");
                    }
                    catch
                    {
                        
                    }
                }
                string aa = "";

                foreach (ImgModel img in ImgList)
                {
                    aa += img.imgUrl + ";";
                }

                Declaration_Mol.CCC5 = aa;
                Declaration_Mol.OtherPart = path111;
                Declaration_Mol.BreakDown = myEditor.Value;
                Declaration_Bll.Update(Declaration_Mol);
                Response.Write("<script>alert('提交成功!');window.location.href='RepairBX.aspx'</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepairBX.aspx");
        }

        protected void rauFiles_FileUploaded(object sender, FileUploadedEventArgs e)
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
    }
}