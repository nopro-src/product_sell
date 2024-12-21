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
            if(!IsPostBack)
                HienThi();
        }

        private void HienThi()
        {
            grdDs.DataSource = data.Product();
            DataBind();
        }
        protected void Delete_Click(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "xoa")
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
    }
}