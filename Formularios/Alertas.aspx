<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alertas.aspx.cs" Inherits="Formularios_Alertas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Store ID="strAlerta" runat="server" OnReadData="strAlerta_Refresh" PageSize="15">
            <Model>
                <ext:Model runat="server" IDProperty="id_alerta">
                    <Fields>
                        <ext:ModelField Name="id_alerta" />
                        <ext:ModelField Name="alerta" />
                        <ext:ModelField Name="fecha_creacion" Type="Date" />
                        <ext:ModelField Name="id_unico" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Viewport runat="server" Layout="BorderLayout">
            <Items>
                <ext:TabPanel runat="server" Region="Center">
                    <Items>
                        <ext:Panel ID="pnlAlerta" runat="server" Title="Alertas" Border="false" Layout="FitLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grdAlertas" Header="false" Border="false" StoreID="strAlerta" ForceFit="true">
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn runat="server" Text="#" Width="35" />
                                            <ext:Column runat="server" Text="Alerta" DataIndex="alerta" Sortable="true" />
                                            <ext:Column runat="server" Text="#Cita" DataIndex="id_unico" Sortable="true" />
                                            <ext:DateColumn runat="server" Text="Fecha alerta" Width="120" Sortable="true" DataIndex="fecha_creacion" Format="dd/m/Y">
                                            </ext:DateColumn>
                                            <ext:CommandColumn runat="server" Width="160">
                                                <Commands>
                                                    <ext:GridCommand Icon="UserAlert" CommandName="oAlerta" Text="Eliminar" />
                                                </Commands>
                                                <Listeners>
                                                    <Command Handler="App.direct.accionComando(command, record.data.id_alerta);" />
                                                </Listeners>
                                            </ext:CommandColumn>
                                        </Columns>
                                    </ColumnModel>
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
                                                        <Select Handler="#{grdAlertas}.store.pageSize = parseInt(this.getValue(), 15); #{grdAlertas}.store.reload();" />
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
