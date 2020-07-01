<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="RepairCenterY.BackManagement.ChangePassword" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改密码</title>
     <script type="text/javascript">
         //关闭模式窗口
         function GetRadWindow() {
             var oWnd = null;
             if (window.radWindow) oWnd = window.radWindow;
             else if (window.frameElement.radWindow) oWnd = window.frameElement.radWindow;
             return oWnd;
         }
         function GetClose() {
             var oWnd = GetRadWindow();
             oWnd.Close();
         }
         function CloseAndRebind(args) {
             GetRadWindow().Close();
             GetRadWindow().BrowserWindow.refreshGrid(args);
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
          <table style="float:left; margin-left:39%; margin-top:1%;">
        <tr>
            <td style=" float:left; margin-top:29px; font-weight:bold; font-size:20px; font-weight:bold;">修改密码</td>
        </tr>

        </table>
        <div style="width:95%; background-color:#fff; float:left; margin-left:5%; margin-top:2%;">
    <div style="width: 100%; float: left;">
        <table style="width:100%; line-height:40px;">
            <tr>
                <td style="text-align:right; font-weight:bold;">旧密码：
                </td>
                <td>
                    <telerik:RadTextBox ID="RadTextBox1" runat="server" LabelWidth="30px" MaxLength="30" TextMode="Password"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; font-weight:bold;">新密码：
                </td>
                <td>
                    <telerik:RadTextBox ID="RadTextBox2" runat="server" LabelWidth="30px" MaxLength="30" TextMode="Password"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; font-weight:bold;">确认密码：
                </td>
                <td>
                    <telerik:RadTextBox ID="RadTextBox3" runat="server" LabelWidth="30px" MaxLength="30" TextMode="Password"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <telerik:RadButton ID="RadButton1" runat="server" Text="确定" OnClick="RadButton1_Click" Skin="Metro"  BackColor="White"></telerik:RadButton>         
                    <telerik:RadButton ID="RadButton2" runat="server" Text="返回" OnClick="RadButton2_Click" Skin="Metro"  BackColor="White"></telerik:RadButton>                   
                    </td>
            </tr>
        </table>
    </div>
        </div>
    </form>
</body>
</html>
