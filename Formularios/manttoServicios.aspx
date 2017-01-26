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
        <ext:ResourceManager runat="server" />
        <ext:FormPanel
            runat="server"
            Title="MANTENIMIENTOS DE SERVICIOS MEDICOS"
            Width="1000"
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
                        <ext:TextField Name="txtservicios" ID="txtservicios" runat="server" FieldLabel="Nombre" />
                        <ext:TextField Name="txtcosto" ID="txtcosto" runat="server" FieldLabel="Costo" />
                        <ext:ButtonGroup runat="server" Title="Acciones" TitleAlign="Left">
                            <Buttons>
                                <ext:Button runat="server" Text="Guardar">
                                    <Listeners>
                                        <Click Handler="App.direct.guardar(App.txtservicios.getValue(), App.txtcosto.getValue());" />
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
                    Height="400">
                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Model>
                                <ext:Model runat="server">
                                    <Fields>
                                        <ext:ModelField Name="nombre" />
                                        <ext:ModelField Name="costo" Type="Float" />
                                        <ext:ModelField Name="fechaingreso" Type="Float" />
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
                            <ext:Column runat="server" Text="Fecha Ingreso" Flex="1" DataIndex="fechaingreso">
                            </ext:Column>
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
