using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class EditOrders : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy thông tin tài khoản từ Session
                Order p = (Order)Session["od"];
                if (p == null)
                {
                    Response.Redirect("~/ManageOrders.aspx"); 
                    return;
                }

                // Gán dữ liệu vào các textbox
                txtorder_id.Text = p.order_id.ToString();

               
                

                    // Cấu hình DropDownList
                    dddm.Items.Clear();
                    dddm.Items.Add(new ListItem("completed", "completed"));
                    dddm.Items.Add(new ListItem("processing", "processing"));
                    dddm.SelectedValue = p.status;
                
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
                Order p = (Order)Session["od"];
              
               

               
                Order CapnhatDH = new Order
                {
                    order_id = int.Parse(txtorder_id.Text),
                   
                    status = dddm.SelectedValue
                };

                data.CapnhatDH(p); 
                mg.Text = "Cập nhật trạng thái đơn hàng thành công!";
            }
            catch (Exception ex)
            {
                mg.Text = "Có lỗi xảy ra: " + ex.Message;
            }

        }
        //     if (!IsPostBack)
        //   {

        // Thêm các mục động vào DropDownList
        //     dddm.Items.Add(new ListItem("completed", "completed"));
        //   dddm.Items.Add(new ListItem("processing", "processing"));
        //}
    }

  
}
