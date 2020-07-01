<%@ Page Title="学生修改页" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="RepairCenterY.BackManagement.StudentEdit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
      <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">学生修改</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">User Edit</p>
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
                                 <asp:Label ID="Yonghuming" runat="server" Text="" style="float:left;margin-top:5px;margin-left:13px" placeholder="请输入用户名..."></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">真实姓名：</label>
                            <div class="col-sm-8">
                                 <asp:TextBox ID="Zhenshixingming" runat="server" CssClass="form-control" placeholder="请输入真实姓名..." MaxLength="20"></asp:TextBox>
                            </div>
                        </div>
                                                   <%--<div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">性别：</label>
                            <div class="col-sm-8">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                <asp:RadioButton ID="xingbienan" runat="server"  Text="男" Checked="True" GroupName="1"/>
                                 <asp:RadioButton ID="xingbienv" runat="server"  Text="女" GroupName="1"/>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                          <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">邮箱：</label>
                            <div class="col-sm-8">
                                 <asp:TextBox ID="Youxiang" runat="server" CssClass="form-control" placeholder="请输入邮箱..." MaxLength="20"></asp:TextBox>
                            </div>
                        </div>
                                                   <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">出生日期：</label>
                            <div class="col-sm-8">
                                <telerik:RadDatePicker ID="Chushengriqi" runat="server" CssClass="form-control" MinDate="1900/1/1" MaxDate="2020/1/1"></telerik:RadDatePicker>
                            </div>
                        </div>
                          <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系方式：</label>
                            <div class="col-sm-8">
                                 <asp:TextBox ID="Lianxidianhua" runat="server" CssClass="form-control" placeholder="请输入联系电话..." MaxLength="20"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">家庭住址：</label>
                            <div class="col-sm-8">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="Suoshusheng" runat="server" CssClass="form-control" Width="500px" OnLoad="Suoshusheng_Load" OnSelectedIndexChanged="Suoshusheng_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                                <div style="float: left; margin-left: 515px; margin-top: -35px;">
                                    <asp:DropDownList ID="Suoshushi" runat="server" CssClass="form-control" Width="500px" OnLoad="Suoshushi_Load" AppendDataBoundItems="true" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                            <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">详细地址：</label>
                            <div class="col-sm-8">
                                 <asp:TextBox ID="Xiangxidizhi" runat="server" CssClass="form-control" placeholder="请输入详细地址..." MaxLength="20"></asp:TextBox>
                            </div>
                        </div>--%>
                                                <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">添加时间：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="tianjiashijian" runat="server" CssClass="form-control" Text=""></asp:Label>
                            </div>
                        </div>
                           <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">账号状态：</label>
                            <div class="col-sm-8">
                                 <div style="float: left; margin-top: 5px;">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                    <div style="float: left;">
                                        <asp:RadioButton ID="qiyong" AutoPostBack="true" runat="server" Text="启用" GroupName="2" Checked="True" /></div>
                                    <div style="float: left; margin-left: 5px;">
                                        <asp:RadioButton ID="weiqiyong" AutoPostBack="true" runat="server" Text="未启用" GroupName="2" /></div>
                                        </ContentTemplate>
                                </asp:UpdatePanel>                   
                                </div>

                            </div>
                        </div>

                        </div>



                    </div>
                </div>
                <!-- END BASIC TABLE -->
                <div class="panel-body">
                    <p class="demo-button" style="float: right;">
                        <telerik:RadButton ID="queding" runat="server" Text="确定" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="xiugai_Click"></telerik:RadButton>
                        <telerik:RadButton ID="fanhui" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="fanhui_Click"></telerik:RadButton>
                    </p>
                </div>
            </div>
        </div>
          </div>
</asp:Content>
