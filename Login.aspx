<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function onGridKeyPress(o, e) {
            if (e.getKey() == 13) {
                Ext.getCmp('btnAceptar').fireEvent('click');
            }
        }
    </script>
    <style type="text/css">
        .x-body {
            background: url(Img/jlorBackground.jpg) no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:Panel ID="pnlMsg" runat="server" Height="150" Width="350" Title="Html" BodyPadding="5" Icon="UserDelete" UI="Danger" Frame="true" Hidden="true">
                </ext:Panel>
                <ext:FormPanel ID="FormPanel1" runat="server" Title="Ingrese sus credenciales" Width="325" Frame="true" BodyPadding="13" DefaultAnchor="100%" Icon="Lock">
                    <Defaults>
                        <ext:Parameter Name="anchor" Value="95%" Mode="Value" />
                        <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="txtUsername" runat="server" AllowBlank="false" BlankText="Ingrese nombre de Usuario." FieldLabel="Usuario" Name="user" EmptyText="Digite Usuario" EnableKeyEvents="true" AutoFocus="true">
                            <Listeners>
                                <KeyPress Fn="onGridKeyPress" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtPassword" runat="server" AllowBlank="false" BlankText="Ingrese la Contraseña." FieldLabel="Contraseña" Name="pass" EmptyText="Digite Contraseña" InputType="Password" EnableKeyEvents="true">
                            <Listeners>
                                <KeyPress Fn="onGridKeyPress" />
                            </Listeners>
                        </ext:TextField>
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button2" runat="server" Text="Iniciar sesión" Icon="LockOpen">
                            <Listeners>
                                <Click Handler="if (!#{txtUsername}.validate() || !#{txtPassword}.validate()) { Ext.Msg.callout(this.up('panel'), {ui:'warning', alignment:'rightbottom', title:'Validación', html: 'Los campos Nombre de <b>usuario</b> y la <b>contraseña</b> son obligatorios', height: 100, width:200, dismissDelay: 5000, closeAction: 'Destroy'});                                 
                                // return false to prevent the btnLogin_Click Ajax Click event from firing.
                                return false; 
                            }" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnLogin_Click">
                                    <EventMask ShowMask="true" Msg="Verificando..." MinDelay="500" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
