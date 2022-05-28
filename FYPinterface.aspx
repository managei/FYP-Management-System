<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FYPinterface.aspx.cs" Inherits="FYP_Management_System_DB_Final_Project.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Style.css" />
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
                            <asp:LinkButton ID="LinkButton1" runat="server">Home</asp:LinkButton>
                            &nbsp;</li>
                        <li class="nav-item">&nbsp;<asp:LinkButton ID="LinkButton2" runat="server">Profile</asp:LinkButton>
                        </li>
                        <li class="nav-item">&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">LogOut</asp:LinkButton>
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
                        <p>
                            <h1>FYP Committe
                            </h1>
                        </p>
                        <button type="button" class="collapsible">Manage Users</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <asp:Button CssClass="button" ID="Button1" runat="server" Text="Load All Users" OnClick="LoadUsers_Click" />
                            <asp:Button CssClass="button" ID="loadFaculty" runat="server" Text="Load All Faculty" OnClick="LoadFaculty_Click" />
                            <asp:Button CssClass="button" ID="Button2" runat="server" Text="Load All Students" OnClick="LoadStudents_Click" />
                            <asp:Button CssClass="button spcBtn" ID="HideTable" runat="server" Text="Hide Table" OnClick="hideTbl_Click" />
                            <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>

                            <div align="center">
                                <button type="button" class="collapsible">
                                    Add Student
                                </button>
                                <div class="content">
                                    <div style="border: 1px solid #555;">
                                        <p>
                                            User Name:
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Email:
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Password:
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                                        </p>
                                        <p>
                                            <asp:Button ID="AddUserBtn" runat="server" Text="Submit" OnClick="addUserBtn" />
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <p></p>
                            <div align="center">
                                <button type="button" class="collapsible">
                                    Add Faculty
                                </button>
                                <div class="content">

                                    <div style="border: 1px solid #555;">
                                        <p>
                                            User Name:
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Email:
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Password:
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
                                        </p>
                                        Faculty Role
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                            <asp:ListItem>FYP Committee</asp:ListItem>
                                            <asp:ListItem>Supervisor</asp:ListItem>
                                            <asp:ListItem>Panel Member</asp:ListItem>
                                        </asp:DropDownList>
                                        <p>
                                            <asp:Button ID="Button3" runat="server" Text="Submit" OnClick="addUserBtn" />
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <br />
                        </div>
                        <button type="button" class="collapsible">Manage FYP's</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <asp:PlaceHolder runat="server" ID="PlaceHolder2"></asp:PlaceHolder>
                        </div>
                        <div>
                            <br />
                        </div>
                        <button type="button" class="collapsible">Manage Projects</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <asp:PlaceHolder runat="server" ID="PlaceHolder3"></asp:PlaceHolder>
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
