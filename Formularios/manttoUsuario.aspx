<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manttoUsuario.aspx.cs" Inherits="Formularios_manttoUsuario" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        var prepareToolbar = function (grid, toolbar, rowIndex, record) {
            //if (record.get("Rol") != '') {
            //    toolbar.items.getAt(0).hide();
            //    toolbar.items.getAt(1).hide();
            //}
            //else {
            //    toolbar.items.getAt(2).hide();
            //    toolbar.items.getAt(3).hide();
            //}
        };

        var prepareCellCommands = function (grid, commands, record, row, col, value) {
            if (record.get("Rol") == "Administrador") {
                commands.push({
                    iconCls: "icon-usergraycool",
                    command: "User",
                    tooltip: {
                        text: "Administrador"
                    }
                });
            }
            else if (record.get("Rol") == "Moderador") {
                commands.push({
                    iconCls: "icon-usergray",
                    command: "UserB",
                    tooltip: {
                        text: "Moderador"
                    }
                });
            }
            else if (record.get("Rol") == "Redactor") {
                commands.push({
                    iconCls: "icon-userbrown",
                    command: "UserC",
                    tooltip: {
                        text: "Redactor"
                    }
                });
            }
        };

        function onGridKeyPress(o, e) {
            if (e.getKey() == 13) {
                Ext.getCmp('btnBuscar').fireEvent('click');
            }
        };

        function getDetalle(dato) {
            App.direct.Detail_Refresh(dato);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
<%--        <ext:Store ID="strUsuarios" runat="server" OnReadData="MyData_Refresh" PageSize="15">--%>
                <ext:Store ID="strUsuarios" runat="server" PageSize="15">
            <Model>
                <ext:Model ID="Model1" runat="server">
                    <Fields>
                        <ext:ModelField Name="IdUsuario" />
                        <ext:ModelField Name="Nombre" />
                        <ext:ModelField Name="Usuario" />
                        <ext:ModelField Name="Rol" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store ID="strDetalleUsuario" runat="server">
            <Model>
                <ext:Model ID="Model5" runat="server">
                    <Fields>
                        <ext:ModelField Name="IdMiembro" />
                        <ext:ModelField Name="GroupName" />
                        <ext:ModelField Name="RolName" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store runat="server" ID="strUserList" AutoLoad="false">
            <Proxy>
                <ext:AjaxProxy Url="listaUsuarios.ashx">
                    <Reader>
                        <ext:JsonReader RootProperty="usuarios" />
                    </Reader>
                    <ActionMethods Read="POST" />
                </ext:AjaxProxy>
            </Proxy>
            <Model>
                <ext:Model ID="Model4" runat="server">
                    <Fields>
                        <ext:ModelField Name="idUsuario" />
                        <ext:ModelField Name="idUsuarioH" />
                        <ext:ModelField Name="usuario" />
                        <ext:ModelField Name="usuarioH" />
                        <ext:ModelField Name="nombreC" />
                        <ext:ModelField Name="nombreCh" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Viewport ID="ViewPort1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:FormPanel ID="fpBusqueda" runat="server" Width="700" BodyPadding="3"
                    Border="false" BodyStyle="background-color:#F8F8F8;" Region="North">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" StyleSpec="padding-bottom:3px;">
                            <Defaults>
                                <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                <ext:Parameter Name="MsgTarget" Value="side" />
                            </Defaults>
                            <Items>
                                <ext:ComboBox ID="cbxBusqueda" runat="server" StoreID="strUserList" ValueField="idUsuario" DisplayField="nombreC" TypeAhead="false" MinChars="1" AllowBlank="false" BlankText="Digite el dato a buscar"
                                    HideTrigger="true" ItemSelector="div.search-item" ListWidth="450" EmptyText="Escribe el código, nombre, apellido, usuario" ForceSelection="false" Width="470">
                                    <ToolTips>
                                        <ext:ToolTip ID="ToolTip1" runat="server" Target="cbxBusqueda" Anchor="top" AnchorOffset="250" Html="Digita * para mostrar todos los resultados" />
                                    </ToolTips>
                                    <ListConfig LoadingText="Buscando...">
                                        <ItemTpl ID="Tpl1" runat="server">
                                            <Html>
                                                <tpl for=".">
                                <div class="search-item">
                                      <h3><span class="column">ID: {idUsuario}</span>{nombreCh}</h3>
                                    Usuario: {usuarioH}
                                  </div>
                                </tpl>
                                            </Html>
                                        </ItemTpl>
                                    </ListConfig>
                                    <Listeners>
                                        <SpecialKey Fn="onGridKeyPress"></SpecialKey>
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ToolbarSpacer ID="ToolbarSpacer" runat="server" />
                                <ext:Button ID="btnBuscar" runat="server" Text="Buscar" Icon="Find">
                                    <Listeners>
                                        <Click Handler="if (#{fpBusqueda}.getForm().isValid()) {App.direct.buscar()} else{Ext.net.Notification.show({iconCls:'icon-error', html:'Digite el dato a buscar', title:'Validación', HideDelay:'3000'});}" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarFill ID="ToolbarFill" runat="server" />
                                <ext:ToolbarSeparator ID="ToolbarSeparator" runat="server" />
                                <ext:Button ID="Button3" runat="server" Text="Nuevo" Icon="UserAdd">
                                    <Listeners>
                                        <Click Handler="#{winCrear}.show();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:FormPanel>
                <ext:GridPanel ID="GridPanel1" runat="server" StoreID="strUsuarios" Title="Gestion de usuarios"
                    AnchorHorizontal="90%" AnchorVertical="100%" Region="Center">
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="C1" runat="server" Text="Código" DataIndex="IdUsuario" Width="60" Align="Center" />
                            <ext:Column ID="C2" runat="server" Text="Nombre" DataIndex="Nombre" Flex="1" />
                            <ext:Column ID="C3" runat="server" Text="Usuario" DataIndex="Usuario" Width="100" />
                            <%--<ext:Column ID="C4" runat="server" Text="Rol Actual" Width="150" DataIndex="Rol">
                                <Commands>
                                    <ext:ImageCommand CommandName="tPerfil" />
                                </Commands>
                                <PrepareCommands Fn="prepareCellCommands" />
                            </ext:Column>--%>
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Width="325" Text="Acciones" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="VcardAdd" CommandName="Asignar" Text="Asignar">
                                        <ToolTip Text="Asignar Grupo y Rol" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                    <ext:GridCommand Icon="UserEdit" CommandName="Editar" Text="Editar">
                                        <ToolTip Text="Editar Usuario" />
                                    </ext:GridCommand>
                                    <%--<ext:CommandSeparator />
                                    <ext:GridCommand Icon="UserDelete" CommandName="Eliminar" Text="Desactivar">
                                        <ToolTip Text="Desactivar Usuario" />
                                    </ext:GridCommand>--%>
                                </Commands>
                                <PrepareToolbar Fn="prepareToolbar" />
                                <Listeners>
                                    <Command Handler="App.direct.accionComando(command, record.data.IdUsuario, record.data.Nombre, record.data.Apellidos);" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Single">
                            <Listeners>
                                <Select Handler="if (#{GridView2}.isVisible()) {getDetalle(record.data.IdUsuario);}" Buffer="250" />
                            </Listeners>
                        </ext:RowSelectionModel>
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
                <ext:GridPanel ID="GridPanel2" runat="server" StoreID="strDetalleUsuario" Title="Detalle de usuarios"
                    AnchorHorizontal="90%" Height="240" Region="South">
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" Text="Cod" DataIndex="IdMiembro" Width="80" Align="Center" />
                            <ext:Column ID="Column2" runat="server" Text="Nombre Grupo" DataIndex="GroupName" Flex="1" />
                            <ext:Column ID="Column3" runat="server" Text="Nombre Rol" DataIndex="RolName" Flex="1">
                                <Commands>
                                    <ext:ImageCommand CommandName="tPerfil" />
                                </Commands>
                                <PrepareCommands Fn="prepareCellCommands" />
                            </ext:Column>
                            <ext:CommandColumn ID="CommandColumn2" runat="server" Width="325" Text="Acciones" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="VcardEdit" CommandName="EditarR" Text="Editar">
                                        <ToolTip Text="Editar Grupo o Rol" />
                                    </ext:GridCommand>
                                </Commands>
                                <Listeners>
                                    <Command Handler="App.direct.accionComando2(command, record.data.IdMiembro);" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" Mode="Single" />
                    </SelectionModel>
                    <View>
                        <ext:GridView ID="GridView2" runat="server" StripeRows="true" />
                    </View>
                    <%--<BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server">
                            <Items>
                                <ext:Label ID="Label4" runat="server" Text="Cantidad de registros:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
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
                                <ext:ProgressBarPager ID="ProgressBarPager2" runat="server" />
                            </Plugins>
                        </ext:PagingToolbar>
                    </BottomBar>--%>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
        <ext:Window ID="winCrear" runat="server" Icon="UserAdd" Title="Nuevo Usuario"
            Hidden="true" Width="400" Height="175" MinWidth="300" MinHeight="175" DefaultFocus="txtUsuario" Modal="true">
            <Items>
                <ext:FormPanel ID="FormPanel1" runat="server" BodyPadding="5" Layout="FormLayout">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                        <ext:Parameter Name="Anchor" Value="95%" Mode="Value" />
                    </Defaults>
                    <Items>
                        <ext:Label ID="Label2" runat="server" Html="<CENTER>REGISTRAR USUARIO</CENTER><br/>" HideLabel="true" />
                        <ext:TextField ID="txtUsuario" runat="server" FieldLabel="Usuario" Name="txtusuario" AllowBlank="false" BlankText="Digita el usuario" EmptyText="Digita el 'Usuario' a crear">
                            <AfterLabelTextTpl ID="AfterLabelTextTpl1" runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:TextField>
                        <ext:TextField ID="txtNombre" runat="server" FieldLabel="Nombre" Name="Nombre" AllowBlank="false" BlankText="Digita en nombre del usuario" EmptyText="Digita el 'Nombre' del usuario a crear">
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
                        <ext:Button ID="Button5" runat="server" Text="Registrar" Handler="if (#{FormPanel1}.getForm().isValid()) {App.direct.newUser()} else{Ext.net.Notification.show({iconCls:'icon-error', html:'Existen campos vacios!!', title:'Validación', HideDelay:'3000'});}" Icon="Disk" />
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>
        <ext:Window ID="winAsignar" runat="server" Icon="VcardAdd" Title="Asignación de rol"
            Hidden="true" Width="400" Height="200" MinWidth="300" MinHeight="200" DefaultFocus="firstName"
            Layout="FitLayout">
            <Items>
                <ext:FormPanel ID="fpAsignar" runat="server" BodyPadding="5">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                        <ext:Parameter Name="Anchor" Value="95%" Mode="Value" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="txtIdUsuarioA" runat="server" FieldLabel="CodUser" Disabled="true" Name="IdUsuarioA" Hidden="true" />
                        <ext:TextField ID="txtUsuarioA" runat="server" FieldLabel="Nombre" Disabled="true" Name="UsuarioA" />
                        <ext:ComboBox ID="cbxGrupos" runat="server" FieldLabel="Grupos" Name="Grupos" AllowBlank="false" BlankText="Selecciona el 'Grupo'"
                            DisplayField="nomgrupo" ValueField="idgrupo" TypeAhead="true" QueryMode="Local" ForceSelection="true"
                            TriggerAction="All" EmptyText="Selecciona el 'Grupo'" Width="50">
                            <Store>
                                <ext:Store ID="strGrupos" runat="server">
                                    <Model>
                                        <ext:Model ID="Model3" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="idgrupo" />
                                                <ext:ModelField Name="nomgrupo" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <AfterLabelTextTpl ID="AfterLabelTextTpl3" runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbxRoles" runat="server" FieldLabel="Roles" Name="Roles" AllowBlank="false" BlankText="Selecciona el 'Rol'"
                            DisplayField="nomrol" ValueField="idrol" TypeAhead="true" QueryMode="Local" ForceSelection="true"
                            TriggerAction="All" EmptyText="Selecciona el 'Rol'" Width="50">
                            <Store>
                                <ext:Store ID="strRoles" runat="server">
                                    <Model>
                                        <ext:Model ID="Model2" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="idrol" />
                                                <ext:ModelField Name="nomrol" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <Select Handler="#{Button2}.setDisabled(false)" />
                            </Listeners>
                            <AfterLabelTextTpl ID="AfterLabelTextTpl6" runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:ComboBox>
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button1" runat="server" Text="Cancelar" Icon="Cancel">
                            <Listeners>
                                <Click Handler="this.up('form').getForm().reset(); this.up('window').hide(); #{Button2}.setDisabled(true);" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button2" runat="server" Text="Asignar" Handler="if (#{fpAsignar}.getForm().isValid()) {App.direct.assignGroupRol()} else{Ext.net.Notification.show({iconCls:'icon-error', html:'Existen Campos Vacios!!', title:'Validación', HideDelay:'3000'});}" Icon="Disk" Disabled="true" />
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>
        <ext:Window ID="winEditar" runat="server" Icon="UserEdit" Title="Editar Usuario"
            Hidden="true" Width="400" Height="160" MinWidth="300" MinHeight="160" Modal="true">
            <Items>
                <ext:FormPanel ID="FormPanel2" runat="server" BodyPadding="5" Layout="FormLayout">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                        <ext:Parameter Name="Anchor" Value="95%" Mode="Value" />
                    </Defaults>
                    <Items>
                        <ext:Label ID="Label3" runat="server" Html="<CENTER>EDITAR USUARIO</CENTER>" HideLabel="true" />
                        <ext:TextField ID="txtIdUsuarioE" runat="server" FieldLabel="CodUsuario" Name="txtIdUsuarioE" Disabled="true" Hidden="true" />
                        <ext:TextField ID="txtUsuarioE" runat="server" FieldLabel="Usuario" Name="txtUsuarioE" Disabled="true">
                        </ext:TextField>
                        <ext:TextField ID="txtNombreE" runat="server" FieldLabel="Nombre" Name="txtNombreUsuarioE" AllowBlank="false" BlankText="Digite el nombre del usuario">
                            <AfterLabelTextTpl ID="AfterLabelTextTpl8" runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:TextField>
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button6" runat="server" Text="Cancelar" Icon="Cancel">
                            <Listeners>
                                <Click Handler="this.up('form').getForm().reset(); this.up('window').hide();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button7" runat="server" Text="Actualizar" Handler="if (#{FormPanel2}.getForm().isValid()) {App.direct.editUser()} else{Ext.net.Notification.show({iconCls:'icon-error', html:'Existen campos vacios!!', title:'Validación', HideDelay:'3000'});}" Icon="DiskBlack" />
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>
        <ext:Window ID="winEditarR" runat="server" Icon="VcardEdit" Title="Edición de perfil"
            Hidden="true" Width="400" Height="150" MinWidth="300" MinHeight="150" DefaultFocus="firstName"
            Layout="FitLayout">
            <Items>
                <ext:FormPanel ID="fpEditarR" runat="server" DefaultAnchor="100%" BodyPadding="5">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                        <ext:Parameter Name="Anchor" Value="95%" Mode="Value" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="txtIdMiembroR" runat="server" FieldLabel="CodMember" Disabled="true" Name="txtIdMiembroR" Hidden="true" />
                        <ext:ComboBox ID="cbxGruposR" runat="server" FieldLabel="Grupos" Name="cbxGruposR" AllowBlank="false" BlankText="Seleccione el grupo"
                            DisplayField="nomgrupo" ValueField="idgrupo" TypeAhead="true" QueryMode="Local" ForceSelection="true"
                            TriggerAction="All" EmptyText="Seleccione" Width="50">
                            <Store>
                                <ext:Store ID="strGruposR" runat="server">
                                    <Model>
                                        <ext:Model ID="Model7" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="idgrupo" />
                                                <ext:ModelField Name="nomgrupo" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <AfterLabelTextTpl ID="AfterLabelTextTpl4" runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbxRolesR" runat="server" FieldLabel="Roles" Name="RolesR" AllowBlank="false" BlankText="Seleccione el rol"
                            DisplayField="nomrol" ValueField="idrol" TypeAhead="true" QueryMode="Local" ForceSelection="true"
                            TriggerAction="All" EmptyText="Seleccione" Width="50">
                            <Store>
                                <ext:Store ID="strRolesR" runat="server">
                                    <Model>
                                        <ext:Model ID="Model6" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="idrol" />
                                                <ext:ModelField Name="nomrol" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <Select Handler="#{Button9}.setDisabled(false)" />
                            </Listeners>
                            <AfterLabelTextTpl ID="AfterLabelTextTpl12" runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Requerido">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:ComboBox>
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button8" runat="server" Text="Cancelar" Icon="Cancel">
                            <Listeners>
                                <Click Handler="this.up('form').getForm().reset(); this.up('window').hide();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button9" runat="server" Text="Actualizar" Handler="if (#{fpEditarR}.getForm().isValid()) {App.direct.confirmEditRol()} else{Ext.net.Notification.show({iconCls:'icon-error', html:'Seleccione el rol del usuario!!', title:'Validación', HideDelay:'3000'});}" Icon="DiskBlack" />
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
