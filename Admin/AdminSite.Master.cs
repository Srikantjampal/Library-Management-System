using System;

namespace LMS_Project.Admin
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Adminrole"] != null && Session["Adminrole"].ToString() == "Admin")
            {
                if (!IsPostBack)
                {
                    lblUsername.Text = "Hi," + Session["Adminusername"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/signout.aspx");
            }
        }
    }
}
