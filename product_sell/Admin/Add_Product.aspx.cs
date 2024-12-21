using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class Add_Product : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dddm.DataSource = data.Category();
                dddm.DataTextField = "name";
                dddm.DataValueField = "category_id";
                DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.SKU = txtSKU.Text;
                p.description = txtdescription.Text;
                p.price = decimal.Parse(txtprice.Text);
                p.stock = int.Parse(txtstock.Text);
                //  p.Category_catego = int.Parse(txtCategory_catego.Text);
                p.Category_catego = int.Parse(dddm.SelectedValue);
                p.image = txtimage.Text;
                data.ThemSP(p);
                mg.Text = "Thêm thành công";
            }
            catch (Exception e1)
            {
                mg.Text = "Có lỗi khi thêm sản phẩm: " + e1.Message;
            }
        }
    }
}