<%@ Page Title="个人中心修改" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="InformationEdit.aspx.cs" Inherits="RepairCenterY.BackManagement.InformationEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       #t  td {
            width:500px;
        }
        #myEditor {
            width: 265px;
            height: 66px;
        }
        img {
        max-width:1200px;
        }
    </style>
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
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="imgPic" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="rauFiles" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="TextBox1">
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadioButton2" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadioButton1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="DropDownList1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="DropDownList2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;"><h3 class="panel-title">个人信息修改</h3></div>
           <div style="float:left;"> <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Information Edit</p></div>
        </div>
          <div class="panel-body" style="margin-top:40px;">
               <div class="col-md-6" style="width: 100%;">
                <!-- BASIC TABLE -->
               <%-- <div class="panel" style="width: 100%;">--%>
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">头像：</label>
                            <div class="col-sm-8">
                                <asp:Image ID="imgPic" runat="server" Height="100" Width="140" />
                    <telerik:RadAsyncUpload ID="rauFiles" runat="server" Culture="zh-CN" AutoAddFileInputs="False" MaxFileInputsCount="1" OnFileUploaded="rauFiles_FileUploaded" OnClientFilesUploaded="OnClientFilesUploaded" AllowedFileExtensions="jpeg,jpg,gif,png" ChunkSize="0">
                        <Localization Cancel="取消" DropZone="拖动文件到此处" Remove="移除" Select="选择" />
                        <FileFilters>
                            <telerik:FileFilter Description="Images(jpeg,jpg,gif,png)" Extensions="jpeg,jpg,gif,png" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
                    <div id="Div1" runat="server">
                        <script type="text/javascript">
                            (function (global, undefined) {
                                var demo = {};
                                function OnClientFilesUploaded(sender, args) {
                                    $find(demo.ajaxManagerID).ajaxRequest();
                                }
                                function serverID(name, id) {
                                    demo[name] = id;
                                }
                                global.serverID = serverID;
                                global.OnClientFilesUploaded = OnClientFilesUploaded;
                            })(window)
                            serverID("ajaxManagerID", "<%= RadAjaxManager1.ClientID %>");
                        </script>
                    </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">用户名：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">真实姓名：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" MaxLength="30">汤颖</asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" id="XB" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label" >性别：</label>
                            <div class="col-sm-8">.
                                 <div style="float: left; margin-top: 5px;">
                                    <div style="float: left;">
                                        <asp:RadioButton ID="RadioButton1" AutoPostBack="true" runat="server" Text="男" GroupName="1" /></div>
                                    <div style="float: left; margin-left: 5px;">
                                        <asp:RadioButton ID="RadioButton2" AutoPostBack="true" runat="server" Text="女" GroupName="1"/></div>                   
                                </div> 
                            </div>
                        </div>
                        <div class="form-group" id="LXDH" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label" >联系电话：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" MaxLength="30">15380238771</asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" id="YX" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label" >邮箱：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" MaxLength="30">2361193298@qq.com</asp:TextBox>
                            </div>
                        </div>  
                            <div class="form-group" id="DW" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label">单位：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label7" runat="server" CssClass="form-control" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-group" id="CSRQ" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label" >出生日期：</label>
                            <div class="col-sm-8">
                                 <telerik:RadDatePicker ID="RadDatePicker1" runat="server" CssClass="form-control" MinDate="1900/1/1" ></telerik:RadDatePicker>
                        </div>
                            
                            </div>
                        <div class="form-group" id="JTZZ" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label" >家庭住址：</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="49%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnLoad="DropDownList1_Load" AutoPostBack="True" AppendDataBoundItems="True">
                                </asp:DropDownList>
                                <div style="float:left; margin-left:51%; margin-top:-35px; width:50%;">
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Width="98%" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                    </div>
                            </div>
                        </div>
                        <div class="form-group" id="XXDZ" runat="server">
                            <label for="focusedinput" class="col-sm-2 control-label" >详细地址：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" MaxLength="30">丹阳市</asp:TextBox>
                            </div>
                        </div>
                        
                    </div>
            </div>
                </div>
              </div>
                <div class="panel-body">
                    <p class="demo-button" style="float: right;">

                            &nbsp;<telerik:RadButton ID="RadButton1" runat="server" Text="确定" OnClick="RadButton1_Click1" Skin="Metro" height="34px" width="74px" BackColor="White"></telerik:RadButton>
                    <telerik:RadButton ID="RadButton2" runat="server" Text="返回" OnClick="RadButton2_Click" Skin="Metro" height="34px" width="74px" BackColor="White"></telerik:RadButton>
                    </p>
                </div>
                <!-- END BASIC TABLE -->
            </div>
    </div>
</asp:Content>
