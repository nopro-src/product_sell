using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Khai báo đối tượng DataUtil để sử dụng các phương thức lấy dữ liệu
        DataUtil data = new DataUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalesReport();  // Tải báo cáo bán hàng
                LoadPurchaseHistory(); // Tải lịch sử mua hàng
                LoadTopSellingProducts(); // Tải top sản phẩm bán chạy
                LoadTotalRevenue(); // Tải tổng doanh thu
            }
        }

        private void LoadSalesReport()
        {
            try
            {
                DataTable dt = data.GetSalesReport();
                gvSalesReport.DataSource = dt;
                gvSalesReport.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi không thể tải báo cáo bán hàng
                Response.Write($"<script>alert('Có lỗi xảy ra khi tải báo cáo bán hàng: {ex.Message}');</script>");
            }
        }

        private void LoadPurchaseHistory()
        {
            try
            {
                DataTable dt = data.GetPurchaseHistory();
                gvPurchaseHistory.DataSource = dt;
                gvPurchaseHistory.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi không thể tải lịch sử mua hàng
                Response.Write($"<script>alert('Có lỗi xảy ra khi tải lịch sử mua hàng: {ex.Message}');</script>");
            }
        }

        private void LoadTopSellingProducts()
        {
            try
            {
                DataTable dt = data.GetTopSellingProducts();
                gvTopSellingProducts.DataSource = dt;
                gvTopSellingProducts.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi không thể tải top bán chạy
                Response.Write($"<script>alert('Có lỗi xảy ra khi tải top bán chạy: {ex.Message}');</script>");
            }
        }

        private void LoadTotalRevenue()
        {
            try
            {
                // Gọi phương thức tính tổng doanh thu
                decimal totalRevenue = data.GetTotalRevenue();
                lblTotalRevenue.Text = "Tổng doanh thu: " + totalRevenue.ToString("C"); // Hiển thị tổng doanh thu trên Label
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi không thể tải tổng doanh thu
                Response.Write($"<script>alert('Có lỗi xảy ra khi tải tổng doanh thu: {ex.Message}');</script>");
            }
        }

        // Xử lý các sự kiện RowDataBound nếu cần thiết
        protected void gvTopSellingProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Có thể thêm xử lý thêm khi dữ liệu được bind vào GridView
            }
        }
    }
}
