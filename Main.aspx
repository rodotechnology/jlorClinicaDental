<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Assets/Css/fugue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="hookServer.js"></script>
    <script type="text/javascript">
        var loadPage = function (tabPanel, record) {
            var tab = tabPanel.getComponent(record.id);

            if (tab) {
                tabPanel.setActiveTab(tab);
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
                    iconCls: record.data.iconCls
                });
                tabPanel.setActiveTab(tab);
            }
        };
    </script>
    <style type="text/css">
        .x-panel-header-text-container-default {
            color: white;
            font-family: tahoma,arial,verdana,sans-serif;
            font-size: 13px;
            font-weight: bold;
            text-transform: none;
        }

        .x-tree-node-text {
            font-size: 12px;
            vertical-align: middle;
            color: #080808;
            font-family: tahoma,arial,verdana,sans-serif;
            outline: 0 none;
            text-decoration: none;
        }

        .x-tree-panel .x-grid-cell a {
            color: #0589C7;
            font-family: tahoma,arial,verdana,sans-serif;
            outline: 0 none;
            text-decoration: none;
        }

        a:link {
            text-decoration: none;
            color: #add2ed;
        }

        a:visited {
            text-decoration: none;
            color: #ADD2ED;
        }

        a:hover {
            text-decoration: none;
            color: #FFF;
        }

        a:active {
            text-decoration: none;
            color: #FFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="PanelN" runat="server" Height="45" BodyStyle="background-image: url(Img/banner-superior.jpg)"
                    Region="North">
                    <Content>
<%--                        <div style="position: absolute; bottom: -2px; right: 10px">
                            <img alt="Sistema de Recurso Docente" src="Assets/Img/letras_srd.png" />
                        </div>
                        <div style="position: absolute; bottom: -2px; left: 40px">
                            <img alt="Universidad Francisco Gavidia" src="Assets/Img/Logo Institucional-W.png" width="110" height="45" />
                        </div>--%>
                    </Content>
                </ext:Panel>
                <ext:TreePanel ID="optTree" runat="server" Region="West" Width="220" Title="Opciones"
                    Icon="ChartOrganisation" Collapsible="true" Split="true" UseArrows="true"
                    CollapseFirst="false" ContainerScroll="true" RootVisible="false">
                    <Listeners>
                        <%--<ItemClick Handler="loadPage(record.getId(),record.data.text,record.data.href);" />--%>
                        <ItemClick Handler="if (record.data.href) { e.stopEvent(); loadPage(#{mTabs}, record); }" />
                    </Listeners>
                    <BottomBar>
                        <ext:Toolbar ID="Toolbar1" runat="server" StyleSpec="background-color:#157fcc; border: solid 1px #add2ed;">
                            <Items>
                                <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="2017 &copy Powered By <a href='http://www.jlor.com.sv' target='_blank'>JLOR</a>" StyleSpec="color: #fff; text-decoration: none;" />
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                </ext:TreePanel>
                <ext:TabPanel ID="mTabs" runat="server" Region="Center" ActiveTabIndex="0" Border="false" Layout="FitLayout">
                    <Items>
                        <ext:Panel ID="Tab1" runat="server" Closable="false" Title="Alertas" Icon="Monitor" Layout="fit">
                            <Content>
                                <ext:Panel ID="Panel1" runat="server" Layout="fit">
                                    <Content>
                                        <ext:Panel ID="DashBoardPanel" runat="server" Cls="items-view" ShrinkWrap="Height" Border="false">
                                            <TopBar>
                                                <ext:Toolbar ID="Toolbar2" runat="server" Flat="true">
                                                    <Items>
                                                        <ext:ToolbarFill />

                                                        <ext:Button ID="btnDesplegarAll" runat="server" Icon="BulletPlus" Text="Desplegar todo">
                                                            <Listeners>
                                                                <Click Handler="#{Dashboard}.el.select('.group-header').removeCls('collapsed');" />
                                                            </Listeners>
                                                        </ext:Button>

                                                        <ext:Button ID="btnOcultarAll" runat="server" Icon="BulletMinus" Text="Ocultar todo">
                                                            <Listeners>
                                                                <Click Handler="#{Dashboard}.el.select('.group-header').addCls('collapsed');" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnReload" Icon="ArrowRefresh" Text="Actualizar">
                                                            <Listeners>
                                                                <Click Handler="#{refreshAlerta}.stopAll();App.direct.updateGrupodAlertas();#{refreshAlerta}.startAll();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="30" />
                                                    </Items>
                                                </ext:Toolbar>
                                            </TopBar>
                                            <Items>
                                                <ext:DataView
                                                    ID="Dashboard"
                                                    runat="server"
                                                    SingleSelect="true"
                                                    ItemSelector="div.group-header"
                                                    EmptyText="<span id='noalerta'>No hay alertas....</span>">
                                                    <Store>
                                                        <ext:Store ID="strGrupoAlertas" runat="server">
                                                            <Model>
                                                                <ext:Model ID="Model1" runat="server">
                                                                    <Fields>
                                                                        <ext:ModelField Name="Title" />
                                                                        <ext:ModelField Name="Items" Type="Object" />
                                                                    </Fields>
                                                                </ext:Model>
                                                            </Model>
                                                        </ext:Store>
                                                    </Store>
                                                    <Tpl ID="Tpl1" runat="server">
                                                        <Html>
                                                            <div id="items-ct">
                                <tpl for=".">
                                    <div class="group-header">
                                        <h2><div>{Title}</div></h2>
                                        <dl>
                                            <tpl for="Items">                                                
                                                <div id="{Id}" class="item-wrap"><img src="{Icon}"/>                                                    
                                                    <div><H6>{Title}<span class="test"> ({total})</span></H6></div>
                                                </div>                                                
                                            </tpl>
                                            <div style="clear:left"></div>
                                         </dl>
                                    </div>
                                </tpl>
                            </div>
                                                        </Html>
                                                    </Tpl>
                                                    <Listeners>
                                                        <%--<ItemClick Fn="itemClick" />--%>
                                                        <Refresh Handler="this.el.select('.item-wrap').addClsOnOver('x-view-over');" Delay="100" />
                                                    </Listeners>
                                                </ext:DataView>
                                            </Items>
                                        </ext:Panel>
                                    </Content>
                                </ext:Panel>
                            </Content>
                        </ext:Panel>
                    </Items>
                    <%--<Items>
                        <%--<ext:Panel ID="Tab1" runat="server" Closable="false" Title="Información" Icon="Monitor"
                            Layout="fit" Hidden="false" AutoScroll="true">
                            <Content>
                               <ext:Panel ID="DashBoardPanel" runat="server" Cls="items-view" ShrinkWrap="Height" Border="false">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server" Flat="true">
                                            <Items>
                                                <ext:ToolbarFill />

                                                <ext:Button ID="btnDesplegarAll" runat="server" Icon="BulletPlus" Text="Desplegar todo">
                                                    <Listeners>
                                                        <Click Handler="#{Dashboard}.el.select('.group-header').removeCls('collapsed');" />
                                                    </Listeners>
                                                </ext:Button>

                                                <ext:Button ID="btnOcultarAll" runat="server" Icon="BulletMinus" Text="Ocultar todo">
                                                    <Listeners>
                                                        <Click Handler="#{Dashboard}.el.select('.group-header').addCls('collapsed');" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnReload" Icon="ArrowRefresh" Text="Actualizar">
                                                    <Listeners>
                                                        <Click Handler="#{refreshAlerta}.stopAll();App.direct.updateGrupodAlertas();#{refreshAlerta}.startAll();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="30" />
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Items>
                                        <ext:DataView
                                            ID="Dashboard"
                                            runat="server"
                                            SingleSelect="true"
                                            ItemSelector="div.group-header"
                                            EmptyText="<span id='noalerta'>No hay alertas....</span>">
                                            <Store>
                                                <ext:Store ID="strGrupoAlertas" runat="server">
                                                    <Model>
                                                        <ext:Model ID="Model1" runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="Title" />
                                                                <ext:ModelField Name="Items" Type="Object" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <Tpl ID="Tpl1" runat="server">
                                                <Html>
                                                    <div id="items-ct">
                                <tpl for=".">
                                    <div class="group-header">
                                        <h2><div>{Title}</div></h2>
                                        <dl>
                                            <tpl for="Items">                                                
                                                <div id="{Id}" class="item-wrap"><img src="{Icon}"/>                                                    
                                                    <div><H6>{Title}<span class="test"> ({total})</span></H6></div>
                                                </div>                                                
                                            </tpl>
                                            <div style="clear:left"></div>
                                         </dl>
                                    </div>
                                </tpl>
                            </div>
                                                </Html>
                                            </Tpl>
                                            <Listeners>
                                                <ItemClick Fn="itemClick" />
                                                <Refresh Handler="this.el.select('.item-wrap').addClsOnOver('x-view-over');" Delay="100" />
                                            </Listeners>
                                        </ext:DataView>
                                    </Items>
                                </ext:Panel>
                            </Content>
                        </ext:Panel>
                    </Items>--%>
                </ext:TabPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
