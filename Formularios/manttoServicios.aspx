<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manttoServicios.aspx.cs" Inherits="Formularios_servicios" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResoruceManager1" runat="server" />
        <ext:FormPanel
            runat="server"
            Title="MANTENIMIENTO DE SERVICIOS MEDICOS"
            BodyPadding="5"
            Layout="ColumnLayout">
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" />
            <Items>
                <ext:FieldSet
                    runat="server"
                    ColumnWidth="0.4"
                    Title="Detalle Servicios"
                    MarginSpec="0 0 0 10"
                    ButtonAlign="Right">
                    <Defaults>
                        <ext:Parameter Name="LabelWidth" Value="115" />
                    </Defaults>
                    <Items>
                        <ext:TextField Name="txtIDServicio" ID="txtIDServicio" runat="server" Hidden="true" />
                        <ext:TextField Name="txtservicios" ID="txtservicios" runat="server" FieldLabel="Nombre" />
                        <ext:TextField Name="txtcosto" ID="txtcosto" runat="server" FieldLabel="Costo" />
                        <ext:ButtonGroup runat="server" TitleAlign="Left">
                            <Buttons>
                                <ext:Button runat="server" ID="btnGuardar" Text="Guardar">
                                    <Listeners>
                                        <Click Handler="App.direct.msgConfirmarSave();App.direct.SelectRegistros();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" ID="btnUpdate" Text="Modificar" Hidden="true">
                                    <Listeners>
                                        <Click Handler="App.direct.msgConfirmarModificacion();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="Borrar">
                                    <Listeners>
                                        <Click Handler="this.up('form').getForm().reset();" />
                                    </Listeners>
                                </ext:Button>

                            </Buttons>
                        </ext:ButtonGroup>
                    </Items>
                    <%--<buttons>--%>


                    <%-- </buttons>--%>
                </ext:FieldSet>
                <ext:GridPanel
                    runat="server"
                    ColumnWidth="0.6"
                    Layout="FitLayout">
                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Model>
                                <ext:Model runat="server">
                                    <Fields>
                                        <ext:ModelField Name="id_servicio" />
                                        <ext:ModelField Name="nombre" />
                                        <ext:ModelField Name="costo" />
                                        <ext:ModelField Name="fechaingreso" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column runat="server" Text="Nombre Servicio" DataIndex="nombre" Flex="1" />
                            <ext:Column runat="server" Text="Costo" DataIndex="costo" Flex="1">
                            </ext:Column>
                            <ext:CommandColumn runat="server" Align="Center" Width="70">
                                <Commands>
                                    <ext:GridCommand Icon="BookEdit" CommandName="modificar">
                                        <ToolTip Text="Modificar" />
                                    </ext:GridCommand>
                                    <ext:GridCommand Icon="Delete" CommandName="eliminar">
                                        <ToolTip Text="Eliminar" />
                                    </ext:GridCommand>
                                </Commands>
                                <Listeners>
                                    <Command Handler="App.direct.Acciones(command, record.data.id_servicio,record.data.nombre,record.data.costo);" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <%--<Listeners>
                        <SelectionChange Handler="if(selected[1]) { this.up('form').getForm().loadRecord(selected[1]); }" />
                    </Listeners>--%>
                </ext:GridPanel>


            </Items>

        </ext:FormPanel>
    </form>
</body>
</html>
