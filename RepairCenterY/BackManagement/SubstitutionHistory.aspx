<%@ Page Title="代用机历史管理" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="SubstitutionHistory.aspx.cs" Inherits="RepairCenterY.BackManagement.SubstitutionHistory" %>

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
            <telerik:AjaxSetting AjaxControlID="btnselect">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnselect" UpdatePanelCssClass="" />
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
                <div style="float: left">
                    <h3 class="panel-title">代用机历史管理</h3>
                </div>
                <div style="float: left">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">SubstitutionHistory</p>
                </div>
            </div>
            <div class="panel-body">
                <div class="navbar-form navbar-left" style="margin-top: 0px; width: 100%;">
                    <div class="input-group">
                        <table>
                            <tr>
                                <%--<td>代用机名称：<telerik:RadTextBox ID="txtPartName" runat="server" CssClass="form-control" Resize="None" Width="160px" Height="34" placeholder="请输入" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" MaxLength="20"></telerik:RadTextBox></td>
                                <td style="width: 60px"></td>--%>
                                <td>借出时间：<telerik:RadDatePicker ID="GOTIME" runat="server" Width="160px" Height="34"></telerik:RadDatePicker>
                                </td>
                                <td>至<telerik:RadDatePicker ID="ENDTIME" runat="server" Width="160px" Height="34"></telerik:RadDatePicker>
                                </td>
                                <td>归还时间：<telerik:RadDatePicker ID="GOTIME2" runat="server" Width="160px" Height="34"></telerik:RadDatePicker>
                                </td>
                                <td>至<telerik:RadDatePicker ID="ENDTIME2" runat="server" Width="160px" Height="34"></telerik:RadDatePicker>
                                </td>

                                <td style="width: 80px"></td>
                                <td><span class="input-group-btn">
                                    <asp:Button ID="btnselect" runat="server" CssClass="btn btn-primary" Text="搜索" OnClick="btnselect_Click" /></span></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-md-6" style="width: 100%;">
                    <!-- BASIC TABLE -->
                    <div class="panel" style="width: 100%;">

                        <div class="panel-body">

                            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" Skin="Metro" OnNeedDataSource="RadGrid1_NeedDataSource" PageSize="10" OnPageIndexChanged="RadGrid1_PageIndexChanged">
                                <%--                                <ClientSettings Selecting-AllowRowSelect="true">
                                    <Selecting AllowRowSelect="true" />
                                    <ClientEvents OnRowClick="GetID" />
                                </ClientSettings>--%>
                                <MasterTableView DataKeyNames="ReplacementRecordID" ClientDataKeyNames="ReplacementRecordID" NoMasterRecordsText="暂无数据">
                                    <Columns>

                                        <telerik:GridTemplateColumn HeaderText="序号" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal1" runat="server" Text="<%# Container.ItemIndex +1 %>"></asp:Literal>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机名称" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("ReplacementName") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机借出时间" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("ReplacementLendTime","{0:yyyy-MM-dd}") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机归还时间" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("ReplacementBackTime","{0:yyyy-MM-dd}") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

<%--                                        <telerik:GridTemplateColumn HeaderText="代用机借出单位" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("UnitID") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>

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
                    <!-- END BASIC TABLE -->
                </div>
                <div class="panel-body">
                    <p class="demo-button" style="float: right;">
                        &nbsp;<telerik:RadButton ID="btnback" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="btnback_Click"></telerik:RadButton>
                    </p>
                </div>

            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>

</asp:Content>
