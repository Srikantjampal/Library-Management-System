using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_Project.Admin
{
    public partial class BookIssueReturn : System.Web.UI.Page
    {
        DBConnect dbcon = new DBConnect();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGridData();
            }
        }

        private void BindGridData()
        {

            cmd = new SqlCommand("sp_getIssueBook", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@StatementType", "Select");
            GridView1.DataSource = dbcon.Load_Data(cmd);
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                GetMemName();
                GetBookName();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Enter Valid Member Id and Book ID','error')", true);

            }
        }

        private void GetBookName()
        {
            cmd = new SqlCommand("sp_getBook_ByID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@StatementType", "SelectByID");
            cmd.Parameters.AddWithValue("@id", txtBookID.Text.Trim());
            DataTable dt = dbcon.Load_Data(cmd);
            if (dt.Rows.Count >= 1)
            {
                txtBookName.Text = dt.Rows[0]["book_name"].ToString();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','wrong book id','error')", true);

            }
        }

        private void GetMemName()
        {
            cmd = new SqlCommand("sp_getMember_ByID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@id", txtMemID.Text.Trim());
            DataTable dt = dbcon.Load_Data(cmd);
            if (dt.Rows.Count >= 1)
            {
                txtMemName.Text = dt.Rows[0]["full_name"].ToString();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','wrong member id','error')", true);

            }
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if (isBookExist() && isMemberExist())
            {
                if (isIssueEntryExist())
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('success','Member has already issues the book','success')", true);

                }
                else
                {
                    issueBook();
                    BindGridData();
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Enter Valid Member Id and Book ID','error')", true);
            }
        }

        private void issueBook()
        {
            cmd = new SqlCommand("sp_InsertBookIssue", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtMemID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_name", txtMemName.Text.Trim());
            cmd.Parameters.AddWithValue("@book_name", txtBookName.Text.Trim());
            cmd.Parameters.AddWithValue("@issue_date", txtIssueDate.Text.Trim());
            cmd.Parameters.AddWithValue("@due_date", txtDueDate.Text.Trim());
            if (dbcon.InsertUpdateData(cmd))
            {
                updateBookStock();

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Book not Issued ','error')", true);

            }

        }

        private void updateBookStock()
        {
            cmd = new SqlCommand("sp_UpdateBookIssueStock", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());

            if (dbcon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Issued Succesfully','success')", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Stock not IUpdated ','error')", true);
            }

        }

        private bool isIssueEntryExist()
        {
            cmd = new SqlCommand("sp_checkIssueExist", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@bid", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@mid", txtMemID.Text.Trim());
            DataTable dt = dbcon.Load_Data(cmd);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isBookExist()
        {
            cmd = new SqlCommand("sp_checkBookstockExist", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            DataTable dt = dbcon.Load_Data(cmd);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool isMemberExist()
        {
            cmd = new SqlCommand("sp_getMember_ByID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", txtMemID.Text.Trim());
            DataTable dt = dbcon.Load_Data(cmd);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (isBookExist() && isMemberExist())
            {
                if (isIssueEntryExist())
                {
                    if (CheckFine())
                    {
                        ReturnBook();
                        BindGridData();
                    }
                    else
                    {
                        //RepeatDirection to fine page
                        Response.Redirect("BookFine.aspx?bid="+txtBookID.Text + "&mid="+txtMemID.Text+ "&day="+ Session["day"].ToString());
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Member has already returned the book','error')", true);
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Enter Valid Member Id and Book ID','error')", true);
            }
        }

        private void ReturnBook()
        {
            cmd = new SqlCommand("sp_ReturnBook", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtMemID.Text.Trim());
            if (dbcon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('success','Book returned Successfully','success')", true);


            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Book not Issued ','error')", true);

            }
        }

        protected void txtDueDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if(today > dt)
                    {
                        e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        private bool CheckFine()
        {
            int days;
            cmd = new SqlCommand("sp_getNumOfDay", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", txtMemID.Text.Trim());
            DataTable dt = dbcon.Load_Data(cmd);
            if(dt.Rows.Count > 0)
            {
                days = Convert.ToInt32(dt.Rows[0]["Number_of_day"].ToString());
                Session["day"] = days;
                if(days <= 0)                
                    return true;            
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}