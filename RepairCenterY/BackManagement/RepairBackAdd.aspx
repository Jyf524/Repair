<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairBackAdd.aspx.cs" Inherits="RepairCenterY.BackManagement.ReapirBackAdd" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/css/demo.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
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
        <div style="margin-left: 13%; margin-top: 21%;">
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
            <label style="line-height: 34px; margin-right: 10px;">返修说明:</label>
            <telerik:RadTextBox ID="RadRepairBack" MaxLength="50"  runat="server"></telerik:RadTextBox>
            <div style="float:left">
                <div style="float:left;">
            <asp:Button ID="btnadd" runat="server" CssClass="btn btn-default" Text="保存" OnClick="btnadd_Click" />
                    </div>
                <div style="float:left;margin-left:40px">
            <asp:Button ID="btnback" runat="server" CssClass="btn btn-default" Text="返回" />
                    </div>
                </div>
        </div>
    </form>
</body>
</html>
