using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace product_sell.Login_Register
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showalert", "alert('Vui lòng nhập tên đăng nhập và mật khẩu.');", true);
                return;
            }

            string sqlCon = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";
            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT customer_id, role FROM Customer WHERE (email = @username OR phone_number = @username) AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["customer_id"]);
                            string role = reader["role"].ToString();

                            Session["UserId"] = userId;
                            Session["UserRole"] = role;
                            Session["Username"] = username;

                            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("~/Admin/Dashboard.aspx", false);
                            }
                            else if (role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("~/Client/Home.aspx", false);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showalert", "alert('Sai tên đăng nhập hoặc mật khẩu.');", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showalert", $"alert('Lỗi hệ thống: {ex.Message}');", true);
                }
            }
        }
    }
}
