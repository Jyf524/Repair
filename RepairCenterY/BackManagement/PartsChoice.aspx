<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartsChoice.aspx.cs" Inherits="RepairCenterY.BackManagement.PartsChoice" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="../assets/vendor/bootstrap/css/bootstrap.min.css"/>
	<link rel="stylesheet" href="../assets/vendor/font-awesome/css/font-awesome.min.css"/>
	<link rel="stylesheet" href="../assets/vendor/linearicons/style.css"/>
	<link rel="stylesheet" href="../assets/vendor/chartist/css/chartist-custom.css"/>
	<!-- MAIN CSS -->
	<link rel="stylesheet" href="../assets/css/main.css"/>
	<!-- FOR DEMO PURPOSES ONLY. You should remove this in your project -->
	<link rel="stylesheet" href="../assets/css/demo.css"/>
	<!-- GOOGLE FONTS -->
	<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700" rel="stylesheet"/>
	<!-- ICONS -->
    <link rel="apple-touch-icon" sizes="76x76" href="../favicon1.ico"/>
    <link rel="icon"  sizes="96x96" href="../favicon1.ico"/>
     <script type="text/javascript">
         //关闭模式窗口
         function GetRadWindow() {
             var oWnd = null;
             if (window.radWindow) oWnd = window.radWindow;
             else if (window.frameElement.radWindow) oWnd = window.frameElement.radWindow;
             return oWnd;
         }
         function GetClose() {
             var oWnd = GetRadWindow();
             oWnd.Close();
         }
         function CloseAndRebind(args) {
             GetRadWindow().Close();
             GetRadWindow().BrowserWindow.refreshGrid(args, "添加成功");
         }
    </script>
    <link href="../CSS/lanren.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
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
                <telerik:AjaxSetting AjaxControlID="LinkButton3">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadListView2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="RadDataPager1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDataPager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
                        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title" style="font-size:x-large">配件选择</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100; width:100px;">Parts Choice</p>
            </div>
        </div>
    <div style="min-height:1px;float:left;">

        <div>

         <div class="leibie"> 
             <div class="lanren">
                    <div id="nav-2015" aria-autocomplete="none">
                        <div id="category-2015" onmouseover="this.className='on'" onmouseleave="this.className=''">

                            <div id="allsort" style="    border: 1px solid #dfdfdf;">
                                <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration: none; text-align: left; margin-right:90px; color: #000000;" OnClick="LinkButton3_Click">全部</asp:LinkButton>
                                <%--循环第一层--%>
                                <telerik:RadListView ID="RadListView2" runat="server" OnItemDataBound="RadListView2_ItemDataBound" OnNeedDataSource="RadListView2_NeedDataSource" DataKeyNames="PartTypeID" AllowPaging="True">
                                    <ItemTemplate>
                                        <div class="item" onmouseover="this.className='item on'" onmouseleave="this.className='item'">
                                            <span>
                                                <h3><%--父类名称--%>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Style="text-decoration: none; text-align: left; color: #000000;"  CommandArgument='<%# Eval("PartTypeID") %>' OnClick="LinkButton1_Click"><%#Eval("PartTypeName")%></asp:LinkButton>></h3>
                                            </span>
                                            <div class="i-mc">
                                                <%--循环第二层--%><telerik:RadListView ID="RadListView3" runat="server">
                                                    <ItemTemplate>
                                                        <%--子类名称--%></a><%--循环第二层--%>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Style="text-decoration: none; text-align: left; color: #000000;" CommandArgument='<%# Eval("PartID") %>' OnClick="LinkButton2_Click"><%#Eval("PartName")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:RadListView>
                                            </div>
                                        </div>
                                        <%--循环第一层--%>
                                    </ItemTemplate>                                  
                                </telerik:RadListView>
                            </div>
                        </div>
                        <div style=" float:left; width:700px; margin-left:20px;">
                            <table style="border-collapse: collapse;  text-align:left;" width="700";>
<tr style=" background:#ebe9e9; height:50px;">
<td style="width:90px;" >商品图片</td>
<td style ="width:100px;"> 商品名称</td>
    <td style ="width:100px;"> 库存</td>
<td style="width:100px;">价格</td>
<%--<td style="width:70px;">折扣率</td>--%>
    <td style="width:90px;">
        操作
    </td>
</tr>
    </table>
        <div style="width:700px; float:left;">
            <telerik:RadListView ID="RadListView1" runat="server" MasterTableView-DataKeyNames="PartPutRecordID"    AllowPaging="True" PageSize="5" OnNeedDataSource="RadListView1_NeedDataSource" OnPageIndexChanged="RadListView1_PageIndexChanged" OnPageSizeChanged="RadListView1_PageSizeChanged" OnItemCommand="RadListView1_ItemCommand" OnItemDataBound="RadListView1_ItemDataBound">
            <ItemTemplate>
        <table style="border-collapse: collapse;  text-align:left;" width="700" cellspacing=2 cellpadding=2>
    
<tr>
<td style="width:100px; height:90px; text-align:left;">
                            <img src="<%#Eval("PartPicture")%>" width="60" height="60" style="border: 1px solid #dddddd;" /></td>
<td style ="width:100px;"><%#Eval("PartName")%></td>
    <td style ="width:100px;"><%#Eval("PartPutNumber")%></td>

<td style="width:100px; color:#ff0000;">￥<%#Eval("PartPrice")%></td>

<td style="width:90px;"><p><asp:LinkButton ID="Linb_del" runat="server" CommandName="tian" CommandArgument='<%# Eval("PartPutRecordID") %>' style="color:#000; text-decoration:none"  >添加</asp:LinkButton> </p></td>
</tr>
             </table>
</ItemTemplate>
            <EmptyItemTemplate>
                <div style="text-align: center; float: left; width: 1000px;font-size:xx-large;">暂无配件！</div>
            </EmptyItemTemplate>
            <EmptyDataTemplate>
                <div style="text-align: center; float: left; width: 1000px;font-size:xx-large; margin-top:50px;">暂无配件！</div>
            </EmptyDataTemplate>
        </telerik:RadListView>
           
            </div>
        <div style ="width:700px;"></div>
       <div style="margin:0 auto;">
        
        <telerik:RadDataPager ID="RadDataPager1" runat="server" PagedControlID="RadListView1" PageSize="5" Culture="zh-CN" SEOPagingQueryPageKey="RadListView1" Skin="Metro">
                    <Fields>
                        <telerik:RadDataPagerButtonField FieldType="FirstPrev"></telerik:RadDataPagerButtonField>
                        <telerik:RadDataPagerButtonField FieldType="Numeric"></telerik:RadDataPagerButtonField>
                        <telerik:RadDataPagerButtonField FieldType="NextLast"></telerik:RadDataPagerButtonField>
                    </Fields>
                </telerik:RadDataPager></div>

    <div>
        <table id="jiesuan" runat="server" style="border-collapse: collapse; text-align:left; " width="700" >
<tr style=" background: #efebeb; height:50px;">
    <td style="width:130px"></td>
    
<td style="width:100px;"></td>

<td style=" min-width:80px; color:#ff0000; font-size:xx-large; text-align:right;"></td>
    <td style="color:#ff0000; font-size:xx-large; text-align:left;"><div style="float:left;"></div></td>

<td style="width:100px;">
    <telerik:RadButton ID="RadButton2" runat="server" Text="确定" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton2_Click"></telerik:RadButton></td>
    <td style="width:100px;">
      <telerik:RadButton ID="RadButton3" runat="server" Text="返回" Height="34px" Width="74px" BackColor="White" Skin="Metro" CssClass="btn-default" OnClick="RadButton3_Click" ></telerik:RadButton></td>
    
</tr>
    </table>
                        </div>
                            </div>
                    </div>
                </div>
        

         </div>   
            

            </div>
    </div>
    </form>
</body>
</html>
