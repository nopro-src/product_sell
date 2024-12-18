using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace product_sell.Admin
{
    public partial class AddAccounts : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Thêm các tùy chọn cho DropDownList
                sl_role.Items.Add(new ListItem("Customer", "Customer"));
                sl_role.Items.Add(new ListItem("Admin", "Admin"));
            }
        }

        protected void btn_add_accounts_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                string firstName = first_name.Text.Trim();
                string lastName = last_name.Text.Trim();
                string emailInput = email.Text.Trim();
                string passwordInput = password.Text.Trim();
                string addressInput = address.Text.Trim();
                string phoneInput = phonenumber.Text.Trim();
                string role = sl_role.SelectedValue;

                // Validate dữ liệu
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                    string.IsNullOrEmpty(emailInput) || string.IsNullOrEmpty(passwordInput) ||
                    string.IsNullOrEmpty(addressInput) || string.IsNullOrEmpty(phoneInput))
                {
                    msg_add_accounts.Text = "Vui lòng điền đầy đủ thông tin.";
                    msg_add_accounts.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Validate email
                if (!Regex.IsMatch(emailInput, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    msg_add_accounts.Text = "Email không đúng định dạng.";
                    msg_add_accounts.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Kiểm tra email đã tồn tại chưa
                if (data.IsEmailExists(emailInput))
                {
                    msg_add_accounts.Text = "Email này đã được sử dụng.";
                    msg_add_accounts.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Validate password
                if (!Regex.IsMatch(passwordInput, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$"))
                {
                    msg_add_accounts.Text = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ cái, số và ký tự đặc biệt.";
                    msg_add_accounts.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Validate phone number
                if (!Regex.IsMatch(phoneInput, @"^[0-9]{9,15}$"))
                {
                    msg_add_accounts.Text = "Số điện thoại không đúng định dạng.";
                    msg_add_accounts.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Kiểm tra số điện thoại đã tồn tại chưa
                if (data.IsPhoneNumberExists(phoneInput))
                {
                    msg_add_accounts.Text = "Số điện thoại này đã được sử dụng.";
                    msg_add_accounts.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Nếu dữ liệu hợp lệ, tạo tài khoản mới
                Account ac = new Account
                {
                    first_name = firstName,
                    last_name = lastName,
                    email = emailInput,
                    password = passwordInput,
                    address = addressInput,
                    phone_number = phoneInput,
                    role = role
                };

                // Thêm tài khoản vào cơ sở dữ liệu
                data.Add(ac);
                msg_add_accounts.Text = "Thêm tài khoản thành công!";
                msg_add_accounts.ForeColor = System.Drawing.Color.Green;

                // Xóa nội dung các trường sau khi thêm thành công
                ClearFields();
            }
            catch (Exception ex)
            {
                msg_add_accounts.Text = "Có lỗi xảy ra khi thêm tài khoản: " + ex.Message;
                msg_add_accounts.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Hàm xóa nội dung các trường
        private void ClearFields()
        {
            first_name.Text = string.Empty;
            last_name.Text = string.Empty;
            email.Text = string.Empty;
            password.Text = string.Empty;
            address.Text = string.Empty;
            phonenumber.Text = string.Empty;
            sl_role.SelectedIndex = 0;
        }


    }
}
