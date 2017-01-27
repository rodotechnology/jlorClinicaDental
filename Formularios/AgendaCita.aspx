<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgendaCita.aspx.cs" Inherits="Vista_Cita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Scripts/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="rm" runat="server" Namespace="CompanyX" Locale="es-ES"/>
        <ext:Store runat="server" ID="strServicio">
            <Model>
                <ext:Model runat="server" IDProperty="id_servicio">
                    <Fields>
                        <ext:ModelField Name="id_servicio" />
                        <ext:ModelField Name="servicio" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store runat="server" ID="strMedico" AutoLoad="false" OnReadData="strMedicoRefresh">
            <Model>
                <ext:Model runat="server" IDProperty="id_medico">
                    <Fields>
                        <ext:ModelField Name="id_medico" />
                        <ext:ModelField Name="medico" />
                    </Fields>
                </ext:Model>
            </Model>
            <Listeners>
                <Load Handler="#{cbxMedico}.setValue(#{cbxMedico}.store.getAt(0).get('id_medico'));" />
            </Listeners>
        </ext:Store>
        <ext:Viewport runat="server" Layout="Border">
            <Items>
                <ext:Panel
                    runat="server"
                    Height="35"
                    Border="false"
                    Region="North"
                    Cls="app-header"
                    BodyCls="app-header-content">
                    <Content>
                        <div id="app-logo">
                            <div class="logo-top">&nbsp;</div>
                            <div id="logo-body">&nbsp;</div>
                            <div class="logo-bottom">&nbsp;</div>
                        </div>
                        <h1>My Calendar</h1>
                        <span id="app-msg" class="x-hidden"></span>
                    </Content>
                </ext:Panel>

                <ext:Panel ID="Panel1" runat="server" Title="..." Layout="Border" Region="Center" Cls="app-center">
                    <Items>
                        <ext:Panel runat="server" Width="213" Region="West" Border="false" Cls="app-west">
                            <Items>
                                <ext:DatePicker
                                    ID="DatePicker1"
                                    runat="server"
                                    Cls="ext-cal-nav-picker">
                                    <Listeners>
                                        <Select Fn="CompanyX.setStartDate" Scope="CompanyX" />
                                    </Listeners>
                                </ext:DatePicker>
                            </Items>
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button runat="server" Text="Registrar Cita" Icon="Add" Handler="Ext.getCmp('winRegistroCita').show();" />
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>

                        <ext:CalendarPanel ID="CalendarPanel1" runat="server" Region="Center" ActiveIndex="2" Border="false" DayText="Día" WeekText="Semana" MonthText="Mes">
                            <EventStore ID="EventStore1" runat="server" />
                            <CalendarStore ID="CalendarStore1" runat="server">
                                <Calendars>
                                    <ext:CalendarModel CalendarId="1" Title="Home" />
                                    <ext:CalendarModel CalendarId="2" Title="Work" />
                                    <ext:CalendarModel CalendarId="3" Title="School" />
                                    <ext:CalendarModel CalendarId="4" Title="Other" />
                                </Calendars>
                            </CalendarStore>
                            <%-- Setting enableFx to false is a workaround for #833 --%>
                            <MonthView
                                runat="server"
                                ShowHeader="true"
                                ShowWeekLinks="true"
                                ShowWeekNumbers="true"
                                EnableFx="false" />
                            <WeekView runat="server">
                                <CustomConfig>
                                    <ext:ConfigItem Name="enableFx" Value="false" Mode="Raw" />
                                </CustomConfig>
                            </WeekView>
                            <DayView runat="server">
                                <CustomConfig>
                                    <ext:ConfigItem Name="enableFx" Value="false" Mode="Raw" />
                                </CustomConfig>
                            </DayView>
                            <Listeners>
                                <ViewChange Fn="CompanyX.viewChange" Scope="CompanyX" />
                                <%--<EventClick Fn="CompanyX.record.show" Scope="CompanyX" />--%>
                                <DayClick Fn="CompanyX.dayClick" Scope="CompanyX" />
                                <%--<RangeSelect Fn="CompanyX.rangeSelect" Scope="CompanyX" />--%>
                                <%--<EventMove Fn="CompanyX.record.move" Scope="CompanyX" />--%>
                                <%--<EventResize Fn="CompanyX.record.resize" Scope="CompanyX" />--%>

                                <%--<EventAdd Fn="CompanyX.record.addFromEventDetailsForm" Scope="CompanyX" />--%>
                                <%--<EventUpdate Fn="CompanyX.record.updateFromEventDetailsForm" Scope="CompanyX" />
                                <EventDelete Fn="CompanyX.record.removeFromEventDetailsForm" Scope="CompanyX" />--%>
                            </Listeners>
                        </ext:CalendarPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>

        <ext:EventWindow
            ID="EventWindow1"
            runat="server"
            Hidden="true"
            CalendarStoreID="CalendarStore1">
            <Listeners>
                <%--<EventAdd Fn="CompanyX.record.add" Scope="CompanyX" />
                <EventUpdate Fn="CompanyX.record.update" Scope="CompanyX" />
                <EditDetails Fn="CompanyX.record.edit" Scope="CompanyX" />
                <EventDelete Fn="CompanyX.record.remove" Scope="CompanyX" />--%>
            </Listeners>
        </ext:EventWindow>
        <ext:Window runat="server" ID="winRegistroCita" Title="Nueva Cita" Icon="Add" Width="600" Height="430" Collapsible="true" BodyStyle="background-color: #fff;" BodyPadding="5" Hidden="true" Modal="true">
            <Items>
                <ext:FormPanel runat="server" ID="frmPnlCita" BodyPadding="5" DefaultAnchor="100%">
                    <Items>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout">
                            <Items>
                                <ext:DateField runat="server" ID="finicio" FieldLabel="Fecha Inicio" Format="dd/MM/yyyy" AllowBlank="false">
                                    <AfterLabelTextTpl runat="server">
                                        <Html>
                                            <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                        </Html>
                                    </AfterLabelTextTpl>
                                </ext:DateField>
                                <ext:TimeField runat="server" ID="hinicio" FieldLabel="Hora Inicio" MinTime="8:00" MaxTime="18:00" Increment="30" Format="HH:mm" TriggerIcon="SimpleTime" AllowBlank="false">
                                    <AfterLabelTextTpl runat="server">
                                        <Html>
                                            <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                        </Html>
                                    </AfterLabelTextTpl>
                                </ext:TimeField>
                            </Items>
                        </ext:FieldContainer>
                        <ext:ComboBox runat="server" ID="cbxServicio" FieldLabel="Servicio" Editable="false" QueryMode="Local" TriggerAction="All" Flex="1" EmptyText="Seleccione un servicio" StoreID="strServicio" TypeAhead="true" ForceSelection="true" DisplayField="servicio"
                            ValueField="id_servicio" AllowBlank="false">
                            <AfterLabelTextTpl runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                            <Listeners>
                                <Select Handler="#{cbxMedico}.clearValue(); #{strMedico}.reload();" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="cbxMedico" FieldLabel="Medico" Editable="false" QueryMode="Local" TriggerAction="All" Flex="1" EmptyText="Seleccione un medico" StoreID="strMedico" TypeAhead="true" ForceSelection="true" DisplayField="medico"
                            ValueField="id_medico" AllowBlank="false">
                            <AfterLabelTextTpl runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:ComboBox>
                        <ext:TextField runat="server" ID="txtNombre" FieldLabel="Nombres" EmptyText="Digité su nombres" AllowBlank="false">
                            <AfterLabelTextTpl runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txtApellidos" FieldLabel="Apellidos" EmptyText="Digité su apellidos" AllowBlank="false">
                            <AfterLabelTextTpl runat="server">
                                <Html>
                                    <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                </Html>
                            </AfterLabelTextTpl>
                        </ext:TextField>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtTelefono" FieldLabel="teléfono" EmptyText="(xxx)xxxx-xxxx"
                                    MaskRe="[\d\-\(\)]" Regex="^\(\d{3}\)\d{4}-\d{4}$" RegexText="Debe estar en el formato (xxx)xxxx-xxxx" AllowBlank="false">
                                    <AfterLabelTextTpl runat="server">
                                        <Html>
                                            <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                        </Html>
                                    </AfterLabelTextTpl>
                                </ext:TextField>
                            </Items>
                        </ext:FieldContainer>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtCorreo" FieldLabel="Correo" Vtype="email" AllowBlank="false">
                                    <AfterLabelTextTpl runat="server">
                                        <Html>
                                            <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                        </Html>
                                    </AfterLabelTextTpl>
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtDui" FieldLabel="DUI" EmptyText="xxxxxxxx-x"
                                    MaskRe="[\d\-]" Regex="(^\d{8})-(\d$)" RegexText="Debe estar en el formato xxxxxxxx-x" MaxLength="14" AllowBlank="false">
                                    <AfterLabelTextTpl runat="server">
                                        <Html>
                                            <span style="color: red; font-weight: bold" data-qtip="Required">*</span>
                                        </Html>
                                    </AfterLabelTextTpl>
                                </ext:TextField>
                            </Items>
                        </ext:FieldContainer>
                    </Items>
                    <Listeners>
                        <ValidityChange Handler="#{btnGenerar}.setDisabled(!valid);" />
                    </Listeners>
                    <Buttons>
                        <ext:Button runat="server" ID="btnGenerar" Text="Generar" Icon="Disk" Disabled="true">
                            <DirectEvents>
                                <Click Complete="CompanyX.direct.actualizarCalendario();" OnEvent="btnGenerar_Click" Before="if (!dui_ver(#{txtDui}.getValue())) {Ext.Msg.show({icon: Ext.MessageBox.WARNING, msg: 'El DUI no es valido', buttons:Ext.Msg.OK});return false;}" Method="POST">
                                    <EventMask ShowMask="true" />
                                    <ExtraParams>
                                        <ext:Parameter Name="objCita" Value="Ext.encode(this.up('form').getForm().getValues())" Mode="Raw" />
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                            <Listeners>
                                <Click Handler="dui_ver(Ext.getCmp('txtDui').getValue());" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Cancelar" Icon="Cancel">
                            <Listeners>
                                <Click Handler="this.up('form').getForm().reset();this.up('window').hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
            <Listeners>
                <Hide Handler="Ext.getCmp('frmPnlCita').reset();" />
            </Listeners>
        </ext:Window>

    </form>
</body>
</html>
