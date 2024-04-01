<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="LMS_Project.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <a href="default.aspx"><img src="Logoimg/error.gif" /></a>
            <div>
                <asp:Label ID="errorDesp" runat="server" Text=" " ForeColor="Red"></asp:Label>
            </div>
        </center>
    </form>
</body>
</html>
