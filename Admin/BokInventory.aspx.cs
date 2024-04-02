using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_Project.Admin
{
    public partial class BokInventory : System.Web.UI.Page
    {
        DBConnect dbcon = new DBConnect();
        SqlCommand cmd;
        static int actual_stock, current_stock, issued_book;
        static string filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Autogenerate();
                Bind_Author_Publisher();
                BindGridData();
            }

        }

        private void Bind_Author_Publisher()
        {
            cmd = new SqlCommand("spGetAuthor", dbcon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            ddlAuthor.DataSource = dbcon.Load_Data(cmd);
            ddlAuthor.DataTextField = "author_name";
            ddlAuthor.DataBind();
            ddlAuthor.Items.Insert(0, new ListItem("-- Select --"));

            cmd = new SqlCommand("sp_getPublisher", dbcon.GetCon());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            ddlPublisherName.DataSource = dbcon.Load_Data(cmd);
            ddlPublisherName.DataTextField = "membar_name";
            ddlPublisherName.DataBind();
            ddlPublisherName.Items.Insert(0, new ListItem("-- Select --"));

        }


        // Add button
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkDuplicateBook())
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Book already Exists','error')", true);

            }
            else
            {
                AddBooks();
                BindGridData();
            }
        }

        private bool checkDuplicateBook()
        {
            cmd = new SqlCommand("sp_getBookID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", TxtBookID.Text);
            DataTable dt2 = new DataTable();
            dt2 = dbcon.Load_Data(cmd);
            if (dt2.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddParameter()
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", TxtBookID.Text);
            cmd.Parameters.AddWithValue("@book_name", txtBookName.Text);
            cmd.Parameters.AddWithValue("@author_name", ddlAuthor.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publish_name", ddlPublisherName.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publish_date", TxtPublishDate.Text);
            cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@edition", TxtEdition.Text);
            cmd.Parameters.AddWithValue("@book_cost", txtBookCost.Text);
            cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text);
            cmd.Parameters.AddWithValue("@book_description", txtBookDesc.Text);
            cmd.Parameters.AddWithValue("@actual_stock", txtActualStock.Text);
            cmd.Parameters.AddWithValue("@current_stock", txtActualStock.Text);
        }


        private void AddBooks()
        {
            // listing genre in a array [genre1,genre2]
            string genres = "";
            foreach (int i in ListBoxGenre.GetSelectedIndices())
            {
                genres = genres + ListBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);

            // storing book img and saving the image of the book in specified folder
            string filepath = "~/book_img/";
            string filename = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/book_img" + filename));
            filepath = "~/book_img/" + filename;


            cmd = new SqlCommand("sp_Insert_Up_Del_bookInventory", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            AddParameter();
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            cmd.Parameters.AddWithValue("@genre", genres);
            cmd.Parameters.AddWithValue("@book_img_link", filepath);



            if (dbcon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Added Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record not Inserted ','error')", true);

            }
            ClearControl();
            Autogenerate();
        }


        // update btn 
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkDuplicateBook())
            {
                UpdateBooks();
                BindGridData();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record not Inserted ','error')", true);
            }
        }

        private void UpdateBooks()
        {

            int A_stock = Convert.ToInt32(txtActualStock.Text.Trim());
            int C_stock = Convert.ToInt32(txtCurrentStock.Text.Trim());
            if (actual_stock == A_stock )
            {

            }
            else
            {
                if(A_stock < actual_stock)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Actual stock value cannot be less than issued books','error')", true);

                }
                else
                {
                    current_stock = actual_stock - issued_book;
                    txtCurrentStock.Text = C_stock + "";
                }
            }


            // listing genre in a array [genre1,genre2]
            string genres = "";
            foreach (int i in ListBoxGenre.GetSelectedIndices())
            {
                genres = genres + ListBoxGenre.Items[i] + ",";
            }
            genres = genres.Remove(genres.Length - 1);


            // storing book img and saving the image of the book in specified folder
            string f_path = "~/book_img/book.jpg";
            string filename = Path.GetFileName(FileUpload1.FileName);
            if (filename == "" || filename==null )
            {
                f_path = filepath;
            }
            else
            {
                FileUpload1.SaveAs(Server.MapPath("~/book_img/" + filename));
                f_path = "~/book_img/" + filename;

            }

            cmd = new SqlCommand("sp_Insert_Up_Del_bookInventory", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            //AddParameter();
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            cmd.Parameters.AddWithValue("@book_id", TxtBookID.Text);
            cmd.Parameters.AddWithValue("@book_name", txtBookName.Text);
            cmd.Parameters.AddWithValue("@author_name", ddlAuthor.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publish_name", ddlPublisherName.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@publish_date", TxtPublishDate.Text);
            cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@edition", TxtEdition.Text);
            cmd.Parameters.AddWithValue("@book_cost", txtBookCost.Text);
            cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text);
            cmd.Parameters.AddWithValue("@book_description", txtBookDesc.Text);
            cmd.Parameters.AddWithValue("@genre", genres);
            cmd.Parameters.AddWithValue("@actual_stock", A_stock.ToString());
            cmd.Parameters.AddWithValue("@current_stock", C_stock.ToString());
            cmd.Parameters.AddWithValue("@book_img_link", f_path);
            if (dbcon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Books Updated Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record not Inserted ','error')", true);

            }
            ClearControl();
            Autogenerate();


        }
        
        
        // delete btn
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkDuplicateBook())
            {
                DeleteBooks();
                BindGridData();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record not Inserted ','error')", true);

            }
        }

        private void DeleteBooks()
        {
            cmd = new SqlCommand("sp_Insert_Up_Del_bookInventory", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            //AddParameter();
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            cmd.Parameters.AddWithValue("@book_id", TxtBookID.Text.Trim());
            if (dbcon.InsertUpdateData(cmd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success','Book Deleted Succesfully','success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record not Inserted ','error')", true);

            }
            ClearControl();
            Autogenerate();

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }


        //---------------------------------------------------------------------------
        public void SearchBooks() 
        {
            cmd = new SqlCommand("sp_getBookID", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@book_id", TxtBookID.Text);
            DataTable dt2 = new DataTable();
            dt2 = dbcon.Load_Data(cmd);
            if(dt2.Rows.Count >=1 ) 
            {
                txtBookName.Text = dt2.Rows[0]["book_name"].ToString();
                TxtPublishDate.Text = dt2.Rows[0]["publisher_date"].ToString();
                TxtEdition.Text = dt2.Rows[0]["edition"].ToString();
                txtBookCost.Text = dt2.Rows[0]["book_cost"].ToString().Trim();
                txtPages.Text = dt2.Rows[0]["no_of_pages"].ToString().Trim();
                txtActualStock.Text = dt2.Rows[0]["actual_stock"].ToString().Trim();
                txtCurrentStock.Text = dt2.Rows[0]["current_stock"].ToString().Trim();
                txtBookDesc.Text = dt2.Rows[0]["book_description"].ToString();
                txtIssuedBooks.Text = "" + (Convert.ToInt32(dt2.Rows[0]["actual_stock"].ToString()) - (Convert.ToInt32(dt2.Rows[0]["current_stock"].ToString())));

                ddlLanguage.SelectedValue = dt2.Rows[0]["language"].ToString().Trim();
                ddlPublisherName.SelectedValue = dt2.Rows[0]["publisher_name"].ToString();
                ddlAuthor.SelectedValue = dt2.Rows[0]["author_name"].ToString().Trim();

                ListBoxGenre.ClearSelection();
                string[] genre = dt2.Rows[0]["genre"].ToString().Trim().Split(',');
                for(int i =0; i < genre.Length; i++)
                {
                    for(int j =0; j < ListBoxGenre.Items.Count; j++)
                    {
                        if (ListBoxGenre.Items[j].ToString() == genre[i].ToString())
                        {
                            ListBoxGenre.Items[j].Selected = true;
                        }
                    }
                }
                actual_stock = Convert.ToInt32(dt2.Rows[0]["actual_stock"].ToString().Trim());
                current_stock = Convert.ToInt32(dt2.Rows[0]["current_stock"].ToString().Trim());
                actual_stock = actual_stock - current_stock;
                filepath = dt2.Rows[0]["book_img_link"].ToString();
                if(filepath!="" || filepath!=null)
                {
                    ImgPhoto.ImageUrl = filepath;
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error','Error! Record not Inserted ','error')", true);
                ClearControl();
            }
        }


        public void Autogenerate()
        {
            int r;
            dbcon.OpenCon();
            cmd = new SqlCommand("select max(book_id) as ID from book_master_tbl", dbcon.GetCon());
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    TxtBookID.Text = "1";
                }
                else
                {
                    r = Convert.ToInt32(dr[0].ToString());
                    r = r + 1;
                    TxtBookID.Text = r.ToString();
                }
                
            }
            dbcon.CloseCon();

        }
        private void ClearControl()
        {
            txtBookName.Text = txtActualStock.Text = txtBookCost.Text = txtBookDesc.Text = txtCurrentStock.Text = TxtEdition.Text = TxtPublishDate.Text =txtPages.Text = string.Empty;
            ddlAuthor.SelectedIndex = -1;
            ddlPublisherName.SelectedIndex = -1;
            FileUpload1.PostedFile.InputStream.Dispose();
            ImgPhoto.ImageUrl = "../book_img/book.jpg";
        }

        private void BindGridData()
        {

            cmd = new SqlCommand("sp_Insert_Up_Del_bookInventory", dbcon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            GridView1.DataSource = dbcon.Load_Data(cmd);
            GridView1.DataBind();
        }

    }
}