using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserData();
                LoadOrderHistory();
            }
        }

        private void LoadUserData()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                string query = "SELECT first_name, last_name, email, address, phone_number FROM Customer WHERE customer_id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["first_name"].ToString();
                        txtLastName.Text = reader["last_name"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtAddress.Text = reader["address"].ToString();
                        txtPhone.Text = reader["phone_number"].ToString();
                    }
                }
            }
        }

        private void LoadOrderHistory()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                string query = @"
                    SELECT 
                        o.order_id AS OrderID, 
                        o.order_date AS OrderDate, 
                        o.total_price AS TotalPrice, 
                        o.status AS Status 
                    FROM [Order] o 
                    WHERE o.Customer_custo = @UserId";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvOrderHistory.DataSource = dt;
                    gvOrderHistory.DataBind();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                string query = "UPDATE Customer SET first_name = @FirstName, last_name = @LastName, address = @Address, phone_number = @Phone WHERE customer_id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    string message = rowsAffected > 0 ? "Cập nhật thông tin thành công!" : "Cập nhật thất bại!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
                }
            }
        }


    }
}