using NavigationPlatformWeb.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepairCenterY.BackManagement
{
    public partial class EquipmentTypeAdd : System.Web.UI.Page
    {
        Maticsoft.BLL.MachineFatherType MachineFatherType_bll = new Maticsoft.BLL.MachineFatherType();
        Maticsoft.Model.MachineFatherType MachineFatherType_Model = new Maticsoft.Model.MachineFatherType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsersInfo.UserID == "")//判断是否登录
            {


                Response.Write("<script> alert('请先登录'); window.location.href='/BackLogin.aspx' </script>");//提示并跳转
            }
            else
            {
                RadButton2.Attributes["onclick"] = "GetClose();return false;";//弹窗
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            string search1 = TextBox1.Text;
            string xxdz1 = TextBox1.Text.Trim();
            Regex pattern1 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？'' ']");//特殊字符正则判断
            if ((pattern1.IsMatch(xxdz1) == true))
            {
                Response.Write("<script>alert('请不要输入特殊字符！')</script>");
                return;
            }

            if (TextBox1.Text == "")//判断输入框是否为空
            {
                Response.Write("<script>alert('请输入设备父类别名称！')</script>");
                return;
            }
            else if (MachineFatherType_bll.GetRecordCount(" MachineFatherName ='" + TextBox1.Text + "' ") != 0)//判断是否存在该父类别
            {
                Response.Write("<script>alert('不能重复添加！')</script>");
            }
            else
            {
                MachineFatherType_Model.MachineFatherID = DateTime.Now.ToString("yyyyMMddhhmmss");//添加数据
                MachineFatherType_Model.MachineFatherName = TextBox1.Text;//添加数据
                MachineFatherType_Model.MachineFatherAddTime = DateTime.Now;//添加数据
                MachineFatherType_bll.Add(MachineFatherType_Model);//更新数据
                RadAjaxManager1.Alert("添加成功!");//提示
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
        }
    }
}