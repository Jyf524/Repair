<%@ Page Title="配件使用记录" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="PartsHistory.aspx.cs" Inherits="RepairCenterY.BackManagement.PartsHistory" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var id = -1;
        function GetUuserId(sender, args) {
            id = args.getDataKeyValue("PartID");
        }
        function refreshGrid(arg) {
            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
        }
    </script>
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
            <telerik:AjaxSetting AjaxControlID="btnselect">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">

            <div class="panel-heading">
                <div style="float: left;">
                    <h3 class="panel-title">配件使用记录</h3>
                </div>
                <div style="float: left;">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Part Management</p>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-6" style="width: 100%;">
                    <!-- BASIC TABLE -->
                    <div class="panel" style="width: 100%;">
                        <div class="panel-body">
                            <div class="navbar-form navbar-left" style="margin-top: -20px;">
                                <div class="input-group">
                                    <div style="float: left; line-height: 34px;">单号：</div>
                                    <div style="float: left;width:21%; margin-left: 10px;">
                                        <telerik:RadTextBox ID="txtListID" runat="server" CssClass="form-control" MaxLength="20" LabelWidth="64px" Resize="None" Width="100%" Height="34"></telerik:RadTextBox>
                                    </div>
                                    <div style="float: left; margin-left: 10px; line-height: 34px;">使用时间：</div>
                                    <div style="float: left; width:25%; margin-left: 10px;">
                                        <telerik:RadDatePicker ID="dpstarttime" runat="server" LabelWidth="64px" Resize="None" Width="100%" Height="34"></telerik:RadDatePicker>
                                    </div>
                                    <div style="float: left; margin-left: 10px; line-height: 34px;">至</div>
                                    <div style="float: left;width:25%; margin-left: 10px;">
                                        <telerik:RadDatePicker ID="dpendtime" runat="server" LabelWidth="64px" Resize="None" Width="100%" Height="34"></telerik:RadDatePicker>
                                    </div>

                                </div>
                                <div style="margin-left: 690px; margin-top: -34px;">
                                    <span class="input-group-btn" style="margin-left: 15px;">
                                        <asp:Button ID="btnselect" runat="server" CssClass="btn btn-primary" Text="查询" OnClick="btnselect_Click" /></span>
                                </div>
                            </div>

                            <div style="margin-top: 50px;">
                                <telerik:RadGrid ID="RadGrid1" runat="server" OnNeedDataSource="RadGrid1_NeedDataSource1" OnPageIndexChanged="RadGrid1_PageIndexChanged" OnItemCommand="RadGrid1_ItemCommand" Skin="Metro">
                                    <ClientSettings Selecting-AllowRowSelect="true">
                                        <Selecting AllowRowSelect="true" />
                                        <ClientEvents OnRowClick="GetUuserId" />
                                    </ClientSettings>
                                    <MasterTableView NoMasterRecordsText="暂无数据" AllowPaging="true" DataKeyNames="PartUseRecordID" PageSize="10" AutoGenerateColumns="false" ClientDataKeyNames="PartUseRecordID">
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <HeaderTemplate>序号</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Literal ID="literal" runat="server" Text="<%#Container.ItemIndex+1 %>"></asp:Literal>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="PartUseNumber" HeaderText="配件使用数量"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="RepairID" HeaderText="使用单号"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UserRealName" HeaderText="维修员"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PartUseTime" HeaderText="配件使用时间" DataFormatString="{0:yyyy-MM-dd}"></telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('确认要删除此行?');" CommandName="Delete" CommandArgument='<%#Eval("PartUseRecordID") %>'>删除</asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <Selecting AllowRowSelect="true" />
                                    </ClientSettings>
                                    <PagerStyle FirstPageToolTip="第一页" LastPageToolTip="最后一页" PrevPageToolTip="上一页" NextPageToolTip="下一页" PageSizeLabelText="每页显示数" PagerTextFormat="{4}共<strong>{5}</strong>条数据" />
                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                </telerik:RadGrid>
                            </div>
                        </div>

                    </div>
                    <!-- END BASIC TABLE -->
                </div>
                <div class="panel-body">
                    <p class="demo-button" style="float: right;">
                        <asp:Button ID="btnback" runat="server" CssClass="btn btn-default" Text="返回" OnClick="btnback_Click" />
                    </p>
                </div>

            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>
</asp:Content>
