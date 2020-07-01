<%@ Page Title="维修列表" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="RepairListLS.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairListLS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <script type="text/javascript">
                var id = -1;
                function GetDeclarationID(sender, args) {
                    id = args.getDataKeyValue("DeclarationID");
                }
                function Openlook() {
                    if (-1 == id) {
                        window.alert("请选择一条数据!");
                    }
                    else {
                        window.location.href = "RepairAcceptanceZB.aspx?ID=" + id;
                    }
                }
                function refreshGrid(arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
         <AjaxSettings>
             <telerik:AjaxSetting AjaxControlID="RadGrid1">
                 <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                 </UpdatedControls>
             </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnlook">
                 <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                 </UpdatedControls>
             </telerik:AjaxSetting>
         </AjaxSettings>

    </telerik:RadAjaxManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;"><h3 class="panel-title">维修管理</h3></div>
           <div style="float:left;"> <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Detail</p></div>
        </div>
            <div class="panel-body">
                <div class="col-md-6" style="width: 100%;">
                    <div class="panel-body">
                        <div class="col-md-6" style="width: 100%; top: 0px; left: 0px;">
                            <!-- BASIC TABLE -->
                            <div class="panel" style="width: 100%;">
                                <div class="panel-body">
                                   <%-- <form class="navbar-form navbar-left" style="margin-top: -20px; text-align: center;">
                                        <div class="input-group" style="width: 1350px;">
                                            <div class="machine" style="float: left; margin-left: 10px;">
                                                报修设备：<telerik:RadTextBox ID="RadTxtSearchName" runat="server" LabelWidth="64px" Resize="None" Width="160px" Height="34px" ></telerik:RadTextBox>
                                            </div>
                                            <div class="machine" style="float: left; margin-left: 10px;">
                                                报修单位：&nbsp;
                                                <asp:DropDownList ID="ddlUnitsInfo" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="160" Height="34"></asp:DropDownList>
                                            </div>

                                            <div class="Repairzt" style="float: left; width: 240px; height: 35px; margin-left: 10px; line-height: 35px">
                                                报修状态:&nbsp;
                                            <asp:DropDownList ID="ddlPartName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="160" Height="34">
                                                <asp:ListItem runat="server" Text="请选择" Value=""></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地维修中" Value="维修基地维修中"></asp:ListItem>
                                                <asp:ListItem runat="server" Text="维修基地已完修" Value="维修基地已完修"></asp:ListItem>
                                                <asp:ListItem>维修基地维修中(返修)</asp:ListItem>
                                                <asp:ListItem>维修基地已完修(返修)</asp:ListItem>
                                                <asp:ListItem>装备中心已取回</asp:ListItem>
                                                <asp:ListItem>装备中心已取回(返修)</asp:ListItem>
                                            </asp:DropDownList>
                                            </div>
                                            <div style="float: left; margin-left: 10px; line-height: 34px;">使用时间从：</div>
                                            <div style="float: left; margin-left: 10px;">
                                                <telerik:RadDatePicker ID="dpstarttime" runat="server" LabelWidth="64px" Resize="None" Width="175px" Height="34"></telerik:RadDatePicker>
                                            </div>
                                            <div style="float: left; margin-left: 5px; line-height: 34px;">到:</div>
                                            <div style="float: left; margin-left: 10px;">
                                                <telerik:RadDatePicker ID="dpendtime" runat="server" LabelWidth="64px" Resize="None" Width="175px" Height="34"></telerik:RadDatePicker>
                                            </div>
                                        </div>

                                        <div style="margin-left: 1265px; margin-top: -34px;">
                                            <span class="input-group-btn">
                                               <telerik:RadButton ID="RadButton1" runat="server" Text="查询" Skin="Metro" BackColor="#00A0F0" ForeColor="White" Width="63px" Height="30px" BorderColor="#00A0F0" OnClick="RadButton1_Click"></telerik:RadButton>
                                        </div>
                                    </form>--%>
                                                                        <table id="list_Table" style="width:100%">

                                        <tr style="height:45px">
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">报修设备  ：</td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                               <telerik:RadTextBox ID="RadTxtSearchName" runat="server" LabelWidth="64px" Resize="None" Width="160px" Height="34px"></telerik:RadTextBox>
                                            </td>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">报修时间  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <telerik:RadDatePicker ID="dpstarttime" runat="server" LabelWidth="64px" Resize="None" Width="80%" Height="30"></telerik:RadDatePicker>
                                            </td>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">至  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <telerik:RadDatePicker ID="dpendtime" runat="server" LabelWidth="64px" Resize="None" Width="80%" Height="30"></telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;">报修单位  ：</td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                               <asp:DropDownList ID="ddlUnitsInfo" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Width="160" Height="34"></asp:DropDownList>
                                            </td>
                                            <td style="width: 13%; float: left; height: 32px; font-size: 15px; text-align: right; border-right: none; line-height: 35px;">报修状态  ：</td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
<asp:DropDownList ID="ddlPartName" runat="server" Width="160px" Height="34px" AppendDataBoundItems="True">
                                                                                                <asp:ListItem runat="server" Text="请选择" Value=""></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="申请维修" Value="申请维修"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="申请已撤回" Value="申请已撤回"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="装备中心待受理" Value="装备中心待受理"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="装备中心已受理" Value="装备中心已受理"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="装备中心维修中" Value="装备中心维修中"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="装备中心已完修" Value="装备中心已完修"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地待受理" Value="维修基地待受理"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地已受理" Value="维修基地已受理"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地维修中" Value="维修基地维修中"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地已完修" Value="维修基地已完修"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地待受理(返修)" Value="维修基地待受理(返修)"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地已受理(返修)" Value="维修基地已受理(返修)"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地维修中(返修)" Value="维修基地维修中(返修)"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修基地已完修(返修)" Value="维修基地已完修(返修)"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="建议报废" Value="建议报废"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="装备中心已取回" Value="装备中心已取回"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="装备中心已取回(返修)" Value="装备中心已取回(返修)"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="维修完成" Value="维修完成"></asp:ListItem>
                                                                                                <asp:ListItem runat="server" Text="返修完成" Value="返修完成"></asp:ListItem>
                                                                                                <asp:ListItem>待上门</asp:ListItem>
                                                                                            </asp:DropDownList>

                                            </td>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;"">
                                                
                                            </td>
                                            <td style="width: 18%; text-align: left; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <telerik:RadButton ID="RadButton1" runat="server" Text="查询" Skin="Metro" BackColor="#00A0F0" ForeColor="White" Width="63px" Height="30px" BorderColor="#00A0F0" OnClick="RadButton1_Click"></telerik:RadButton>
                                            </td>
                                        </tr>

                                        
                                    </table>
                                    <div class="content_main" style="margin-top: 50px;">
                                        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-CN" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound" Skin="Metro" OnItemCommand="RadGrid1_ItemCommand">
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
                                                    <telerik:GridBoundColumn DataField="RepairerID" HeaderText="维修员" Display="false"></telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="操作">
                                                        <ItemTemplate>
                                                           
                                                            <asp:LinkButton ID="btngive" runat="server" CommandName="fenpei" CommandArgument='<%#Eval("DeclarationID") %>'>分配</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="wc" CommandArgument='<%#Eval("DeclarationID") %>'>填写维修信息</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="dy" CommandArgument='<%#Eval("DeclarationID") %>'>打印报修单</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="wu" CommandArgument='<%#Eval("DeclarationID") %>'>无</asp:LinkButton>

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
            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>
</asp:Content>
