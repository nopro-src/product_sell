using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

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
                Response.Write($"<script>alert('Có lỗi xảy ra khi tải top bán chạy: {ex.Message}');</script>");
            }
        }

        private void LoadTotalRevenue()
        {
            try
            {
                decimal totalRevenue = data.GetTotalRevenue();
                lblTotalRevenue.Text = "Tổng doanh thu: " + totalRevenue.ToString("C");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Có lỗi xảy ra khi tải tổng doanh thu: {ex.Message}');</script>");
            }
        }

        // Phương thức để tải dữ liệu biểu đồ doanh thu
    }
}
