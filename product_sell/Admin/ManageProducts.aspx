<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="product_sell.Admin.ManageProducts" %>

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

        /* Nút tìm kiếm */
        .btn-primary {
            background-color: #007bff;
            color: white;
        }

        .btn-primary:hover {
            background-color: #0056b3;
        }

        /* Nút xóa tìm kiếm */
        .btn-secondary {
            background-color: #6c757d;
            color: white;
        }

        .btn-secondary:hover {
            background-color: #5a6268;
        }

        /* Vị trí ô tìm kiếm */
        .search-container {
            text-align: center;
            margin: 20px 0;
        }

        .search-bar input[type="text"] {
            padding: 7px;
            width: 250px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin: 5px;
        }

        .search-bar button {
            margin: 5px;
        }

        /* Vị trí bảng */
        .table {
            width: 100%;
            margin: 20px auto;
            border-collapse: collapse;
        }

        .table th, .table td {
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

        .table img {
            border-radius: 5px;
        }

        /* Nút thêm sản phẩm góc phải */
        .btn-add-container {
            text-align: right;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="text-align: center; margin-bottom: 20px;">Danh sách sản phẩm</h2>

        <!-- Nút Thêm sản phẩm ở góc phải -->
        <div class="btn-add-container">
            <asp:Button ID="btnAdd" Text="Thêm sản phẩm" CssClass="btn btn-success" runat="server" PostBackUrl="~/Admin/Add_Product.aspx" />
        </div>

        <!-- Khu vực tìm kiếm -->
        <div class="search-container">
            <div class="search-bar">
                <asp:TextBox ID="txtSearchById" runat="server" CssClass="form-control" Placeholder="Tìm theo mã sản phẩm"></asp:TextBox>
                <asp:TextBox ID="txtSearchByDescription" runat="server" CssClass="form-control" Placeholder="Tìm theo mô tả sản phẩm"></asp:TextBox>
            </div>
            <div class="search-bar">
                <asp:Button ID="btnSearch" Text="Tìm kiếm" CssClass="btn btn-primary" runat="server" OnClick="btnSearch_Click" />
                <asp:Button ID="btnClearSearch" Text="Xóa tìm kiếm" CssClass="btn btn-secondary" runat="server" OnClick="btnClearSearch_Click" />
            </div>
        </div>

        <!-- Bảng danh sách sản phẩm -->
        <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
                <asp:BoundField DataField="SKU" HeaderText="SKU" />
                <asp:BoundField DataField="description" HeaderText="Mô tả" />
                <asp:BoundField DataField="price" HeaderText="Giá" />
                <asp:BoundField DataField="stock" HeaderText="Kho" />
                <asp:BoundField DataField="Category_catego" HeaderText="Danh mục" />
                <asp:TemplateField HeaderText="Hình ảnh">
                    <ItemTemplate>
                        <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# "~/images/" + Eval("image") %>' Width="100px" Height="100px" AlternateText="No Image" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" CommandName="xoa" CommandArgument='<%# Bind("product_id") %>' Text="Xóa" CssClass="btn btn-danger" OnCommand="Delete_Click" OnClientClick="return confirm('Bạn có chắc chắn xóa không?')" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CommandName="sua" CommandArgument='<%# Bind("product_id") %>' Text="Sửa" CssClass="btn btn-warning" OnCommand="Edit_Click" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
