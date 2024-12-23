<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="product_sell.Admin.ManageAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Nút chung */
        .btn {
            padding: 7px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
        }

        /* Nút xóa */
        .btn-danger {
            background-color: #ff4d4d;
            color: white;
        }

        .btn-danger:hover {
            background-color: #cc0000;
        }

        /* Nút sửa */
        .btn-warning {
            background-color: #ffc107;
            color: black;
        }

        .btn-warning:hover {
            background-color: #e0a800;
        }

        /* Nút thêm */
        .btn-success {
            background-color: #28a745;
            color: white;
        }

        .btn-success:hover {
            background-color: #218838;
        }

        /* Bảng */
        .table {
            width: 100%;
            margin: 20px auto;
            border-collapse: collapse;
        }

        .table th,
        .table td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: center;
        }

        .table th {
            background-color: #f2f2f2;
            color: black;
        }

        .table tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .table tr:hover {
            background-color: #f1f1f1;
        }

        /* Nút thêm tài khoản góc phải */
        .btn-add-container {
            text-align: right;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="text-align: center; margin-bottom: 20px;">Quản lý tài khoản</h2>

        <!-- Nút Thêm tài khoản ở góc phải -->
        <div class="btn-add-container">
            <asp:Button ID="btn_add" runat="server" PostBackUrl="AddAccounts.aspx" Text="Thêm tài khoản" CssClass="btn btn-success" />
        </div>

        <!-- Bảng danh sách tài khoản -->
        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField DataField="customer_id" HeaderText="ID" />
                <asp:BoundField DataField="first_name" HeaderText="First name" />
                <asp:BoundField DataField="last_name" HeaderText="Last name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="password" HeaderText="Password" />
                <asp:BoundField DataField="address" HeaderText="Address" />
                <asp:BoundField DataField="phone_number" HeaderText="Phone number" />
                <asp:BoundField DataField="role" HeaderText="Role" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("customer_id") %>'
                            Text="Xoá" CssClass="btn btn-danger" OnCommand="Xoa_click" runat="server"
                            OnClientClick="return confirm('Bạn có chắc chắn muốn xoá không?')" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Update">
                    <ItemTemplate>
                        <asp:Button ID="sua" CommandName="sua" CommandArgument='<%# Bind("customer_id") %>'
                            Text="Sửa" CssClass="btn btn-warning" OnCommand="Sua_click" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
