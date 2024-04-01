using System;

namespace LMS_Project
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex.InnerException != null)
            {
                Response.Write("ErrorPage.aspx?ErrorMessage=" + ex.InnerException.Message);
            }
            else
            {
                Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message);
            }
        }
    }
}