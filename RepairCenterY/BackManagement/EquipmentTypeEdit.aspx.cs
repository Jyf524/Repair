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
    public partial class EquipmentTypeEdit : System.Web.UI.Page
    {
        Maticsoft.BLL.MachineFatherType MachineFatherType_bll = new Maticsoft.BLL.MachineFatherType();
        Maticsoft.Model.MachineFatherType MachineFatherType_Model = new Maticsoft.Model.MachineFatherType();
        public static string name;


        protected void Page_Load(object sender, EventArgs e)
        {

                if (UsersInfo.UserID == "")//判断是否登录
                {


                    Response.Write("<script> alert('请先登录'); window.location.href='/BackLogin.aspx' </script>");//提示并登录
                }
                else
                {
                    if (!IsPostBack)
                    {
                        Maticsoft.Model.MachineFatherType MachineFatherType_Model = MachineFatherType_bll.GetModel(Request.QueryString["ID"].ToString());//引用id的所有信息
                        name = TextBox1.Text = MachineFatherType_Model.MachineFatherName;//为输入框赋值
                    }
                }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            string yh = "MachineFatherName='" + TextBox1.Text + "'";          
            string search1 = TextBox1.Text;
            string xxdz1 = TextBox1.Text.Trim();
            Regex pattern1 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ’ ']");//特殊字符正则判断
            if ((pattern1.IsMatch(xxdz1) == true))
            {
                Response.Write("<script>alert('请不要输入特殊字符！')</script>");
                return;
            }
            DataSet ds = MachineFatherType_bll.GetList(yh);

            if (TextBox1.Text == "")//判断输入框是否为空
            {
                Response.Write("<script>alert('请输入设备父类别！')</script>");
                return;
            }
            else if (MachineFatherType_bll.GetRecordCount(" MachineFatherName ='" + TextBox1.Text + "' ") != 0 && TextBox1.Text != name)//判断是否存在该父类别名称
            {
                Response.Write("<script>.0alert('该父类别名称已存在！')</script>");
            }

            else
            {
                //Maticsoft.Model.GoodsParentForm modelfclass1 = BLLFClass.GetModel(Request.QueryString["ID"].ToString());//引用id的所有信息
                MachineFatherType_Model = MachineFatherType_bll.GetModel(Request.QueryString["ID"].ToString());//引用id的所有信息
                MachineFatherType_Model.MachineFatherName = TextBox1.Text;//添加数据
                MachineFatherType_bll.Update(MachineFatherType_Model);//更新数据
                RadAjaxManager1.Alert("修改成功!");//提示
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
        }
    }
}