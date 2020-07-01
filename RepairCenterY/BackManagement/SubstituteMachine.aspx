<%@ Page Title="代用机管理" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="SubstituteMachine.aspx.cs" Inherits="RepairCenterY.BackManagement.SubstituteMachine" %>

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
            <telerik:AjaxSetting AjaxControlID="MachineFather">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MachineFather" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="MachineSon" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="MachineSon">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MachineFather" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="MachineSon" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="DDLZ">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="DDLZ" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnselect">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnselect" />
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

    <script type="text/javascript">
        var id = -1;
        function GetID(sender, args) {
            id = args.getDataKeyValue("ReplacementID");
        }
        function OpenAddPro() {
            window.location.href = "SubstituteMachineAdd.aspx";
        }
        function OpenAddProTwo() {
            if (-1 == id) {
                window.alert("请选择一条数据!");
            }
            else {
                window.location.href = "SubstituteMachineEdit.aspx?ID=" + id;
            }
        }

        function OpenAddProFour() {
            if (-1 == id) {
                window.alert("请选择一条数据!");
            }
            else {
                window.location.href = "SubstitutionHistory.aspx?ID=" + id;
            }
        }
    </script>


    <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">
            <div class="panel-heading" style="float: left">
                <div style="float: left;">
                    <h3 class="panel-title">代用机管理</h3>
                </div>
                <div style="float: left;">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">SubstituteMachine</p>
                </div>
            </div>
            <div class="panel-body">
                <div class="navbar-form navbar-left" style="margin-top: 0px; width: 100%;">
                    <div class="panel-body">
                        <table id="list_Table" style="width: 100%">
                            <tr style="height: 45px">


                                <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none; line-height: 35px;">代用机名称：</td>
                                <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                    <telerik:RadTextBox ID="txtPartName" runat="server" CssClass="form-control" Resize="None" Width="80%" Height="34" placeholder="请输入" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" MaxLength="20"></telerik:RadTextBox>
                                </td>

                                <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none; line-height: 35px;">代用机状态：</td>
                                <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                    <asp:DropDownList ID="DDLZ" runat="server" Width="80%" Height="34" CssClass="form-control">
                                        <asp:ListItem Value="请选择">请选择</asp:ListItem>
                                        <asp:ListItem Value="已借出">已借出</asp:ListItem>
                                        <asp:ListItem Value="未借出">未借出</asp:ListItem>
                                        <asp:ListItem Value="已报废">已报废</asp:ListItem>
                                    </asp:DropDownList>
                                </td>

                                </tr>

                            <tr>

                                <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none; line-height: 35px;">代用机父类：</td>
                                <td style="width: 18%; float: left; height: 32px; border-right: none; line-height: 35px; padding-left: 10px;">
                                    <asp:DropDownList ID="MachineFather" runat="server" Width="80%" Height="34" CssClass="form-control" OnSelectedIndexChanged="MachineFather_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true"></asp:DropDownList>
                                </td>
                                <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none; line-height: 35px;">代用机子类：</td>
                                <td style="width: 18%; float: left; height: 32px; border-right: none; line-height: 35px; padding-left: 10px;">
                                    <asp:DropDownList ID="MachineSon" runat="server" Width="80%" Height="34" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true"></asp:DropDownList>
                                </td>
                                

                                <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;line-height: 35px;""></td>
                                <td style="width: 18%; text-align: left; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                    <span class="input-group-btn" style="margin-left: 15px;">
                                    <asp:Button ID="btnselect" runat="server" CssClass="btn btn-primary" Text="查询" OnClick="btnselect_Click" /></span></td>
                            </tr>



                        </table>
                    </div>
                    <%--                    <div style="margin-left: 290px; margin-top: -34px;">
                        
                    </div>--%>
                </div>
                <div class="col-md-6" style="width: 100%;">
                    <!-- BASIC TABLE -->
                    <div class="panel" style="width: 100%;">
                        <div class="panel-body">


                            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" Skin="Metro" Width="100%" OnNeedDataSource="RadGrid1_NeedDataSource" PageSize="10" OnItemCommand="RadGrid1_ItemCommand" OnPageIndexChanged="RadGrid1_PageIndexChanged">

                                <ClientSettings Selecting-AllowRowSelect="true">
                                    <Selecting AllowRowSelect="true" />
                                    <ClientEvents OnRowClick="GetID" />
                                </ClientSettings>

                                <MasterTableView DataKeyNames="ReplacementID" ClientDataKeyNames="ReplacementID" NoMasterRecordsText="暂无数据">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="序号" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Literal ID="Literal1" runat="server" Text="<%# Container.ItemIndex +1 %>"></asp:Literal>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机名称" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="GOXX" runat="server" CommandName="GOGO" CommandArgument='<%# Eval("ReplacementID") %>'><%# Eval("ReplacementName") %></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机型号" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <%# Eval("ReplacementModel") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机类别名称" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("MachineFatherName") %>-<%# Eval("MachineSonName") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机状态" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("ReplacementState") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="代用机添加时间" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <%# Eval("ReplacementAddTime","{0:yyyy-MM-dd}") %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="操作" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtn_Delete" runat="server" OnClientClick="return confirm('确定吗？')" CommandName="Delete" HeaderText="删除" CommandArgument='<%# Eval("ReplacementID") %>'>删除</asp:LinkButton>
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
                    <!-- END BASIC TABLE -->
                </div>
                <div class="panel-body">
                    <p class="demo-button" style="float: right;">
                        &nbsp;<telerik:RadButton ID="btnadd" runat="server" Text="添加代用机" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default"></telerik:RadButton>
                        <telerik:RadButton ID="btnxg" runat="server" Text="修改代用机" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default"></telerik:RadButton>
                        <telerik:RadButton ID="btnls" runat="server" Text="查看代用机历史记录" Height="34px" Width="120px" BackColor="White" Skin="Metro" CssClass="btn-default"></telerik:RadButton>
                    </p>
                </div>

            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>

</asp:Content>
