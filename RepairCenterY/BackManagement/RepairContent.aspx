<%@ Page Title="报修单详细" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="RepairContent.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairContent" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <style>
        img {
            max-width: 160px;
            float:left;
            margin-left:10px;
        }
    </style>
    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">报修详细</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Detail</p>
            </div>
        </div>
    <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备子类别:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label14" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备名称：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label1" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">资产序号：</label>
                            <div class="col-sm-8" >
                                <asp:Label ID="Label2" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">型号参数:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label3" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">其他附件：</label>
                            <div class="col-sm-8" >
                                <div class="form-control">
                                 <a id="aDown" style="color:#555" runat="server" >下载文件</a>
                                    </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机是否使用：</label>
                            <div class="col-sm-8" >
                                <asp:Label ID="Label6" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group" id="ReplacementID" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label" >代用机编号：</label>
                            <div class="col-sm-8" >
                                <asp:Label ID="Label4" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">报修单位：</label>
                            <div class="col-sm-8" >
                                <asp:Label ID="Label7" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">报修时间：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label8" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系人：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label9" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系电话：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label10" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">是否上门服务：</label>
                            <div class="col-sm-8" >
                                <asp:Label ID="Label11" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div  class="form-horizontal">
                        <div id="RepairID" runat="server" class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">维修员编号：</label>
                            <div class="col-sm-8">
                                 <asp:Label ID="Label12" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">维修进度：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label13" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            </div>
                        </div>        
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备图片：</label>
                            <div class="col-sm-8">

                                <telerik:RadListView ID="RadListView1" runat="server" OnNeedDataSource="RadListView1_NeedDataSource" PageSize="5">
                                    <ItemTemplate>
                                        <tr>
                                            <li style="list-style: none; float: left;">
                                                <asp:Image ID="imgPic" runat="server" Width="200" Height="140" CssClass="form-control" src='<%#Eval("imgUrl") %>' AlternateText="暂无数据"/>
                                            </li>
                                        </tr>
                                    </ItemTemplate>
                                </telerik:RadListView>

                            </div>
                        </div>                          
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障现象：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END BASIC TABLE -->

            <div class="panel-body">
                <p class="demo-button" style="float: right;">

                    <asp:Button ID="Button1" runat="server" class="btn btn-default" Text="返回" OnClick="Button1_Click" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
