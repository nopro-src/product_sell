<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="product_sell.Login_Register.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(to right, #00c6ff, #0072ff);
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        .register-form {
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
            width: 400px;
            text-align: center;
            max-height: 90vh; /* Đảm bảo form không vượt quá chiều cao màn hình */
            overflow-y: auto; /* Thêm scroll nếu form dài hơn màn hình */
            box-sizing: border-box;
        }

            .register-form h2 {
                margin-bottom: 20px;
                color: #333;
                font-weight: 600;
            }

        .input-group {
            margin-bottom: 15px;
            text-align: left;
        }

            .input-group label {
                font-size: 14px;
                color: #555;
                margin-bottom: 5px;
                display: block;
            }

            .input-group input {
                width: 100%;
                padding: 12px;
                font-size: 14px;
                border: 1px solid #ccc;
                border-radius: 5px;
                transition: border-color 0.3s;
            }

                .input-group input:focus {
                    border-color: #0072ff;
                    outline: none;
                    box-shadow: 0 0 5px rgba(0, 114, 255, 0.5);
                }

        .btn {
            background-color: #0072ff;
            color: #fff;
            padding: 12px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
            font-weight: 600;
            transition: background-color 0.3s;
        }

            .btn:hover {
                background-color: #005bb5;
            }

        .links {
            margin-top: 20px;
            font-size: 14px;
            color: #555;
        }

            .links a {
                color: #0072ff;
                text-decoration: none;
                transition: color 0.3s;
            }

                .links a:hover {
                    color: #005bb5;
                    text-decoration: underline;
                }

        .error-message {
            color: red;
            margin-top: 10px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-form">
            <h2>Đăng ký tài khoản</h2>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>

            <div class="input-group">
                <asp:Label ID="lblFirstName" runat="server" Text="Họ" AssociatedControlID="txtFirstName"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" Placeholder="Nhập họ"></asp:TextBox>
            </div>

            <div class="input-group">
                <asp:Label ID="lblLastName" runat="server" Text="Tên" AssociatedControlID="txtLastName"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" Placeholder="Nhập tên"></asp:TextBox>
            </div>

            <div class="input-group">
                <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ" AssociatedControlID="txtAddress"></asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" Placeholder="Nhập địa chỉ"></asp:TextBox>
            </div>

            <div class="input-group">
                <asp:Label ID="lblPhoneNumber" runat="server" Text="Số điện thoại" AssociatedControlID="txtPhoneNumber"></asp:Label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" Placeholder="Nhập số điện thoại"></asp:TextBox>
            </div>

            <div class="input-group">
                <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Nhập email"></asp:TextBox>
            </div>

            <div class="input-group">
                <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu" AssociatedControlID="txtPassword"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Nhập mật khẩu"></asp:TextBox>
            </div>

            <div class="input-group">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Nhập lại mật khẩu" AssociatedControlID="txtConfirmPassword"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Placeholder="Nhập lại mật khẩu"></asp:TextBox>
            </div>

            <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" CssClass="btn" OnClick="btnRegister_Click" />

            <div class="links">
                <span>Bạn đã có tài khoản? <a href="Login.aspx">Đăng nhập ngay</a></span>
            </div>
        </div>
    </form>
</body>
</html>
