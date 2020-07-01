<%@ Page Title="装备中心受理单" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="RepairAcceptanceZB.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairAddZB" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../CSS/RepairDetailedWX.css" rel="stylesheet" />
    <style>
        img
        {
            max-width: 980px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadioButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadioButton1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButton2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButton3" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="sbms" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="gzyp" />
                    <telerik:AjaxUpdatedControl ControlID="time" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadioButton1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButton2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButton3" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="sbms" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="gzyp" />
                    <telerik:AjaxUpdatedControl ControlID="time" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButton3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadioButton1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButton2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButton3" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" />
                    <telerik:AjaxUpdatedControl ControlID="sbms" />
                    <telerik:AjaxUpdatedControl ControlID="gzyp" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="time" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <div class="panel panel-headline">
            <div class="panel-heading">
                <div style="float: left;">
                    <h3 class="panel-title">维修分配</h3>
                </div>
                <div style="float: left;">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Detail</p>
                </div>
            </div>
        <div class="panel-body" style="margin-top:40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">单号：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label1" runat="server" CssClass="form-control" Text="22145333"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系人：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label2" runat="server" CssClass="form-control" Text="天阳"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系电话：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label3" runat="server" CssClass="form-control" Text="13003443575"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备名称：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label4" runat="server" CssClass="form-control" Text="电脑"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">资产序号：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label5" runat="server" CssClass="form-control" Text="F8854"></asp:Label>
                            </div>
                        </div>
<%--                                                <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障现象：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label11" runat="server" CssClass="form-control" Text="开不了机"></asp:Label>
                            </div>
                        </div>--%>
                                            <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">故障现象：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblBreakDown" runat="server" CssClass="form-control form_style" Text="Label" style="height: auto;"></asp:Label>
                        </div>
                    </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">是否上门服务：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label6" runat="server" CssClass="form-control" Text="否"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">型号参数：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label7" runat="server" CssClass="form-control" Text="44555"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">其他附件：</label>
                            <div class="col-sm-8">
                                <a id="down" runat="server" href="#" target="_blank"><asp:Label ID="Label9" runat="server" CssClass="form-control" Text="下载附件"></asp:Label></a>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">申请使用代用机：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label10" runat="server" CssClass="form-control" Text="下载附件"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group" id="bianhao" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机：</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">接修处理：</label>
                            <div class="col-sm-8">
                                <div style="float: left; margin-top: 5px;">
                                    <div style="float: left;">
                                         <asp:RadioButton ID="RadioButton1" AutoPostBack="true" runat="server" Text="建议报废" GroupName="1" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                        </div>
                                    <div style="float: left; margin-left: 5px;">
                                        <asp:RadioButton ID="RadioButton2" AutoPostBack="true" runat="server" Text="装备中心修理" GroupName="1" OnCheckedChanged="RadioButton2_CheckedChanged" /></div>
                                    <div style="float: left; margin-left: 5px;">
                                        <asp:RadioButton ID="RadioButton3" AutoPostBack="true" runat="server" Text="维修基地修理" GroupName="1"  OnCheckedChanged="RadioButton3_CheckedChanged1" /></div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" id="sbms" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">设备描述：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" id="gzyp" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">故障预判：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                                                <div class="form-group" id="time" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">预计完修时间：</label>
                            <div class="col-sm-8">
                                <%--<telerik:RadDatePicker ID="RadDatePicker1" runat="server" CssClass="form-control"></telerik:RadDatePicker>--%>
                                <telerik:RadDatePicker ID="RadDatePicker1" runat="server" CssClass="form-control"></telerik:RadDatePicker>
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
