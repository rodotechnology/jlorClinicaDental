<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manttoEspecialidad.aspx.cs" Inherits="Formularios_MattoEspecialidad" %>

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
            Title="MANTENIMIENTOS DE ESPECIALIDADES MEDICAS"
            Width="1000"
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
                        <ext:TextField Name="nombre" runat="server" FieldLabel="Nombre" Width="300"/>
                        <ext:ComboBox
                            runat="server"
                            FieldLabel="Servicios:"
                            DisplayField="nombre"
                            ValueField="id_servicio"
                            Width="325">
                            <Store>
                                <ext:Store runat="server" ID="StoreServicios" AutoDataBind="true">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="id_servicio" />
                                                <ext:ModelField Name="nombre" />
                                                <ext:ModelField Name="costo" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                    <Reader>
                                        <ext:ArrayReader />
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ButtonGroup runat="server" Title="Acciones" TitleAlign="Left">
                            <Buttons>
                                <ext:Button runat="server" Text="Guardar">
                                    <%--<Listeners>
                        <Click Handler="var form = this.up('form'),
                                            r = form.getForm().getRecord();

                                        if (r) {
                                            form.getForm().updateRecord(form.down('grid').getSelectionModel().getLastSelected());
                                        }" />
                    </Listeners>--%>
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
                                        <ext:ModelField Name="nomServicio"/>
                                        <ext:ModelField Name="fechaingreso"/>
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
