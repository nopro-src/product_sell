<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="product_sell.Admin.ManageOders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách đơn hàng</h2>
    <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false">
        <columns>
            <asp:BoundField DataField="order_id" HeaderText="order_id" />
            <asp:BoundField DataField="order_date" HeaderText="order_date" />
            <asp:BoundField DataField="total_price" HeaderText="total_price" />
            <asp:BoundField DataField="status" HeaderText="status" />
            <asp:BoundField DataField="Customer_custo" HeaderText="Customer_custo" />
            <asp:BoundField DataField="Payment_payme" HeaderText="Payment_payme" />
            <asp:BoundField DataField="Shipment_shipm" HeaderText="Shipment_shipm" />

            <asp:TemplateField HeaderText="Edit">
                <itemtemplate>
                    <asp:Button ID="sua" CommandName="sua" CommandArgument='<%# Bind("order_id") %>'
                        Text="Edit" OnCommand="Edit_Click" runat="server" />

                </itemtemplate>
            </asp:TemplateField>
          
        </columns>
    </asp:GridView>

    </div>
</asp:Content>
