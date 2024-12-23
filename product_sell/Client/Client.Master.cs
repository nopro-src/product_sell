using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Client
{
    public partial class Client : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItemCount();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim(); // Lấy nội dung tìm kiếm
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Chuyển hướng tới Home.aspx với từ khóa tìm kiếm
                Response.Redirect($"~/Client/Home.aspx?search={Server.UrlEncode(searchQuery)}");
            }
        }
        private void LoadCartItemCount()
        {
            // Kiểm tra nếu khách hàng đã đăng nhập
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                string connectionString = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"
                            SELECT COUNT(*) FROM Cart 
                                WHERE Customer_customer_id = (
                                    SELECT customer_id 
                                    FROM Customer 
                                    WHERE email = @username OR phone_number = @username
                         )";


                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            int itemCount = Convert.ToInt32(cmd.ExecuteScalar());

                            // Hiển thị số lượng sản phẩm trong giỏ hàng
                            CartItemCount.Text = itemCount.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    CartItemCount.Text = "0";
                }
            }
            else
            {
                // Nếu chưa đăng nhập, hiển thị 0
                CartItemCount.Text = "0";
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Xóa tất cả session
            Session.Clear();
            Session.Abandon();

            // Chuyển hướng về trang đăng nhập
            Response.Redirect("~/Login_Register/Login.aspx");
        }


    }
}