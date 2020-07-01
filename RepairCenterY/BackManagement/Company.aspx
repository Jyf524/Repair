<%@ Page Title="报修单位页面" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="RepairCenterY.BackManagement.Company" %>

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
            <telerik:AjaxSetting AjaxControlID="Button1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <script type="text/javascript">
        var id = -1;
        function UnitsID(sender, args) {
            id = args.getDataKeyValue("UnitID");
        }

        function OpenEdit() {
            if (-1 == id || id == null) {
                window.alert("请选择一条数据!");
            }
            else {
                document.location.href = "../BackManagement/CompanyEdit.aspx?ID=" + id;
            }
        }
        function ClearAndDelete() {
            if (confirm('确认删除?')) {
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
                document.location.href = "../BackManagement/CompanyDetailed.aspx?ID=" + id;
            }
        }
    </script>
    <style>
        #Search_row td {
            min-height: 40px;
            line-height: 40px;
        }
    </style>


      <div class="container-fluid">
        <!-- OVERVIEW -->
        <div class="panel panel-headline">
                   <div class="panel-heading">
            <div style="float: left;"><h3 class="panel-title">报修单位</h3></div>
           <div style="float:left;"> <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Reporting</p></div>
        </div>
            <div class="panel-body">
                <div class="col-md-6" style="width: 100%;">
                    <div class="panel-body">
                        <div class="col-md-6" style="width: 100%;">
                            <!-- BASIC TABLE -->
                            <div class="panel" style="width: 100%;">
                                <div class="panel-body">
                                    <form class="navbar-form navbar-left" style="margin-top: -20px; text-align: center;">
                                        <div class="input-group" style="width: 683px;">
                                            <div class="machine" style="float: left; margin-left: 10px;">
                                                  单位名称： <telerik:RadTextBox ID="RadTextBox1" runat="server" CssClass="form-control" LabelWidth="64px" Resize="None" Width="200px" Height="34" Skin="Metro"></telerik:RadTextBox>
                                            </div>
                                            <div class="machine" style="float: left; margin-left: 10px;">
                                                单位代码：&nbsp;
                                                <telerik:RadTextBox ID="RadTextBox2" runat="server" CssClass="form-control" LabelWidth="64px" Resize="None" Width="200px" Height="34" Skin="Metro"></telerik:RadTextBox>
                                            </div>
                                        </div>

                                        <div style="margin-left: 610px; margin-top: -34px;">
                                            <span class="input-group-btn">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="搜索" OnClick="Button1_Click" />
                                                </span>
                                        </div>
                                    </form>
                                    <div class="content_main" style="margin-top: 50px;">
                         
                                          <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" Width="100%"
                                    AutoGenerateColumns="False" ClientSettings-EnableRowHoverStyle="true" OnNeedDataSource="RadGrid1_NeedDataSource" OnPageIndexChanged="RadGrid1_PageIndexChanged" Skin="Metro" OnItemCommand="RadGrid1_ItemCommand" Culture="zh-CN" OnPageSizeChanged="RadGrid1_PageSizeChanged">
                                    <ExportSettings>
                                        <Pdf>
                                            <PageHeader>
                                                <LeftCell Text=""></LeftCell>
                                                <MiddleCell Text=""></MiddleCell>
                                                <RightCell Text=""></RightCell>
                                            </PageHeader>
                                            <PageFooter>
                                                <LeftCell Text=""></LeftCell>
                                                <MiddleCell Text=""></MiddleCell>
                                                <RightCell Text=""></RightCell>
                                            </PageFooter>
                                        </Pdf>
                                    </ExportSettings>
                                    <ClientSettings EnableRowHoverStyle="True">
                                        <Selecting AllowRowSelect="True" />
                                        <ClientEvents OnRowClick="UnitsID"></ClientEvents>
                                    </ClientSettings>
                                    <ClientSettings Selecting-AllowRowSelect="true">
                                        <Selecting AllowRowSelect="true" />
                                        <ClientEvents OnRowClick="UnitsID" />
                                    </ClientSettings>
                                    <MasterTableView NoMasterRecordsText="暂无数据" NoDetailRecordsText="暂无数据" DataKeyNames="UnitID" AllowPaging="true" PageSize="10" ClientDataKeyNames="UnitID">
                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <HeaderTemplate>
                                                    序号
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Literal ID="list" runat="server" Text="<%#Container.ItemIndex+1%>">
                                                    </asp:Literal>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="UnitName" HeaderText="单位名称">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text=""></ModelErrorMessage>
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UnitCode" HeaderText="单位代码">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text=""></ModelErrorMessage>
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UnitPhone" HeaderText="联系方式">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text=""></ModelErrorMessage>
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UnitUserID" HeaderText="单位负责人">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text=""></ModelErrorMessage>
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn>
                                                <HeaderTemplate>单位地址</HeaderTemplate>
                                                <ItemTemplate>
                                                      <%#Eval("Unitprovince")%>
                                                        -
                                                       <%#Eval("UnitCity")%>
                                                     -
                                                       <%#Eval("UnitAddress")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>



                                             <telerik:GridBoundColumn DataField="AddTime" HeaderText="添加时间"  DataFormatString="{0:yyyy-MM-dd}">
                                                <ColumnValidationSettings>
                                                    <ModelErrorMessage Text=""></ModelErrorMessage>
                                                </ColumnValidationSettings>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="delete" runat="server" OnClientClick="return ClearAndDelete()" CommandName="Delete" CommandArgument='<%#Eval("UnitID") %>'>删除</asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                        <BatchEditingSettings EditType="Cell"></BatchEditingSettings>
                                        <PagerStyle FirstPageToolTip="第一页" LastPageToolTip="最后一页" NextPageToolTip="下一页" PagerTextFormat="更改页：{4} &amp;nbsp;第&lt;strong&gt;{0}&lt;/strong&gt;页，共&lt;strong&gt;{1}&lt;/strong&gt;页，记录数 第&lt;strong&gt;{2}&lt;/strong&gt; 条到第 &lt;strong&gt;{3}&lt;/strong&gt;条 ，一共 &lt;strong&gt;{5}&lt;/strong&gt; 条记录" PageSizeLabelText="每页显示的数量" PrevPageToolTip="上一页" />
                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                    </MasterTableView>
                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
                                    </div>
                                </div>
                            </div>
                            <!-- END BASIC TABLE -->
                        </div>
                        <div class="panel-body">
                            <p class="demo-button" style="float: right;">
                              <telerik:RadButton ID="RadButton1" runat="server" Text="添加" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton1_Click"></telerik:RadButton>
                            <telerik:RadButton ID="RadButton2" runat="server" Text="修改" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default"></telerik:RadButton>
                          <%--  <telerik:RadButton ID="RadButton3" runat="server" Text="查看" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default"></telerik:RadButton>--%>

                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END OVERVIEW -->
    </div>



</asp:Content>
