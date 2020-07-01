<%@ Page Title="老师列表页" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="TeacherInformation.aspx.cs" Inherits="RepairCenterY.BackManagement.TeacherInformation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        UserID = -1;
        ////function OpenAddPro3() {
        ////    if (UserID == -1 || UserID == null) {
        ////        alert("请选择一条数据！");
        ////    }
        ////    else {
        ////        window.location.href = "TeacherEdit.aspx?" + "UserID=" + encodeURI(UserID);
        ////    }
        ////}
        function GetID1(sender, args) {
            UserID = args.getDataKeyValue("UserID");
        }
        //function OpenAddPro4() {
        //    if (UserID == -1 || UserID == null) {
        //        alert("请选择一条数据！");
        //    }
        //    else {
        //        window.location.href = "TeacherContent.aspx?" + "UserID=" + encodeURI(UserID);
        //    }
        //}
    </script>
<%--    <style type="text/css">
        body {
            overflow: hidden;
        }
    </style>--%>
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
            <telerik:AjaxSetting AjaxControlID="chaxun1">
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
                    <h3 class="panel-title">老师管理</h3>
                </div>
                <div style="float: left;">
                    <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">User Detail</p>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-md-6" style="width: 100%;">
                    <!-- BASIC TABLE -->
                    <div class="panel" style="width: 100%;">
                        <div class="panel-body">
                            <div class="form-three widget-shadow" style="width:100%;min-width:1000px">
                            <form class="navbar-form navbar-left" style="margin-top: -20px; text-align: center;">
                                <%--<div class="input-group" style="width: 1400px;">--%>
                                <div class="machine" style="float: left;width:10%;line-height:35px">
                                    用户名：
                                    </div>
                                <div class="machine" style="float: left;width:14%;margin-left:-5.5%">
                                <telerik:RadTextBox ID="RadTxtSearchName" runat="server" LabelWidth="64px" Resize="None" Width="66%" Height="34px" style="margin-left:7%"></telerik:RadTextBox>
                                </div>
                                <div class="RepairTimeWord" style="float: left; margin-left: -1%; line-height: 35px;width:10%">
                                    添加时间：
                                </div>
                                <div class="RepairTime1" style="float: left; width: 10%;margin-left:-3.5%">
                                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Width="120%" Height="34px" Culture="zh-CN" MinDate="1900/1/1" MaxDate="2020/1/1"></telerik:RadDatePicker>
                                </div>
                                <div class="RepairTimeWord" style="float: left; margin-left: 3%; line-height: 35px;width:10%">
                                    至
                                </div>
                                <div class="RepairTime1" style="float: left; width: 10%;margin-left:-7.5%">
                                    <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Width="120%" Height="34px" Culture="zh-CN" MinDate="1900/1/1" MaxDate="2020/1/1"></telerik:RadDatePicker>
                                </div>
                                <%--</div>--%>
                                <div style="margin-left:55%;width:10%">
                                    <span class="input-group-btn">
                                        <telerik:RadButton ID="chaxun1" runat="server" Text="查询" Skin="Metro" BackColor="#00A0F0" ForeColor="White" Width="63px" Height="30px" BorderColor="#00A0F0" OnClick="chaxun1_Click"></telerik:RadButton>
                                    </span>
                                </div>
                            </form>
                                </div>
                            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-CN" AutoGenerateColumns="False" GridLines="None" Skin="Metro" AllowPaging="True" Style="margin-top: 30px;" OnNeedDataSource="RadGrid1_NeedDataSource1" OnItemCommand="RadGrid1_ItemCommand1">
                                <ClientSettings Selecting-AllowRowSelect="true">
                                    <Selecting AllowRowSelect="true" />
                                    <ClientEvents OnRowClick="GetID1" />
                                </ClientSettings>

                                <MasterTableView DataKeyNames="UserID" ClientDataKeyNames="UserID" PageSize="10" NoMasterRecordsText="暂无数据">

                                    <Columns>
                                        <%--                      <telerik:GridTemplateColumn HeaderStyle-Width="5%">
                     <HeaderTemplate >
                            序号
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server" Text="<%#Container.ItemIndex+1%>" ></asp:Literal>
                        </ItemTemplate>
                         </telerik:GridTemplateColumn>--%>
                                                                 <telerik:GridTemplateColumn HeaderStyle-Width="25%">
                            <HeaderTemplate>
                                序号
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Literal ID="lit" runat="server" Text="<%#Container.ItemIndex+1%>"></asp:Literal>
                            </ItemTemplate>
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="UserName" HeaderText="用户名"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="UserSex" HeaderText="性别"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="UserPhone" HeaderText="联系电话"></telerik:GridBoundColumn>
                                           <telerik:GridTemplateColumn>
                                                <HeaderTemplate>详细地址</HeaderTemplate>
                                                <ItemTemplate>
                                                      <%#Eval("UserProvince")%>
                                                        -
                                                       <%#Eval("UserCity")%>
                                                     -
                                                       <%#Eval("UserAddress")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="UserAddTime" HeaderText="添加时间"></telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="shanchu" runat="server" OnClientClick="return confirm('确认要删?');" CommandName="Deletes" CommandArgument='<%#Eval("UserID")%>' ForeColor="#727272" Font-Size="14px">删除</asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <PagerStyle FirstPageToolTip="第一页" LastPageToolTip="最后一页" PageSizeLabelText="每页显示的数量" NextPageToolTip="下一页" PagerTextFormat="更改页：{4} &amp;nbsp;第&lt;strong&gt;{0}&lt;/strong&gt;页，共&lt;strong&gt;{1}&lt;/strong&gt;页，记录数 第&lt;strong&gt;{2}&lt;/strong&gt; 条到第 &lt;strong&gt;{3}&lt;/strong&gt;条 ，一共 &lt;strong&gt;{5}&lt;/strong&gt; 条记录" PrevPageToolTip="上一页" />
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>

                    </div>
                    <!-- END BASIC TABLE -->
                </div>
                <div class="panel-body">
                    <p class="demo-button" style="float: right;">
                        <telerik:RadButton ID="bianji" runat="server" Text="修改" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="bianji_Click"></telerik:RadButton>
                        <telerik:RadButton ID="tianjia" runat="server" Text="添加" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="tianjia_Click1"></telerik:RadButton>
                        <%--<telerik:RadButton ID="chakan" runat="server" Text="查看" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="chakan_Click"></telerik:RadButton>--%>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
