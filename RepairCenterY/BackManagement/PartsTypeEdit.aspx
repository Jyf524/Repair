<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartsTypeEdit.aspx.cs" Inherits="RepairCenterY.BackManagement.PartsTypeEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/css/demo.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <title>配件类别修改</title>
     <link rel="stylesheet" href="../assets/vendor/bootstrap/css/bootstrap.min.css"/>
	<!-- MAIN CSS -->
	<link rel="stylesheet" href="../assets/css/main.css"/>
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
<body style="background-color:white;">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
        <%--<div style="margin-left: 13%; margin-top: 21%;">
            <label style="line-height:34px;margin-right:10px;">配件类别:</label>
            <telerik:radtextbox id="txtPartTypeName" runat="server" MaxLength="16" labelwidth="64px" resize="None" width="160px" Height="34px"></telerik:radtextbox>
            <asp:Button ID="btnadd" runat="server" CssClass="btn btn-default" Text="保存" OnClick="btnadd_Click" />
            <asp:Button ID="btnback" runat="server" CssClass="btn btn-default" Text="返回" />
        </div>--%>


        
        <div class="panel panel-headline">
        <div class="panel-heading">
             <div style="float: left;"><h3 class="panel-title">配件类别修改</h3></div>
           <div style="float:left;"> <p class="panel-subtitle" style="margin-left: 5px; font-weight: 100; margin-top:5px;">Part Add</p></div>
            </div>
              <div class="panel-body" style="margin-top:10px;">
             <div class="col-md-6">
                <!-- BASIC TABLE -->
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                          <div class="form-group" style="margin-top:20px;">
                            <label for="focusedinput" class="col-sm-2 control-label">配件类别</label>
                              <div class="col-sm-8" style="width:78%; float:right; margin-top:-10px;">
                                  <%--<telerik:radtextbox id="txt111PartName" runat="server"  CssClass="form-control" MaxLength="16"></telerik:radtextbox>--%>
                                  <asp:TextBox ID="PartTypeName" runat="server" CssClass="form-control" MaxLength="16"></asp:TextBox>
                                
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
                    </div>
                 </div>
                  </div>
<%--        <table style="float:left; margin-left:37%; margin-top:1%;">
        <tr>
            <td style=" float:left; margin-top:29px; font-weight:bold; font-size:20px; font-weight:bold;">父类别添加</td>
        </tr>
        </table>--%>
    <div class="panel-body">
                    <div class="demo-button" style="float: right;">
                    <telerik:RadButton ID="btnadd" runat="server" Text="确定" OnClick="btnadd_Click" Skin="Metro" height="34px" width="74px" BackColor="White"></telerik:RadButton>         
                    <telerik:RadButton ID="btnback" runat="server" Text="返回" Skin="Metro" height="34px" width="74px" BackColor="White"></telerik:RadButton>                   
                    </div>
                     </div>
              



    </form>
</body>
</html>
