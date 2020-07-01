<%@ Page Title="配件类别管理" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="PartsType.aspx.cs" Inherits="RepairCenterY.BackManagement.PartsType" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var id = -1;
        function GetUuserId(sender, args) {
            id = args.getDataKeyValue("PartTypeID");
        }
        function OpenAddPro() {
            var oWnd = radopen("PartsTypeAdd.aspx", "RadWindowManager1");
            oWnd.setSize(500, 300);
            oWnd.center();
            oWnd.show();
        }
        function Openxg() {
            if (-1 == id) {
                window.alert("请选择一条数据!");
            }
            else if (id == null)
            {
                window.alert("请选择一条数据!");
            }
            else {
                oWnd = radopen("PartsTypeEdit.aspx?ID=" + id, "RadWindowManager1");
                oWnd.setSize(500, 300);
                oWnd.center();
                oWnd.show();
            }
        }
        function deletepart() {
            if (confirm('确认删除?')) {
                id = -1;
                return true;
            }
            return false;
        }
        function OpenAddProLook() {
            if (-1 == id) {
                window.alert("请选择一条数据!");
            }
            else if (id == null) {
                window.alert("请选择一条数据!");
            }
            else {
                window.location.href = "Parts.aspx?ID=" + id;
            }
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
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close" Modal="true" VisibleStatusbar="false" Height="20px">
        <Localization Close="关闭" Reload="刷新" Maximize="最大化" Restore="恢复" OK="确定" Cancel="取消" />
    </telerik:RadWindowManager>
    <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">

            <div class="panel-heading">
                <div style="float: left;">
                    <h3 class="panel-title">配件类别管理</h3>
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
                                    <div style="float: left; line-height: 34px;">类别名称：</div>
                                    <div style="float: left; margin-left: 10px;">
                                        <telerik:RadTextBox ID="txtPartTypeName" runat="server" MaxLength="16" CssClass="form-control" LabelWidth="64px" Resize="None" Width="200px" Height="34"></telerik:RadTextBox>
                                    </div>
                                    

                                </div>
                                <div style="margin-left: 300px; margin-top: -34px;">
                                    <span class="input-group-btn" style="margin-left: 15px;">
                                        <asp:Button ID="btnselect" runat="server" CssClass="btn btn-primary" Text="查询" OnClick="btnselect_Click1" /></span>
                                </div>
                            </div>
                            <div style="margin-top: 50px;">
                                <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand1" OnNeedDataSource="RadGrid1_NeedDataSource1" OnPageIndexChanged="RadGrid1_PageIndexChanged" Skin="Metro">
                                    <ClientSettings Selecting-AllowRowSelect="true">
                                        <Selecting AllowRowSelect="true" />
                                        <ClientEvents OnRowClick="GetUuserId" />
                                    </ClientSettings>
                                    <MasterTableView NoMasterRecordsText="暂无数据" AllowPaging="true" DataKeyNames="PartTypeID" PageSize="10" AutoGenerateColumns="false" ClientDataKeyNames="PartTypeID">
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <HeaderTemplate>序号</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal1" runat="server" Text="<%#Container.ItemIndex +1 %>"></asp:Literal>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="PartTypeName" HeaderText="类别名称"></telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return deletepart()" CommandName="Delete" CommandArgument='<%#Eval("PartTypeID") %>'>删除</asp:LinkButton>
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
                        <asp:Button ID="btnadd" runat="server" CssClass="btn btn-default" Text="添加" />
                        <asp:Button ID="btnxg" runat="server" CssClass="btn btn-default" Text="修改" />
                        <asp:Button ID="btnlook" runat="server" CssClass="btn btn-default" Text="查看配件" />
                    </p>
                </div>

            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>
</asp:Content>
