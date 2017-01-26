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
                            /*getSede(Session["id_usuario"].ToString());
                            getCenter(Session["id_usuario"].ToString());*/
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
        //permiso TODOS
        nodo = new ArrayList()
        { "Gestión de citas","#","Administrador,Secretaria",Icon.BookOpenMark, new ArrayList()
            {
               new ArrayList() { "Agenda", "Formularios/descargarRD.aspx", "", Icon.BookTabs, null},
               new ArrayList() { "Asignación de cubículos", "Formularios/registroDocentes.aspx", "", Icon.HouseGo, null}
            }
        };
        //ooo
        arbol.Add(nodo);
        // nodo = new ArrayList() 
        //    { "Gestión Administrativa","#","PLA.SER,PLA.ADM","fugue-gear", new ArrayList() 
        //        {
        //           new ArrayList() { "Gestión Administrativa", "Formularios/rd-05.aspx", "PLA.ADM", "fugue-hard-hat--exclamation", null},
        //           new ArrayList() { "Acciones de Personal", "Administrativa/Acciones.aspx", "PLA.SER", "fugue-hard-hat--exclamation", null}
        //        }
        //    };

        //arbol.Add(nodo);
        /*nodo = new ArrayList() 
            { "Reportes","#","",Icon.ReportGo, new ArrayList() 
                {
                    new ArrayList() { "RD-01", "Reportes/rd-01.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-02", "Reportes/rd-02.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-03", "Reportes/rd-03.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-04", "Reportes/rd-04.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-05", "Reportes/rd-05.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-06", "Reportes/rd-06.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-07", "Reportes/rd-07.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-08", "Reportes/rd-08.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-09", "Reportes/rd-09.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-10", "Reportes/rd-10.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-11", "Reportes/rd-11.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-12", "Reportes/rd-12.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-13", "Reportes/rd-13.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-14", "Reportes/rd-14.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-15", "Reportes/rd-15.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-16", "Reportes/rd-16.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-17", "Reportes/rd-17.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-18", "Reportes/rd-18.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-19", "Reportes/rd-19.aspx", "", "fugue-document-text-image", null},
                    new ArrayList() { "RD-20", "Reportes/rd-20.aspx", "", "fugue-document-text-image", null}
                    //new ArrayList() { "Expediente", "Reportes/expediente.aspx", "PLA.ADM", "fugue-hard-hat--exclamation", null}
                }
            };
        arbol.Add(nodo);*/

        //permiso SRD.ADMIN
        nodo = new ArrayList()
        { "Gestión de consultas","#","Administrador,Medico",Icon.TableGear, new ArrayList()
            {
                new ArrayList() { "Consultas", "Mantenimientos/manttoEscalafon.aspx", "", Icon.HourglassGo, null}
                /*new ArrayList() { "Instituciones/Empresas", "Mantenimientos/manttoInstitucionEmpresa.aspx", "", Icon.BuildingAdd, null},
                new ArrayList() { "Nacionalidades", "Mantenimientos/manttoNacionalidad.aspx", "", Icon.FlagWhite, null},
                new ArrayList() { "Universidades", "Mantenimientos/manttoUniversidades.aspx", "", Icon.HouseStar, null}*/
            }
        };
        arbol.Add(nodo);

        //permiso SRD.ADMIN
        /*nodo = new ArrayList() 
            { "Gestión de evaluaciones","#","","fugue-clipboard--pencil", new ArrayList() 
                {               
                    new ArrayList() { "Gestión de coordinadores", "Mantenimientos/manttoCoordinadores.aspx", "", "fugue-user-detective", null},
                    new ArrayList() { "Gestión de encuestas", "Mantenimientos/manttoCuestionarios.aspx", "", "fugue-clipboard-task", null}
                }
            };
        arbol.Add(nodo);*/

        //permiso SRD.ADMIN
        nodo = new ArrayList()
            { "Gestión de pacientes","#","",Icon.UserGray, new ArrayList()
                {
                    new ArrayList() { "Expediente", "http://isaf.ufg.edu.sv/planilla/Planilla/Mantenimiento/manttoTrasladoAdmToHc.aspx?sede=" + DamSede, "",Icon.FolderTable, null }
                    /*new ArrayList() {"Realizar","Planilla/Presentacion/accionPersonal.aspx","PLA.SEP","fugue-document",null},                    
                    new ArrayList() {"Accion de personal docente", "http://isaf.ufg.edu.sv/planilla/Planilla/accionPerAdiHoras.aspx", "", "fugue-document-attribute", null},
                    new ArrayList() { "Anulación de Acciones Enviadas", "https://isaf.ufg.edu.sv/Planilla/Planilla/Presentacion/recepcionAccionesPersonales.aspx?idusuario=687", "", "fugue-clipboard-sign-out", null }*/
                }
            };
        arbol.Add(nodo);

        //permiso SRD.ADMIN
        nodo = new ArrayList()
            { "Gestión de pagos","#","Administrador,Secretaria",Icon.Money, new ArrayList()
                {
                    new ArrayList() { "Orden de Pago", "http://isaf.ufg.edu.sv/planilla/Planilla/Reportes/rptAccionesMensualDocentesHC.aspx", "",Icon.MoneyDollar,null}
                    /*new ArrayList() {"Reporte de Carga Academica", "http://isaf.ufg.edu.sv/planilla/Planilla/Decanatos/RepoCargaDocentesHC.aspx", "","fugue-blue-folder-open-table",null},
                    new ArrayList() {"Reporte de Marcaciones", "http://isaf.ufg.edu.sv/planilla/Planilla/Decanatos/RepoMarcacionesDocentesHC.aspx", "","fugue-fingerprint",null},
                    new ArrayList() {"Resumen de Movimientos", "http://isaf.ufg.edu.sv/planilla/Planilla/Decanatos/ResumenMovimientos.aspx", "","fugue-chart-up-color",null}*/
                }
            };
        arbol.Add(nodo);

        //permiso SRD.CDSOFT
        nodo = new ArrayList()
        { "Gestión de sistema","#","Administrador",Icon.Computer, new ArrayList()
            {               
                new ArrayList() { "Registro de usuarios", "Mantenimientos/manttoUsuario.aspx", "", Icon.UserAdd, null},
                new ArrayList() { "Registro de roles", "Mantenimientos/manttoGruposP.aspx", "", Icon.GroupAdd, null},
                new ArrayList() { "Registro de Médicos", "Mantenimientos/manttoPermisosP.aspx", "", Icon.UserSuit, null},
                new ArrayList() { "Registro de Servicios", "Mantenimientos/manttoUsuarioUnidad.aspx", "", Icon.SitemapColor, null},
                new ArrayList() { "Registro de Especialidades", "Mantenimientos/manttoUsuarioUnidad.aspx", "", Icon.RosetteBlue, null},
                new ArrayList() { "Registro de Variables", "Mantenimientos/manttoUsuarioUnidad.aspx", "", Icon.CogAdd, null}
            }
        };
        arbol.Add(nodo);

        //Nodo de Manual
        //nodo = new ArrayList() { "Manual de uso", "manual.html", "PLA.DEC", Icon.Help, null };
        nodo = new ArrayList() { "Manual de uso", "http://isaf.ufg.edu.sv/planilla/manual.html", "", Icon.Help, null };
        arbol.Add(nodo);

        nodo = new ArrayList() { "Cerrar sesión", "http://isaf.ufg.edu.sv/planilla/manual.html", "", Icon.DoorOut, null };
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

    private void getSede(string usuario)
    {
        Int64 sede = 0;
        //Conexion a la base de datos
        string strconexion = System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;

        SqlConnection conn = new SqlConnection(strconexion);
        conn.Open();
        string sql = "select id_usuario from usuario where usuario ='" + usuario + "'";
        SqlCommand comm = new SqlCommand(sql, conn);
        SqlDataReader dr = comm.ExecuteReader();

        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sede = Convert.ToInt64(dr["id_sede"].ToString());
                DamId = dr["ID_usuario"].ToString();
                DamSede = Convert.ToInt64(dr["id_sede"].ToString());
            }
            Session["id_sede"] = sede;
        }
        dr.Close();
        dr.Dispose();
        comm.Dispose();
        conn.Close();
        conn.Dispose();
    }

    private void getCenter(string usuario)
    {
        Int64 center = 0;
        //Conexion a la base de datos
        string strconexion = System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;

        SqlConnection conn = new SqlConnection(strconexion);
        conn.Open();
        string sql = "SELECT IdUsuarioCentro, IdUsuario, IdCentro FROM USUARIO_CENTRO WHERE(IdUsuario = @IdUser)";
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.Parameters.AddWithValue("@IdUser", usuario);
        SqlDataReader dr = comm.ExecuteReader();

        if (dr.HasRows)
        {
            while (dr.Read())
            {
                center = Convert.ToInt64(dr["IdCentro"]);
            }
        }

        dr.Close();
        dr.Dispose();
        comm.Dispose();
        conn.Close();
        conn.Dispose();

        Session["IdCentro"] = center;
    }
}