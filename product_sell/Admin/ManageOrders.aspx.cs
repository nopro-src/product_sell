using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class ManageOrders : Page
    {
        private readonly string connectionString = "Data Source=NOPRO\\TRUNGKIEN;Initial Catalog=Shopping;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders(string fromDate = null, string toDate = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT 
                        o.order_id,
                        o.order_date,
                        SUM(oi.quantity * oi.price) AS total_price,
                        o.Customer_custo AS customer_id,
                        c.phone_number,
                        c.email,
                        o.Payment_payme AS payment_id,
                        o.Shipment_shipm AS shipment_id,
                        o.status
                    FROM [Order] o
                    JOIN Customer c ON o.Customer_custo = c.customer_id
                    JOIN Order_Item oi ON o.order_id = oi.Order_order_i
                    WHERE 1=1";

                if (!string.IsNullOrEmpty(fromDate))
                {
                    sql += " AND o.order_date >= @fromDate";
                }

                if (!string.IsNullOrEmpty(toDate))
                {
                    sql += " AND o.order_date <= @toDate";
                }

                sql += @"
                    GROUP BY 
                        o.order_id, o.order_date, o.Customer_custo, c.phone_number, c.email, o.Payment_payme, o.Shipment_shipm, o.status
                    ORDER BY o.order_date DESC";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (!string.IsNullOrEmpty(fromDate))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    }

                    if (!string.IsNullOrEmpty(toDate))
                    {
                        cmd.Parameters.AddWithValue("@toDate", toDate);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdDs.DataSource = dt;
                    grdDs.DataBind();
                }
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string fromDate = txtFromDate.Text;
            string toDate = txtToDate.Text;

            if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                LoadOrders(fromDate, toDate);
            }
            else
            {
                LoadOrders(); // Nếu không nhập ngày, tải toàn bộ đơn hàng
            }
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
            LoadOrders(); // Xóa lọc và tải toàn bộ đơn hàng
        }

        protected void grdDs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChangeStatus")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Get current status
                    string sql = "SELECT status FROM [Order] WHERE order_id = @orderId";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    con.Open();
                    string currentStatus = cmd.ExecuteScalar().ToString();
                    con.Close();

                    // Toggle status
                    string newStatus = (currentStatus == "processing") ? "success" : "processing";

                    // Update new status
                    sql = "UPDATE [Order] SET status = @status WHERE order_id = @orderId";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                // Reload orders
                LoadOrders();
            }
        }
    }
}
