<%@ Page Title="用户列表页" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="UserDetailed.aspx.cs" Inherits="RepairCenterY.BackManagement.UserDetailed" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <script type="text/javascript">
                UserID = -1;
                //function OpenAddPro3() {
                //    if (UserID == -1 || UserID == null) {
                //        alert("请选择一条数据！");
                //    }
                //    else {
                //        window.location.href = "UserEdit.aspx?" + "UserID=" + encodeURI(UserID);
                //    }
                //}
                function GetID1(sender, args) {
                    UserID = args.getDataKeyValue("UserID");
                }
                //function OpenAddPro4() {
                //    if (UserID == -1 || UserID == null) {
                //        alert("请选择一条数据！");
                //    }
                //    else {
                //        window.location.href = "UnitUser.aspx?" + "UserID=" + encodeURI(UserID);
                //    }
                //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close" Modal="true" VisibleStatusbar="false" Height="20px">
            <Localization Close="关闭" Reload="刷新" Maximize="最大化" Restore="恢复" OK="确定" Cancel="取消" />
        </telerik:RadWindowManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
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
            <telerik:AjaxSetting AjaxControlID="chaxun">
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
                <h3 class="panel-title">用户管理</h3>
                </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">User Detail</p>
            </div></div>
						<div class="panel-body" style="margin-top:40px">
							<div class="cbp-spmenu-push">
							<!-- BASIC TABLE -->
                        <div class="form-three widget-shadow" style="width:100%;min-width:1000px">
                                <form class="navbar-form navbar-left" style="margin-top: -20px; text-align: center;width:50%">
                                    <%--<div class="input-group" style="width: 1400px;">--%>
                                        <div class="RepairTimeWord" style="float: left;width:10%;line-height:35px">
                                            用户名：</div><div class="machine" style="float: left;width:16%;margin-left:-5.6%"><telerik:RadTextBox ID="RadTxtSearchName" runat="server" LabelWidth="64px" Resize="None" Width="66%" Height="34px" style="margin-left:7%"></telerik:RadTextBox>
                                        </div>
                                        <div class="RepairTimeWord" style="float: left;margin-left:-2.5%;line-height: 35px;width:7%">
                                            身份：
                                        </div>
                                        <div class="RepairTime1" style="float: left; width: 20%;margin-left:-3%">
                                            <asp:DropDownList ID="Shenfen" runat="server" Height="25px" style="position:relative;left:5px;height:34px" Width="50%">
                                <Items>
                                    <asp:ListItem Text="全部"></asp:ListItem>
                                    <asp:ListItem Text="报修单位用户"></asp:ListItem>
                                    <asp:ListItem Text="装备中心管理员"></asp:ListItem>
                                    <asp:ListItem Text="维修基地管理员"></asp:ListItem>
                                    <asp:ListItem Text="指导老师"></asp:ListItem>
                                    <asp:ListItem Text="学生"></asp:ListItem>
                </Items>
            </asp:DropDownList>
                                        </div>
                               <div class="RepairTimeWord" style="float: left; margin-left: -7.5%; line-height: 35px;width:10%;">
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
                                    <div style="margin-left:69%;width:10%">
                                        <span class="input-group-btn">
                                           <telerik:RadButton ID="chaxun" runat="server" Text="查询" Skin="Metro" BackColor="#00A0F0" ForeColor="White" Width="63px" Height="30px" BorderColor="#00A0F0" OnClick="chaxun_Click"></telerik:RadButton>
                                            </span>
                                    </div>
                                </form>
                                    </div>
                                     <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-CN" AutoGenerateColumns="False" GridLines="None" Skin="Metro" AllowPaging="True" style="margin-top:30px;" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand">
                    <ClientSettings Selecting-AllowRowSelect="true">
                        <Selecting AllowRowSelect="true" />
                           <ClientEvents OnRowClick="GetID1" />
                    </ClientSettings>
<%--                                         <ClientSettings EnableRowHoverStyle="true">
                                             <Scrolling AllowScroll="true" />
                                         </ClientSettings>--%>
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
                    <telerik:GridBoundColumn HeaderText="单位名称" DataField="UnitName"></telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="UserName" HeaderText="用户名"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="UserIdentity" HeaderText="身份"></telerik:GridBoundColumn>
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
                        <PagerStyle FirstPageToolTip="第一页" LastPageToolTip="最后一页" NextPageToolTip="下一页" PageSizeLabelText="每页显示的数量" PagerTextFormat="更改页：{4} &amp;nbsp;第&lt;strong&gt;{0}&lt;/strong&gt;页，共&lt;strong&gt;{1}&lt;/strong&gt;页，记录数 第&lt;strong&gt;{2}&lt;/strong&gt; 条到第 &lt;strong&gt;{3}&lt;/strong&gt;条 ，一共 &lt;strong&gt;{5}&lt;/strong&gt; 条记录" PrevPageToolTip="上一页"/>
                    </MasterTableView>
                </telerik:RadGrid>
								</div> 
							</div>
     						<!-- END BASIC TABLE -->
                                </div>
                        <div class="panel-body">
									<p class="demo-button"  style="float:right;">
                                        <telerik:RadButton ID="bianji" runat="server" Text="修改" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="bianji_Click"></telerik:RadButton>
                                         <telerik:RadButton ID="tianjia" runat="server" Text="添加" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="tianjia_Click"></telerik:RadButton>
										<%--<telerik:RadButton ID="chakan" runat="server" Text="查看" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="chakan_Click"></telerik:RadButton>--%>
                                    </p>
                                    </div>
						</div>
</asp:Content>
   <%-- <div class="main" style="width:auto;width:100%;position:relative;top:-109px;height:200px;overflow:hidden;text-overflow:ellipsis;white-space: nowrap;margin:auto">
			<!-- MAIN CONTENT -->
			<div class="main-content">
				<div class="container-fluid">
					<!-- OVERVIEW -->
					<div class="panel panel-headline">
						<div class="panel-heading">
							<h3 class="panel-title">用户管理</h3>
							<p class="panel-subtitle">User Management</p>
						</div>
						<div class="panel-body">
							<div class="col-md-6" style="width:100%;">
							<!-- BASIC TABLE -->
							<div class="panel" style="width:100%;">
								<div class="panel-body">
                                <div class="navbar-form navbar-left" style="margin-top:-20px;">
					<div class="input-group">
						<input type="text" value="" class="form-control" placeholder="Search dashboard..."/></div>
                        <div style="margin-left:220px; margin-top:-34px;">
						<span class="input-group-btn" style=" margin-left:15px;"><button type="button" class="btn btn-primary">Go</button></span>
					</div>
				</div><br /><br />
                                    <div style="position:relative;left:-455px">
                                        <table style="min-width:800px">
                                        <tr>
                                        <td style="pos"><asp:Label ID="Label2" runat="server" Text="用户ID" style="position:relative;margin-left:15%;top:12px"></asp:Label></td>
                                        <td><asp:Label ID="Label3" runat="server" Text="单位ID" style="position:relative;left:;top:12px"></asp:Label></td>
                                        <td><asp:Label ID="Label4" runat="server" Text="用户名" style="position:relative;left:-100px;top:12px"></asp:Label></td>
                                        <td><asp:Label ID="Label5" runat="server" Text="身份" style="position:relative;left:20px;top:12px"></asp:Label></td>
                                        <td><asp:Label ID="Label6" runat="server" Text="性别" style="position:relative;left:220px;top:12px"></asp:Label></td>
                                        <td><asp:Label ID="Label7" runat="server" Text="联系电话" style="position:relative;left:330px;top:12px"></asp:Label></td>
                                        <td><asp:Label ID="Label8" runat="server" Text="详细地址" style="position:relative;left:500px;top:12px"></asp:Label></td>
                                        <td><asp:Label ID="Label9" runat="server" Text="操作" style="position:relative;left:690px;top:12px"></asp:Label></td>
                                        </tr>
                                        </table>
                                    </div>
                                    <hr style="width:100%;height:1.5px;background-color:#b9b9b9;min-width:800px"/>
                                    <table style="min-width:800px">
									<telerik:RadListView ID="RadListView1" runat="server" Skin="Metro" BackColor="White" OnNeedDataSource="RadListView1_NeedDataSource" OnItemCommand="RadListView1_ItemCommand">
                                               <EmptyDataTemplate>
                                                      <label style="margin-left:500px;margin-top:350px;position:absolute">未能查询到数据</label>
                                               </EmptyDataTemplate>
                                               <ItemTemplate>
                                                   <tr>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:14%;line-height:8px;"><asp:Label ID="yonghuid" runat="server" Text='<%#Eval("UserID") %>' style="position:absolute;top:-10px;left:15%"></asp:Label></td>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:14%;line-height:8px"><asp:Label ID="danweiid" runat="server" Text='<%#Eval("UnitID") %>'  style="position:absolute;top:-10px;left:-20.5%"></asp:Label></td>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:14%;line-height:8px"><asp:Label ID="yonghuming" runat="server" Text='<%#Eval("UserName") %>'  style="position:absolute;top:-10px;left:-47.5%"></asp:Label></td>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:15%;line-height:8px"><asp:Label ID="shenfen" runat="server" Text='<%#Eval("UserIdentity") %>'  style="position:absolute;top:-10px;left:-59.4%"></asp:Label></td>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:14%;line-height:8px"><asp:Label ID="xingbie" runat="server" Text='<%#Eval("UserSex") %>'  style="position:relative;top:-10px;left:-53%"></asp:Label></td>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:15%;line-height:8px"><asp:Label ID="lianxidianhua" runat="server" Text='<%#Eval("UserPhone") %>'  style="position:relative;top:-10px;left:-76%"></asp:Label></td>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:15%;line-height:8px"><asp:Label ID="Label1" runat="server" Text='<%#Eval("UserAddress") %>'  style="position:relative;top:-10px;left:-73%"></asp:Label></td>
                                                       <td style="position:relative;border-bottom:solid;border-bottom-color:#b9b9b9;width:15%;line-height:8px"><asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('确认删除?');" CommandName="Delete" CommandArgument='<%#Eval("UserID") %>' style="top:-10px;position:relative;left:-311%">删除</asp:LinkButton></td>
                                                   </tr>
                                               </ItemTemplate>
                                    </telerik:RadListView>
                                    </table>
                                    </div>
						</div>
					</div>
					<!-- END OVERVIEW -->
				</div>
			</div>
			<!-- END MAIN CONTENT -->
		</div>
                </div>
        </div>--%>