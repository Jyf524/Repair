<%@ Page Title="维修详细" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="MaintenanceListWX.aspx.cs" Inherits="RepairCenterY.BackManagement.MaintenanceListWX" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/RepairDetailedWX.css" rel="stylesheet" />
    <style>
        img
        {
            max-width: 1000px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
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
                <h3 class="panel-title">维修详细</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Detail</p>
            </div>
        </div>
        <div class="panel-body" style="margin-top: 40px;">
            <div class="cbp-spmenu-push">
                <!-- BASIC TABLE -->

                <div id="baoxiu" runat="server" class="form-horizontal">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">单号：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblListID" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">设备名称：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblMachineName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">设备父类别：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblMachineFatherName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">设备子类别：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblMachineSonName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">资产序号：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblAssetsID" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">型号参数：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblModel" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">是否上门服务：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblDoorServer" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">故障现象：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblBreakDown" runat="server" CssClass="form-control form_style" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">报修单位：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblUnitName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">联系人：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblContact" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">联系人电话：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblContactPhone" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">其他附件：</label>
                        <div class="col-sm-8">
                            <a id="down" runat="server" href="#" target="_blank">
                                <asp:Label ID="lblOtherPart" runat="server" CssClass="form-control" Text="下载附件"></asp:Label></a>
                        </div>
                    </div>

                </div>
                <div id="shouli" runat="server" class="form-horizontal">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">设备描述：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblDeviceDescription" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">故障预判：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblFaultPrediction" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">分配老师：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblteacher" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">预计完修时间：</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblEstimateTime" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-three widget-shadow">
                    <div id="repair" runat="server" class="form-horizontal">
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">维修员：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblRepairerName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">指导老师：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblTeacherName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">故障诊断及维修方案：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblRepairPlan" runat="server" CssClass="form-control form_style" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">配件价格：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblPartPrice" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                 <%--       <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">修理结果：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblResult" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">完修时间：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblResultTime" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">维修费用：</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblRepairPrice" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                        </div>


                    </div>

                </div>
            </div>
        </div>








        <div class="panel-body">
            <p class="demo-button" style="float: right;">
                <asp:Button ID="btnback" runat="server" class="btn btn-default" Text="返回" OnClick="btnback_Click" />

            </p>
        </div>



    </div>

</asp:Content>
