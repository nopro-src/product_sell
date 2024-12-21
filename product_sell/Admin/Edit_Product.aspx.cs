using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class Edit_Product : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Product p = (Product)Session["sp"];
                txtproduct_id.Text = p.product_id.ToString();
                txtSKU.Text = p.SKU;
                txtdescription.Text = p.description;
                txtprice.Text = p.price.ToString();
                txtstock.Text = p.stock.ToString();
                txtimage.Text = p.image;
                dddm.DataSource = data.Category();
                dddm.DataTextField = "name";
                dddm.DataValueField = "category_id";
                DataBind();
                dddm.SelectedValue = p.Category_catego.ToString();
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.product_id = int.Parse(txtproduct_id.Text);
                p.SKU = txtSKU.Text;
                p.description = txtdescription.Text;
                p.price = decimal.Parse(txtprice.Text);
                p.stock = int.Parse(txtstock.Text);
                p.Category_catego = int.Parse(dddm.SelectedValue);
                p.image = txtimage.Text;
                data.CapnhatSP(p);
                mg.Text = "Cập nhật thành công";
            }
            catch (Exception ex)
            {
                mg.Text = "Có lỗi: " + ex;
            }
        }
    }
}