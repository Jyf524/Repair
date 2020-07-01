<%@ Page Title="代用机详细" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="SubstitutionDetails.aspx.cs" Inherits="RepairCenterY.BackManagement.SubstitutionDetails" %>

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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>

    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left">
                <h3 class="panel-title">代用机详细</h3>
            </div>
            <div style="float: left">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">SubstitutionDetails</p>
            </div>
        </div>

        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机编号：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label1" runat="server" Text="" CssClass="form-control"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机型号：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label2" runat="server" Text="" CssClass="form-control"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机名称：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label3" runat="server" Text="" CssClass="form-control"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机类别：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label4" runat="server" Text="" CssClass="form-control"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机状态：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label5" runat="server" Text="" CssClass="form-control"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机图片：</label>
                            <div class="col-sm-8">

                                <telerik:RadListView ID="RadListView1" runat="server" OnNeedDataSource="RadListView1_NeedDataSource" PageSize="5">
                                    <ItemTemplate>
                                        <tr>
                                            <li style="list-style: none; float: left;">
                                                <asp:Image ID="imgPic" runat="server" Width="200" Height="140" CssClass="form-control" src='<%#Eval("imgUrl") %>' AlternateText="暂无数据"/>
                                            </li>
                                        </tr>
                                    </ItemTemplate>
                                </telerik:RadListView>

                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">添加时间：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label6" runat="server" Text="" CssClass="form-control"></asp:Label>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body">
            <p class="demo-button" style="float: right;">
                <telerik:RadButton ID="btnback" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="btnback_Click"></telerik:RadButton>
            </p>
        </div>

    </div>

</asp:Content>
