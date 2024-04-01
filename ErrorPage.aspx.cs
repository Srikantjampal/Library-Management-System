using System;

namespace LMS_Project
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorDesp.Text = Request.QueryString["ErrorMessage"];
        }
    }
}