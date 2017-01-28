<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Formularios_frmConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:GridPanel
            ID="GridPanel1"
            runat="server"
            Layout="FitLayout">
            <Store>
                <ext:Store ID="StoreConsulta" runat="server" PageSize="10">
                    <Model>
                        <ext:Model runat="server">
                            <Fields>
                                <ext:ModelField Name="id_consulta" />
                                <ext:ModelField Name="id_cita" />
                                <ext:ModelField Name="nomMedica" />
                                <ext:ModelField Name="nomCliente" />
                                <ext:ModelField Name="id_tipo_cliente" />
                                <ext:ModelField Name="estado" />
                                <ext:ModelField Name="fecha_inicio" />
                                <ext:ModelField Name="horaConsulta" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <%--<ext:RowNumbererColumn runat="server" Width="35" />--%>
                    <ext:Column runat="server" Text="No." DataIndex="id_consulta" Width="60" Align="Center" />
                    <ext:Column runat="server" Text="Medicio" DataIndex="nomMedica" Flex="1" />
                    <ext:Column runat="server" Text="Paciente" DataIndex="nomCliente" Flex="1" />
                    <ext:Column runat="server" Text="Fecha" Width="125" DataIndex="fecha_inicio" Align="Center" />
                    <ext:Column runat="server" Text="Hora" Width="125" DataIndex="horaConsulta" Align="Center" />
                    <ext:CommandColumn runat="server" Width="60">
                        <Commands>
                            <ext:GridCommand Icon="Accept" CommandName="AtenderConsulta">
                                <ToolTip Text="Atender Consulta"></ToolTip>
                            </ext:GridCommand>
                        </Commands>
                        <Listeners>
                            <Command Handler="App.direct.Acciones(command, record.data.id_consulta);" />
                        </Listeners>
                    </ext:CommandColumn>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" Mode="Multi" />
            </SelectionModel>
            <View>
                <ext:GridView runat="server" StripeRows="true" />
            </View>
            <%-- <BottomBar>
                <ext:PagingToolbar runat="server">
                    <Items>
                        <ext:Label runat="server" Text="Page size:" />
                        <ext:ToolbarSpacer runat="server" Width="10" />
                        <ext:ComboBox runat="server" Width="80">
                            <Items>
                                <ext:ListItem Text="1" />
                                <ext:ListItem Text="2" />
                                <ext:ListItem Text="10" />
                                <ext:ListItem Text="20" />
                            </Items>
                            <SelectedItems>
                                <ext:ListItem Value="10" />
                            </SelectedItems>
                            <Listeners>
                                <Select Handler="#{GridPanel1}.store.pageSize = parseInt(this.getValue(), 10); #{GridPanel1}.store.reload();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                    <Plugins>
                        <ext:ProgressBarPager runat="server" />
                    </Plugins>
                </ext:PagingToolbar>
            </BottomBar>--%>
            <%--<TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Print" Icon="Printer" Handler="this.up('grid').print();" />
                        <ext:Button runat="server" Text="Print current grid page" Icon="Printer" Handler="this.up('grid').print({currentPageOnly : true});" />
                    </Items>
                </ext:Toolbar>
            </TopBar>--%>
        </ext:GridPanel>



        <ext:Window
            ID="WinFormConsulta"
            runat="server"
            Title="Formulario de consulta"
            Width="835"
            Height="500"
            BodyPadding="10" Hidden="true" Modal="true">
            <Items>
                <ext:TabPanel runat="server" Width="800" Height="440">
                    <Items>

                        <ext:Panel runat="server" Title="Odontrograma">
                            <TabConfig runat="server" UI="Primary" />
                            <Items>
                                <ext:FieldSet
                                    runat="server"
                                    Title="ODONTOGRAMA"
                                    MarginSpec="0 0 0 10">
                                    <Defaults>
                                        <ext:Parameter Name="LabelWidth" Value="115" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtIdConsulta" FieldLabel="ID Consulta" Width="200" ReadOnly="true" />
                                        <ext:ComboBox Name="cbxDentincion" ID="cbxDentincion" runat="server" FieldLabel="Dentición" Width="350" Editable="false" EmptyText="Seleccionar">
                                            <Items>
                                                <ext:ListItem Text="SUPERIOR DERECHO" Value="1" />
                                                <ext:ListItem Text="SUPERIOR IZQUIERDO" Value="2" />
                                                <ext:ListItem Text="INFERIOR IZQUIERDO" Value="3" />
                                                <ext:ListItem Text="INFERIOR DERECHO" Value="4" />
                                            </Items>
                                            <Listeners>
                                                <Select Handler="App.direct.getDientes(Ext.getCmp('cbxDentincion').getValue())" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:ComboBox Name="cbxPiezaDentales" ID="cbxPiezaDentales"
                                            runat="server" FieldLabel="Pieza D." Width="250" DisplayField="descripcion" ValueField="id_pieza" Editable="true" EmptyText="Seleccionar">
                                            <Store>
                                                <ext:Store runat="server" ID="Store2">
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="id_pieza" />
                                                                <ext:ModelField Name="descripcion" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                        <ext:ComboBox
                                            runat="server"
                                            FieldLabel="Servicios:"
                                            DisplayField="servicioCosto"
                                            ValueField="id_servicio"
                                            Width="500" ID="cbxServicios" Editable="false" EmptyText="Seleccionar">
                                            <Store>
                                                <ext:Store runat="server" ID="StoreServicios">
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="id_servicio" />
                                                                <ext:ModelField Name="servicioCosto" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                    </Items>
                                    <Items>
                                        <ext:TextArea ID="txtObservaciones" runat="server" FieldLabel="Observaciones" Width="710">
                                        </ext:TextArea>
                                    </Items>
                                    <Items>
                                        <ext:Button runat="server" Text="Agregar">
                                            <Listeners>
                                                <Click Handler="App.direct.AgregarDetalleConsulta();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" UI="Info" Title="Detalle Consulta">
                            <TabConfig runat="server" UI="Info" />
                            <Items>
                                <ext:GridPanel
                                    runat="server"
                                    ColumnWidth="0.6"
                                    Layout="FitLayout"
                                    Height="250">
                                    <Store>
                                        <ext:Store ID="StoreDetalleConsulta" runat="server">
                                            <Model>
                                                <ext:Model runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="id_detalle_consulta" />
                                                        <ext:ModelField Name="nombre" />
                                                        <ext:ModelField Name="Pieza_dental" />
                                                        <ext:ModelField Name="allazgo" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="SERVICIO" DataIndex="nombre" Flex="1" />
                                            <ext:Column runat="server" Text="PIEZA DENTAL" DataIndex="Pieza_dental" Flex="1" />
                                            <ext:Column runat="server" Text="Observaciones" DataIndex="allazgo" Flex="1" />
                                            <ext:CommandColumn runat="server" Align="Center" Width="70">
                                                <Commands>
                                                    <ext:GridCommand Icon="Delete" CommandName="eliminar">
                                                        <ToolTip Text="Eliminar" />
                                                    </ext:GridCommand>
                                                </Commands>
                                                <Listeners>
                                                    <Command Handler="App.direct.msgConfirmacionEliminacion(record.data.id_detalle_consulta);" />
                                                </Listeners>
                                            </ext:CommandColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <%--<Listeners>
                        <SelectionChange Handler="if(selected[1]) { this.up('form').getForm().loadRecord(selected[1]); }" />
                    </Listeners>--%>
                                </ext:GridPanel>
                            </Items>
                            <Buttons>
                                <ext:Button runat="server" Text="Finalizar Consulta">
                                    <Listeners>
                                        <Click Handler="App.direct.msgConfirmacionFinalizar();" />
                                    </Listeners>
                                </ext:Button>
                            </Buttons>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
