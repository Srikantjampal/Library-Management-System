using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_Project.Admin
{
    public partial class UpdateMemberDetails : System.Web.UI.Page
    {
        DBConnect dbcon = new DBConnect();
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGridView();
                GridView1.DataSource = dbcon.Load_Data(cmd);
            }
        }

        private void BindGridView()
        {
            cmd = new SqlCommand("sp_getMember_AllRecords", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            GridView1.DataSource = dbcon.Load_Data(cmd);
            GridView1.DataBind();

        }

        protected void btnSearchMember_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Search_MemberRecord();
            }

        }

        private void Search_MemberRecord()
        {
            cmd = new SqlCommand("sp_getMemberByID", dbcon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", TxtMemberID.Text.Trim());
            dbcon.OpenCon();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TxtFullName.Text = dr.GetValue(0).ToString();
                    TxtDOB.Text = dr.GetValue(1).ToString();
                    TxtContactNO.Text = dr.GetValue(2).ToString();
                    TxtEmail.Text = dr.GetValue(3).ToString();
                    ddlState.SelectedValue = dr.GetValue(4).ToString();
                    TxtCity.Text = dr.GetValue(5).ToString();
                    TxtPin.Text = dr.GetValue(6).ToString();
                    TxtAddress.Text = dr.GetValue(7).ToString();

                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Record not found .... try again','error')", true);

            }
            dbcon.CloseCon();
        }



        private void UpdateMemberStatus(string varStatus)
        {
            if (CheckMemberExist())
            {
                dbcon.OpenCon();
                cmd = new SqlCommand("spUpdateMemberStatusByID", dbcon.GetCon());
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", TxtMemberID.Text.Trim());
                cmd.Parameters.AddWithValue("@qrType", varStatus);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Member Status updated','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Record not updated .... try again','error')", true);

                }
                dbcon.CloseCon();
                BindGridView();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Record not found .... try again','error')", true);

            }
        }

        private bool CheckMemberExist()
        {
            dbcon.OpenCon();
            cmd = new SqlCommand("sp_getMemberByID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", TxtMemberID.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dbcon.CloseCon();
            if (dt.Rows.Count >= 1)
                return true;
            else
                return false;
        }

        protected void btnActiveMember_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UpdateMemberStatus("Active");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Validation error .... try again','error')", true);

            }

        }
        protected void btnPendingMember_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UpdateMemberStatus("Pending");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Validation error .... try again','error')", true);

            }
        }

        protected void btnDeactiveMember_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UpdateMemberStatus("Deactive");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Validation error .... try again','error')", true);

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.PageIndex = e.NewEditIndex;
            BindGridView();
        }



        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Label mid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDisplayID");
            int ID = Convert.ToInt32(mid.Text);


            TextBox updatetxtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditName");
            TextBox updatetxtdob = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditdob");
            TextBox updatetxtcontact = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditContact");
            TextBox updatetxtemail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditEmail");
            DropDownList updateddlstate = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlEditState");
            TextBox updatetxtcity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditCity");
            TextBox updatetxtpincode = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditpincode");
            TextBox updatetxtaddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditaddress");

            cmd = new SqlCommand("sp_UpdateMember_AllRecords", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@full_name",updatetxtName.Text);
            cmd.Parameters.AddWithValue("@dob", updatetxtdob.Text);
            cmd.Parameters.AddWithValue("@contact_no", updatetxtcontact.Text);
            cmd.Parameters.AddWithValue("@email", updatetxtemail.Text);
            cmd.Parameters.AddWithValue("@state", updateddlstate.Text);
            cmd.Parameters.AddWithValue("@city", updatetxtcity.Text);
            cmd.Parameters.AddWithValue("@pincode", updatetxtpincode.Text);
            cmd.Parameters.AddWithValue("@full_address", updatetxtaddress.Text);
            cmd.Parameters.AddWithValue("@member_id", ID);
            dbcon.OpenCon();
            cmd.ExecuteNonQuery();
            dbcon.CloseCon();
            GridView1.EditIndex = -1;
            BindGridView();

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label mid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDisplayID");
            int ID = Convert.ToInt32(mid.Text);
                
            cmd = new SqlCommand("sp_DeleteMember", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();           
            cmd.Parameters.AddWithValue("@member_id", ID);
            dbcon.OpenCon();
            cmd.ExecuteNonQuery();
            dbcon.CloseCon();
            BindGridView();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlEditState_value = (DropDownList)e.Row.FindControl("ddlEditState");
                Label lblstate = (Label)e.Row.FindControl("lblEditState");
                ddlEditState_value.SelectedValue = lblstate.Text;
            }
        }
    }
}