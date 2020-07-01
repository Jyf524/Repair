<%@ Page Title="老师维修单" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="MaintenanceListLS.aspx.cs" Inherits="RepairCenterY.BackManagement.MaintenanceListLS" %>

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
        <style>
        img
        {
            max-width: 1000px;
        }
    </style>
    <style type="text/css">
        .auto-style1 {
            width: 44px;
        }

        .auto-style2 {
            width: 210px;
        }
    </style>
    <script type="text/javascript">
        var id = -1;
        function GetID(sender, args) {
            //id = args.getDataKeyValue("SubTypeID");
        }

        function OpenAddPro(a) {
            var oWnd = radopen("PartsChoice.aspx", "RadWindowManager1");
            oWnd.setSize(1000, 700);
            oWnd.center();
            oWnd.show();
        }
        function refreshGrid(arg) {
            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
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
    <%--    <telerik:RadAjaxManager runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest1" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Label5" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadDataPager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="TextBox2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Label5" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="TextBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Label5" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label5" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Label5" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadDataPager1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadDataPager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Label5" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox2" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="TextBox1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Label9" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadDataPager1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close" Modal="true" VisibleStatusbar="false" Height="20px">
        <Localization Close="关闭" Reload="刷新" Maximize="最大化" Restore="恢复" OK="确定" Cancel="取消" />
    </telerik:RadWindowManager>


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
                            <label for="focusedinput" class="col-sm-2 control-label">指导老师：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label1" runat="server" CssClass="form-control" Text="王老师"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">学生：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label2" runat="server" CssClass="form-control" Text="汤颖，姚月影，吕文婷"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障诊断及维修方案：</label>
                            <div class="col-sm-8">
                                <textarea id="myEditor" name="myEditor" runat="server" onblur="setUeditor()" style="width: 1000px; height: 120px;"></textarea>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">完修时间：</label>
                            <div class="col-sm-8">
                                <telerik:RadDatePicker ID="RadDatePicker1" runat="server" CssClass="form-control" Enabled="false"></telerik:RadDatePicker>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">配件费用：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label5" runat="server" CssClass="form-control" Text="0"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">人工费用：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true" Text="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">维修费用：</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text="0" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">实际费用：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="Label9" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">配件选择：</label>
                            <div class="col-sm-8">
                                <div style="float: left; margin-left: 20px; width: 700px;">
                                    <table style="border-collapse: collapse; text-align: left; width: 700px;">
                                        <tr style="background: #ebe9e9; height: 50px;">
                                            <td style="width: 90px;">商品图片</td>
                                            <td style="width: 100px;">商品名称</td>
                                            <td style="width: 100px;">库存</td>
                                            <td style="width: 110px;">数量</td>
                                            <td style="width: 100px;">价格</td>
                                            <%--<td style="width:70px;">折扣率</td>--%>
                                            <td style="width: 90px;">操作
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 700px; float: left;">
                                        <telerik:RadListView ID="RadListView1" runat="server" MasterTableView-DataKeyNames="PartPutRecordID" AllowPaging="True" PageSize="5" OnNeedDataSource="RadListView1_NeedDataSource" OnPageIndexChanged="RadListView1_PageIndexChanged" OnPageSizeChanged="RadListView1_PageSizeChanged" OnItemCommand="RadListView1_ItemCommand">
                                            <ItemTemplate>
                                                <table style="border-collapse: collapse; text-align: left;" width="700" cellspacing="2" cellpadding="2">

                                                    <tr>
                                                        <td style="width: 100px; height: 90px; text-align: left;">
                                                            <img src="<%#Eval("PartPicture")%>" width="60" height="60" style="border: 1px solid #dddddd;" /></td>
                                                        <td style="width: 100px;"><%#Eval("PartName")%></td>
                                                        <td style="width: 100px;"><%#Eval("PartPutNumber")%></td>
                                                        <td style="width: 120px;">
                                                            <div>
                                                                <div style="float: left;">
                                                                    <telerik:RadButton ID="RadButton2" runat="server" Text="-" Style="float: left; width: 15px; height: 20px;" Skin="Metro" CommandName="jian" CommandArgument='<%# Eval("PartPutRecordID") %>'></telerik:RadButton>
                                                                </div>
                                                                <div style="float: left;">
                                                                    <telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Style="float: left; width: 40px; margin-top: -3px;" DbValue='<%#Eval("PartUseNumber")%>' NumberFormat-DecimalDigits="0" MinValue="1" MaxValue="9999999" Height="22px" Width="70px" MaxLength="7" ReadOnly="True"></telerik:RadNumericTextBox>
                                                                </div>
                                                                <div style="float: left;">
                                                                    <telerik:RadButton ID="RadButton1" runat="server" Text="+" Style="float: left; width: 15px; height: 20px;" Skin="Metro" CommandName="add" CommandArgument='<%# Eval("PartPutRecordID") %>'></telerik:RadButton>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <!--使用数量-->

                                                        <td style="width: 100px; color: #ff0000;">￥<%#Eval("PartPrice")%></td>

                                                        <td style="width: 90px;">
                                                            <p>
                                                                <asp:LinkButton ID="Linb_del" runat="server" CommandName="Delete" CommandArgument='<%# Eval("PartPutRecordID") %>' Style="color: #000; text-decoration: none;">删除</asp:LinkButton>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EmptyItemTemplate>
                                                <div style="text-align: center; float: left; width: 1000px; font-size: xx-large;">暂无配件！</div>
                                            </EmptyItemTemplate>
                                            <EmptyDataTemplate>
                                                <div style="text-align: center; float: left; width: 1000px; font-size: xx-large; margin-top: 50px;">暂无配件！</div>
                                            </EmptyDataTemplate>
                                        </telerik:RadListView>

                                    </div>
                                    <div style="width: 700px;"></div>
                                    <div style="margin: 0 auto;">

                                        <telerik:RadDataPager ID="RadDataPager1" runat="server" PagedControlID="RadListView1" PageSize="5" Culture="zh-CN" SEOPagingQueryPageKey="RadListView1" Skin="Metro">
                                            <Fields>
                                                <telerik:RadDataPagerButtonField FieldType="FirstPrev"></telerik:RadDataPagerButtonField>
                                                <telerik:RadDataPagerButtonField FieldType="Numeric"></telerik:RadDataPagerButtonField>
                                                <telerik:RadDataPagerButtonField FieldType="NextLast"></telerik:RadDataPagerButtonField>
                                            </Fields>
                                        </telerik:RadDataPager>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END BASIC TABLE -->
                    <div class="panel-body">
                        <div class="demo-button" style="float: right;">
                            <div class="modal fade" tabindex="-1" role="dialog">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">平均线在</button>
                                            <h4 class="modal-title">Modal title</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>One fine body</p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary">Save changes</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <!-- /.modal -->
                            <telerik:RadButton ID="RadButton5" runat="server" Text="选择配件" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton5_Click"></telerik:RadButton>
                            <telerik:RadButton ID="RadButton2" runat="server" Text="确定" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton2_Click"></telerik:RadButton>
                            <%--<telerik:RadButton ID="RadButton3" runat="server" Text="刷新" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton3_Click1" Visible="False"></telerik:RadButton>--%>
                            <telerik:RadButton ID="RadButton1" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton1_Click"></telerik:RadButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
