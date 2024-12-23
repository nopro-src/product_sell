using System;
using System.Web.UI;

namespace product_sell.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // Kiểm tra session
                if (Session["Username"] != null && Session["UserRole"] != null)
                {
                    // Hiển thị tên đăng nhập của admin
                    string username = Session["Username"].ToString();
                    lblWelcome.Text = $"Welcome, {username}!";
                }
                else
                {
                    // Nếu không có session, chuyển hướng về trang đăng nhập
                    Response.Redirect("~/Login_Register/Login.aspx", false);
                }
            }
        }
    }
}
