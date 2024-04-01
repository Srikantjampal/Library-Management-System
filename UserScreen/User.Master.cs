using System;

namespace LMS_Project.UserScreen
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null && Session["role"].Equals("user"))
            {
                if (!IsPostBack)
                {
                    lblUsername.Text = "Hi," + Session["fullname"].ToString();
                }
            }
            else
            {
                Response.Redirect("signout.aspx");
            }
        }
    }
}