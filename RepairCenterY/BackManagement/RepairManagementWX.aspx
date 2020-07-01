<%@ Page Title="维修管理" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="RepairManagementWX.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairManagementWX" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=6.2.12.1017, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var id = -1;
        function GetDeclarationID(sender, args) {
            id = args.getDataKeyValue("DeclarationID");
        }
        //function Openlook() {
        //    if (-1 == id) {
        //        window.alert("请选择一条数据!");
        //    }
        //    else {
        //        window.location.href = "MaintenanceListWX.aspx?ID=" + id;
        //    }
        //}
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
            <telerik:AjaxSetting AjaxControlID="ddlUnitName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlUnitName" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlDeclarationState">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlDeclarationState" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">

            <div class="panel-heading">
                <div style="float: left;">
                    <h3 class="panel-title">维修管理</h3>
                </div>
                <div style="float: left;">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Management</p>
                </div>
            </div>

            <div class="panel-body">
                <div class="col-md-6" style="width: 100%;">
                    <!-- BASIC TABLE -->
                    <div class="panel" style="width: 100%;">
                        <div class="panel-body">
                            <table id="list_Table" style="width:100%">

                                        <tr style="height:45px">
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">报修设备  ：</td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                                <telerik:RadTextBox ID="txtMachineName" runat="server" MaxLength="16" LabelWidth="64px" Resize="None" Width="80%" Height="30px" ></telerik:RadTextBox>
                                            </td>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">报修时间  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <telerik:RadDatePicker ID="dpstarttime" runat="server" LabelWidth="64px" Resize="None" Width="80%" Height="30"></telerik:RadDatePicker>
                                            </td>
                                            <td style="width: 10%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">至  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <telerik:RadDatePicker ID="dpendtime" runat="server" LabelWidth="64px" Resize="None" Width="80%" Height="30"></telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">报修单位  ：</td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                                <asp:DropDownList ID="ddlUnitName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="80%" Height="30"></asp:DropDownList>
                                            </td>
                                            <td style="width: 13%; float: left; height: 32px; font-size: 15px; text-align: right; border-right: none; line-height: 35px;">报修状态  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <asp:DropDownList ID="ddlDeclarationState" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="80%" Height="30">
                                                <asp:ListItem runat="server" Text="全部" Value=""></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地待受理" Value="维修基地待受理"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地已受理" Value="维修基地已受理"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地维修中" Value="维修基地维修中"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地已完修" Value="维修基地已完修"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="装备中心已取回" Value="装备中心已取回"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修完成" Value="维修完成"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地待受理(返修)" Value="维修基地待受理(返修)"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地已受理(返修)" Value="维修基地已受理(返修)"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地维修中(返修)" Value="维修基地维修中(返修)"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地已完修(返修)" Value="维修基地已完修(返修)"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="装备中心已取回(返修)" Value="装备中心已取回(返修)"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="返修完成" Value="返修完成"></asp:ListItem>
                                            </asp:DropDownList>

                                            </td>
                                            <td style="width: 10%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;"">
                                                
                                            </td>
                                            <td style="width: 18%; text-align: left; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <asp:Button ID="Btn_search" runat="server" Text="查询" class="btn btn-primary" OnClick="Btn_search_Click" />
                                            </td>
                                        </tr>

                                        
                                    </table>
                            <%--<form class="navbar-form navbar-left" style="margin-top: -20px; text-align: center;">
                                <div class="input-group" style="width: 1350px;">
                                    <div class="machine" style="float: left; margin-left: 10px;">
                                        <div style="float: left;line-height: 35px">报修设备：</div>
                                        <div style="float: left;">
                                            </div>
                                    </div>
                                    <div class="machine" style="float: left; margin-left: 10px;">
                                        <div style="float: left;line-height: 35px">报修单位：&nbsp;</div>
                                        <div style="float: left;">
                                            </div>
                                    </div>

                                    <div class="Repairzt" style="float: left; width: 240px; height: 35px; margin-left: 10px; line-height: 35px">
                                        <div style="float: left;">报修状态:&nbsp;</div>
                                        <div style="float: left;">
                                            
                                        </div>
                                    </div>
                                    <div style="float: left; margin-left: 3px; line-height: 34px;">报修时间从：</div>
                                    <div style="float: left; margin-left: 10px;">
                                        
                                    </div>
                                    <div style="float: left; margin-left: 5px; line-height: 34px;">至</div>
                                    <div style="float: left; margin-left: 10px;">
                                        
                                    </div>
                                </div>

                                <div style="margin-left: 1265px; margin-top: -34px;">
                                    <span class="input-group-btn">
                                        
                                </div>
                            </form>--%>
                            <div class="content_main" style="margin-top: 25px;">
                                <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-CN" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound" Skin="Metro" OnItemCommand="RadGrid1_ItemCommand" OnPageIndexChanged="RadGrid1_PageIndexChanged">
                                    <ClientSettings Selecting-AllowRowSelect="true">
                                        <Selecting AllowRowSelect="true" />
                                        <ClientEvents OnRowClick="GetDeclarationID" />
                                    </ClientSettings>
                                    <MasterTableView NoMasterRecordsText="暂无数据" AllowPaging="true" DataKeyNames="DeclarationID" PageSize="10" AutoGenerateColumns="false" ClientDataKeyNames="DeclarationID">
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <HeaderTemplate>序号</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal1" runat="server" Text="<%#Container.ItemIndex +1 %>"></asp:Literal>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="MachineName" HeaderText="设备名称"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="MachineSonName" HeaderText="设备类别"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UnitName" HeaderText="报修单位"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="RepairTime" HeaderText="报修时间" DataFormatString="{0:yyyy-MM-dd}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DeclarationState" HeaderText="状态"></telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btndeal" runat="server" CommandName="deal" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>受理</asp:LinkButton>
                                                    <asp:LinkButton ID="btngive" runat="server" CommandName="give" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>分配</asp:LinkButton>
                                                    <asp:Label ID="lblnone" runat="server" Visible="false" Text="无"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>

                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>

                                        <BatchEditingSettings EditType="Cell"></BatchEditingSettings>

                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <Selecting AllowRowSelect="true" />
                                    </ClientSettings>
                                    <PagerStyle FirstPageToolTip="第一页" LastPageToolTip="最后一页" PrevPageToolTip="上一页" NextPageToolTip="下一页" PageSizeLabelText="每页显示数" PagerTextFormat="{4}共<strong>{5}</strong>条数据" />
                                    <PagerStyle PageSizeControlType="RadComboBox" />

                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>

                                    <div>
        
    </div>

                            </div>
                        </div>
                    </div>
                    <!-- END BASIC TABLE -->
                </div>
                <div class="panel-body">
                    <p class="demo-button" style="float: right;">
                        <asp:Button ID="btnlook" runat="server" class="btn btn-default" Text="查看维修" OnClick="btnlook_Click" />
                    </p>
                </div>
            </div>

        </div>
        <!-- END OVERVIEW -->
    </div>
    </span>
</asp:Content>
