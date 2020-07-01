<%@ Page Title="设备父类别" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="EquipmentType.aspx.cs" Inherits="RepairCenterY.BackManagement.EquipmentType" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var id = -1;
        function GetID(sender, args) {
            id = args.getDataKeyValue("MachineFatherID");
        }
        function OpenAddPro() {
            var oWnd = radopen("../BackManagement/EquipmentTypeAdd.aspx", "RadWindowManager1");
            oWnd.setSize(500, 300);
            oWnd.center();
            oWnd.show();
        }
        function deleteID()
        {
            id = -1;
        }

        function OpenAddProTwo() {
            if (-1 == id || id == null) {
                window.alert("请选择一条数据!");
            }
            else {
                var oWnd = radopen("EquipmentTypeEdit.aspx?ID=" + id, "RadWindowManager1");

                oWnd.setSize(500, 300);
                oWnd.center();
                oWnd.show();
            }
        }
        function ClearAndDelete()
        {
            if (confirm('确认删除?'))
            {
                id = -1;
                return true;
            }
            return false;
        }
            function OpenAddProThree() {
                if (-1 == id || id == null) {
                    window.alert("请选择一条数据!");
                }
                else {
                    document.location.href = "../BackManagement/EquipmentSonType.aspx?ID=" + id;

                }
            }
            function refreshGrid(arg) {
                $find("<%= RadAjaxManager1.ClientID%>").ajaxRequest("Rebind");
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
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadWindowManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
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
                    <h3 class="panel-title">设备父类别管理</h3>
                </div>
                <div style="float: left;">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Equipment Type Management</p>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-6" style="width: 100%;">
                    <div class="panel-body">
                        <div class="col-md-6" style="width: 100%;">
                            <!-- BASIC TABLE -->
                            <div class="panel" style="width: 100%;">
                                <div class="panel-body">
                                    <form class="navbar-form navbar-left" style="margin-top: -20px; text-align: center;">
                                        <div class="input-group" >
                                            <div class="machine" style="float: left; margin-left: 10px;">
                                                父类别名称：<telerik:RadTextBox ID="RadTxtSearchName" runat="server" LabelWidth="64px" Resize="None" Width="160px" Height="34px"></telerik:RadTextBox>
                                            </div>
                                            </div>
                                            <div style="margin-left: 280px; margin-top: -34px;">
                                                <span class="input-group-btn">
                                                    <telerik:RadButton ID="RadButton1" runat="server" Text="查询" Skin="Metro" BackColor="#00A0F0" ForeColor="White" Width="63px" Height="34px" BorderColor="#00A0F0" OnClick="RadButton1_Click"></telerik:RadButton>
                                                    </span>
                                            </div>
                                    </form>
                                    <div class="content_main" style="margin-top: 20px;">
                                        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-CN" GridLines="None" Width="100%" OnNeedDataSource="RadGrid1_NeedDataSource" Skin="Metro" OnItemCommand="RadGrid1_ItemCommand" OnPageSizeChanged="RadGrid1_PageSizeChanged" AutoGenerateColumns="False" ClientSettings-EnableRowHoverStyle="true" >
                                            <ClientSettings Selecting-AllowRowSelect="true">
                                                <Selecting AllowRowSelect="true" />
                                                <ClientEvents OnRowClick="GetDeclarationID" />
                                            </ClientSettings>
                                            <MasterTableView NoMasterRecordsText="暂无数据" AllowPaging="true" DataKeyNames="MachineFatherID" PageSize="10" AutoGenerateColumns="false" ClientDataKeyNames="MachineFatherID">
                                                <Columns>
                                                    <telerik:GridTemplateColumn>
                                                        <HeaderTemplate>序号</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="Literal1" runat="server" Text="<%#Container.ItemIndex +1 %>"></asp:Literal>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="MachineFatherName" HeaderText="父类别名称"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="MachineFatherAddTime" HeaderText="添加时间" DataFormatString="{0:yyyy-MM-dd}"></telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="操作">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="delete" runat="server" OnClientClick="return ClearAndDelete();" CommandName="Delete" CommandArgument='<%#Eval("MachineFatherID") %>'>删除</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <PagerStyle FirstPageToolTip="第一页" LastPageToolTip="最后一页" NextPageToolTip="下一页" PagerTextFormat="更改页：{4} &amp;nbsp;第&lt;strong&gt;{0}&lt;/strong&gt;页，共&lt;strong&gt;{1}&lt;/strong&gt;页，记录数 第&lt;strong&gt;{2}&lt;/strong&gt; 条到第 &lt;strong&gt;{3}&lt;/strong&gt;条 ，一共 &lt;strong&gt;{5}&lt;/strong&gt; 条记录" PageSizeLabelText="每页显示的数量" PrevPageToolTip="上一页" />
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            </MasterTableView>
                                            <ClientSettings EnableRowHoverStyle="True">
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <ClientSettings Selecting-AllowRowSelect="true">
                                                <Selecting AllowRowSelect="true" />
                                                <ClientEvents OnRowClick="GetID" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                            </div>
                            <!-- END BASIC TABLE -->
                        </div>
                        <div class="panel-body">
                            <p class="demo-button" style="float: right;">
                                <telerik:RadButton ID="RadButton2" runat="server" Text="添加" OnClick="RadButton2_Click" Skin="Metro" Width="85px" Height="34px"></telerik:RadButton>
                                <telerik:RadButton ID="RadButton3" runat="server" Text="修改" OnClick="RadButton3_Click" Skin="Metro" Width="85px" Height="34"></telerik:RadButton>
                                <telerik:RadButton ID="RadButton4" runat="server" Text="查看子类别" OnClick="RadButton4_Click" Skin="Metro" Width="85px" Height="34px"></telerik:RadButton>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>                                    
</asp:Content>
