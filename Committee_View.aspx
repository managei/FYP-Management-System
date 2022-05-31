<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Committee_View.aspx.cs" Inherits="FYP_Management_System_DB_Final_Project.Student_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="committee_panel_style.css" />
</head>
<body>
    <form id="form1" runat="server">
       <header>
            <nav class="navbar" style="background: #F6F5FC">
                <div class="container">

                    <ul class="navbar-nav">
                        <li class="nav-item activeBtn">
                            <asp:LinkButton ID="LinkButton1" runat="server">Home</asp:LinkButton>
                            &nbsp;</li>
                        <li class="nav-item">&nbsp;<asp:LinkButton ID="LinkButton2" runat="server">Profile</asp:LinkButton>
                        </li>
                        <li class="nav-item">&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">LogOut</asp:LinkButton>
                        </li>
                    </ul>
                    <a href="FYPinterface.aspx" class="navbar-brand">
                        <h1>FYP Management</h1>
                    </a>

                </div>
            </nav>
        </header>
         <div style="border-style: double; border-width: 1px; padding: 10px; width: 273px; color: #000000; background-color: #F6F5FC; margin-top: 9px;">
            <h1>Role:
                <asp:Label ID="roleLabel" runat="server"></asp:Label>
            </h1>
            <h1>Member Name:&nbsp;
                <asp:Label ID="nameLabel" runat="server"></asp:Label>
            </h1>
            <h1>Email: <asp:Label ID="emailLabel" runat="server"></asp:Label>
            </h1>

        </div>
    </form>
</body>
</html>
