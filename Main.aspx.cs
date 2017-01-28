using System;
using System.Collections;
using Ext.Net;
using System.Data.SqlClient;

public partial class Main : System.Web.UI.Page
{
    Hashtable Catalogo = new Hashtable();
    Hashtable Relaciones = new Hashtable();
    ArrayList Principales = new ArrayList();
    string DamId = string.Empty;
    Int64 DamSede = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["login"] = 1;
        if (Request.QueryString["usuario"] != null)
        {
            Session["user"] = Request.QueryString["usuario"].ToString();
            Session["id_usuario"] = Request.QueryString["id_usuario"].ToString();
        }

        if (!IsPostBack)
        {
            if (Session["login"] != null)
            {
                if (Session["login"].ToString() == "1")
                {
                    if (Session["user"] == null || Session["id_usuario"] == null)
                    {
                        Response.Redirect("SessionExpired.aspx");
                    }
                    else
                    {
                        //getPermisos(Session["idusuario"].ToString());
                        if (Session["permisos"] != null)
                        {
                            Node root = new Node();
                            this.optTree.Root.Add(root);
                            string var = Session["user"].ToString();
                            genTree(dataArbol(), ref root);
                        }
                        else
                        {
                            Response.Redirect("Login.aspx?Denied=1");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Main.aspx");
                }
            }
            else
            {
                Response.Redirect("Main.aspx");
            }
        }

        if (!X.IsAjaxRequest)
        {
            ResourceManager1.RegisterIcon(Icon.Accept);
            ResourceManager1.RegisterIcon(Icon.MoneyAdd);
            ResourceManager1.RegisterIcon(Icon.Error);
            ResourceManager1.RegisterIcon(Icon.Exclamation);
            ResourceManager1.RegisterIcon(Icon.Information);
            ResourceManager1.RegisterIcon(Icon.TableColumn);
        }
    }

    private void genTree(ArrayList arbol, ref Node nodo)
    {
        /*ArrayList permisos = new ArrayList();
        if (Session["permisos"] != null) { permisos = (ArrayList)Session["permisos"]; }*/
        string permisos = Session["permisos"].ToString();

        foreach (ArrayList rama in arbol)
        {
            if (hasPermiso((String)rama[2], ref permisos))
            {
                string tipo = rama[3].GetType().Name;
                Node Nrama = new Node();
                Nrama.Text = (String)rama[0];
                if (tipo.Equals("Icon"))
                {
                    Nrama.Icon = (Icon)rama[3];
                }
                else
                {
                    Nrama.IconCls = (String)rama[3];
                }

                Nrama.Href = (String)rama[1];
                if (rama[4] != null) { genTree((ArrayList)rama[4], ref Nrama); }
                else { Nrama.Leaf = true; }
                nodo.Children.Add(Nrama);
                //nodo.Nodes.Add(Nrama);
            }
        }
    }

    private ArrayList dataArbol()
    {
        ArrayList arbol = new ArrayList();
        ArrayList nodo = null;
        // {titulo,pagina,permisos,icono,nuevo nodo()}
        //permiso Administrador,Secretaria
        nodo = new ArrayList()
        { "Gestión de citas","#","Administrador,Secretaria",Icon.BookOpenMark, new ArrayList()
            {
               new ArrayList() { "Agenda", "Formularios/AgendaCita.aspx", "", Icon.BookTabs, null},
               new ArrayList() { "Asignación de cubículos", "Formularios/asignacionCubiculos.aspx", "", Icon.HouseGo, null}
            }
        };
        arbol.Add(nodo);


        //permiso Administrador,Medico
        nodo = new ArrayList()
        { "Gestión de consultas","#","Administrador,Medico",Icon.TableGear, new ArrayList()
            {
                new ArrayList() { "Consultas", "Formularios/consulta.aspx", "", Icon.HourglassGo, null}
            }
        };
        arbol.Add(nodo);

        //permiso Todos
        nodo = new ArrayList()
            { "Gestión de pacientes","#","",Icon.UserGray, new ArrayList()
                {
                    new ArrayList() { "Ficha del paciente", "Formularios/fichaPaciente.aspx", "",Icon.FolderTable, null }
                }
            };
        arbol.Add(nodo);

        //permiso Administrador,Secretaria
        nodo = new ArrayList()
            { "Gestión de pagos","#","Administrador,Secretaria",Icon.Money, new ArrayList()
                {
                    new ArrayList() { "Orden de Pago", "Formularios/ordenPago.aspx", "",Icon.MoneyDollar,null}
                }
            };
        arbol.Add(nodo);

        //permiso Administrador
        nodo = new ArrayList()
        { "Gestión de sistema","#","Administrador",Icon.Computer, new ArrayList()
            {               
                new ArrayList() { "Registro de usuarios", "Formularios/manttoUsuario.aspx", "", Icon.UserAdd, null},
                new ArrayList() { "Registro de roles", "Formularios/manttoRol.aspx", "", Icon.GroupAdd, null},
                new ArrayList() { "Registro de Médicos", "Formularios/ManttoMedico.aspx", "", Icon.UserSuit, null},
                new ArrayList() { "Registro de Servicios", "~/Formularios/manttoServicios.aspx", "", Icon.SitemapColor, null},
                new ArrayList() { "Registro de Especialidades", "Formularios/manttoEspecialidad.aspx", "", Icon.RosetteBlue, null},
                new ArrayList() { "Registro de Variables", "Formularios/manttoUsuarioUnidad.aspx", "", Icon.CogAdd, null}
            }
        };
        arbol.Add(nodo);

        //Nodo de Manual
        //permiso todos
        nodo = new ArrayList() { "Manual de uso", "Docs/manual.html", "", Icon.Help, null };
        arbol.Add(nodo);

        return arbol;
    }

    private Boolean hasPermiso(String permisosAevaluar, ref string listaPermisos)
    {
        Boolean respuesta = false;
        if (permisosAevaluar.Equals(""))
        {
            respuesta = true;
        }
        else
        {
            string[] permisos = permisosAevaluar.Split(',');
            foreach (string permiso in permisos)
            {
                if (listaPermisos.Contains(permiso) || permiso.Equals("")) { respuesta = true; break; }
            }
        }
        return respuesta;
    }

}