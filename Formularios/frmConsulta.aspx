<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmConsulta.aspx.cs" Inherits="Formularios_frmConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Window
            ID="FormConsulta"
            runat="server"
            Title="Formulario de consulta"
            Width="800"
            Height="600"
            BodyPadding="10">
            <Items>
                <ext:FormPanel
                    runat="server"
                    BodyPadding="5"
                    Layout="FitLayout">
                    <FieldDefaults LabelAlign="Left" MsgTarget="Side" />
                    <Items>
                        <ext:FieldSet
                            runat="server"
                            Title="ODONTOGRAMA"
                            MarginSpec="0 0 0 10">
                            <Defaults>
                                <ext:Parameter Name="LabelWidth" Value="115" />
                            </Defaults>
                            <Items>
                                <ext:TextField runat="server" ID="txtIdConsulta" FieldLabel="ID Consulta" Width="200" />
                                <ext:ComboBox Name="cbxDentincion" ID="cbxDentincion" runat="server" FieldLabel="Dentición" Width="350">
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
                                    runat="server" FieldLabel="Pieza D." Width="200" DisplayField="descripcion" ValueField="id_pieza">
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
                                    Width="500" ID="cbxServicios">
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
                                </ext:Button>
                            </Items>
                            
                        </ext:FieldSet>
                        <ext:GridPanel
                            runat="server"
                            ColumnWidth="0.6"
                            Layout="FitLayout"
                            Height="480">
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
                                    <ext:Column runat="server" Text="Emisferio" DataIndex="" Flex="1" />
                                    <ext:Column runat="server" Text="Pieza Dental" DataIndex="" Flex="1" />
                                    <ext:Column runat="server" Text="Servicios" DataIndex="costo" Flex="1" />
                                    <ext:Column runat="server" Text="Observaciones" DataIndex="" Flex="1" />
                                    <ext:CommandColumn runat="server" Align="Center" Width="70">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="eliminar">
                                                <ToolTip Text="Eliminar" />
                                            </ext:GridCommand>
                                        </Commands>
                                    </ext:CommandColumn>
                                </Columns>
                            </ColumnModel>
                            <%--<Listeners>
                        <SelectionChange Handler="if(selected[1]) { this.up('form').getForm().loadRecord(selected[1]); }" />
                    </Listeners>--%>
                        </ext:GridPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Finalizar">
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
