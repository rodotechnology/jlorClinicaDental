<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Confirmacion.aspx.cs" Inherits="Formularios_Confirmacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Store ID="strCitasPorConfirmar" runat="server" OnReadData="strCitasPorConfirmar_Refresh" PageSize="15">
            <Model>
                <ext:Model runat="server" IDProperty="id_cita">
                    <Fields>
                        <ext:ModelField Name="id_cita" />
                        <ext:ModelField Name="id_cliente" />
                        <ext:ModelField Name="nombre" />
                        <ext:ModelField Name="apellidos" />
                        <ext:ModelField Name="servicio" />
                        <ext:ModelField Name="dia_cita" Type="Date" />
                        <ext:ModelField Name="hora_inicio" Type="Date" />
                        <ext:ModelField Name="medico" />
                        <ext:ModelField Name="fecha_registro" Type="Date" />
                        <ext:ModelField Name="id_medico" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Viewport runat="server" Layout="BorderLayout">
            <Items>
                <ext:TabPanel runat="server" Region="Center">
                    <Items>
                        <ext:Panel ID="pnlCitasPorConfirmar" runat="server" Title="Confirmacion de Cita" Border="false" Layout="FitLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grdPorConfirmar" Header="false" Border="false" StoreID="strCitasPorConfirmar" ForceFit="true">
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn runat="server" Text="#" Width="35" />
                                            <ext:Column runat="server" Text="Nombre" DataIndex="nombre" Sortable="true" />
                                            <ext:Column runat="server" Text="Apellidos" DataIndex="apellidos" Sortable="true" />
                                            <ext:Column runat="server" Text="Servicio" DataIndex="servicio" Sortable="true" />
                                            <ext:DateColumn runat="server" Text="Fecha Cita" Width="120" Sortable="true" DataIndex="dia_cita" Format="dd/m/Y">
                                            </ext:DateColumn>
                                            <ext:DateColumn runat="server" Text="Hora" Width="120" Sortable="true" DataIndex="hora_inicio" Format="HH:mm">
                                            </ext:DateColumn>
                                            <ext:DateColumn runat="server" Text="fecha registro" Width="120" Sortable="true" DataIndex="fecha_registro" Format="dd/m/Y">
                                            </ext:DateColumn>
                                            <ext:Column runat="server" Text="Medico" DataIndex="medico" Sortable="true" />
                                            <ext:CommandColumn runat="server" Width="160">
                                                <Commands>
                                                    <ext:GridCommand Icon="Tick" CommandName="oConfirmar" Text="Confirmar" />
                                                    <ext:CommandSeparator />
                                                    <ext:GridCommand Icon="Delete" CommandName="oEliminar" Text="Eliminar" />
                                                </Commands>
                                                <Listeners>
                                                    <Command Handler="App.direct.accionComando(command, record.data.id_cita,record.data.nombre+ ' '+ record.data.nombre,record.data.id_cliente);" />
                                                </Listeners>
                                            </ext:CommandColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <View>
                                        <ext:GridView runat="server" LoadMask="false" />
                                    </View>
                                    <Plugins>
                                        <ext:GridFilters runat="server" />
                                    </Plugins>
                                    <BottomBar>
                                        <ext:PagingToolbar runat="server">
                                            <Items>
                                                <ext:Label runat="server" Text="Page size:" />
                                                <ext:ToolbarSpacer runat="server" Width="10" />
                                                <ext:ComboBox runat="server" Width="80">
                                                    <Items>
                                                        <ext:ListItem Text="15" />
                                                        <ext:ListItem Text="30" />
                                                        <ext:ListItem Text="40" />
                                                        <ext:ListItem Text="50" />
                                                    </Items>
                                                    <SelectedItems>
                                                        <ext:ListItem Value="15" />
                                                    </SelectedItems>
                                                    <Listeners>
                                                        <Select Handler="#{grdPorConfirmar}.store.pageSize = parseInt(this.getValue(), 15); #{grdPorConfirmar}.store.reload();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                            <Plugins>
                                                <ext:ProgressBarPager runat="server" />
                                            </Plugins>
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
