using System;
using System.Data;
using System.Data.SqlClient;

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
                    CartMessage.Text = $"Lỗi: {ex.Message}";
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            // Chuyển đến trang Order.aspx
            Response.Redirect("~/Client/Order.aspx");
        }


    }
}
