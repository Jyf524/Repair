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
    public partial class ChangePassword : System.Web.UI.Page
    {
        Maticsoft.BLL.UsersInfo UsersInfo_Bll = new Maticsoft.BLL.UsersInfo();
        Maticsoft.Model.UsersInfo UsersInfo_Model = new Maticsoft.Model.UsersInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsersInfo.UserID == "")//判断是否登录
            {


                Response.Write("<script> alert('请先登录'); window.location.href='/BackLogin.aspx' </script>");//提示并跳转
            }
            else
            {
                string id = NavigationPlatformWeb.util.UsersInfo.UserID;
                if (!IsPostBack)
                {
                    Maticsoft.Model.UsersInfo UsersInfo_Model = UsersInfo_Bll.GetModel(id);//引用id所在行的数据
                }
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            string search = RadTextBox1.Text;
            string xxdz = RadTextBox1.Text.Trim();
            Regex pattern = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ]");//特殊字符正则判断
            if ((pattern.IsMatch(xxdz) == true))
            {
                Response.Write("<script>alert('请不要输入特殊字符！')</script>");
                return;
            }

            string search1 = RadTextBox2.Text;
            string xxdz1 = RadTextBox2.Text.Trim();
            Regex pattern1 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ]");//特殊字符正则判断
            if ((pattern1.IsMatch(xxdz1) == true))
            {
                Response.Write("<script>alert('请不要输入特殊字符！')</script>");
                return;
            }

            string search2 = RadTextBox3.Text;
            string xxdz2 = RadTextBox3.Text.Trim();
            Regex pattern2 = new Regex("[%--`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？ ]");//特殊字符正则判断
            if ((pattern2.IsMatch(xxdz2) == true))
            {
                Response.Write("<script>alert('请不要输入特殊字符！')</script>");
                return;
            }

            string id = UsersInfo.UserID;
            UsersInfo_Model = UsersInfo_Bll.GetModel(id);//引用id所在行的数据          
             if (RadTextBox1.Text == "")//判读输入框是否为空
            {
                Response.Write("<script>alert(\"请输入原密码\")</script>");
                return;
            }
             else if (RadTextBox2.Text == "")//判读输入框是否为空
             {
                 Response.Write("<script>alert(\"请输入新密码\")</script>");
                 return;
             }
             else if (RadTextBox3.Text == "")//判读输入框是否为空
             {
                 Response.Write("<script>alert(\"请输入确认密码\")</script>");
                 return;
             }
             else if (RadTextBox1.Text != UsersInfo_Model.UserPassword)//判断原密码输入是否正确
            {
                Response.Write("<script>alert(\"原密码输入错误\")</script>");
                return;
            }
            else if (RadTextBox3.Text != RadTextBox2.Text)//判断新密码与确认密码是否一致
            {
                Response.Write("<script>alert(\"密码不一致\")</script>");
                return;
            }
            else if (RadTextBox2.Text == RadTextBox1.Text)//判断原密码与新密码是否一致
            {
                Response.Write("<script>alert(\"新密码不可以与旧密码一致\")</script>");
                return;
            }
            else if (RadTextBox2.Text.Length<6)//判断密码位数
            {
                Response.Write("<script>alert(\"密码不可以少于六位\")</script>");
                return;
            }
            else
            {
                UsersInfo_Model.UserPassword = RadTextBox2.Text;//添加数据
                UsersInfo_Bll.Update(UsersInfo_Model);//更新数据
                UsersInfo.UserID = null;
                UsersInfo.UserName = null;
                UsersInfo.UserRole = null;//清空用户信息
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
               
                //Response.Write("<script>window.location.href='/BackLogin.aspx'</script>");
            }
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>CloseAndRebind();</script>");//关闭弹窗
        }
    }
}