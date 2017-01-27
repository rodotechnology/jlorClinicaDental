<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manttoEspecialidad.aspx.cs" Inherits="Formularios_MattoEspecialidad" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <form runat="server">
        <ext:ResourceManager runat="server" />

        <ext:FormPanel
            runat="server"
            Title="MANTENIMIENTO DE ESPECIALIDADES MEDICAS"
            BodyPadding="5"
            Layout="ColumnLayout">

            <FieldDefaults LabelAlign="Left" MsgTarget="Side" />

            <Items>
                <ext:FieldSet
                    runat="server"
                    ColumnWidth="0.4"
                    Title="Detalle Especialidades"
                    MarginSpec="0 0 0 10"
                    ButtonAlign="Right">
                    <Defaults>
                        <ext:Parameter Name="LabelWidth" Value="115" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="txtIdEspecialidad" runat="server" Hidden="true"/>
                        <ext:TextField Name="nombre" ID="txtNombre" runat="server" FieldLabel="Nombre" Width="300" />
                        <ext:ComboBox
                            runat="server"
                            FieldLabel="Servicios:"
                            DisplayField="nombre"
                            ValueField="id_servicio"
                            Width="405" ID="cbxServicios">
                            <Store>
                                <ext:Store runat="server" ID="StoreServicios">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="id_servicio" />
                                                <ext:ModelField Name="nombre" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ButtonGroup runat="server" TitleAlign="Left">
                            <Buttons>
                                <ext:Button runat="server" ID="btnGuardar" Text="Guardar">
                                    <Listeners>
                                        <Click Handler="App.direct.guardar();this.up('form').getForm().reset(); App.direct.SelectRegistros();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" ID="btnUpdate" Text="Modificar" Hidden="true">
                                    <Listeners>
                                        <Click Handler="" />
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
                                        <ext:ModelField Name="id_especialidad" />
                                        <ext:ModelField Name="nombre" />
                                        <ext:ModelField Name="idServicios" />
                                        <ext:ModelField Name="nomServicio" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column runat="server" Text="Nombre Especialidad" DataIndex="nombre" Flex="1" />
                            <ext:Column runat="server" Text="Servicios" DataIndex="nomServicio" Flex="1">
                            </ext:Column>
                            <ext:CommandColumn runat="server" Width="75">
                                <Commands>
                                    <ext:GridCommand Icon="BookEdit" CommandName="modificar">
                                        <ToolTip Text="Modificar"></ToolTip>
                                    </ext:GridCommand>
                                    <ext:GridCommand Icon="Cancel" CommandName="Eliminar">
                                        <ToolTip Text="Eliminar"></ToolTip>
                                    </ext:GridCommand>
                                </Commands>
                                <Listeners>
                                    <Command Handler="App.direct.Acciones(command, record.data.id_especialidad,record.data.nombre,record.data.idServicios);" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <%--<Listeners>
                        <SelectionChange Handler="if (selected[0]) { this.up('form').getForm().loadRecord(selected[0]); }" />
                    </Listeners>--%>
                </ext:GridPanel>


            </Items>

        </ext:FormPanel>
    </form>
</body>
</html>
