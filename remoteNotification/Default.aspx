<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="remoteNotification.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>Send Apple remote Notification</b>
        <br />
        <asp:Textbox runat="server" ID="Message" TextMode="MultiLine" Width="300px" Height="50px" />
        <br />
        <asp:Button runat="server" ID="btnSend" TextMode="SEND" />
        <br />
        <asp:Lable runat="server" ID="result" ForeColor="red" />
    </div>
    </form>
</body>
</html>
