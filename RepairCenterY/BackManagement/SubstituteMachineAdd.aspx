﻿<%@ Page Title="代用机添加" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="SubstituteMachineAdd.aspx.cs" Inherits="RepairCenterY.BackManagement.SubstituteMachineAdd" %>

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
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="rauFiles" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="MachineFather">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MachineFather" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="MachineSon" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="MachineSon">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MachineFather" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="MachineSon" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>



    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">代用机添加</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">SubstituteMachineAdd</p>
            </div>
        </div>

        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机名称：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="ReplacementName" runat="server" CssClass="form-control" placeholder="请输入" MaxLength="20"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机型号：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="ReplacementModel" runat="server" CssClass="form-control" placeholder="请输入" MaxLength="20"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机类别：</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="MachineFather" runat="server" CssClass="form-control" OnSelectedIndexChanged="MachineFather_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:DropDownList ID="MachineSon" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机图片：</label>
                            <div class="col-sm-8">

                                <telerik:RadAsyncUpload ID="rauFiles" runat="server" Culture="zh-CN" AutoAddFileInputs="true" MaxFileInputsCount="5" OnFileUploaded="rauFiles_FileUploaded" OnClientFilesUploaded="OnClientFilesUploaded" Skin="Metro">
                                    <Localization Cancel="取消" DropZone="拖动文件到此处" Remove="移除" Select="选择" />
                                    <FileFilters>
                                        <telerik:FileFilter Description="Images(jpeg,jpg,gif,png)" Extensions="jpeg,jpg,gif,png" />
                                    </FileFilters>
                                </telerik:RadAsyncUpload>

                                <telerik:RadListView ID="RadListView1" runat="server" OnNeedDataSource="RadListView1_NeedDataSource" PageSize="5" OnItemCommand="RadListView1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <li style="list-style: none; float: left;">
                                                <asp:Image ID="imgPic" runat="server" Width="200" Height="140" CssClass="form-control" src='<%#Eval("imgUrl") %>' />
                                                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandName="Delete" HeaderText="删除" CommandArgument='<%# Eval("ID") %>'>删除</asp:LinkButton>
                                            </li>
                                        </tr>
                                    </ItemTemplate>
                                </telerik:RadListView>

                                

                                <div id="Div1" runat="server">
                                    <script type="text/javascript">
                                        (function (global, undefined) {
                                            var demo = {};

                                            function OnClientFilesUploaded(sender, args) {
                                                $find(demo.ajaxManagerID).ajaxRequest();
                                            }

                                            function serverID(name, id) {
                                                demo[name] = id;
                                            }

                                            global.serverID = serverID;

                                            global.OnClientFilesUploaded = OnClientFilesUploaded;
                                        })(window)
                                        //<![CDATA[
                                        serverID("ajaxManagerID", "<%= RadAjaxManager1.ClientID %>");
                                        //]]>
                                    </script>
                                </div>
                            </div>
                        </div>





                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <p class="demo-button" style="float: right;">
                <telerik:RadButton ID="btnadd" runat="server" Text="确认" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="btnadd_Click"></telerik:RadButton>
                <telerik:RadButton ID="btnback" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="btnback_Click"></telerik:RadButton>
            </p>
        </div>
    </div>
</asp:Content>