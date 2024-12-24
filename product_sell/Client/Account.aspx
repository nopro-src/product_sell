<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="product_sell.Client.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thông tin người dùng</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 90%;
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            display: flex;
            gap: 20px;
        }

        .form-section {
            flex: 2;
        }

        .message-section {
            flex: 1;
            text-align: right;
        }

        h1 {
            text-align: center;
            color: #333;
            margin: 20px 0;
        }

        h3 {
            color: #444;
            margin-bottom: 15px;
        }

        .form-control {
            width: 100%;
            max-width: 400px;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        .form-control:focus {
            border-color: #007bff;
            outline: none;
        }

        .btn {
            display: inline-block;
            padding: 10px 15px;
            font-size: 16px;
            color: #fff;
            background-color: #007bff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-top: 10px;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .message {
            color: green;
            font-weight: bold;
        }

        .order-history {
            width: 100%;
            max-width: 800px;
            margin: 20px auto;
            border-collapse: collapse;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        .order-history th, .order-history td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        .order-history th {
            background-color: #007bff;
            color: #fff;
        }

        .order-history tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .order-history tr:hover {
            background-color: #ddd;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Thông tin tài khoản</h1>
    
    <!-- Hiển thị thông tin người dùng -->
    <div>
        <h3>Thông tin cá nhân</h3>
        <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server" Placeholder="Họ" CssClass="form-control"></asp:TextBox><br />
        <asp:TextBox ID="txtLastName" runat="server" Placeholder="Tên" CssClass="form-control"></asp:TextBox><br />
        <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control" ReadOnly="true"></asp:TextBox><br />
        <asp:TextBox ID="txtAddress" runat="server" Placeholder="Địa chỉ" CssClass="form-control"></asp:TextBox><br />
        <asp:TextBox ID="txtPhone" runat="server" Placeholder="Số điện thoại" CssClass="form-control"></asp:TextBox><br />
        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật thông tin" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
    </div>

    <!-- Hiển thị lịch sử đặt hàng -->
    <div>
        <h3>Lịch sử đặt hàng</h3>
        <asp:GridView ID="gvOrderHistory" runat="server" CssClass="order-history" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Mã đơn hàng" />
                <asp:BoundField DataField="OrderDate" HeaderText="Ngày đặt" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Tổng tiền" DataFormatString="{0:#,##0 VNĐ}" />
                <asp:BoundField DataField="Status" HeaderText="Trạng thái" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
