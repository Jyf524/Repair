<%@ Page Title="配件入库管理" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="WarehousingDetails.aspx.cs" Inherits="RepairCenterY.BackManagement.WarehousingDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var id = -1;
        function GetUuserId(sender, args) {
            id = args.getDataKeyValue("PartPutRecordID");
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
            <telerik:AjaxSetting AjaxControlID="ddlPartTypeName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlPartTypeName" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="ddlPartName" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPartName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlPartTypeName" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="ddlPartName" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnselect">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">

            <div class="panel-heading">
                <div style="float: left;">
                    <h3 class="panel-title">配件入库管理</h3>
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
                            <table id="list_Table" style="width:100%">

                                        <tr style="height:45px">
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">配件类别  ：</td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                                <asp:DropDownList ID="ddlPartTypeName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="80%" Height="34" OnSelectedIndexChanged="ddlPartTypeName_SelectedIndexChanged1"></asp:DropDownList>
                                            </td>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">配件名称  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <asp:DropDownList ID="ddlPartName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="80%" Height="34"></asp:DropDownList>
                                            </td>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;"></td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">入库时间  ：</td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                                <telerik:RadDatePicker ID="dpstarttime" runat="server" LabelWidth="64px" Resize="None" Width="80%" Height="34"></telerik:RadDatePicker>
                                            </td>
                                            <td style="width: 13%; float: left; height: 32px; font-size: 15px; text-align: right; border-right: none; line-height: 35px;">至  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <telerik:RadDatePicker ID="dpendtime" runat="server" LabelWidth="64px" Resize="None" Width="80%" Height="34"></telerik:RadDatePicker>
                                            </td>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;"">
                                                
                                            </td>
                                            <td style="width: 18%; text-align: left; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <asp:Button ID="btnselect" runat="server" CssClass="btn btn-primary" Text="查询" OnClick="btnselect_Click" />
                                            </td>
                                        </tr>

                                        
                                    </table>
                            <%--<div class="navbar-form navbar-left" style="margin-top: -20px;">
                                <div class="input-group">
                                    <div style="float: left; line-height: 34px;">配件类别：</div>
                                    <div style="float: left; margin-left: 10px;">
                                        
                                    </div>
                                    <div style="float: left; line-height: 34px;margin-left: 10px;">配件名称：</div>
                                    <div style="float: left; margin-left: 10px;">
                                        
                                    </div>
                                    <div style="float: left; margin-left: 10px; line-height: 34px;">入库时间从：</div>
                                    <div style="float: left; margin-left: 10px;">
                                        
                                    </div>
                                    <div style="float: left; margin-left: 10px; line-height: 34px;">至</div>
                                    <div style="float: left; margin-left: 10px;">
                                        
                                    </div>

                                </div>
                                
                                <div style="margin-left: 1200px; margin-top: -34px;">
                                    <span class="input-group-btn" style="margin-left: 15px;">
                                        </span>
                                </div>
                            </div>--%>
                            <div style="margin-top:25px;">
                            <telerik:RadGrid ID="RadGrid1" runat="server" OnNeedDataSource="RadGrid1_NeedDataSource1" OnPageIndexChanged="RadGrid1_PageIndexChanged" OnItemCommand="RadGrid1_ItemCommand" Skin="Metro">
                                <ClientSettings Selecting-AllowRowSelect="true">
                                    <Selecting AllowRowSelect="true" />
                                    <ClientEvents OnRowClick="GetUuserId" />
                                </ClientSettings>
                                <MasterTableView NoMasterRecordsText="暂无数据" AllowPaging="true" DataKeyNames="PartPutRecordID" PageSize="10" AutoGenerateColumns="false" ClientDataKeyNames="PartPutRecordID">
                                    <Columns>
                                        <telerik:GridTemplateColumn>
                                            <HeaderTemplate>序号</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Literal ID="literal" runat="server" Text="<%#Container.ItemIndex+1 %>"></asp:Literal>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="PartTypeName" HeaderText="配件类别名称"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PartName" HeaderText="配件名称"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PartModel" HeaderText="配件型号"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PartPutNumber" HeaderText="配件数量"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PartPrice" HeaderText="配件价格"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PartSource" HeaderText="配件来源"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PartPutTime" HeaderText="入库时间"  DataFormatString="{0:yyyy-MM-dd}"></telerik:GridBoundColumn>
                                        
                                        <telerik:GridTemplateColumn HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('确认要删除此行?');" CommandName="Delete" CommandArgument='<%#Eval("PartPutRecordID") %>'>删除</asp:LinkButton>
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
                        
                        <asp:Button ID="btnadd" runat="server" CssClass="btn btn-default" Text="配件入库" OnClick="btnadd_Click" />

                    </p>
                </div>

            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>

</asp:Content>
