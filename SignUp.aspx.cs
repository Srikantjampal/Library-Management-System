using System;
using System.Data;
using System.Data.SqlClient;

namespace LMS_Project
{
    public partial class SignUp : System.Web.UI.Page
    {
        DBConnect dbcon = new DBConnect();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Autogenerate();
            }
        }
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            //inserting the data to db
            if (CheckDuplicationMemberExist())
            {
                Response.Write("<script> alert('Member already exists  with this ID')</script>");
            }
            else
            {
                createAccount();

            }
        }

        private void createAccount()
        {
            dbcon.OpenCon();
            cmd = new SqlCommand("sp_InsertSignup", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@full_name", TxtFullName.Text);
            cmd.Parameters.AddWithValue("@dob", TxtDOB.Text);
            cmd.Parameters.AddWithValue("@contact_no", TxtContactNO.Text);
            cmd.Parameters.AddWithValue("@email", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@state", ddlState.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@city", TxtCity.Text);
            cmd.Parameters.AddWithValue("@pincode", TxtPin.Text);
            cmd.Parameters.AddWithValue("@full_address", TxtAddress.Text);
            cmd.Parameters.AddWithValue("@member_id", TxtMemberID.Text);
            cmd.Parameters.AddWithValue("@password", TxtPassword.Text);
            cmd.Parameters.AddWithValue("@account_status", "pending");
            if (cmd.ExecuteNonQuery() == 1)
            {
                //Response.Write("<script>alert('account created succesfully')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Account created Succesfully','success')", true);
                clrcontrol();
                Autogenerate();
            }
            else
            {
                //Response.Write("<script>alert('error try again')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! record not inserted. Try again!!','error')", true);

            }
            dbcon.CloseCon();
        }

        protected bool CheckDuplicationMemberExist()
        {
            cmd = new SqlCommand("sp_CheckDuplicateMember", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@member_id", TxtMemberID.Text.Trim());
            cmd.Parameters.AddWithValue("@email", TxtEmail.Text.Trim());
            dbcon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Autogenerate()
        {
            try
            {
                int r;
                dbcon.OpenCon();
                cmd = new SqlCommand("select max(member_id) as ID from member_master_tbl", dbcon.GetCon());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string d = dr[0].ToString();
                    if (d == "")
                    {
                        TxtMemberID.Text = "1001";
                    }
                    else
                    {
                        r = Convert.ToInt32(dr[0].ToString());
                        r = r + 1;
                        TxtMemberID.Text = r.ToString();
                    }
                    TxtMemberID.ReadOnly = true;
                }
                dbcon.CloseCon();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script");
            }
        }

        private void clrcontrol()
        {
            TxtAddress.Text = TxtCity.Text = TxtContactNO.Text = TxtDOB.Text = TxtEmail.Text = TxtFullName.Text = TxtPassword.Text = TxtEmail.Text = TxtPin.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            ddlState.SelectedItem.Text = "select";
            TxtFullName.Focus();
        }
    }
}