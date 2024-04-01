using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LMS_Project.Admin
{
    public partial class AuthorDetails : System.Web.UI.Page
    {
        DBConnect dbcon = new DBConnect();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Autogenerate();
                BindReapeter();
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_AuthorDetails", dbcon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", TxtID.Text);
            cmd.Parameters.AddWithValue("@name", TxtAuthorName.Text);
            dbcon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Author Saved Succesfully','success')", true);
                clrcontrol();
                BindReapeter();
                Autogenerate();
            }
            else
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Eroor',' Saved Unsuccesful','error')", true);

            }
        }

        protected void clrcontrol()
        {
            TxtAuthorName.Text = TxtID.Text = string.Empty;
            TxtID.Focus();
        }

        public void Autogenerate()
        {
            try
            {
                int r;
                dbcon.OpenCon();
                cmd = new SqlCommand("select max(author_id) as ID from author_master_tbl", dbcon.GetCon());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string d = dr[0].ToString();
                    if (d == "")
                    {
                        TxtID.Text = "101";
                    }
                    else
                    {
                        r = Convert.ToInt32(dr[0].ToString());
                        r = r + 1;
                        TxtID.Text = r.ToString();
                    }
                    TxtID.ReadOnly = true;
                }
                dbcon.CloseCon();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script");
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                SearchDataForUpdate(Convert.ToInt32(id));
            }
            else if (e.CommandName == "delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                cmd = new SqlCommand("sp_DeleteAuthorDetails", dbcon.GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                dbcon.OpenCon();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    dbcon.CloseCon();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Deleted Succesfully','success')", true);
                    clrcontrol();
                    BindReapeter();
                    Autogenerate();
                    btnAdd.Visible = true;
                    btnupdate.Visible = false;
                    btncancel.Visible = false;
                }
                else
                {
                    dbcon.CloseCon();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Record not Deleted ','error')", true);

                }
            }
        }

        private void SearchDataForUpdate(int idd)
        {
            cmd = new SqlCommand("spGetAuthorByID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", idd);
            dbcon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds, "dt");
            dbcon.CloseCon();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["AuthorId"] = ds.Tables[0].Rows[0]["author_id"].ToString();
                TxtID.Text = ds.Tables[0].Rows[0]["author_id"].ToString();
                TxtAuthorName.Text = ds.Tables[0].Rows[0]["author_name"].ToString();
                btnAdd.Visible = false;
                btnupdate.Visible = true;
                btncancel.Visible = true;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Eroor',' No Record Found Try again','error')", true);
            }
        }

        protected void BindReapeter()
        {
            cmd = new SqlCommand("spGetAuthor", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dbcon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_UpdateAuthorDetails", dbcon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", TxtID.Text);
            cmd.Parameters.AddWithValue("@name", TxtAuthorName.Text);
            dbcon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Updated Succesfully','success')", true);
                clrcontrol();
                BindReapeter();
                Autogenerate();
                btnAdd.Visible = true;
                btnupdate.Visible = false;
                btncancel.Visible = false;
            }
            else
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Record not updated ','error')", true);

            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}