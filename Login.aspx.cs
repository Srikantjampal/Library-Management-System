using System;
using System.Data.SqlClient;

namespace LMS_Project
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect dbcon = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //for member login
            SqlCommand cmd = new SqlCommand("sp_UserLogin", dbcon.GetCon());
            dbcon.OpenCon();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@member_id", TxtMemberID.Text);
            cmd.Parameters.AddWithValue("@password", TxtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Response.Write("<script> alert('Login Successfully');</script>");
                    Session["role"] = "user";
                    Session["fullname"] = dr.GetValue(0).ToString();
                    Session["username"] = dr.GetValue(1).ToString();
                    Session["status"] = dr.GetValue(3).ToString();
                    Session["mid"] = TxtMemberID.Text;
                }
                Response.Redirect("~/UserScreen/UserHome.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Eroor',' Invalid credentials...try again','error')", true);
            }
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            //ADmin Logic
            SqlCommand cmd = new SqlCommand("sp_AdminLogin", dbcon.GetCon());
            dbcon.OpenCon();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", txtAdminID.Text);
            cmd.Parameters.AddWithValue("@password", txtAdminPass.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    //Response.Write("<script> alert('Login Successfully');</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Login Successfully','success')", true);
                    Session["Adminrole"] = "Admin";
                    Session["Adminusername"] = dr.GetValue(0).ToString();
                    Session["Adminfullname"] = dr.GetValue(2).ToString();
                    //Session["status"] = dr.GetValue(3).ToString();
                }
                Response.Redirect("~/Admin/AdminHome.aspx");
            }
            else
            {
                //Response.Write("<script> alert('Invalid credentials...try again')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Eroor',' Invalid credentials...try again','error')", true);

            }
        }
    }
}