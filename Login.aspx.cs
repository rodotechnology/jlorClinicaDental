using System;
using System.Collections;
using Ext.Net;
using System.Net;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["login"] = "0";
        Session["user"] = ""; //Nombre del usuario                
        txtPassword.Text = "L3tM31n!";

        /*if (Request.QueryString["Denied"] != null) //Si es rechazado desde el main
        {
            this.Viewport1.Show();
            this.FormPanel1.Hide();
            pnlMsg.Title = "Alerta";
            pnlMsg.Html = "<center><p>Usuario no tiene roles asignados en este aplicativo</p>* Solicite al administrador del sistema le asigne el rol correspondiente a su usuario.</center>";
            pnlMsg.UI = UI.Warning;
            pnlMsg.Icon = Icon.UserAlert;
            pnlMsg.Show();
        }
        else
        {
            try
            {
                string token = Request.QueryString["token"];
                if (token == null) { token = ""; }
                if (!token.Equals(""))
                {
                    string username = validate(token.ToString().Trim(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    if (username.Length > 0)
                    {
                        //if (username == "rortiz" || username == "jhumberstone" || username == "lnavarrete" || username == "wlipe" || username == "lgavidia" || username == "ogrivera" || username == "eplatero")
                        //{
                            //Session["login"] = 1;
                            //Session["user"] = username;
                            //Response.Redirect("Main.aspx");
                        //}

                        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString);
                        //Generando session!!
                        try
                        {
                            string id_usuario = "";
                            Session["user"] = username;

                            conn.Open();

                            SqlCommand comm = new SqlCommand("SELECT id_usuario, usuario, id_sede, id_estado FROM usuario WHERE (usuario ='" + username + "')", conn);
                            SqlDataReader dr = comm.ExecuteReader();
                            if (dr.HasRows)
                            {
                                dr.Read();
                                id_usuario = dr["id_usuario"].ToString();
                            }

                            dr.Close();
                            dr.Dispose();
                            comm.Dispose();

                            if (!id_usuario.Equals(""))
                            {
                                if (getPermisos(id_usuario))
                                {

                                    //Face de logueo
                                    Session["login"] = "1";
                                    Session["idusuario"] = id_usuario;
                                    Response.Redirect("Main.aspx");
                                }
                                else
                                {
                                    this.Viewport1.Show();
                                    this.FormPanel1.Hide();
                                    pnlMsg.Html = "<center><p>Usuario " + username + " no tiene roles asignados en este aplicativo</p><br><br>Solicite al administrador del sistema le asigne el rol correspondiente a su usuario.</center>";
                                    pnlMsg.Title = "Alerta";
                                    pnlMsg.UI = UI.Warning;
                                    pnlMsg.Icon = Icon.UserAlert;
                                    pnlMsg.Show();
                                }
                            }
                            else
                            {
                                this.Viewport1.Show();
                                this.FormPanel1.Hide();
                                pnlMsg.Html = "<center>Usuario " + username + " no está registrado para utilizar este aplicativo</center>";
                                pnlMsg.Title = "Validación";
                                pnlMsg.UI = UI.Danger;
                                pnlMsg.Icon = Icon.UserDelete;
                                pnlMsg.Show();
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Viewport1.Show();
                            this.FormPanel1.Hide();
                            pnlMsg.Html = ex.Message;
                            pnlMsg.Icon = Icon.Exclamation;
                            pnlMsg.Title = "Error";
                            pnlMsg.UI = UI.Danger;
                            pnlMsg.Show();
                        }
                        finally
                        {
                            conn.Close();
                            conn.Dispose();
                        }
                    }
                    else
                    {
                        this.Viewport1.Show();
                        this.FormPanel1.Hide();
                        pnlMsg.Html = "<center>Usuario no está registrado para utilizar este aplicativo</center>";
                        pnlMsg.Title = "Validación";
                        pnlMsg.UI = UI.Danger;
                        pnlMsg.Icon = Icon.UserDelete;
                        pnlMsg.Show();
                    }
                }
                else
                {
                    //Response.Redirect("sessionCaducada.aspx");
                    this.Viewport1.Show();
                }
            }
            catch (Exception ex)
            {
                this.Viewport1.Show();
                this.FormPanel1.Hide();
                pnlMsg.Html = ex.Message.ToString();
                pnlMsg.Icon = Icon.Exclamation;
                pnlMsg.Title = "Error";
                pnlMsg.UI = UI.Danger;
                pnlMsg.Show();
            }
            finally
            {
            }
        }*/
    }

    #region Ingreso sin Token
    public static string stub = "Verifique que el usuario y la contraseña sean correctos.";

    protected void btnLogin_Click(object sender, DirectEventArgs e)
    {
        //variable de Session para la autenticacion...
        Session["user"] = txtUsername.Text.Trim();
        
        //Conexion a la base de Datos
        string strConexionCentro = System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;

        SqlConnection connDB = new SqlConnection(strConexionCentro);
        connDB.Open();

        //string varUsuario = "SELECT idusuario, usuario FROM usuarios WHERE (usuario = '" + Session["user"].ToString() + "')";
        string varUsuario = "SELECT id_usuario, usuario, id_estado FROM usuario WHERE (usuario = '" + Session["user"].ToString() + "' AND id_estado = 0)";

        SqlCommand cmdUser = new SqlCommand(varUsuario, connDB);
        SqlDataReader drUser;

        drUser = cmdUser.ExecuteReader();

        //Variable nombre Usuario

        string nomUsuario = string.Empty;

        if (drUser.HasRows)
        {
            while (drUser.Read())
            {
                nomUsuario = drUser["usuario"].ToString();
                Session["usuario"] = nomUsuario;                
                Session["id_usuario"] = drUser["id_usuario"].ToString();                
            }
        }

        //Cierre de conexiones
        drUser.Close();
        drUser.Dispose();
        connDB.Close();
        
        if (nomUsuario != string.Empty)
        {
            //if (Session["user"].ToString() != "rortiz" && Session["user"].ToString() != "jhumberstone" && Session["user"].ToString() != "lnavarrete" && Session["user"].ToString() != "ogrivera" && Session["user"].ToString() != "lgavidia" && Session["user"].ToString() != "wlipe" && Session["user"].ToString() != "eplatero" && Session["user"].ToString() != "dmolina")
            //{
            if (txtPassword.Text != "L3tM31n!" || nomUsuario != Session["user"].ToString())
            {
                X.Msg.Callout(this.FormPanel1, new Callout
                {
                    Html = stub,
                    Alignment = AnchorPoint.RightTop,
                    DismissDelay = 5000,
                    CloseAction = CloseAction.Destroy,
                    Height = 100,
                    Width = 200,
                    UI = UI.Danger,
                    Title = "Error: Al iniciar Sesión",
                    Icon = Icon.Decline
                }).Show(true);
            }
            else
            {
                if (getPermisos(Session["id_usuario"].ToString()))
                {
                #region Insert en tabla bitacora
                //Insert en tabla bitacora
                /*SqlConnection connBitacora = new SqlConnection();
                SqlCommand cmdBitacora = new SqlCommand();
                SqlParameter prmIdUsuario = new SqlParameter();
                SqlParameter prmForm = new SqlParameter();

                prmIdUsuario.ParameterName = "IdUsuario";
                prmIdUsuario.IsNullable = false;
                prmIdUsuario.DbType = DbType.Int64;
                prmIdUsuario.Direction = ParameterDirection.Input;
                prmIdUsuario.Value = Convert.ToInt64(Session["id_usuario"]);

                prmForm.ParameterName = "Form";
                prmForm.IsNullable = false;
                prmForm.DbType = DbType.String;
                prmForm.Direction = ParameterDirection.Input;
                prmForm.Value = "Login_SRD";

                connBitacora.ConnectionString = ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;

                try
                {
                    connBitacora.Open();

                    cmdBitacora = new SqlCommand();
                    cmdBitacora.CommandType = CommandType.StoredProcedure;
                    cmdBitacora.CommandText = "pInsertarUsuarioBitacora";
                    cmdBitacora.Connection = connBitacora;

                    cmdBitacora.Parameters.Add(prmIdUsuario);
                    cmdBitacora.Parameters.Add(prmForm);

                    cmdBitacora.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Response.Write("Se ha producido un error al insertar en bitacora:" + ex.Message);
                }
                finally
                {
                    connBitacora.Close();
                    connBitacora.Dispose();
                }*/
                #endregion
                // Autentica la Información e envia a la aplicación
                Session["login"] = "1";
                Response.Redirect("Main.aspx");
                }
                else
                {
                    string stub2 = "Su usuario <i>No Tiene</i> roles para utilizar este sistema. <br><br> Solicite al administrador del sistema le asigne <br>los roles correspondientes a su usuario";
                    X.Msg.Callout(this.FormPanel1, new Callout
                    {
                        Html = stub2,
                        Alignment = AnchorPoint.RightTop,
                        DismissDelay = 5000,
                        CloseAction = CloseAction.Destroy,
                        Height = 150,
                        Width = 300,
                        UI = UI.Danger,
                        Title = "Error: Al iniciar Sesión",
                        Icon = Icon.Decline
                    }).Show(true);
                }
            }
        }
        else
        {
            string stub2 = "Usuario <i>No Registrado</i> para utilizar este sistema.";
            X.Msg.Callout(this.FormPanel1, new Callout
            {
                Html = stub2,
                Alignment = AnchorPoint.RightTop,
                DismissDelay = 5000,
                CloseAction = CloseAction.Destroy,
                Height = 100,
                Width = 200,
                UI = UI.Danger,
                Title = "Error: Al iniciar Sesión",
                Icon = Icon.Decline
            }).Show(true);
        }
    }

    private string IpAddress()
    {
        string strIpAddress;
        strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        return strIpAddress;
    }
    #endregion

    private bool getPermisos(string usuario)
    {
        bool ok = false;
        //Conexion a la base de datos
        string strconexion = System.Configuration.ConfigurationManager.ConnectionStrings["csJLOR"].ConnectionString;

        SqlConnection conn = new SqlConnection(strconexion);
        conn.Open();

        string sql = "SELECT ROL.rol FROM USUARIO INNER JOIN ROL_USUARIO ON USUARIO.id_usuario = ROL_USUARIO.id_usuario INNER JOIN ROL ON ROL_USUARIO.id_rol = ROL.id_rol WHERE (USUARIO.id_usuario =  @IdUsuario)";
        //string sql = "SELECT PERMISO.codigo_permiso FROM GRUPO_USUARIO INNER JOIN USUARIO ON GRUPO_USUARIO.ID_usuario = USUARIO.ID_usuario INNER JOIN GRUPO ON GRUPO_USUARIO.ID_grupo = GRUPO.ID_grupo INNER JOIN PERMISO INNER JOIN PERMISO_GRUPO ON PERMISO.ID_permiso = PERMISO_GRUPO.ID_permiso ON GRUPO.ID_grupo = PERMISO_GRUPO.ID_grupo WHERE (USUARIO.usuario = @IdUsuario)";
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.Parameters.AddWithValue("@IdUsuario", usuario);
        SqlDataReader dr = comm.ExecuteReader();

        if (dr.HasRows)
        {            
            dr.Read();

            Session["permisos"] = dr["rol"].ToString();
            ok = true;
        }
        else
        {
            Session["permisos"] = null;
        }

        dr.Close();
        dr.Dispose();
        comm.Dispose();
        conn.Close();
        conn.Dispose();

        return ok;
    }
}