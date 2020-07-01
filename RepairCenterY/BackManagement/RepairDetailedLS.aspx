<%@ Page Title="老师受理" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="RepairDetailedLS.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairDetailedLS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        img
        {
            max-width: 980px;
        }
    </style>
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

    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">报修详细</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Detail</p>
            </div>
        </div>
        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">单号：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label1" runat="server" CssClass="form-control" Text="55555444"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系人：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label2" runat="server" CssClass="form-control" Text="能天使"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系电话</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label3" runat="server" CssClass="form-control" Text="13155555444"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备名称：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label4" runat="server" CssClass="form-control" Text="投影仪"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">资产序号：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label5" runat="server" CssClass="form-control" Text="W55256666"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障现象：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label13" runat="server" CssClass="form-control" Text="投影模糊" style="height: auto;"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">是否上门服务：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label6" runat="server" CssClass="form-control" Text="是"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">型号参数：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label7" runat="server" CssClass="form-control" Text="WE7545"></asp:Label>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">其他附件：</label>
                            <div class="col-sm-8">
                                <a id="down" runat="server" href="#">
                                    <asp:Label ID="Label9" runat="server" CssClass="form-control" Text="下载附件"></asp:Label>
                                </a>

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">是否申请使用代用机：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label10" runat="server" CssClass="form-control" Text="是"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备描述：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label11" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障预判：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label12" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">预计完修时间：</label>
                            <div class="col-sm-8">
                               <asp:Label ID="Label8" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">分配：</label>
                            <div class="col-sm-8">
                                <telerik:RadListBox ID="RadListBox1" runat="server" RenderMode="Lightweight" Height="200px" Width="230px" AllowTransfer="true" TransferToID="RadListBox2" ButtonSettings-AreaWidth="35" DataTextField="UserName"  DataValueField="UserID" Skin="Metro"> 

                                </telerik:RadListBox>
                                <telerik:RadListBox ID="RadListBox2" runat="server" RenderMode="Lightweight" Height="200px" Width="230px" ButtonSettings-AreaWidth="35px" Skin="Metro" ></telerik:RadListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END BASIC TABLE -->

            <div class="panel-body">
                <p class="demo-button" style="float: right;">

                    <telerik:RadButton ID="RadButton2" runat="server" Text="确定" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton2_Click"></telerik:RadButton>
                    <telerik:RadButton ID="RadButton1" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton1_Click"></telerik:RadButton>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
