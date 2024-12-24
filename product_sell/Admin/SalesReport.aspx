<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="product_sell.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sales Report</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }

        .screen {
            margin: 20px;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .title-page {
            text-align: center;
            color: #333;
            font-size: 24px;
            margin-bottom: 20px;
        }

        .tong-thu-nhap,
        .sl-ban,
        .ls-mua,
        .top-selling-products {
            margin-bottom: 40px;
        }

        h2 {
            color: #555;
            font-size: 20px;
            margin-bottom: 10px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
            table-layout: fixed;
        }

        .table th,
        .table td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
            word-wrap: break-word;
            white-space: normal;
        }

        .table th {
            background-color: #f8f9fa;
            font-weight: bold;
            text-align: center;
        }

        .table tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .table tr:hover {
            background-color: #f1f1f1;
        }

        .total-revenue {
            font-size: 18px;
            color: #28a745;
            font-weight: bold;
        }

        .chart-container {
            margin-top: 40px;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="screen">
        <h1 class="title-page">Sales Report</h1>

        <div class="tong-thu-nhap">
            <h2 class="title-page">Tổng thu nhập</h2>
            <asp:Label ID="lblTotalRevenue" runat="server" CssClass="total-revenue" Text="Tổng doanh thu:"></asp:Label>
        </div>

        <div class="sl-ban">
            <h2>Thống kê đơn hàng</h2>
            <asp:GridView ID="gvSalesReport" runat="server" AutoGenerateColumns="True" CssClass="table"></asp:GridView>
        </div>

        <div class="ls-mua">
            <h2>Chi tiết đơn hàng</h2>
            <asp:GridView ID="gvPurchaseHistory" runat="server" AutoGenerateColumns="True" CssClass="table"></asp:GridView>
        </div>

        <div class="top-selling-products">
            <h2>Top bán chạy</h2>
            <div class="grid-sell">
                <asp:GridView ID="gvTopSellingProducts" runat="server" AutoGenerateColumns="False" CssClass="table" 
                    HeaderStyle-CssClass="thead-dark" EmptyDataText="Không có sản phẩm nào bán chạy">
                    <Columns>
                        <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="product_id" />
                        <asp:BoundField DataField="SKU" HeaderText="SKU" SortExpression="SKU" />
                        <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                        <asp:BoundField DataField="total_quantity_sold" HeaderText="Total Quantity Sold" SortExpression="total_quantity_sold" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
