<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ordenPago.aspx.cs" Inherits="Formularios_ordenPago" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        var template = '<span style="color:{0};">{1}</span>';

        var setFormat = function setFormat() {
            Ext.util.Format.thousandSeparator = ',';
            Ext.util.Format.decimalSeparator = '.';
            Ext.util.Format.UsMoney;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <%--        <ext:Store ID="strRols" runat="server" OnReadData="MyData_Refresh" PageSize="15">--%>
        <ext:Store ID="strPagos" runat="server" PageSize="15">
            <Model>
                <ext:Model ID="Model1" runat="server">
                    <Fields>
                        <ext:ModelField Name="id_rol" />
                        <ext:ModelField Name="rol" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store runat="server" ID="strDetalleFactura">
            <Model>
                <ext:Model ID="Model2" runat="server" IDProperty="id_servicio">
                    <Fields>
                        <ext:ModelField Name="id_servicio" />
                        <ext:ModelField Name="servicio" />
                        <ext:ModelField Name="cantidad" />
                        <ext:ModelField Name="monto" />
                        <ext:ModelField Name="total" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Viewport ID="ViewPort1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:GridPanel ID="GridPanel1" runat="server" StoreID="strPagos"
                    AnchorHorizontal="90%" AnchorVertical="100%" Region="Center">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" StyleSpec="padding-bottom:3px;">
                            <Items>
                                <ext:Label ID="Label3" runat="server" Html="<CENTER><b>PACIENTES PENDIENTES DE PAGO</b></CENTER>" HideLabel="true" Flex="1" />
                                <%-- <ext:ToolbarSeparator ID="ToolbarSeparator" runat="server" />
                               <ext:Button ID="Button3" runat="server" Text="Nuevo" Icon="LockAdd" ToolTip="Nuevo Rol">
                                    <Listeners>
                                        <Click Handler="#{winCrear}.show();" />
                                    </Listeners>
                                </ext:Button>--%>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="C1" runat="server" Text="Código" DataIndex="id_factura" Width="80" Align="Center" />
                            <ext:Column ID="C2" runat="server" Text="Nombre" DataIndex="paciente" Flex="1" />
                            <ext:Column ID="C3" runat="server" Text="Monto" DataIndex="monto" Width="100" Align="Center" />
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Width="125" Text="Acciones" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="LockEdit" CommandName="Editar" Text="Editar">
                                        <ToolTip Text="Editar Rol" />
                                    </ext:GridCommand>
                                </Commands>
                                <Listeners>
                                    <Command Handler="App.direct.accionComando(command, record.data.id_factura);" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Single" />
                    </SelectionModel>
                    <View>
                        <ext:GridView ID="GridView1" runat="server" StripeRows="true" />
                    </View>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="Cantidad de registros:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                    <Items>
                                        <ext:ListItem Text="15" />
                                        <ext:ListItem Text="25" />
                                        <ext:ListItem Text="50" />
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Value="15" />
                                    </SelectedItems>
                                    <Listeners>
                                        <Select Handler="#{GridPanel1}.store.pageSize = parseInt(this.getValue(), 10); #{GridPanel1}.store.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                            <Plugins>
                                <ext:ProgressBarPager ID="ProgressBarPager1" runat="server" />
                            </Plugins>
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
        <ext:Window ID="winFactura" runat="server" Title="Factura" Icon="CoinsAdd" Width="500" Height="500" Closable="false" Layout="FitLayout">
            <Items>
                <ext:FormPanel runat="server" BodyPadding="5" DefaultAnchor="100%">
                    <Items>
                        <ext:Hidden runat="server" ID="id_consulta" />
                        <ext:DateField runat="server" ID="txtFecha" FieldLabel="Fecha" Editable="false" AnchorHorizontal="98%" />
                        <ext:TextField runat="server" ID="txtCliente" FieldLabel="Cliente" Editable="false" AnchorHorizontal="98%" />
                        <ext:TextField runat="server" ID="txtMedico" FieldLabel="Medico" Editable="false" AnchorHorizontal="98%" />
                        <ext:GridPanel runat="server" ID="grdDetalleFactura" StoreID="strDetalleFactura" AnchorHorizontal="98%" Height="350">
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:Column ID="servicio" runat="server" Text="Servicio" DataIndex="servicio" Flex="1" />
                                    <ext:Column ID="cantidad" runat="server" Text="Cantidad" DataIndex="cantidad" />
                                    <ext:Column ID="monto" runat="server" Text="v. Unitario" DataIndex="monto" />
                                    <ext:Column ID="total" runat="server" Text="Monto" DataIndex="total" />
                                </Columns>
                            </ColumnModel>
                            <BottomBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:ToolbarFill />
                                        <ext:TextField runat="server" ID="txtTotal" Width="100" />
                                    </Items>
                                </ext:Toolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Items>
                </ext:FormPanel>
            </Items>
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btndelFactura" Text="Cerrar" Icon="Cancel">
                            <Listeners>
                                <Click Handler="App.winFactura.hide();" />
                            </Listeners>
                        </ext:Button>
                        <ext:ToolbarFill />
                        <ext:Button runat="server" ID="btnAddFactura" Text="Aceptar" Icon="Accept"></ext:Button>
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:Window>
    </form>
</body>
</html>
