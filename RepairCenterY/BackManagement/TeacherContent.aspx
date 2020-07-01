<%@ Page Title="用户详细页" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="TeacherContent.aspx.cs" Inherits="RepairCenterY.BackManagement.TeacherContent" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
      <div class="container-fluid">
    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">用户详细</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">User Information</p>
            </div>
        </div>
        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">用户名：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="yonghuming" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">真实姓名：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="zhenshixingming" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">性别：</label>
                            <div class="col-sm-8">
                                     <asp:Label ID="xingbie" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">邮箱：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="youxiang" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                                                <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">出生日期：</label>
                            <div class="col-sm-8">
                                 <asp:Label ID="shengri" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系方式：</label>
                            <div class="col-sm-8">
                                 <asp:Label ID="lianxifangshi" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">家庭住址：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="xiangxidizhi" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">账号状态：</label>
                                <div class="col-sm-8">
                                     <asp:Label ID="zhanghaozhuangtai" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                                                        <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">添加时间：</label>
                                <div class="col-sm-8">
                                     <asp:Label ID="tianjiashijian" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- END BASIC TABLE -->

                <div class="panel-body">
                    <p class="demo-button" style="float: right;">
                        <telerik:RadButton ID="fanhui" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton1_Click1"></telerik:RadButton>
                    </p>
                </div>
            </div>
        </div>
        </div>
          </div>
</asp:Content>
