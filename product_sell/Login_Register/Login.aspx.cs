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
                // Sử dụng ScriptManager để hiển thị alert mà không reload trang
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showalert", "alert('Vui lòng nhập tên đăng nhập và mật khẩu.');", true);
                return;
            }
            // kết nối database
            string sqlCon = "Data Source=LAPTOP-H87TDBVU\\VIETBACH;Initial Catalog=Shopping;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT role FROM Customer WHERE (email = @username OR phone_number = @username) AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string role = result.ToString();
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
