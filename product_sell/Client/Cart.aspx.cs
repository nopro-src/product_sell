using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace product_sell.Client
{
    public partial class Cart : System.Web.UI.Page
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
                            SELECT p.product_id, p.SKU, p.description, p.price, c.quantity, p.image 
                            FROM Cart c
                            JOIN Product p ON c.Product_product_id = p.product_id
                            WHERE c.Customer_customer_id = (
                                SELECT customer_id 
                                FROM Customer 
                                WHERE email = @username OR phone_number = @username
                            )";

                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@username", username);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            CartRepeater.DataSource = dt;
                            CartRepeater.DataBind();
                        }
                        else
                        {
                            CartMessage.Text = "Giỏ hàng của bạn đang trống.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    CartMessage.Text = "Lỗi khi tải giỏ hàng: " + ex.Message;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sản phẩm đã chọn
            List<Dictionary<string, object>> selectedProducts = new List<Dictionary<string, object>>();

            foreach (RepeaterItem item in CartRepeater.Items)
            {
                CheckBox selectProduct = (CheckBox)item.FindControl("SelectProduct");
                if (selectProduct != null && selectProduct.Checked)
                {
                    HiddenField productIdField = (HiddenField)item.FindControl("ProductIdHiddenField");
                    TextBox quantityBox = (TextBox)item.FindControl("QuantityTextBox");

                    if (productIdField != null && quantityBox != null)
                    {
                        int productId = int.Parse(productIdField.Value);
                        int quantity = int.Parse(quantityBox.Text);

                        // Thêm sản phẩm vào danh sách đã chọn
                        selectedProducts.Add(new Dictionary<string, object>
                        {
                            { "ProductId", productId },
                            { "Quantity", quantity }
                        });
                    }
                }
            }

            // Kiểm tra nếu không có sản phẩm nào được chọn
            if (selectedProducts.Count == 0)
            {
                CartMessage.Text = "Vui lòng chọn ít nhất một sản phẩm.";
                return;
            }

            // Lưu danh sách sản phẩm đã chọn vào session
            Session["SelectedProducts"] = selectedProducts;

            // Chuyển hướng đến trang Order
            Response.Redirect("~/Client/Order.aspx");
        }
    }
}
