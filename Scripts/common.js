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
        return false;
    } else { return true; }
}