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
                        <h1>UserName:</h1>
                        <asp:Label ID="userName" runat="server" Font-Bold="False" Font-Size="X-Large" ForeColor="Black" Text="username"></asp:Label>
                        <br />
                        <h1>Role:</h1>
                        <asp:Label ID="role" runat="server" Text="role"></asp:Label>
                    </div>
                </div>
                <div style="margin: auto; float: right; width: 74%;">
                    <div style="border-style: double; border-width: 1px; padding: 10px;">
                        <p>
                            <h1>FYP Committe
                                Name:&nbsp;
                        <asp:Label ID="LabelCommName" runat="server" ForeColor="Black" Text="Committee Name" Font-Size="Medium"></asp:Label>

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
                                            Email:&nbsp;&nbsp;&nbsp;
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
                    <asp:TextBox ID="F_UName" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Email:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="F_Email" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Password:
                    <asp:TextBox ID="F_Pass" runat="server" TextMode="Password"></asp:TextBox>
                                        </p>
                                        <p>
                                            <asp:Button ID="Button3" runat="server" Text="Submit" OnClick="Button3_Click" />
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <br />
                        </div>
                        <button type="button" class="collapsible">Manage Committee</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <asp:Button CssClass="button" ID="loadCommites" runat="server" Text="Load all Commities" OnClick="loadCommites_Click" />
                            <asp:Button CssClass="button spcBtn" ID="HideComms" runat="server" Text="Hide Table" OnClick="HideComms_Click" />
                            <asp:PlaceHolder ID="PlaceHolderCommitee" runat="server"></asp:PlaceHolder>
                            <div align="center">
                                <button type="button" class="collapsible">
                                    Add Committe
                                </button>
                                <div class="content">
                                    <div style="border: 1px solid #555;">
                                        <p>
                                            Committee Name:
                    <asp:TextBox ID="commNameText" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            <asp:Button ID="AddCommitteBTN" runat="server" Text="Submit" OnClick="Button3_Click" />
                                        </p>
                                    </div>
                                </div>
                                <p></p>
                                <button type="button" class="collapsible">
                                    Add a Member to Committe
                                </button>
                                <div class="content">
                                    <div style="border: 1px solid #555;">
                                        <p>
                                            Select Committee: 
                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="comittee_name" DataValueField="committee_id"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="SELECT [committee_id], [comittee_name] FROM [FYP_COMMITTEE]"></asp:SqlDataSource>
                                        </p>
                                        <p>
                                            Select Member: 
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="SELECT [id], [name] FROM [FACULTY]"></asp:SqlDataSource>
                                        </p>
                                        <asp:Button ID="Button6" runat="server" Text="Submit" OnClick="Button6_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p></p>
                        <button type="button" class="collapsible">
                            Manage FYP's                   
                        </button>
                        <div class="content">

                            <p>Lorem ipsum...</p>
                            <asp:PlaceHolder runat="server" ID="PlaceHolder2"></asp:PlaceHolder>
                        </div>
                        <p></p>
                        <button type="button" class="collapsible">Manage Groups</button>
                        <div class="content">
                            <p>Here you can view and manage all Groups</p>
                            <asp:Button CssClass="button" ID="loadGroupsButton" runat="server" Text="Load All Groups" OnClick="LoadGroups_Click" />
                            <asp:Button CssClass="button" ID="loadFYPgroup" runat="server" Text="Load Group FYP" OnClick="LoadGroupFYP_Click" />
                            <asp:Button CssClass="button" ID="loadGroupMembers" runat="server" Text="Load Group Members" OnClick="LoadGroupMembers_Click" />
                            <asp:Button CssClass="button" ID="loadGroupSupervisors" runat="server" Text="Load Group Supervisors" OnClick="LoadGroupSuper_Click" />
                            <asp:Button CssClass="button" ID="loadGroupPanel" runat="server" Text="Load Group Panel" OnClick="LoadGroupPanel_Click" />
                            <asp:Button CssClass="button spcBtn" ID="Button4" runat="server" Text="Hide Table" OnClick="hideTbl3_Click" />

                            <asp:PlaceHolder runat="server" ID="PlaceHolder3"></asp:PlaceHolder>
                            <div align="center">
                                <button type="button" class="collapsible">
                                    Add Group
                                </button>
                                <div class="content">

                                    <div style="border: 1px solid #555;">
                                        <p>
                                            User Name:
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Email:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Password:
                    <asp:TextBox ID="TextBox9" runat="server" TextMode="Password"></asp:TextBox>
                                        </p>
                                        Faculty Role
                                        <asp:DropDownList ID="DropDownList2" runat="server">
                                            <asp:ListItem>FYP Committee</asp:ListItem>
                                            <asp:ListItem>Supervisor</asp:ListItem>
                                            <asp:ListItem>Panel Member</asp:ListItem>
                                        </asp:DropDownList>
                                        <p>
                                            <asp:Button ID="Button5" runat="server" Text="Submit" OnClick="addUserBtn" />
                                        </p>
                                    </div>
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
