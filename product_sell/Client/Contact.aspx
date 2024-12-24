<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="product_sell.Client.Contact" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Liên hệ - Shop Thời Trang</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }

        .contact-container {
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background: #ffffff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            border-radius: 10px;
        }

        h1, h2 {
            color: #333333;
        }

        p {
            color: #555555;
            line-height: 1.6;
        }

        .contact-info, .contact-form, .social-media {
            margin-bottom: 20px;
        }

            .contact-form label {
                display: block;
                margin-bottom: 8px;
                font-weight: bold;
                color: #333;
            }

            .contact-form input, .contact-form textarea {
                width: 100%;
                padding: 10px;
                margin-bottom: 15px;
                border: 1px solid #cccccc;
                border-radius: 5px;
                box-sizing: border-box;
            }

            .contact-form button {
                background-color: #007bff;
                color: #ffffff;
                padding: 10px 20px;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                font-size: 16px;
            }

                .contact-form button:hover {
                    background-color: #0056b3;
                }

            .social-media a {
                display: inline-block;
                margin-right: 10px;
                text-decoration: none;
                color: #007bff;
            }

                .social-media a:hover {
                    text-decoration: underline;
                }

        .image-container {
            text-align: center;
            margin-bottom: 20px;
        }

        .shop-image {
            max-width: 100%;
            height: auto;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }
        .back-home {
            text-align: center;
            margin-top: 30px;
        }

        .btn-back-home {
            display: inline-block;
            background-color: #28a745;
            color: #ffffff;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 5px;
            font-size: 16px;
            font-weight: bold;
            transition: background-color 0.3s ease;
        }

        .btn-back-home:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contact-container">
            <h1>Liên Hệ Với Chúng Tôi</h1>
            <p>Shop Thời Trang với phương châm “Luôn đồng hành cùng phong cách thời trang của bạn”.</p>
            <div class="image-container">
                <img src="../images/nen.jpg" alt="Hình ảnh cửa hàng" class="shop-image" />
            </div>
            <div class="contact-info">
                <h2>Thông tin liên hệ</h2>
                <p><strong>Địa chỉ:</strong> Minh Khai, Bắc Từ Liêm, Hà Nội</p>
                <p><strong>Điện thoại:</strong> 0123 456 789</p>
                <p><strong>Email:</strong> nopro@gmail.com</p>
                <p><strong>Thời gian làm việc:</strong> 9:00 AM - 11:00 PM (Thứ Hai - Chủ Nhật)</p>
            </div>

            <div class="contact-form">
                <h2>Gửi thông tin liên hệ</h2>
                <form action="ContactSubmit.aspx" method="post">
                    <label for="name">Họ tên:</label>
                    <input type="text" id="name" name="name" required />

                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" required />

                    <label for="message">Nội dung:</label>
                    <textarea id="message" name="message" rows="5" required></textarea>

                    <button type="submit">Gửi</button>
                </form>
            </div>

            <div class="social-media">
                <h2>Kết nối với chúng tôi</h2>
                <a href="#">Facebook</a>
                <a href="#">Instagram</a>
                <a href="#">TikTok</a>
            </div>
            <div class="back-home">
                <a href="../Client/Home.aspx" class="btn-back-home">Quay lại Trang chủ</a>
            </div>
        </div>
    </form>
</body>
</html>
