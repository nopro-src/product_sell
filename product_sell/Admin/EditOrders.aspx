<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditOrders.aspx.cs" Inherits="product_sell.Admin.EditOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
     <h2>Sửa sản phẩm</h2>
     <asp:Table runat="server" ID="tblds">

         <asp:TableRow>
             <asp:TableCell>order_id</asp:TableCell>
             <asp:TableCell>
                 <asp:TextBox ID="txtorder_id" runat="server" Enabled="false" />
             </asp:TableCell></asp:TableRow><asp:TableRow>
             <asp:TableCell>status</asp:TableCell><asp:TableCell>
                 <%--      <asp:TextBox ID="txtCategory_catego" runat="server" /> --%>
                 <asp:DropDownList ID="dddm" runat="server" size="2" />
             </asp:TableCell></asp:TableRow></asp:Table><br />
     <asp:Button ID="btnEdit" runat="server" Text="Update" OnClick="btnEdit_Click"  /><asp:Button ID="btnCancel" runat="server" Text="Cancel"  />
     <p>
         <asp:Label ID="mg" runat="server" Font-Italic="true" />
     </p>
     <p>
         <asp:Button ID="bt2" Text="Danh sách đơn hàng" runat="server" PostBackUrl="~/Admin/ManageOrders.aspx" />
     </p>

 </div>
</asp:Content>
