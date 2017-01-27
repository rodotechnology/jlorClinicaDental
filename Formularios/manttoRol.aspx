<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manttoRol.aspx.cs" Inherits="Formularios_manttoRol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="strRols" runat="server" OnReadData="MyData_Refresh" PageSize="15">
            <Model>
                <ext:Model ID="Model1" runat="server">
                    <Fields>
                        <ext:ModelField Name="id_rol" />
                        <ext:ModelField Name="rol" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Viewport ID="ViewPort1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:GridPanel ID="GridPanel1" runat="server" StoreID="strRols"
                    AnchorHorizontal="90%" AnchorVertical="100%" Region="Center">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" StyleSpec="padding-bottom:3px;">
                            <Items>
                                <ext:Label ID="Label3" runat="server" Html="<CENTER><b>GESTION DE ROLES</b></CENTER>" HideLabel="true" Flex="1" />
                                <ext:ToolbarSeparator ID="ToolbarSeparator" runat="server" />
                                <ext:Button ID="Button3" runat="server" Text="Nuevo" Icon="LockAdd" ToolTip="Nuevo Rol">
                                    <Listeners>
                                        <Click Handler="#{winCrear}.show();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="C1" runat="server" Text="Código" DataIndex="id_rol" Width="60" Align="Center" />
                            <ext:Column ID="C3" runat="server" Text="Nombre" DataIndex="rol" Flex="1" />
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Width="125" Text="Acciones" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="LockEdit" CommandName="Editar" Text="Editar">
                                        <ToolTip Text="Editar Rol" />
                                    </ext:GridCommand>
                                </Commands>
                                <Listeners>
                                    <Command Handler="App.direct.accionComando(command, record.data.id_rol);" />
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
                <ext:Window ID="winCrear" runat="server" Hidden="true" Width="400" Height="150" MinWidth="400" MinHeight="150" DefaultFocus="" Modal="true" Icon="LockAdd" Title="Registrar Rol">
                    <Items>
                        <ext:FormPanel ID="FormPanel1" runat="server" BodyPadding="5" Layout="FormLayout">
                            <Defaults>
                                <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                <ext:Parameter Name="MsgTarget" Value="side" />
                                <ext:Parameter Name="anchor" Value="95%" Mode="Value" />
                            </Defaults>
                            <Items>
                                <ext:TextField ID="txtNombreRol" runat="server" FieldLabel="Nombre del Rol" Name="txtNombreRol" AllowBlank="false" BlankText="Digita el 'Nombre' del Rol." LabelWidth="125" EmptyText="Digita el 'Nombre' del Rol">
                                    <AfterLabelTextTpl ID="AfterLabelTextTpl2" runat="server">
                                        <Html>
                                            <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                        </Html>
                                    </AfterLabelTextTpl>
                                </ext:TextField>
                            </Items>
                            <Buttons>
                                <ext:Button ID="Button4" runat="server" Text="Cancelar" Icon="Cancel">
                                    <Listeners>
                                        <Click Handler="this.up('form').getForm().reset(); this.up('window').hide();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button5" runat="server" Text="Registrar" Handler="if (#{FormPanel1}.getForm().isValid()) {App.direct.newPermission()} else{Ext.net.Notification.show({iconCls:'icon-error', html:'Existen campos vacios!!', title:'Validación', HideDelay:'3000'});}" Icon="Disk" />
                            </Buttons>
                        </ext:FormPanel>
                    </Items>
                </ext:Window>
                <ext:Window ID="winEditar" runat="server" Hidden="true" Width="400" Height="150" MinWidth="400" MinHeight="150" DefaultFocus="" Modal="true" Icon="LockEdit" Title="Actualizar Rol">
                    <Items>
                        <ext:FormPanel ID="FormPanel2" runat="server" BodyPadding="5" Layout="FormLayout">
                            <Defaults>
                                <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                <ext:Parameter Name="MsgTarget" Value="side" />
                                <ext:Parameter Name="Anchor" Value="95%" Mode="Value" />
                            </Defaults>
                            <Items>
                                <ext:TextField ID="txtIdRolA" runat="server" FieldLabel="CodRol" Name="txtIdRolA" Hidden="true" />
                                <ext:TextField ID="txtNombreRolA" runat="server" FieldLabel="Nombre del Rol" Name="txtNombreRolA" AllowBlank="false" BlankText="Ingrese nombre de Rol." LabelWidth="125">
                                    <AfterLabelTextTpl ID="AfterLabelTextTpl1" runat="server">
                                        <Html>
                                            <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                        </Html>
                                    </AfterLabelTextTpl>
                                </ext:TextField>
                            </Items>
                            <Buttons>
                                <ext:Button ID="Button1" runat="server" Text="Cancelar" Icon="Cancel">
                                    <Listeners>
                                        <Click Handler="this.up('form').getForm().reset(); this.up('window').hide();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button2" runat="server" Text="Actualizar" Handler="if (#{FormPanel2}.getForm().isValid()) {App.direct.editPermission()} else{Ext.net.Notification.show({iconCls:'icon-error', html:'Existen campos vacios!!<br/>o el formato del nombre es incorrecto!!', title:'Validación', HideDelay:'3000'});}" Icon="DiskBlack" />
                            </Buttons>
                        </ext:FormPanel>
                    </Items>
                </ext:Window>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
