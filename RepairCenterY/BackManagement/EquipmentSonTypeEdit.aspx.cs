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
    public partial class EquipmentSonTypeEdit : System.Web.UI.Page
    {
        Maticsoft.BLL.MachineSonType MachineSonType_bll = new Maticsoft.BLL.MachineSonType();
        Maticsoft.Model.MachineSonType MachineSonType_Model = new Maticsoft.Model.MachineSonType();
        public static string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsersInfo.UserID == "")//判断是否登录
            {


                Response.Write("<script> alert('请先登录'); window.location.href='/BackLogin.aspx' </script>");//提示并跳转
            }
            else
            {
                if (!IsPostBack)
                {
                    Maticsoft.Model.MachineSonType MachineSonType_Model = MachineSonType_bll.GetModel(Request.QueryString["ID"].ToString());//引用id的所有信息
                    name=TextBox1.Text = MachineSonType_Model.MachineSonName;//为输入框赋值
                }
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            string yh = "MachineSonName='" + TextBox1.Text + "'";        
            string search1 = TextBox1.Text;
            string xxdz1 = TextBox1.Text.Trim();
            Regex pattern1 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ' ’]");//特殊字符正则判断
            if ((pattern1.IsMatch(xxdz1) == true))
            {
                Response.Write("<script>alert('请不要输入特殊字符！')</script>");
                return;
            }
            DataSet ds = MachineSonType_bll.GetList(yh);
           
            if (TextBox1.Text == "")//判断输入框是否为空
            {
                Response.Write("<script>alert('请输入设备子类别！')</script>");
                return;
            }
            else if (MachineSonType_bll.GetRecordCount(" MachineSonName ='" + TextBox1.Text + "' ") != 0 && TextBox1.Text != name)//判断是否存在该子类别名称
            {
                Response.Write("<script>alert('该子类别名称已存在！')</script>");
            }
            else
            {
                //Maticsoft.Model.GoodsChildForm modelcclass1 = BLLCClass.GetModel(Request.QueryString["ID"].ToString());//引用id的所有信息
                MachineSonType_Model = MachineSonType_bll.GetModel(Request.QueryString["ID"].ToString());//引用id的所有信息
                MachineSonType_Model.MachineSonName = TextBox1.Text;//添加数据
                MachineSonType_bll.Update(MachineSonType_Model);//更新数据
                RadAjaxManager1.Alert("修改成功!");//提示
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
            }
        }
    }
}