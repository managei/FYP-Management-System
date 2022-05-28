<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInterface.aspx.cs" Inherits="FYP_Management_System_DB_Final_Project.StudentInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        :root {
            --primary: #6C55F9;
            --accent: #FF3D85;
            --secondary: #645F88;
            --success: #35bb78;
            --info: #05B4E1;
            --warning: #FAC14D;
            --danger: #FF4943;
            --grey: #B4B2C5;
            --dark: #2D2B3A;
            --light: #F6F5FC;
        }

        body {
            line-height: 1.5;
            color: #2D2B3A;
            background: #B4B2C5;
        }

        h1 {
            font-family: arial, sans-serif;
            font-size: 16px;
            font-weight: bold;
            margin-top: 0px;
            margin-bottom: 1px;
        }

        a {
            color: #6C55F9;
            text-decoration: none;
            background-color: transparent;
        }

            a:hover {
                color: #5641df;
                text-decoration: underline;
            }

        .nav-item {
            flex-basis: 0;
            flex-grow: 1;
            text-align: center;
            display: inline;
            float: left;
            display: block;
            padding-inline: 8px;
            width: 62px;
            border: 1px solid #555;
        }

        .activeBtn {
            font-weight: bold;
        }


        .navbar-brand {
            display: inline;
            float: left;
            display: block;
            padding: 8px;
            width: 134px;
        }

        .navbar-nav {
            display: inline-block;
            float: right;
            margin: 0px;
            margin-top: 8px;
        }

        .container {
            align-content: baseline;
            display: block;
            height: 42px;
            padding: 10px;
            border: 1px solid #555;
        }

        .main-body {
            border: 1px solid #555;
        }

        .collapsible {
            background-color: #645F88;
            color: #F6F5FC;
            cursor: pointer;
            padding: 18px;
            width: 100%;
            border: none;
            text-align: left;
            outline: none;
            font-size: 15px;
        }

            .active, .collapsible:hover {
                background-color: #2D2B3A;
            }

        .content {
            padding: 0 18px;
            display: none;
            overflow: hidden;
            background-color: #f1f1f1;
        }

        .td {
            border: 1px solid #2D2B3A;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar" style="background: #F6F5FC">
                <div class="container">
                    <a href="FYPinterface.aspx" class="navbar-brand">
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
                        <h1>Student Portal
                        </h1>
                        <p>You have acces to following operations:</p>
                        <button type="button" class="collapsible">Manage FYP</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
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
