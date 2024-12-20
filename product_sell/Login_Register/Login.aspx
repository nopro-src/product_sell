<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="product_sell.Login_Register.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(to right, #667eea, #764ba2);
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .login-form {
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
            width: 350px;
            text-align: center;
        }

        .login-form h2 {
            margin-bottom: 25px;
            color: #333;
            font-weight: 600;
        }

        .input-group {
            margin-bottom: 20px;
            text-align: left;
            margin-right: 20px;
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
            border-color: #667eea;
            outline: none;
            box-shadow: 0 0 5px rgba(102, 126, 234, 0.5);
        }

        .btn {
            background-color: #667eea;
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
            background-color: #5563c1;
        }

        .links {
            margin-top: 20px;
            font-size: 14px;
            color: #555;
        }

        .links a {
            color: #667eea;
            text-decoration: none;
            transition: color 0.3s;
        }

        .links a:hover {
            color: #5563c1;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="login-form">
        <h2>Đăng nhập</h2>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>

                <div class="input-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Email/Số điện thoại" AssociatedControlID="txtUsername"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Nhập email hoặc số điện thoại"></asp:TextBox>
                </div>

                <div class="input-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu" AssociatedControlID="txtPassword"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Nhập mật khẩu"></asp:TextBox>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="btn" OnClick="btnLogin_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="links">
            <a href="ForgotPassword.aspx">Quên mật khẩu?</a><br />
            <span>Bạn chưa có tài khoản? <a href="Register.aspx">Đăng ký ngay</a></span>
        </div>
    </div>
</form>

</body>
</html>
