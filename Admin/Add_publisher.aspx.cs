using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace LMS_Project.Admin
{
    public partial class Add_publisher : System.Web.UI.Page
    {
        DBConnect dbcon = new DBConnect();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Autogenerate();
                BindRecord();
                btnAdd.Visible = true;
                btnupdate.Visible = false;
                btnCancel.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Insertpublisher();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Validation Error! please enter valid data ','error')", true);

            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_UpdatePublisherByID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtpublisherID.Text);
            cmd.Parameters.AddWithValue("@name", txtPublsiherName.Text);
            dbcon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Updated Succesfully','success')", true);
                BindRecord();
                Autogenerate();
                Clrcontrol();
                btnAdd.Visible = true;
                btnupdate.Visible = false;
                btnCancel.Visible = false;
            }
            else
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Record not updated ','error')", true);

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

        public void Autogenerate()
        {
            int r;
            dbcon.OpenCon();
            cmd = new SqlCommand("select max(member_id) as ID from publisher_master_tbl", dbcon.GetCon());
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    txtpublisherID.Text = "101";
                }
                else
                {
                    r = Convert.ToInt32(dr[0].ToString());
                    r = r + 1;
                    txtpublisherID.Text = r.ToString();
                }
                txtpublisherID.ReadOnly = true;
            }
            dbcon.CloseCon();

        }

        protected void BindRecord()
        {
            cmd = new SqlCommand("sp_getPublisher", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dbcon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            RptPublisher.DataSource = dt;
            RptPublisher.DataBind();
        }

        protected void Insertpublisher()
        {
            cmd = new SqlCommand("sp_InsertPublisher", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtpublisherID.Text);
            cmd.Parameters.AddWithValue("@name", txtPublsiherName.Text);
            dbcon.OpenCon();
            if (cmd.ExecuteNonQuery() == 1)
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Author Saved Succesfully','success')", true);
                Clrcontrol();
                BindRecord();
                Autogenerate();
            }
            else
            {
                dbcon.CloseCon();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Eroor',' Saved Unsuccesful','error')", true);

            }
        }

        private void Clrcontrol()
        {
            txtpublisherID.Text = txtPublsiherName.Text = string.Empty;
            txtpublisherID.Focus();
        }

        protected void SearchRecordBy_ID(string idd)
        {
            cmd =new SqlCommand("sp_getPublisherByID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", idd);
            dbcon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds, "dt");
            dbcon.CloseCon();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Session["AuthorId"] = ds.Tables[0].Rows[0][""].ToString();
                txtpublisherID.Text = ds.Tables[0].Rows[0]["member_id"].ToString();
                txtPublsiherName.Text = ds.Tables[0].Rows[0]["membar_name"].ToString();
                btnAdd.Visible = false;
                btnupdate.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Eroor',' No Record Found Try again','error')", true);
            }
        }

        protected void RptPublisher_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                SearchRecordBy_ID(id);
            }
            else if (e.CommandName == "delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];                
                cmd = new SqlCommand("sp_DeltePublisherByID", dbcon.GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                dbcon.OpenCon();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    dbcon.CloseCon();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Deleted Succesfully','success')", true);
                    Clrcontrol();
                    BindRecord();
                    Autogenerate();
                    btnAdd.Visible = true;
                    btnupdate.Visible = false;
                    btnCancel.Visible = false;
                }
                else
                {
                    dbcon.CloseCon();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Record not Deleted ','error')", true);

                }
            }
        }
    }
}