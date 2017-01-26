var leafWindow;
var floatWindow;
var leafTab;
var floatTab;

function HookTab(obj) {
    var tab;

    tab = App.mTabs.add(new Ext.Panel({
        id: 't' + obj.idt,
        title: obj.titulo,
        loader: {
            url: obj.url,
            renderer: "frame",
            loadMask: { showMask: true }
        },
        closable: true,
        iconCls: obj.icono
    }));
    App.mTabs.setActiveTab(tab);
    floatTab = tab;
    leafTab = obj.window;
}

//idw, titulo, icono, url, ws, hs
function HookWindow(obj) {
    var aleatorio = Math.round(Math.random() * 100000);

    var exWindow = Ext.getCmp(obj.idw + 'WND_' + aleatorio);
    if (!exWindow) {
        exWindow = new Ext.Window({
            id: obj.idw + 'WND_' + aleatorio,
            modal: true,
            //maximized: true,
            layout: 'fit',
            closable: true,
            width: parseInt(obj.w),
            height: parseInt(obj.h),
            title: obj.titulo,
            iconCls: obj.icono,
            items: new Ext.Panel({
                id: 't' + obj.idw + "_" + aleatorio,
                loader: {
                    url: obj.url,
                    renderer: "frame",
                    loadMask: { showMask: true }
                },
            })
        });
        exWindow.show();
        floatWindow = exWindow;
        leafWindow = obj.window;
    }
}

function finishWindow() {
    floatWindow.close();
    leafWindow.updateW();
    floatWindow = null;
    leafWindow = null;
}

function closeWindow() {
    floatWindow.close();
    //leafWindow.updateW();
    floatWindow = null;
    leafWindow = null;
}

function showAppTab(texto) {
    var raiz = Ext.getCmp('optTree').getRootNode();
    var idnodo = seekNode(raiz, texto);
    if (idnodo != "") {
        var nodo = App.optTree.getStore().getNodeById(idnodo);
        //var objeto = { idt: nodo.id, titulo: nodo.data.text, icono: nodo.data.iconCls, url: nodo.data.href };para hooktab        
        //HookTab(objeto);
        loadAlertasToPage(App.mTabs, nodo);
    }
}

function seekNode(branch, texto) {
    var idnodo = "";
    if (branch.data.text == texto) { idnodo = branch.internalId; }
    else {
        if (branch.childNodes) {
            for (var x = 0; x < branch.childNodes.length; x++) {
                idnodo = seekNode(branch.childNodes[x], texto);
                if (idnodo != "") { break; }
            }
        }
    }
    return idnodo;
}

function loadAlertasToPage(tabPanel, record) {
    var tab = tabPanel.getComponent(record.id);

    if (tab) {
        var task = new Ext.util.DelayedTask(function () {
            tabPanel.setActiveTab(tab);
        });
        task.delay(500);
    }
    else {
        tab = tabPanel.add({
            id: record.id,
            title: record.data.text,
            closable: true,
            loader: {
                url: record.data.href,
                renderer: "frame",
                loadMask: {
                    showMask: true,
                    msg: "Cargando " + record.data.text + "..."
                }
            },
            autoScroll: true,
            iconCls: record.data.iconCls
        });
        var task = new Ext.util.DelayedTask(function () {
            tabPanel.setActiveTab(tab);
        });
        task.delay(500);
    }
}

function finishEdition() {
    floatWindow.close();
    leafWindow.refreshGrid();
    floatWindow = null;
    leafWindow = null;
}

function finishTab() {
    leafTab.updateTab();
    App.mTabs.closeTab(floatTab);
}


//idw, titulo, icono, url, ws, hs
function HookWindowMax(obj) {
    var aleatorio = Math.round(Math.random() * 100000);

    var exWindow = Ext.getCmp(obj.idw + 'WND_' + aleatorio);
    if (!exWindow) {
        exWindow = new Ext.Window({
            id: obj.idw + 'WND_' + aleatorio,
            modal: true,
            maximized: true,
            layout: 'fit',
            closable: true,
            width: parseInt(obj.w),
            height: parseInt(obj.h),
            title: obj.titulo,
            iconCls: obj.icono,
            items: new Ext.Panel({
                id: 't' + obj.idw + "_" + aleatorio,
                loader: {
                    url: obj.url,
                    renderer: "frame",
                    loadMask: { showMask: true }
                },
            })
        });
        exWindow.show();
        floatWindow = exWindow;
        leafWindow = obj.window;
    }
}