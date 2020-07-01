<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipmentSonTypeEdit.aspx.cs" Inherits="RepairCenterY.BackManagement.EquipmentSonTypeEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>设备子类别修改</title>
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
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
         <div class="panel panel-headline">
        <div class="panel-heading">
             <div style="float: left;"><h3 class="panel-title">子类别修改</h3></div>
           <div style="float:left;"> <p class="panel-subtitle" style="margin-left: 5px; font-weight: 100; margin-top:5px;">Subclass modification</p></div>
            </div>
              <div class="panel-body" style="margin-top:10px;">
             <div class="col-md-6">
                <!-- BASIC TABLE -->
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                          <div class="form-group" style="margin-top:20px;">
                            <label for="focusedinput" class="col-sm-2 control-label">子类别名称</label>
                              <div class="col-sm-8" style="width:78%; float:right; margin-top:-30px;">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
                    </div>
                 </div>
              <div class="panel-body">
                    <div class="demo-button" style="float: right;">
                    <telerik:RadButton ID="RadButton1" runat="server" Text="确定" OnClick="RadButton1_Click" Skin="Metro" height="34px" width="74px" BackColor="White"></telerik:RadButton>         
                    <telerik:RadButton ID="RadButton2" runat="server" Text="返回" OnClick="RadButton2_Click" Skin="Metro" height="34px" width="74px" BackColor="White"></telerik:RadButton>                   
                    </div>
                     </div>

              </div>
    </form>
</body>
</html>
