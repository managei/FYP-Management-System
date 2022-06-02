<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInterface.aspx.cs" Inherits="FYP_Management_System_DB_Final_Project.StudentInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
        <div class="main-body" style="background: #F6F5FC; margin-top: 10px; margin-bottom: 10px; padding: 10px; overflow: auto; background-image: url('back.jpg');">

            <div>
                <div style="margin: auto; float: left; width: 25%; background-color: ghostwhite">
                    <div style="border-style: double; border-width: 1px; padding: 10px;">
                        <asp:Label ID="userName" runat="server" Font-Bold="False" Font-Size="X-Large" ForeColor="Black" Text="User Name: ">User Name: </asp:Label>
                        <br />
                        <asp:Label ID="role" runat="server" Text="Role: ">Role: </asp:Label>
                        <br />
                        <br />
                        
                        <asp:Calendar Width="100%" ID="Calendar1" OnDayRender="Calendar1_DayRender" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                    </div>

                </div>
                <div style="margin: auto; float: right; width: 74%; height: 600px;">
                    <div style="border-style: double; border-width: 1px; padding: 10px; background-color: ghostwhite;">
                        <h2>Welcome to the Student Portal
                        </h2>
                        <p>You have access to following operations: </p>
                        <!--<button type="button" class="collapsible">View Student Data</button>-->
                        <!-- <div class="content">   -->
                        <p>Over here you can view all Student data</p>
                        <asp:Button CssClass="button" ID="loadStudentData" runat="server" Text="Load Student Data" OnClick="LoadstudentData_Click" />
                        <asp:Button CssClass="button" ID="loadFYP" runat="server" Text="Load FYP" OnClick="LoadstudentFYPData_Click" />
                        <asp:Button CssClass="button" ID="loadgroup" runat="server" Text="Load Group" OnClick="LoadstudentGroupData_Click" />

                        <asp:Button CssClass="button" ID="loadMembers" runat="server" Text="Load Members" OnClick="LoadstudentGroupMembersData_Click" />
                        <asp:Button CssClass="button" ID="loadNotifications" runat="server" Text="Load Notifications" OnClick="LoadstudentNotify_Click" />
                        <asp:Button CssClass="button" ID="loadReviews" runat="server" Text="Load Review" OnClick="LoadstudentReview_Click" />

                        <asp:Button CssClass="button spcBtn" ID="Button10" runat="server" Text="Hide Table" OnClick="hideTbl_Click" />
                        <br />
                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                        <br />

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
