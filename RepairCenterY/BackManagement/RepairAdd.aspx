<%@ Page Title="报修单添加" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="RepairAdd.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairAdd" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function setUeditor() {
            var myEditor = document.getElementById("myEditor");
            myEditor.value = editor.getContent();//把得到的值给textarea
        }
    </script>
    <script src="../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="../ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var editor = new baidu.editor.ui.Editor();
        editor.render("<%=myEditor.ClientID%>");

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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rauFiles" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
        img {
            max-width: 160px;
            float: left;
            margin-left: 10px;
        }
    </style>
    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">报修添加</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Add</p>
            </div>
        </div>
        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->
                <div class="form-three widget-shadow">
                    <div class="form-horizontal">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <label for="focusedinput" class="col-sm-2 control-label">设备类别:</label>
                                    <div class="col-sm-8" style="margin-top: 4px">
                                        <asp:DropDownList ID="DDMachineFather" runat="server" OnSelectedIndexChanged="DDMachineFather_SelectedIndexChanged" OnLoad="DDMachineFather_Load" AppendDataBoundItems="true" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="focusedinput" class="col-sm-2 control-label">设备子类别:</label>
                                    <div class="col-sm-8" style="margin-top: 4px">
                                        <asp:DropDownList ID="DDMachineSon" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备名称：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">资产序号：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">型号参数：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">代用机是否使用：</label>
                            <div class="col-sm-8">
                                <div class="form-control">
                                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="dyj"
                                        Text="是" /><asp:RadioButton ID="RadioButton2" runat="server" Checked="true" GroupName="dyj" Text="否" />

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系人：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">联系电话：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">是否上门服务：</label>
                            <div class="col-sm-8">
                                <div class="form-control">
                                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="door" Text="是" /><asp:RadioButton ID="RadioButton4" runat="server" Checked="true" GroupName="door" Text="否" />
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">设备图片：</label>
                            <div class="col-sm-8">
                                <telerik:RadAsyncUpload ID="rauFiles" runat="server" Culture="zh-CN" AutoAddFileInputs="true" MaxFileInputsCount="5" OnFileUploaded="rauFiles_FileUploaded" OnClientFilesUploaded="OnClientFilesUploaded" Skin="Metro">
                                    <Localization Cancel="取消" DropZone="拖动文件到此处" Remove="移除" Select="选择" />
                                    <FileFilters>
                                        <telerik:FileFilter Description="Images(jpeg,jpg,gif,png)" Extensions="jpeg,jpg,gif,png" />
                                    </FileFilters>
                                </telerik:RadAsyncUpload>

                                <telerik:RadListView ID="RadListView1" runat="server" OnNeedDataSource="RadListView1_NeedDataSource" PageSize="5" OnItemCommand="RadListView1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <li style="list-style: none; float: left;">
                                                <asp:Image ID="imgPic" runat="server" Width="200" Height="140" CssClass="form-control" src='<%#Eval("imgUrl") %>' />
                                                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandName="Delete" HeaderText="删除" CommandArgument='<%# Eval("ID") %>'>删除</asp:LinkButton>
                                            </li>
                                        </tr>
                                    </ItemTemplate>
                                </telerik:RadListView>



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
                                        //<![CDATA[
                                        serverID("ajaxManagerID", "<%= RadAjaxManager1.ClientID %>");
                                        //]]>
                                    </script>
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">
                                其他附件：
                            </label>
                            <div class="col-sm-8">
                                <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" ChunkSize="0" Culture="zh-CN" MaxFileInputsCount="1" MaxFileSize="5242880" Skin="Metro">
                                    <Localization Remove="移除" Select="上传" Cancel="取消" DropZone="拖放" />
                                    <FileFilters>
                                        <telerik:FileFilter Description="jpg" Extensions="jpg" />
                                        <telerik:FileFilter Description="txt" Extensions="txt" />
                                        <telerik:FileFilter Description="docx" Extensions="docx" />
                                        <telerik:FileFilter Description="rar" Extensions="rar" />
                                        <telerik:FileFilter Description="gif" Extensions="gif" />
                                        <telerik:FileFilter Description="pdf" Extensions="pdf" />
                                    </FileFilters>
                                </telerik:RadAsyncUpload>
                                <asp:Label ID="Label1" runat="server" Text="(支持上传jpg,txt,docx,rar,gif,pdf格式及小于5MB的文件)"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障现象：</label>
                            <div class="col-sm-8">
                                <textarea id="myEditor" name="myEditor" runat="server" onblur="setUeditor()"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END BASIC TABLE -->

            <div class="panel-body">
                <p class="demo-button" style="float: right;">
                    <asp:Button ID="Btn_Add" runat="server" class="btn btn-default" Text="提交" OnClick="Btn_Add_Click" />
                    <asp:Button ID="Btn_down" runat="server" class="btn btn-default" Text="保存" OnClick="Btn_down_Click" />
                    <asp:Button ID="Btn_back" runat="server" class="btn btn-default" Text="返回" OnClick="Btn_back_Click" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
