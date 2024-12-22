using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class ManageAccounts : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }
        private void Display()
        {
            grid.DataSource = data.Account();
            DataBind();
        }
        protected void Xoa_click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                data.Xoa(m);
                Display();
            }
        }
        protected void Sua_click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int m = Convert.ToInt32(e.CommandArgument);
                Account s = data.LayAC(m);
                Session["ac"] = s;
                Response.Redirect("Update_Account.aspx");
            }
        }

    }
}