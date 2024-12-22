<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="product_sell.Admin.ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Danh sách sản phẩm</h2>
        <asp:GridView ID="grdDs" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="product_id" HeaderText="product_id" />
                <asp:BoundField DataField="SKU" HeaderText="SKU" />
                <asp:BoundField DataField="description" HeaderText="description" />
                <asp:BoundField DataField="price" HeaderText="price" />
                <asp:BoundField DataField="stock" HeaderText="stock" />
                <asp:BoundField DataField="Category_catego" HeaderText="Category_catego" />
                <asp:BoundField DataField="image" HeaderText="image" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="xoa" CommandName="xoa" CommandArgument='<%# Bind("product_id") %>'
                            Text="Delete" OnCommand="Delete_Click" runat="server"
                            OnClientClick="return confirm('Bạn có chắc chắn xóa không?')" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:Button ID="sua" CommandName="sua" CommandArgument='<%# Bind("product_id") %>'
                            Text="Edit" OnCommand="Edit_Click" runat="server" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p>
            <asp:Button ID="bt1" Text="Add" runat="server" PostBackUrl="~/Admin/Add_Product.aspx" />
        </p>
    </div>
</asp:Content>
