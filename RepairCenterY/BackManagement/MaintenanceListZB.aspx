<%@ Page Title="装备中心维修单" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="MaintenanceListZB.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairEditZB" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function setUeditor() {
            var myEditor = document.getElementById("myEditor");
            myEditor.value = editor.getContent();//把得到的值给textarea
        }
    </script>
        <style>
        img
        {
            max-width: 1000px;
        }
    </style>
    <script src="../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var editor = new baidu.editor.ui.Editor();
        editor.render("<%=myEditor.ClientID%>");
    </script>

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
            <telerik:AjaxSetting AjaxControlID="TextBox2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="TextBox1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="TextBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">维修信息填写</h3>
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
                            <label for="focusedinput" class="col-sm-2 control-label">维修员：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label2" runat="server" CssClass="form-control" Text="吴奇隆"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障诊断及维修方案</label>
                            <div class="col-sm-8">
                                <textarea id="myEditor" name="myEditor" runat="server" onblur="setUeditor()" style="width: 1000px; height: 120px;"></textarea>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">完修时间：</label>
                            <div class="col-sm-8">
                                <telerik:RadDatePicker ID="RadDatePicker1" runat="server" CssClass="form-control" Enabled="false"></telerik:RadDatePicker>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">人工费用：</label>
                            <div class="col-sm-8">
                                 <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"  OnTextChanged="TextBox2_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">维修费用：</label>
                            <div class="col-sm-8">
                                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  OnTextChanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">实际费用：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label9" runat="server" CssClass="form-control" Text="￥0.00"></asp:Label>
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
