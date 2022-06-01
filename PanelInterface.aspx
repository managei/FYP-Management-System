<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelInterface.aspx.cs" Inherits="FYP_Management_System_DB_Final_Project.PanelInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Panel Interface</title>
    <link rel="stylesheet" href="Style.css" />

</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar" style="background: #F6F5FC">
                <div class="container">
                    <a href="PanelInterface.aspx" class="navbar-brand">
                        <h1>FYP Management</h1>
                    </a>

                    <ul class="navbar-nav">
                        <li class="nav-item activeBtn">
                            <asp:LinkButton ID="HomeButton" runat="server" OnClick="LinkButton1_Click">Home</asp:LinkButton>
                            &nbsp;</li>
                        <li class="nav-item">
                            <asp:LinkButton ID="ProfileButton" runat="server" OnClick="ProfileButton_Click">Profile</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="LogOutButton" runat="server" OnClick="LinkButton3_Click">LogOut</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <div class="main-body" style="background: #F6F5FC; margin-top: 10px; margin-bottom: 10px; padding: 10px; overflow: auto;">
            <h1>Home</h1>
            <div>
                <div style="margin: auto; float: left; width: 25%;">
                    <div style="border-style: double; border-width: 1px; padding: 10px;">
                        <asp:Label ID="userName" runat="server" Font-Bold="False" Font-Size="X-Large" ForeColor="Black" Text="username"></asp:Label>
                        <br />
                        <asp:Label ID="role" runat="server" Text="role"></asp:Label>
                    </div>
                </div>
                <div style="margin: auto; float: right; width: 74%;">
                    <div style="border-style: double; border-width: 1px; padding: 10px;">
                        <h1>Panel
                                Name:&nbsp;
                        <asp:Label ID="LabelPanelName" runat="server" ForeColor="Black" Text="Committee Name" Font-Size="Medium"></asp:Label>
                        </h1>

                        <p>You have acces to following operations:</p>
                        <button type="button" class="collapsible">Manage Groups</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                        </div>
                        <asp:Button CssClass="button" ID="LoadFYP" runat="server" Text="Load Ongoing Groups" OnClick="LoadGroup_Click" />
                        <asp:Button CssClass="button spcBtn" ID="HideTable1" runat="server" Text="Hide Table" />
                        <asp:PlaceHolder ID="PlaceHolderGroup" runat="server"></asp:PlaceHolder>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script>
    var coll = document.getElementsByClassName("collapsible");
    var i;

    for (i = 0; i < coll.length; i++) {
        coll[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var content = this.nextElementSibling;
            if (content.style.display === "block") {
                content.style.display = "none";
            } else {
                content.style.display = "block";
            }
        });
    }
</script>
</html>
