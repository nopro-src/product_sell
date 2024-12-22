<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Edit_Product.aspx.cs" Inherits="product_sell.Admin.Edit_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Sửa sản phẩm</h2>
        <asp:Table runat="server" ID="tblds">

            <asp:TableRow>
                <asp:TableCell>product_id</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtproduct_id" runat="server" Enabled="false" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>SKU</asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtSKU" runat="server" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>description</asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtdescription" runat="server" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>price</asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtprice" runat="server" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>stock</asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtstock" runat="server" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>Category_catego</asp:TableCell><asp:TableCell>
                    <%--      <asp:TextBox ID="txtCategory_catego" runat="server" /> --%>
                    <asp:DropDownList ID="dddm" runat="server" size="3" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>image</asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtimage" runat="server" />
                </asp:TableCell></asp:TableRow></asp:Table><br />
        <asp:Button ID="btnEdit" runat="server" Text="Update" OnClick="btnEdit_Click"  /><asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        <p>
            <asp:Label ID="mg" runat="server" Font-Italic="true" />
        </p>
        <p>
            <asp:Button ID="bt2" Text="Danh sách sản phẩm" runat="server" PostBackUrl="~/Admin/ManageProducts.aspx" />
        </p>

    </div>
</asp:Content>
