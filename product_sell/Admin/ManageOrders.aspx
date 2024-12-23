<%@ Page Title="Quản lý đơn hàng" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="product_sell.Admin.ManageOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .filter-container, .grid-container {
            margin: 20px auto;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #ffffff;
            max-width: 1200px;
            box-sizing: border-box; /* Đảm bảo kích thước không bị tràn */
        }

        h2 {
            text-align: center;
            color: #333;
        }

        .btn {
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
            font-size: 14px;
            margin: 5px;
            transition: background-color 0.3s, transform 0.2s;
        }
        .btn:hover {
            background-color: #0056b3;
            transform: translateY(-2px);
        }

        .grid-table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            font-size: 16px;
            table-layout: fixed; /* Đảm bảo cột không bị tràn */
            word-wrap: break-word; /* Tự động xuống dòng nếu nội dung quá dài */
        }

        .grid-table th, .grid-table td {
            padding: 12px 15px;
            border: 1px solid #ddd;
            text-align: center;
        }

        .grid-table th {
            background-color: #f8f9fa;
        }

        .grid-table tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .grid-table tr:hover {
            background-color: #f1f1f1;
        }

        .btn-change-status {
            padding: 8px 15px;
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 14px;
            cursor: pointer;
        }
        .btn-change-status:hover {
            background-color: #218838;
        }
    </style>

    <script type="text/javascript">
        function confirmStatusChange(orderId, currentStatus) {
            var newStatus = (currentStatus === 'processing') ? 'success' : 'processing';
            return confirm('Bạn có chắc chắn muốn thay đổi trạng thái từ ' + currentStatus + ' thành ' + newStatus + '?');
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="filter-container">
        <asp:Label ID="lblFromDate" runat="server" Text="Từ ngày:" AssociatedControlID="txtFromDate" />
        <asp:TextBox ID="txtFromDate" runat="server" CssClass="input-date" TextMode="Date"></asp:TextBox>
        
        <asp:Label ID="lblToDate" runat="server" Text="Đến ngày:" AssociatedControlID="txtToDate" />
        <asp:TextBox ID="txtToDate" runat="server" CssClass="input-date" TextMode="Date"></asp:TextBox>
        
        <asp:Button ID="btnFilter" runat="server" CssClass="btn" Text="Lọc Đơn Hàng" OnClick="btnFilter_Click" />
        <asp:Button ID="btnClearFilter" runat="server" CssClass="btn" Text="Xóa Lọc" OnClick="btnClearFilter_Click" />
    </div>

    <div class="grid-container">
        <h2>Danh sách đơn hàng</h2>
        <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false" CssClass="grid-table" OnRowCommand="grdDs_RowCommand">
            <Columns>
                <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                <asp:BoundField DataField="order_date" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="customer_id" HeaderText="Customer ID" />
                <asp:BoundField DataField="phone_number" HeaderText="Phone Number" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="payment_id" HeaderText="Payment ID" />
                <asp:BoundField DataField="shipment_id" HeaderText="Shipment ID" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Change Status">
                    <ItemTemplate>
                        <asp:Button ID="btnChangeStatus" runat="server"
                            CommandName="ChangeStatus"
                            CommandArgument='<%# Eval("order_id") %>'
                            Text="Edit"
                            CssClass="btn-change-status"
                            OnClientClick='<%# "return confirmStatusChange(\"" + Eval("order_id") + "\", \"" + Eval("status") + "\");" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
