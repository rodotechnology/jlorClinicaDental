<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgendaCita.aspx.cs" Inherits="Vista_Cita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        var CompanyX = {
            getCalendar: function () {
                return CompanyX.CalendarPanel1;
            },

            getStore: function () {
                return CompanyX.EventStore1;
            },

            getWindow: function () {
                return CompanyX.EventWindow1;
            },

            viewChange: function (p, vw, dateInfo) {
                var win = this.getWindow();

                if (win) {
                    win.hide();
                }

                if (dateInfo) {
                    // will be null when switching to the event edit form, so ignore
                    this.DatePicker1.setValue(dateInfo.activeDate);
                    this.updateTitle(dateInfo.viewStart, dateInfo.viewEnd);
                }
            },

            updateTitle: function (startDt, endDt) {
                var msg = '',
                    fmt = Ext.Date.format;

                if (Ext.Date.clearTime(startDt).getTime() == Ext.Date.clearTime(endDt).getTime()) {
                    msg = fmt(startDt, 'F j, Y');
                } else if (startDt.getFullYear() == endDt.getFullYear()) {
                    if (startDt.getMonth() == endDt.getMonth()) {
                        msg = fmt(startDt, 'F j') + ' - ' + fmt(endDt, 'j, Y');
                    } else {
                        msg = fmt(startDt, 'F j') + ' - ' + fmt(endDt, 'F j, Y');
                    }
                } else {
                    msg = fmt(startDt, 'F j, Y') + ' - ' + fmt(endDt, 'F j, Y');
                }

                this.Panel1.setTitle(msg);
            },

            setStartDate: function (picker, date) {
                this.getCalendar().setStartDate(date);
            },

            rangeSelect: function (cal, dates, callback) {
                this.record.show(cal, dates);
                this.getWindow().on('hide', callback, cal, { single: true });
            },

            dayClick: function (cal, dt, allDay, el) {
                //this.record.show.call(this, cal, {
                //    StartDate: dt,
                //    IsAllDay: allDay
                //}, el);
                Ext.getCmp('winRegistroCita').show();
            },

            record: {
                addFromEventDetailsForm: function (win, rec) {
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was added');
                },

                add: function (win, rec) {
                    win.hide();
                    CompanyX.getStore().add(rec);
                    CompanyX.getStore().sync();
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was added');
                },

                updateFromEventDetailsForm: function (win, rec) {
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was updated');
                },

                update: function (win, rec) {
                    win.hide();
                    rec.commit();
                    CompanyX.getStore().sync();
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was updated');
                },

                removeFromEventDetailsForm: function (win, rec) {
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was deleted');
                },

                remove: function (win, rec) {
                    CompanyX.getStore().remove(rec);
                    CompanyX.getStore().sync();
                    win.hide();
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was deleted');
                },

                edit: function (win, rec) {
                    win.hide();
                    rec.commit();
                    CompanyX.getCalendar().showEditForm(rec);
                },

                resize: function (cal, rec) {
                    rec.commit();
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was updated');
                },

                move: function (cal, rec) {
                    rec.commit();
                    CompanyX.ShowMsg('Event ' + rec.data.Title + ' was moved to ' + Ext.Date.format(rec.data.StartDate, 'F jS' + (rec.data.IsAllDay ? '' : ' \\a\\t g:i a')));
                },

                show: function (cal, rec, el) {
                    CompanyX.getWindow().show(rec, el);
                },

                saveAll: function () {
                    CompanyX.getStore().submitData({
                        mappings: false
                    });
                }
            }
        };

        function dui_ver(value) {
            var x = value;
            var resultado = 0;
            resultado = x.charAt(0) * 9;
            resultado = resultado + x.charAt(1) * 8;
            resultado = resultado + x.charAt(2) * 7;
            resultado = resultado + x.charAt(3) * 6;
            resultado = resultado + x.charAt(4) * 5;
            resultado = resultado + x.charAt(5) * 4;
            resultado = resultado + x.charAt(6) * 3;
            resultado = resultado + x.charAt(7) * 2;
            resultado = resultado % 10;
            resultado = 10 - resultado;
            var a = parseInt(x.charAt(9));
            if (!(resultado == a)) {
                alert("el DUI este mal, favor revisarlo.");
            }
            else {
                Ext.net.Notification.show({
                    hideFx: {
                        args: ['l', {}],
                        fxName: 'ghost'
                    },
                    showFx: {
                        args: ['l', {}],
                        fxName: 'slideIn'
                    },
                    pinEvent: 'click',
                    alignToCfg: {
                        offset: [2, 0],
                        position: 'l-r',
                        el: Ext.net.getEl('winRegistroCita')
                    },
                    height: 350,
                    html: "Es bueno el DUI XD",
                    title: 'Varificado'
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" Namespace="CompanyX" />
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
        <ext:Store runat="server" ID="strMedico">
            <Model>
                <ext:Model runat="server" IDProperty="id_medico">
                    <Fields>
                        <ext:ModelField Name="id_medico" />
                        <ext:ModelField Name="medico" />
                    </Fields>
                </ext:Model>
            </Model>
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
        <ext:Window runat="server" ID="winRegistroCita" Title="Nueva Cita" Icon="Add" Width="600" Height="430" Collapsible="true" BodyStyle="background-color: #fff;" BodyPadding="5" Hidden="false" Modal="true">
            <Items>
                <ext:FormPanel runat="server" BodyPadding="5" DefaultAnchor="100%">
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
                                <ext:TimeField runat="server" ID="hinicio" FieldLabel="Hora Inicio" Increment="30" TriggerIcon="SimpleTime" AllowBlank="false">
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
                                    MaskRe="[\d\-]" Regex="^\d{3}-\d{3}-\d{4}$" RegexText="Debe estar en el formato (xxx)xxxx-xxxx" AllowBlank="false">
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
                    <Buttons>
                        <ext:Button runat="server" Text="Generar" Icon="Disk">
                            <Listeners>
                                <Click Handler="dui_ver(Ext.getCmp('txtDui').getValue());" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Cancelar" Icon="Cancel">
                            <Listeners>
                                <Click Handler="this.up('form').getForm().reset();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>

    </form>
</body>
</html>
