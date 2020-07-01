using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RepairCenterY.BackManagement
{
    public partial class PartsWarehousing : System.Web.UI.Page
    {
        Maticsoft.BLL.PartType bllPartType = new Maticsoft.BLL.PartType();
        Maticsoft.Model.PartType modelPartType = new Maticsoft.Model.PartType();
        Maticsoft.BLL.Part bllPart = new Maticsoft.BLL.Part();
        Maticsoft.Model.Part modelPart = new Maticsoft.Model.Part();
        Maticsoft.BLL.PartPutRecord bllPartPutRecord = new Maticsoft.BLL.PartPutRecord();
        Maticsoft.Model.PartPutRecord modelPartPutRecord = new Maticsoft.Model.PartPutRecord();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //两个下拉框联动
                ddlPartTypeName.Items.Clear();
                ddlPartName.Items.Clear();
                ddlPartTypeName.Items.Add("请选择");
                ddlPartName.Items.Add("请选择");

                ddlPartTypeName.DataSource = bllPartType.GetList("");
                ddlPartTypeName.DataTextField = "PartTypeName";
                ddlPartTypeName.DataValueField = "PartTypeID";
                ddlPartTypeName.DataBind();

                ddlPartName.DataSource = bllPart.GetList(" PartTypeID ='" + ddlPartTypeName.SelectedValue + "'  ");
                ddlPartName.DataTextField = "PartName";
                ddlPartName.DataValueField = "PartID";
                ddlPartName.DataBind();
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href='WarehousingDetails.aspx'</script>");
        }

        protected void ddlPartTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {

                ddlPartName.Items.Clear();//清子类下拉框项目
                ddlPartName.Items.Add("请选择");//给市下拉框添加请选择
                ddlPartName.DataSource = bllPart.GetList(" PartTypeID ='" + ddlPartTypeName.SelectedValue + "'  ");
                ddlPartName.DataTextField = "PartName";
                ddlPartName.DataValueField = "PartID";
                ddlPartName.DataBind();
                ddlPartName.SelectedItem.Text = "请选择";
            
        }

        protected void btnok_Click1(object sender, EventArgs e)
        {
            string name = "^[a-zA-Z0-9.]{1,}$";//字母数字.
            Regex rxname = new Regex(name);
            string shuzi = "^[0-9]{1,}$";//数字
            Regex rxshuzi = new Regex(shuzi);
            string jiage = "^[0-9]+(.[0-9]{2})?$";//价格
            Regex rxjiage = new Regex(jiage);
            
            if (ddlPartTypeName.SelectedItem.Text == "请选择")
            {
                RadAjaxManager1.Alert("请选择配件类别!");
                return;
            }
            if (ddlPartName.SelectedItem.Text == "请选择")
            {
                RadAjaxManager1.Alert("请选择配件!");
                return;
            }
            if (ddlPartSource.SelectedItem.Text == "请选择")
            {
                RadAjaxManager1.Alert("请选择配件来源!");
                return;
            }
            if (txtPartModel.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入配件规格!");
                return;
            }
            if (txtPartPutNumber.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入数量!");
                return;
            }
            if (txtPartPrice.Text.Trim() == "")
            {
                RadAjaxManager1.Alert("请输入配件价格!");
                return;
            }
            if (imgPic.ImageUrl == "")
            {
                RadAjaxManager1.Alert("请选择配件图片!");
                return;
            }
            if (!rxname.IsMatch(txtPartModel.Text.Trim()) && txtPartModel.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("配件规格不能输入特殊字符!");
                return;
            }
            if (!rxshuzi.IsMatch(txtPartPutNumber.Text.Trim()) && txtPartPutNumber.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("数量输入错误!");
                return;
            }
            if (!rxjiage.IsMatch(txtPartPrice.Text.Trim()) && txtPartPrice.Text.Trim() != "")
            {
                RadAjaxManager1.Alert("价格格式错误!");
                return;
            }
            modelPartPutRecord.PartPutRecordID = DateTime.Now.ToString("yyyyMMddHHmmss");//赋值
            modelPartPutRecord.PartID = ddlPartName.SelectedValue;//赋值
            modelPartPutRecord.PartSource = ddlPartSource.SelectedItem.Text;//赋值
            modelPartPutRecord.PartModel = txtPartModel.Text;//赋值
            modelPartPutRecord.PartPutNumber = Convert.ToInt32(txtPartPutNumber.Text);//赋值
            modelPartPutRecord.PartPrice = Convert.ToDecimal(txtPartPrice.Text);//赋值
            modelPartPutRecord.PartPicture = imgPic.ImageUrl;//图片
            modelPartPutRecord.PartPutTime = DateTime.Now;//赋值
            bllPartPutRecord.Add(modelPartPutRecord);//添加数据
            Response.Write("<script>alert('添加成功!');window.location.href='WarehousingDetails.aspx'</script>");
        }
        //上传图片
        protected void rauFiles_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            string filepath = "";
            if (rauFiles.UploadedFiles.Count > 0)//判断是否有图片
            {
                UploadedFile file = rauFiles.UploadedFiles[0];
                string uploadPath = "../UpLoad/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "/";//上传路径
                if (!Directory.Exists(uploadPath))//判断该路径是否存在
                {
                    Directory.CreateDirectory(Server.MapPath(uploadPath));//在指定路径中创建所有目录
                }
                string name = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".png";//图片命名
                filepath = Server.MapPath(uploadPath) + name;
                file.SaveAs(filepath);//保存图片
                imgPic.ImageUrl = uploadPath + name;
            }
        }
    }
}