using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class ManageOders : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            grdDs.DataSource = data.Order();
            DataBind();
        }

        protected void Edit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Order p = data.Layra1DH(m);
                Session["od"] = p;
                Response.Redirect("EditOrder.aspx");


            }
        }
    }
}