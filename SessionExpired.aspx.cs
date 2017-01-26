using System;
using Ext.Net;

public partial class SessionExpired : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            //X.Msg.Alert("Tiempo de sesion", "Su sesion ha caducado, por favor ingrese nuevamente al sistema!!").Show();
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "<img src='Img/clock_error.png' width=15 heigth=15> Tiempo de sesión agotado",
                Message = "<center>Su sesión ha caducado, por favor ingrese nuevamente al sistema!!</center>",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
            });
        }
    }
}