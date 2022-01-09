<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mailFormat.aspx.cs" Inherits="WebApplication1.Account.mailFormat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            To:<br/>
         <asp:TextBox ID="To" runat="server"></asp:TextBox>
         </div>
        <div>
            Subject:<br/>
         <asp:TextBox ID="Subject" runat="server"></asp:TextBox>
            </div>
        <div>
            Message:<br/>
           <asp:TextBox ID="EmailMessage" runat="server" TextMode="MultiLine" Height="99px"></asp:TextBox>
         </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Send Mail" OnClick="SendEmail" />
        </div>
    </form>
</body>
</html>