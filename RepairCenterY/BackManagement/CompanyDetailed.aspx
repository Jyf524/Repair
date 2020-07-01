<%@ Page Title="报修单位详细" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="CompanyDetailed.aspx.cs" Inherits="RepairCenterY.BackManagement.CompanyDetailed" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>


    <div class="panel panel-headline" style="width: 95%; height: 470px; background-color: #fff; margin-left: 2.5%;">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">报修单位详细</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Reporting Detail</p>
            </div>
        </div>
        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">单位代码：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label1" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">单位名称：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label2" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系方式:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label3" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">单位负责人：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label4" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">详细地址：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label5" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <p class="demo-button" style="float: right; margin-right: 248px; margin-top: 3%;">
                            <telerik:RadButton ID="RadButton1" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton1_Click"></telerik:RadButton>
                        </p>
                    </div>
                </div>
            </div>
            <!-- END BASIC TABLE -->
        </div>
    </div>
</asp:Content>
