<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorInerface.aspx.cs" Inherits="FYP_Management_System_DB_Final_Project.SupervisorInerface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supervisor Interface</title>
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
                        <h1>Supervisor Page
                        </h1>
                        <p>You have acces to following operations:</p>
                        <button type="button" class="collapsible">Manage Groups</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <div align="center">
                                <asp:Button CssClass="button" ID="LoadGroups" runat="server" Text="Load Assigned Groups" OnClick="LoadGroups_Click" />
                                <asp:Button CssClass="button" ID="LoadReviews" runat="server" Text="Load Your Reviews" OnClick="LoadReviews_Click" />
                                <asp:Button CssClass="button spcBtn" ID="HideT1" runat="server" Text="Hide Table" OnClick="HideT1_Click" />
                                <asp:PlaceHolder ID="PlaceHolderGroup" runat="server"></asp:PlaceHolder>
                                <button type="button" class="collapsible">Add Review</button>
                                <div class="content">
                                    <p>
                                        Input GroupId:
                                    <asp:TextBox ID="TB_grpId" runat="server"></asp:TextBox>
                                    </p>
                                    <p>
                                        Input Review for group
                                    </p>
                                    <asp:TextBox ID="TB_reviewDetail" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <p>
                                        <asp:Button CssClass="button sucBtn" ID="BtnAddReview" runat="server" Text="Submit" OnClick="BtnAddReview_Click" />
                                    </p>
                                </div>
                            </div>
                        </div>
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
