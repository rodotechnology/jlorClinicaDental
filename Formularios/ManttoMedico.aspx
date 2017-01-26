<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manttoMedico.aspx.cs" Inherits="Formularios_ManttoMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

        <ext:FormPanel
            runat="server"
            Title="MANTENIMIENTOS DE MEDICOS"
            Width="1000"
            BodyPadding="5"
            Layout="ColumnLayout">

            <FieldDefaults LabelAlign="Left" MsgTarget="Side" />

            <Items>
                <ext:FieldSet
                    runat="server"
                    ColumnWidth="0.4"
                    Title="Detalle Medicos"
                    MarginSpec="0 0 0 10"
                    ButtonAlign="Right">
                    <Defaults>
                        <ext:Parameter Name="LabelWidth" Value="115" />
                    </Defaults>
                    <Items>
                        <ext:TextField Name="nombre" runat="server" FieldLabel="Nombre" Width="300"/>
                        <ext:TextField Name="apellidos" runat="server" FieldLabel="Apellidos" Width="300"/>
                        <ext:TextField Name="telefono" runat="server" FieldLabel="Telefono" Width="300"/>
                        <ext:TextField Name="celular" runat="server" FieldLabel="Celular" Width="300"/>
                        <ext:TextField Name="correo" runat="server" FieldLabel="Correo" Width="300"/>
                        <ext:TextField Name="titulo" runat="server" FieldLabel="Titulo A." Width="300"/>
                        <ext:ComboBox
                            runat="server"
                            FieldLabel="Especialidad:"
                            DisplayField="nombre"
                            ValueField="id_especialidad"
                            Width="325">
                            <Store>
                                <ext:Store runat="server" ID="StoreEspecialidad" AutoDataBind="true">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="id_especialidad" />
                                                <ext:ModelField Name="nombre" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                    <Reader>
                                        <ext:ArrayReader />
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox
                            runat="server"
                            FieldLabel="Horarios:"
                            DisplayField="raw"
                            ValueField="id_horario"
                            Width="325">
                            <Store>
                                <ext:Store runat="server" ID="StoreHorarios" AutoDataBind="true">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="id_horario" />
                                                <ext:ModelField Name="raw" />
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
                                        <ext:ModelField Name="apellidos"/>
                                        <ext:ModelField Name="telefono"/>
                                        <ext:ModelField Name="celular"/>
                                        <ext:ModelField Name="titulo"/>
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column runat="server" Text="Nombre Medico" DataIndex="nombre" Flex="1" />
                            <ext:Column runat="server" Text="Apellidos Medico" DataIndex="apellidos" Flex="1" />
                            <ext:Column runat="server" Text="telefono" DataIndex="telefono" Flex="1"/>
                            <ext:Column runat="server" Text="celular" DataIndex="celular" Flex="1"/>
                            <ext:Column runat="server" Text="Titulo Acd." DataIndex="titulo" Flex="1" />
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

