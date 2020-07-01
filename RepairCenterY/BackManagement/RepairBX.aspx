<%@ Page Title="报修单列表" Language="C#" MasterPageFile="~/BackManagement/RepairCenter.Master" AutoEventWireup="true" CodeBehind="RepairBX.aspx.cs" Inherits="RepairCenterY.BackManagement.RepairBX" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var id = -1;
        function GetDeclarationID(sender, args) {
            id = args.getDataKeyValue("DeclarationID");
        }
        function OpenEdit() {
            if (-1 == id) {
                window.alert("请选择一条数据!");
            }
            else {
                document.location.href = "RepairContent.aspx?ID=" + id;
            }
        }
        function OpenAddPro() {
            var oWnd = radopen("RepairBackAdd.aspx", "RadWindowManager1");
            oWnd.setSize(500, 360);
            oWnd.center();
            oWnd.show();
        }
        function openWin() {
            $('#exampleModal').modal('show');
            var Value = args.getDataKeyValue("DeclarationID");
            //var Lblxxx_Text = document.getElementById("Lblxxx");
            //Lblxxx_Text.text = Value;
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close" Modal="true" VisibleStatusbar="false" Height="20px">
        <Localization Close="关闭" Reload="刷新" Maximize="最大化" Restore="恢复" OK="确定" Cancel="取消" />
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadWindowManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <div class="panel panel-headline">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">报修管理</h3>
            </div>
            <div style="float: left;">
                <p class="panel-subtitle" style="line-height: 2; margin-left: 5px; font-weight: 100;">Repair Management</p>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-md-6" style="width: 100%;">
                <div class="panel-body">
                    <div class="col-md-6" style="width: 100%;">
                        <!-- BASIC TABLE -->
                        <div class="panel" style="width: 100%;">
                            <div class="panel-body">
                                    <table id="list_Table" style="width:100%">

                                        <tr style="height:45px">
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;">报修设备  ：
                                            </td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                                <telerik:RadTextBox ID="RadTxtSearchName" runat="server" LabelWidth="64px" Resize="None" Width="100%" Height="34px"></telerik:RadTextBox>
                                            </td>
                                            <td style="width: 13%; float: left; height: 32px; font-size: 15px; text-align: right; border-right: none; line-height: 35px;" >报修状态  :
                                            </td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <asp:DropDownList ID="DropDownList_zt" runat="server" Width="100%" Height="34px">
                                                    <asp:ListItem runat="server" Text="全部" Value=""></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="未上报" Value="未上报"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="待上门" Value="待上门"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="装备中心待受理" Value="装备中心待受理"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="装备中心已受理" Value="装备中心已受理"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="装备中心维修中" Value="装备中心维修中"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="装备中心已完修" Value="装备中心已完修"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地待受理" Value="维修基地待受理"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地已受理" Value="维修基地已受理"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地维修中" Value="维修基地维修中"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地已完修" Value="维修基地已完修"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地待受理(返修)" Value="维修基地待受理(返修)"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地已受理(返修)" Value="维修基地已受理(返修)"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地维修中(返修)" Value="维修基地维修中(返修)"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修基地已完修(返修)" Value="维修基地已完修(返修)"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="建议报废" Value="建议报废"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="装备中心已取回" Value="装备中心已取回"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="报修单位已取回" Value="报修单位已取回"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="报修单位已取回(返修)" Value="报修单位已取回(返修)"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="装备中心已取回(返修)" Value="装备中心已取回(返修)"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="维修完成" Value="维修完成"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="返修完成" Value="返修完成"></asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 13%; text-align: right; float: left; height: 32px; border-right: none;">报修时间 ：
                                            </td>
                                            <td style="width: 18%; float: left; height: 32px; text-align: left; padding-left: 10px; border-right: none;">
                                                <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Width="100%" Height="34px"></telerik:RadDatePicker>
                                            </td>
                                            <td style="width: 13%; float: left; height: 32px; font-size: 15px; text-align: right; border-right: none; line-height: 35px;">至：
                                            </td>
                                            <td style="width: 18%; text-align: right; float: left; height: 32px; padding-left: 10px; text-align: left; border-right: none; line-height: 30px;">
                                                <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Width="100%" Height="34px"></telerik:RadDatePicker>

                                            </td>
                                            <td style="width: 269px; text-align: left; float: right; height: 32px; padding-left: 10px; line-height: 32px;">
                                                <asp:Button ID="Btn_search" runat="server" Text="查询" class="btn btn-primary" OnClick="Btn_search_Click" />
                                                <asp:Label ID="Lable_xxx" runat="server" Text="" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>






                                    <div class="content_main" style="margin-top: 30px;">
                                        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-CN" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemDataBound="RadGrid1_ItemDataBound" Skin="Metro" OnItemCommand="RadGrid1_ItemCommand">
                                            <ExportSettings>
                                                <Pdf>
                                                    <PageHeader>
                                                        <LeftCell Text=""></LeftCell>

                                                        <MiddleCell Text=""></MiddleCell>

                                                        <RightCell Text=""></RightCell>
                                                    </PageHeader>

                                                    <PageFooter>
                                                        <LeftCell Text=""></LeftCell>

                                                        <MiddleCell Text=""></MiddleCell>

                                                        <RightCell Text=""></RightCell>
                                                    </PageFooter>
                                                </Pdf>
                                            </ExportSettings>

                                            <ClientSettings Selecting-AllowRowSelect="true">
                                                <Selecting AllowRowSelect="true" />
                                                <ClientEvents OnRowClick="GetDeclarationID" />
                                            </ClientSettings>
                                            <MasterTableView NoMasterRecordsText="暂无数据" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" ClientDataKeyNames="DeclarationID" DataKeyNames="DeclarationID">
                                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

                                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridTemplateColumn>
                                                        <HeaderTemplate>序号</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="Literal1" runat="server" Text="<%#Container.ItemIndex +1 %>"></asp:Literal>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="MachineName" HeaderText="设备名称">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                                        </ColumnValidationSettings>
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn>
                                                        <HeaderTemplate>设备类别</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#Eval("MachineFatherName")%>
                                                        -
                                                        <%#Eval("MachineSonName")%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <%--                                                <telerik:GridBoundColumn DataField="MachineSonName" HeaderText="设备子类别">
                                                    <ColumnValidationSettings>
                                                        <ModelErrorMessage Text=""></ModelErrorMessage>
                                                    </ColumnValidationSettings>
                                                </telerik:GridBoundColumn>--%>
                                                    <telerik:GridBoundColumn DataField="RepairTime" HeaderText="报修时间" DataFormatString="{0:yyyy-MM-dd}">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                                        </ColumnValidationSettings>
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DeclarationState" HeaderText="状态">
                                                        <ColumnValidationSettings>
                                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                                        </ColumnValidationSettings>
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="操作">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkBtn_CheckOK" runat="server" Visible="false" CommandName="CheckOK" CommandArgument='<%#Eval("DeclarationID") %>'>确认完成</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkBtn_CheckRepair2OK" runat="server" Visible="false" CommandName="CheckRepair2OK" CommandArgument='<%#Eval("DeclarationID") %>'>确认完成(返修)</asp:LinkButton>
                                                            <asp:Label ID="Lbl_None" runat="server" Visible="false" Text="无"></asp:Label>
                                                            <%--                                                        <asp:LinkButton ID="LinkBtn_None" runat="server" CommandName="None" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>无</asp:LinkButton>--%>
                                                            <asp:LinkButton ID="LinkBtn_Return" runat="server" CommandName="Return" OnClientClick="return confirm('确认要撤回此单?');" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>撤回</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkBtn_CheckBack" runat="server" CommandName="CheckBack" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>确认取回</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkBtn_CheckRepair2Back" runat="server" CommandName="CheckRepair2Back" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>确认取回(返修)</asp:LinkButton>
                                                            <asp:LinkButton ID="LinBtn_Chanel" runat="server" CommandName="Chanel" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>修改</asp:LinkButton>
                                                            <asp:LinkButton ID="LinBtn_UP" runat="server" CommandName="UP" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>上报</asp:LinkButton>
                                                            <asp:LinkButton ID="LinBtn_Repair2" runat="server" CommandName="Repair2" Visible="false" OnClientClick="openWin();return false;" CommandArgument='<%#Eval("DeclarationID") %>'>返修</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkBtn_Down" runat="server" target='_blank' CommandName="Down" Visible="false" CommandArgument='<%#Eval("DeclarationID") %>'>下载报修单</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>

                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                </EditFormSettings>

                                                <BatchEditingSettings EditType="Cell"></BatchEditingSettings>

                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                            </MasterTableView>

                                            <ClientSettings EnableRowHoverStyle="true">
                                                <Selecting AllowRowSelect="true" />
                                            </ClientSettings>
                                            <PagerStyle FirstPageToolTip="第一页" LastPageToolTip="最后一页" PrevPageToolTip="上一页" NextPageToolTip="下一页" PageSizeLabelText="每页显示数" PagerTextFormat="{4}共<strong>{5}</strong>条数据" />
                                            <PagerStyle PageSizeControlType="RadComboBox" />

                                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                            </div>
                            <!-- END BASIC TABLE -->
                        </div>
                        <div class="panel-body">
                            <p class="demo-button" style="float: right;">
                                <asp:Button ID="Btn_add" runat="server" class="btn btn-default" Text="添加" OnClick="Btn_add_Click" />
                                <asp:Button ID="Btn_check" runat="server" class="btn btn-default" Text="查看" OnClick="Btn_check_Click1" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="exampleModalLabel">填写返修说明</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="recipient-name" class="control-label">返修说明:</label>
                            <asp:TextBox ID="fxsm" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button1" class="btn btn-default" data-dismiss="modal" runat="server" Text="取消" />
                        <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="提交" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Javascript -->
        <script src="assets/vendor/jquery/jquery.min.js"></script>
        <script src="assets/vendor/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/vendor/jquery-slimscroll/jquery.slimscroll.min.js"></script>
        <script src="assets/vendor/jquery.easy-pie-chart/jquery.easypiechart.min.js"></script>
        <script src="assets/vendor/chartist/js/chartist.min.js"></script>
        <script src="assets/scripts/klorofil-common.js"></script>
        <script>
            $(function () {
                var data, options;

                // headline charts
                data = {
                    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                    series: [
                        [23, 29, 24, 40, 25, 24, 35],
                        [14, 25, 18, 34, 29, 38, 44],
                    ]
                };

                options = {
                    height: 300,
                    showArea: true,
                    showLine: false,
                    showPoint: false,
                    fullWidth: true,
                    axisX: {
                        showGrid: false
                    },
                    lineSmooth: false,
                };

                new Chartist.Line('#headline-chart', data, options);


                // visits trend charts
                data = {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    series: [{
                        name: 'series-real',
                        data: [200, 380, 350, 320, 410, 450, 570, 400, 555, 620, 750, 900],
                    }, {
                        name: 'series-projection',
                        data: [240, 350, 360, 380, 400, 450, 480, 523, 555, 600, 700, 800],
                    }]
                };

                options = {
                    fullWidth: true,
                    lineSmooth: false,
                    height: "270px",
                    low: 0,
                    high: 'auto',
                    series: {
                        'series-projection': {
                            showArea: true,
                            showPoint: false,
                            showLine: false
                        },
                    },
                    axisX: {
                        showGrid: false,

                    },
                    axisY: {
                        showGrid: false,
                        onlyInteger: true,
                        offset: 0,
                    },
                    chartPadding: {
                        left: 20,
                        right: 20
                    }
                };

                new Chartist.Line('#visits-trends-chart', data, options);


                // visits chart
                data = {
                    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                    series: [
                        [6384, 6342, 5437, 2764, 3958, 5068, 7654]
                    ]
                };

                options = {
                    height: 300,
                    axisX: {
                        showGrid: false
                    },
                };

                new Chartist.Bar('#visits-chart', data, options);


                // real-time pie chart
                var sysLoad = $('#system-load').easyPieChart({
                    size: 130,
                    barColor: function (percent) {
                        return "rgb(" + Math.round(200 * percent / 100) + ", " + Math.round(200 * (1.1 - percent / 100)) + ", 0)";
                    },
                    trackColor: 'rgba(245, 245, 245, 0.8)',
                    scaleColor: false,
                    lineWidth: 5,
                    lineCap: "square",
                    animate: 800
                });

                var updateInterval = 3000; // in milliseconds

                setInterval(function () {
                    var randomVal;
                    randomVal = getRandomInt(0, 100);

                    sysLoad.data('easyPieChart').update(randomVal);
                    sysLoad.find('.percent').text(randomVal);
                }, updateInterval);

                function getRandomInt(min, max) {
                    return Math.floor(Math.random() * (max - min + 1)) + min;
                }

            });
            $('#exampleModal').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget) // Button that triggered the modal
                var recipient = button.data('whatever') // Extract info from data-* attributes
                var modal = $(this)
                modal.find('.modal-title').text('New message to ' + recipient)
                modal.find('.modal-body input').val(recipient)
            })
        </script>
    </span>
</asp:Content>
