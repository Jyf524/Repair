<%@ Page Title="个人中心" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="PersonalIinformation.aspx.cs" Inherits="RepairCenterY.BackManagement.PersonalIinformation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OpenAddPro() {
            var oWnd = radopen("ChangePassword.aspx", "RadWindowManager1");
            oWnd.setSize(500, 400);
            oWnd.center();
            oWnd.show();
        }
        function refreshGrid(arg) {
            window.location.reload();
         }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close" Modal="true" VisibleStatusbar="false" Height="20px">
        <Localization Close="关闭" Reload="刷新" Maximize="最大化" Restore="恢复" OK="确定" Cancel="取消" />
    </telerik:RadWindowManager>
   <div class="panel panel-headline">
       <div class="panel-heading">
            <div style="float: left;"><h3 class="panel-title">个人中心</h3></div>
           <div style="float:left;"> <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Personal Iinformation</p></div>
        </div>
        <div class="panel-body" style="margin-top:40px;">
             <div class="col-md-6" style="width: 100%;">
                <!-- BASIC TABLE -->
                <div class="panel" style="width: 100%;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">头像：</label>
                            <div class="col-sm-8">
                                <asp:Image ID="imgPic" runat="server" Height="100" Width="140" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">用户名：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label9" runat="server" CssClass="form-control" Text="TY"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">真实姓名：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label10" runat="server" CssClass="form-control" Text="汤颖"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group"  id="XB" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">性别：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label11" runat="server" CssClass="form-control" Text="女"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group"  id="DH" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">电话号码：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label12" runat="server" CssClass="form-control" Text="15380238771"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group"  id="CSRQ" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">出生日期：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label13" runat="server" CssClass="form-control" Text="2000-10-01"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group"  id="JTZZ" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">家庭住址：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label15" runat="server" CssClass="form-control" Text="江苏省镇江市丹阳市"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group"  id="YX" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">邮箱：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label16" runat="server" CssClass="form-control" Text="2361193298@qq.com"></asp:Label>
                            </div>
                        </div>
                       
                        <div class="form-group"  id="DW" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">单位：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label7" runat="server" CssClass="form-control" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
                    </div>
                 </div> 
                <!-- END BASIC TABLE -->
                 <div class="panel-body">
                    <div class="demo-button" style="float: right;">
                        <telerik:RadButton ID="RadButton1" runat="server" Text="修改个人信息" Skin="Metro" Width="85px" Height="34px" OnClick="RadButton1_Click"></telerik:RadButton>
                        <telerik:RadButton ID="RadButton2" runat="server" Text="修改密码" Skin="Metro" Width="74px" Height="34px" OnClick="RadButton2_Click"></telerik:RadButton>
                        </div>
                     </div>
            </div>
    </div>
</asp:Content>
