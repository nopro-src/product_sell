using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Client
{
    public partial class Giay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null && Session["UserRole"] != null)
                {
                    //string username = Session["Username"].ToString();
                    //lblWelcome.Text = $"Xin chào, {username}!";
                    LoadProducts();

                    // Kiểm tra nếu có thông báo thêm giỏ hàng thành công
                    if (Session["CartSuccess"] != null && (bool)Session["CartSuccess"])
                    {
                        Session["CartSuccess"] = null; // Xóa cờ sau khi sử dụng
                        ScriptManager.RegisterStartupScript(this, GetType(), "CartSuccessAlert",
                            "alert('Sản phẩm đã được thêm vào giỏ hàng thành công!');", true);
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        private void LoadProducts()
        {
            string connectionString = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";
            string searchQuery = Request.QueryString["search"]; // Lấy từ khóa tìm kiếm từ URL

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;

                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        // Search query with additional filtering
                        query = "SELECT product_id, SKU, description, price, stock, image " +
                                                        "FROM Product " +
                                                        "WHERE description LIKE @search OR SKU LIKE @search";
                    }
                    else
                    {
                        // Default query for the "Áo" category
                        query = @"SELECT p.product_id, p.SKU, p.description, p.price, p.stock, p.image 
                    FROM Product p
                    JOIN Category c ON p.Category_catego = c.category_id
                    WHERE c.name = N'Giày'";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@search", "%" + searchQuery + "%");
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Check if no products are found
                    if (dt.Rows.Count == 0)
                    {
                        NoProductMessage.Text = "<p style='color: red; text-align: center;'>Không tìm thấy sản phẩm nào phù hợp.</p>";
                    }
                    else
                    {
                        NoProductMessage.Text = ""; // Clear the message if products are found
                    }

                    // Bind the data to the Repeater
                    ProductRepeater.DataSource = dt;
                    ProductRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Error: {ex.Message}");
            }
        }
        protected void AddToCart_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int productId = int.Parse(button.CommandArgument);

            var item = (RepeaterItem)button.NamingContainer;
            var quantityTextBox = (TextBox)item.FindControl("QuantityTextBox");

            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "InvalidQuantity",
                    "alert('Số lượng không hợp lệ. Vui lòng nhập số lượng hợp lệ.');", true);
                return;
            }

            if (Session["UserId"] == null || !int.TryParse(Session["UserId"].ToString(), out int userId))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "NotLoggedIn",
                    "alert('Bạn cần đăng nhập để thêm sản phẩm vào giỏ hàng.');", true);
                return;
            }

            string connectionString = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT quantity FROM Cart WHERE Product_product_id = @productId AND Customer_customer_id = @userId";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@productId", productId);
                    checkCmd.Parameters.AddWithValue("@userId", userId);

                    object result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        int existingQuantity = Convert.ToInt32(result);
                        string updateQuery = "UPDATE Cart SET quantity = @newQuantity WHERE Product_product_id = @productId AND Customer_customer_id = @userId";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@newQuantity", existingQuantity + quantity);
                        updateCmd.Parameters.AddWithValue("@productId", productId);
                        updateCmd.Parameters.AddWithValue("@userId", userId);
                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Cart (Product_product_id, Customer_customer_id, quantity) VALUES (@productId, @userId, @quantity)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@productId", productId);
                        insertCmd.Parameters.AddWithValue("@userId", userId);
                        insertCmd.Parameters.AddWithValue("@quantity", quantity);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                // Đặt cờ trong Session để tránh lặp lại mã sau khi reload
                Session["CartSuccess"] = true;

                // Tải lại trang
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    $"alert('Đã xảy ra lỗi: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }
    }
}