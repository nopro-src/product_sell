using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Admin
{
    public partial class Update_Account : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy thông tin tài khoản từ Session
                Account s = (Account)Session["ac"];
                if (s == null)
                {
                    Response.Redirect("~/Login.aspx"); // Chuyển hướng nếu Session hết hạn
                    return;
                }

                // Gán dữ liệu vào các textbox
                customer_id.Text = s.customer_id.ToString();
                first_name.Text = s.first_name;
                last_name.Text = s.last_name;
                email.Text = s.email;
                password.Text = s.password;
                address.Text = s.address;
                phone_number.Text = s.phone_number;

                // Cấu hình DropDownList
                sl_role.Items.Clear();
                sl_role.Items.Add(new ListItem("Customer", "Customer"));
                sl_role.Items.Add(new ListItem("Admin", "Admin"));
                sl_role.SelectedValue = s.role;
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin tài khoản hiện tại từ Session
                Account currentAccount = (Account)Session["ac"];
                //if (currentAccount == null)
                //{
                //    msg.Text = "Phiên làm việc đã hết hạn. Vui lòng đăng nhập lại!";
                //    return;
                //}

                // Validate dữ liệu đầu vào
                string validationMessage = ValidateInput();
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    msg.Text = validationMessage;
                    return;
                }

                // Kiểm tra trùng lặp email (ngoại trừ email hiện tại)
                if (email.Text != currentAccount.email && data.IsEmailExists(email.Text))
                {
                    msg.Text = "Email đã tồn tại trong hệ thống!";
                    return;
                }

                // Kiểm tra trùng lặp số điện thoại (ngoại trừ số điện thoại hiện tại)
                if (phone_number.Text != currentAccount.phone_number && data.IsPhoneNumberExists(phone_number.Text))
                {
                    msg.Text = "Số điện thoại đã tồn tại trong hệ thống!";
                    return;
                }

                // Cập nhật thông tin tài khoản
                Account updatedAccount = new Account
                {
                    customer_id = int.Parse(customer_id.Text),
                    first_name = first_name.Text,
                    last_name = last_name.Text,
                    email = email.Text,
                    password = password.Text,
                    address = address.Text,
                    phone_number = phone_number.Text,
                    role = sl_role.SelectedValue
                };

                data.Update(updatedAccount);
                msg.ForeColor = System.Drawing.Color.Green;
                msg.Text = "Cập nhật tài khoản thành công!";
            }
            catch (Exception ex)
            {
                msg.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }

        private string ValidateInput()
        {
            // Validate Email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email.Text, emailPattern))
                return "Email không hợp lệ!";

            // Validate Password: Tối thiểu 8 ký tự, bao gồm ít nhất 1 chữ hoa, 1 chữ thường và 1 số
            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$";
            if (!Regex.IsMatch(password.Text, passwordPattern))
                return "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ cái, số và ký tự đặc biệt.";

            // Validate Phone Number: Chỉ chấp nhận số, dài từ 10-15 ký tự
            string phonePattern = @"^\d{10,15}$";
            if (!Regex.IsMatch(phone_number.Text, phonePattern))
                return "Số điện thoại không hợp lệ!";

            // Validate First Name và Last Name: Không rỗng
            if (string.IsNullOrWhiteSpace(first_name.Text) || string.IsNullOrWhiteSpace(last_name.Text))
                return "Họ và tên không được để trống!";

            return null; // Không có lỗi
        }

    }
}
