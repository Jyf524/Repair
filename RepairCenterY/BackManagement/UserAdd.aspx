<%@ Page Title="用户添加页" Language="C#" EnableEventValidation="false" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="RepairCenterY.BackManagement.UserAdd" %>
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
				<div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">用户添加</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">User Add</p>
            </div>
        </div>
        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">用户名：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Yonghuming" runat="server" CssClass="form-control" MaxLength="20" placeholder="请输入用户名..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">真实姓名：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Zhenshixingming" runat="server" CssClass="form-control" MaxLength="20" placeholder="请输入真实姓名..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">身份：</label>
                            <div class="col-sm-8">
                                        <div style="float: left;">
                                            <asp:RadioButton ID="bxdwyh" AutoPostBack="true" runat="server" Text="报修单位用户" GroupName="3" Checked="true" OnCheckedChanged="bxdwyh_CheckedChanged"/>
                                        </div>
                                        <div style="float: left; margin-left: 5px;">
                                            <asp:RadioButton ID="zbzxgly" AutoPostBack="true" runat="server" Text="装备中心管理员" GroupName="3" OnCheckedChanged="bxdwyh_CheckedChanged"/>
                                        </div>
                                        <div style="float: left; margin-left: 5px;">
                                            <asp:RadioButton ID="wxzxgly" AutoPostBack="true" runat="server" Text="维修中心管理员" GroupName="3" OnCheckedChanged="bxdwyh_CheckedChanged"/>
                                        </div>
                                        <div style="float: left; margin-left: 5px;">
                                            <asp:RadioButton ID="zdls" AutoPostBack="true" runat="server" Text="指导老师" GroupName="3" OnCheckedChanged="bxdwyh_CheckedChanged"/>
                                        </div>
                                        <div style="float: left; margin-left: 5px;">
                                            <asp:RadioButton ID="xs" AutoPostBack="true" runat="server" Text="学生" GroupName="3" OnCheckedChanged="bxdwyh_CheckedChanged"/>
                                        </div>
<%--                                <asp:DropDownList ID="Shenfen" runat="server" CssClass="form-control" OnSelectedIndexChanged="Shenfen_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true">
                                    <items>
                                    <asp:ListItem Text="报修单位用户"></asp:ListItem>
                                    <asp:ListItem Text="装备中心管理员"></asp:ListItem>
                                    <asp:ListItem Text="维修中心管理员"></asp:ListItem>
                                    <asp:ListItem Text="指导老师"></asp:ListItem>
                                    <asp:ListItem Text="学生"></asp:ListItem>
                                    </items>
                                </asp:DropDownList>--%>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="mimahoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">密码:</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Mima" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password" placeholder="请输入密码..." onpaste="return false;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="querenmimahoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">确认密码:</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="querenmima" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password" placeholder="请输入确认密码..." onpaste="return false;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="suoshulaoshihoutai" visible="false">
                            <label for="focusedinput" class="col-sm-2 control-label">所属老师：</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="suoshulaoshi" runat="server" CssClass="form-control" OnLoad="suoshulaoshi_Load">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="danweihoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">单位：</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="Danwei" runat="server" CssClass="form-control" OnLoad="Danwei_Load">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="xingbiehoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">性别：</label>
                              <div style="float: left; margin-top: 5px;margin-left:15px">
                                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <div style="float: left;">
                                            <asp:RadioButton ID="xingbeinan" AutoPostBack="true" runat="server" Text="男" GroupName="1" Checked="true"/>
                                        </div>
                                        <div style="float: left; margin-left: 5px;">
                                            <asp:RadioButton ID="xingbienv" AutoPostBack="true" runat="server" Text="女" GroupName="1" />
                                        </div>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                                    </div>
                        </div>
                        <div class="form-group" runat="server" id="youxianghoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">邮箱：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Youxiang" runat="server" CssClass="form-control" MaxLength="20" placeholder="请输入邮箱..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="chushengriqihoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">出生日期：</label>
                            <div class="col-sm-8">
                                <telerik:RadDatePicker ID="Chushengriqi" runat="server" CssClass="form-control" MaxDate="2020/1/1" MinDate="1900/1/1"></telerik:RadDatePicker>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="lianxifangshihoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">联系方式：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Lianxidianhua" runat="server" CssClass="form-control" MaxLength="20" placeholder="请输入联系方式..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="jiatingzhuzhihoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">家庭住址：</label>
                            <div class="col-sm-8">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="Suoshusheng" runat="server" CssClass="form-control" Width="50%" AppendDataBoundItems="true" AutoPostBack="true" OnLoad="Suoshusheng_Load" OnSelectedIndexChanged="Suoshusheng_SelectedIndexChanged1"></asp:DropDownList>
                                <div style="float: left; margin-left: 50%; margin-top: -35px;width:50%">
                                    <asp:DropDownList ID="Suoshushi" runat="server" CssClass="form-control" Width="100%" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList></div>
                                </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <div class="form-group" runat="server" id="xiangxidizhihoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">详细地址：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Xiangxidizhi" runat="server" CssClass="form-control" MaxLength="20" placeholder="请输入详细地址..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" runat="server" id="zhanghaozhuangtaihoutai">
                            <label for="focusedinput" class="col-sm-2 control-label">账号状态：</label>
                              <div style="float: left; margin-top: 5px;margin-left:15px">
                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div style="float: left;">
                                            <asp:RadioButton ID="qiyong" AutoPostBack="true" runat="server" Text="启用" GroupName="2" Checked="true"/>
                                        </div>
                                        <div style="float: left; margin-left: 5px;">
                                            <asp:RadioButton ID="weiqiyong" AutoPostBack="true" runat="server" Text="未启用" GroupName="2" />
                                        </div>
                                    </div>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
                
            <!-- END BASIC TABLE -->
<asp:Label ID="yingcangzhi" runat="server" Text="1" Visible="false"></asp:Label>
            <div class="panel-body">
                <p class="demo-button" style="float: right;">
                    <telerik:RadButton ID="queding" runat="server" Text="确定" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="Tianjia_Click" Checked="true"></telerik:RadButton>
                    <telerik:RadButton ID="fanhui" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="Fanhui_Click"></telerik:RadButton>
                </p>
            </div>
        </div>
    </div>
                    </div>
</asp:Content>
