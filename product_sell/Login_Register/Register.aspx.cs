using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace product_sell.Login_Register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Kiểm tra các trường hợp để trống
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                lblErrorMessage.Text = "Vui lòng điền đầy đủ thông tin.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Kiểm tra định dạng email
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblErrorMessage.Text = "Email không hợp lệ.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!Regex.IsMatch(phoneNumber, @"^\d{10,11}$"))
            {
                lblErrorMessage.Text = "Số điện thoại không hợp lệ.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Kiểm tra độ dài và tính hợp lệ của mật khẩu
            if (password.Length < 8 || !Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                lblErrorMessage.Text = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ thường, số và ký tự đặc biệt.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Kiểm tra mật khẩu và nhập lại mật khẩu
            if (password != confirmPassword)
            {
                lblErrorMessage.Text = "Mật khẩu không khớp.";
                lblErrorMessage.Visible = true;
                return;
            }

            string sqlCon = "Data Source=LAPTOP-H87TDBVU\\VIETBACH;Initial Catalog=Shopping;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                try
                {
                    con.Open();

                    // Kiểm tra trùng email hoặc số điện thoại
                    string checkQuery = "SELECT COUNT(*) FROM Customer WHERE email = @Email OR phone_number = @PhoneNumber";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        checkCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            lblErrorMessage.Text = "Email hoặc số điện thoại đã tồn tại.";
                            lblErrorMessage.Visible = true;
                            return;
                        }
                    }

                    // Chèn dữ liệu vào bảng Customer
                    string insertQuery = "INSERT INTO Customer (first_name, last_name, address, phone_number, email, password, role) " +
                                         "VALUES (@FirstName, @LastName, @Address, @PhoneNumber, @Email, @Password, @Role)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@FirstName", firstName);
                        insertCmd.Parameters.AddWithValue("@LastName", lastName);
                        insertCmd.Parameters.AddWithValue("@Address", address);
                        insertCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Role", "Customer");

                        insertCmd.ExecuteNonQuery();
                        //lblErrorMessage.Visible = true;
                        //txtFirstName.Text = string.Empty;
                        //txtLastName.Text = string.Empty;
                        //txtAddress.Text = string.Empty;
                        //txtPhoneNumber.Text = string.Empty;
                        //txtEmail.Text = string.Empty;
                        //txtPassword.Text = string.Empty;
                        //txtConfirmPassword.Text = string.Empty;

                        lblErrorMessage.Text = "Đăng ký thành công!";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Lỗi: " + ex.Message;
                    lblErrorMessage.Visible = true;
                }
            }
            
        }
        private void Clear()
        {
            lblErrorMessage.Visible = true;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

    }
}