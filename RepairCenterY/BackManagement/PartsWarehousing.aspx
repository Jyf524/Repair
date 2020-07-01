<%@ Page Title="配件入库" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="PartsWarehousing.aspx.cs" Inherits="RepairCenterY.BackManagement.PartsWarehousing" %>

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
                    <telerik:AjaxUpdatedControl ControlID="imgPic" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="rauFiles" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPartTypeName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlPartTypeName" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="ddlPartName" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPartName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlPartTypeName" />
                    <telerik:AjaxUpdatedControl ControlID="ddlPartName" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPartSource">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlPartSource" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">
            <div class="panel-heading">
                <div style="float: left;">
                    <h3 class="panel-title">配件入库</h3>
                </div>
                <div style="float: left;">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">User Management</p>
                </div>
            </div>
            <div class="panel-body" style="margin-top: 40px;">
                <div class="cbp-spmenu-push">
                    <!-- BASIC TABLE -->
                    <div class="form-three widget-shadow">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">配件类别名称：</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlPartTypeName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddlPartTypeName_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">配件名称：</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlPartName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">配件来源：</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlPartSource" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Text="请选择"></asp:ListItem>
                                        <asp:ListItem Text="采购"></asp:ListItem>
                                        <asp:ListItem Text="拆件"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">配件规格：</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtPartModel" runat="server" MaxLength="16" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">配件数量：</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtPartPutNumber" runat="server" MaxLength="9" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">配件价格：</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtPartPrice" runat="server" MaxLength="9" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">配件图片：</label>
                                <div class="col-sm-8">
                                <asp:Image ID="imgPic" runat="server" Height="100" Width="140" />
                    <telerik:RadAsyncUpload ID="rauFiles" runat="server" Culture="zh-CN" AutoAddFileInputs="False" MaxFileInputsCount="1" Skin="Metro" OnFileUploaded="rauFiles_FileUploaded" OnClientFilesUploaded="OnClientFilesUploaded" AllowedFileExtensions="jpeg,jpg,gif,png" ChunkSize="0">
                        <Localization Cancel="取消" DropZone="拖动文件到此处" Remove="移除" Select="选择" />
                        <FileFilters>
                            <telerik:FileFilter Description="Images(jpeg,jpg,gif,png)" Extensions="jpeg,jpg,gif,png" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
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
                            serverID("ajaxManagerID", "<%= RadAjaxManager1.ClientID %>");
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
                    <asp:Button ID="btnok" runat="server" class="btn btn-default" Text="确认" OnClick="btnok_Click1" />
                    <asp:Button ID="btnback" runat="server" class="btn btn-default" Text="返回" OnClick="btnback_Click" />
                </p>
            </div>


        </div>
        <!-- END OVERVIEW -->
    </div>
</asp:Content>
