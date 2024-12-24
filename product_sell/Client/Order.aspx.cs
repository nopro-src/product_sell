using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace product_sell.Client
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            if (Session["SelectedProducts"] == null)
            {
                lblOrderSuccess.Text = "Không có sản phẩm nào được chọn.";
                return;
            }

            List<Dictionary<string, object>> selectedProducts = Session["SelectedProducts"] as List<Dictionary<string, object>>;

            if (selectedProducts == null || selectedProducts.Count == 0)
            {
                lblOrderSuccess.Text = "Không có sản phẩm nào được chọn.";
                return;
            }

            string connectionString = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Tạo bảng tạm để lưu danh sách sản phẩm đã chọn
                dt.Columns.Add("ProductId", typeof(int));
                dt.Columns.Add("Quantity", typeof(int));

                foreach (var product in selectedProducts)
                {
                    DataRow row = dt.NewRow();
                    row["ProductId"] = product["ProductId"];
                    row["Quantity"] = product["Quantity"];
                    dt.Rows.Add(row);
                }

                // Truy vấn sản phẩm từ cơ sở dữ liệu dựa trên danh sách đã chọn
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                SELECT p.product_id, p.image, p.description, t.Quantity, p.price, (p.price * t.Quantity) AS TotalPrice
                FROM Product p
                JOIN @SelectedProducts t ON p.product_id = t.ProductId";

                    SqlParameter param = cmd.Parameters.AddWithValue("@SelectedProducts", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.SelectedProductType"; // Bạn cần tạo kiểu bảng trong SQL Server

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        OrderRepeater.DataSource = reader;
                        OrderRepeater.DataBind();
                    }
                }
            }
        }


        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string address = txtAddress.Text.Trim();
            string paymentMethod = ddlPaymentMethod.SelectedValue;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address))
            {
                lblOrderSuccess.Text = "<span style='color:red;'>Vui lòng điền đầy đủ thông tin!</span>";
                return;
            }

            List<Dictionary<string, object>> selectedProducts = Session["SelectedProducts"] as List<Dictionary<string, object>>;
            if (selectedProducts == null || selectedProducts.Count == 0)
            {
                lblOrderSuccess.Text = "<span style='color:red;'>Không có sản phẩm nào được chọn!</span>";
                return;
            }

            string connectionString = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";
            decimal totalAmount = 0;
            int paymentId = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Tính tổng tiền từ danh sách sản phẩm đã chọn
                foreach (var product in selectedProducts)
                {
                    int productId = Convert.ToInt32(product["ProductId"]);
                    int quantity = Convert.ToInt32(product["Quantity"]);

                    string query = "SELECT price FROM Product WHERE product_id = @ProductId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        decimal price = Convert.ToDecimal(cmd.ExecuteScalar());
                        totalAmount += price * quantity;
                    }
                }

                // Lấy Payment ID theo phương thức thanh toán
                string getPaymentIdQuery = @"SELECT payment_id 
                                     FROM Payment 
                                     WHERE Customer_custome = @UserId AND payment_method = @PaymentMethod";
                using (SqlCommand cmd = new SqlCommand(getPaymentIdQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    object result = cmd.ExecuteScalar();
                    paymentId = result != null ? Convert.ToInt32(result) : 0;
                }

                if (paymentId == 0)
                {
                    lblOrderSuccess.Text = "<span style='color:red;'>Không tìm thấy phương thức thanh toán!</span>";
                    return;
                }

                // Tạo đơn hàng (Order)
                string insertOrderQuery = @"INSERT INTO [Order] (order_date, total_price, status, Customer_custo, Payment_payme, Shipment_shipm)
                                    VALUES (GETDATE(), @TotalPrice, 'processing', @CustomerId, @PaymentId, 1);
                                    SELECT SCOPE_IDENTITY();";

                int orderId;
                using (SqlCommand cmd = new SqlCommand(insertOrderQuery, con))
                {
                    cmd.Parameters.AddWithValue("@TotalPrice", totalAmount);
                    cmd.Parameters.AddWithValue("@CustomerId", userId);
                    cmd.Parameters.AddWithValue("@PaymentId", paymentId);
                    orderId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Thêm các sản phẩm vào Order_Item (Price calculated in SQL)
                string insertOrderItemQuery = @"
            INSERT INTO Order_Item (quantity, price, Product_produ, Order_order_i)
            SELECT @Quantity, p.price, p.product_id, @OrderId
            FROM Product p
            WHERE p.product_id = @ProductId";

                foreach (var product in selectedProducts)
                {
                    using (SqlCommand cmd = new SqlCommand(insertOrderItemQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", product["Quantity"]);
                        cmd.Parameters.AddWithValue("@ProductId", product["ProductId"]);
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Xóa sản phẩm được chọn khỏi giỏ hàng
                string deleteCartQuery = @"DELETE FROM Cart WHERE Customer_customer_id = @UserId AND Product_product_id = @ProductId";
                foreach (var product in selectedProducts)
                {
                    using (SqlCommand cmd = new SqlCommand(deleteCartQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ProductId", product["ProductId"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Hiển thị thông báo và tổng tiền
            lblTotalAmount.Text = $"<h3>Tổng tiền: {totalAmount:C}</h3>";
            lblOrderSuccess.Text = "<span style='color:green;'>Đặt hàng thành công!</span>";
            // Xóa sản phẩm đã chọn khỏi Session
            Session["SelectedProducts"] = null;
        }


        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Client/Home.aspx"); // Điều chỉnh đường dẫn trang chủ
        }

    }
}
