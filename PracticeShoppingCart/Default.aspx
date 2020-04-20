<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PracticeShoppingCart.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Sher Khan Practice Store App </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 <table align="center" Style= " margin-top:60px" cellpadding="19">
    <tr>
    <td>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Size ="Large" NavigateUrl="~/Default.aspx">HOME</asp:HyperLink>
    </td>
    <td>
    <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Large" NavigateUrl="~/AddProducts.aspx" >ADD PRODUCT</asp:HyperLink>
    </td>
    <td>
    <asp:HyperLink ID="HyperLink3" runat="server" Font-Size ="Large" NavigateUrl="~/ShowProduct.aspx">SHOW PRODUCT</asp:HyperLink>
    </td>
    </tr>
 </table>
 <hr />
 <h1 style="text-align :center; margin-top:70px;"> Welcome to Sher Shopping Online</h1>
    </div>
    </form>
</body>
</html>
