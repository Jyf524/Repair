<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairReport.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairReport" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=6.2.12.1017, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:ReportViewer ID="ReportViewer1" runat="server" Width="50%" Height="700"
            Resources-FirstPageToolTip="首页" Resources-NavigateBackToolTip="后退" Resources-NavigateForwardToolTip="前进" 
            Resources-PreviousPageToolTip="上一页" Resources-NextPageToolTip="后一页" Resources-LastPageToolTip="尾页" Resources-RefreshToolTip="刷新" 
            Resources-ExportToolTip="导出" Resources-TogglePageLayoutToolTip="打印预览" Resources-PrintToolTip="打印" ></telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
