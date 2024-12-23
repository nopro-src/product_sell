using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                HienThi();
        }

        private void HienThi()
        {
            grdDs.DataSource = data.Product();
            DataBind();
        }

        protected void Delete_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                data.XoaSP(m);
                HienThi();
            }
        }

        protected void Edit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Product p = data.Layra1SP(m);
                Session["sp"] = p;
                Response.Redirect("Edit_Product.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keywordId = txtSearchById.Text.Trim();
            string keywordDesc = txtSearchByDescription.Text.Trim();

            if (!string.IsNullOrEmpty(keywordId))
            {
                if (int.TryParse(keywordId, out int productId))
                {
                    grdDs.DataSource = data.TimKiemTheoMa(productId);
                    grdDs.DataBind();
                }
                else
                {
                    // Hiển thị thông báo lỗi nếu mã không phải số
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mã sản phẩm phải là số!');", true);
                }
            }
            else if (!string.IsNullOrEmpty(keywordDesc))
            {
                grdDs.DataSource = data.TimKiemTheoMoTa(keywordDesc);
                grdDs.DataBind();
            }
            else
            {
                HienThi(); // Hiển thị toàn bộ sản phẩm nếu không nhập gì
            }
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchById.Text = "";
            txtSearchByDescription.Text = "";
            HienThi(); // Hiển thị lại danh sách sản phẩm
        }

    }
}
