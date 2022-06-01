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
                                            <asp:Button CssClass="button sucBtn" ID="AddUserBtn" runat="server" Text="Submit" OnClick="addUserBtn" />
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
                                            <asp:Button CssClass="button sucBtn" ID="Button3" runat="server" Text="Submit" OnClick="addFacultyBtn" />
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
                                            <asp:Button CssClass="button sucBtn" ID="AddCommitteBTN" runat="server" Text="Submit" OnClick="Button3_Click" />
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
                    <asp:TextBox ID="TB_addMemComm1" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Select Member:
                    <asp:TextBox ID="TB_addMemComm2" runat="server"></asp:TextBox>
                                        </p>
                                        <asp:Button CssClass="button sucBtn" ID="Button6" runat="server" Text="Submit" OnClick="Button6_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p></p>
                        <button type="button" class="collapsible">
                            Manage Panels              
                        </button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <asp:Button CssClass="button" ID="Button10" runat="server" Text="Load all Panels" OnClick="Button10_Click" />
                            <asp:Button CssClass="button spcBtn" ID="Button11" runat="server" Text="Hide Table" OnClick="Button11_Click" />
                            <asp:PlaceHolder runat="server" ID="PlaceHolder5"></asp:PlaceHolder>
                            <div align="center">
                                <p></p>
                                <button type="button" class="collapsible">
                                    Add Panel</button>
                                <div class="content">
                                    <div style="border: 1px solid #555;">
                                        <p>
                                            Panel Name:
                    <asp:TextBox ID="TB_addPanelName" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            <asp:Button CssClass="button sucBtn" ID="Button12" runat="server" Text="Submit" OnClick="Button12_Click" />
                                        </p>
                                    </div>
                                </div>
                                <p></p>
                                <button type="button" class="collapsible">
                                    Add a Member to Panel
                                </button>
                                <div class="content">
                                    <div style="border: 1px solid #555;">
                                        <p>
                                            Select Panel: 
                                            <asp:TextBox ID="TB_addMemPanel1" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Select Member: 
                                            <asp:TextBox ID="TB_addMemPanel2" runat="server"></asp:TextBox>
                                        </p>
                                        <asp:Button CssClass="button sucBtn" ID="Button13" runat="server" Text="Submit" OnClick="Button13_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p></p>
                        <p></p>
                        <button type="button" class="collapsible">
                            Manage Supervisors          
                        </button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <asp:Button CssClass="button" ID="loadSupervisor" runat="server" Text="Load all Supervisors" OnClick="loadSupervisor_Click" />
                            <asp:Button CssClass="button spcBtn" ID="hideSupTable" runat="server" Text="Hide Table" />
                            <asp:PlaceHolder runat="server" ID="PlaceHolderSuprv"></asp:PlaceHolder>
                            <div align="center">
                                <p></p>
                                <button type="button" class="collapsible">
                                    Add a Member to Supervise</button>
                                <div class="content">
                                    <div style="border: 1px solid #555;">
                                        <p>
                                            Select Member: 
                                            <asp:TextBox ID="TB_setSuprv" runat="server"></asp:TextBox>
                                        </p>
                                        <asp:Button CssClass="button sucBtn" ID="BTNsubmitSuprv" runat="server" Text="Submit" OnClick="BTNsubmitSuprv_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p></p>
                        <button type="button" class="collapsible">
                            Manage FYP's</button>
                        <div class="content">
                            <p>Lorem ipsum...</p>
                            <asp:Button CssClass="button" ID="Button7" runat="server" Text="Load all FYP's" OnClick="Button7_Click" />
                            <asp:Button CssClass="button spcBtn" ID="Button8" runat="server" Text="Hide Table" OnClick="hideTbl2_Click" />
                            <asp:PlaceHolder runat="server" ID="PlaceHolder2"></asp:PlaceHolder>
                            <div align="center">
                                <p></p>
                                <button type="button" class="collapsible">
                                    Add FYP                  
                                </button>
                                <div class="content">
                                    <div style="border: 1px solid #555;">
                                        <p>
                                            FYP Title:
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            FYP Deadline:
                                        </p>
                                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                            <WeekendDayStyle BackColor="#CCCCFF" />
                                        </asp:Calendar>
                                        <p>
                                            <asp:Button CssClass="button sucBtn" ID="Button9" runat="server" Text="Submit" OnClick="Button9_Click" />
                                        </p>
                                    </div>
                                </div>
                            </div>
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
                                            Group Name:
                    <asp:TextBox ID="GroupNameBox" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Panel ID:&nbsp;
                    <asp:TextBox ID="GroupPanelIDBox" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Supervisor ID:
                    <asp:TextBox ID="GroupSuperID" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Committee ID:
                    <asp:TextBox ID="GroupCommitteeID" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            <asp:Button ID="createGroupButton" runat="server" Text="Create Group" OnClick="createGroup" />
                                        </p>
                                    </div>
                                </div>
                                <p />
                                <div align="center">
                                    <button type="button" class="collapsible">
                                        Add Student to Group
                                    </button>
                                    <div class="content">

                                        <div style="border: 1px solid #555;">
                                            <p>
                                                Student ID:
                    <asp:TextBox ID="getStudentID" runat="server"></asp:TextBox>
                                            </p>
                                            <p>
                                                Group ID:&nbsp;
                    <asp:TextBox ID="getGroupID" runat="server"></asp:TextBox>
                                            </p>
                                            <p>
                                                <asp:Button ID="addStudentToGroupButton" runat="server" Text="Submit" OnClick="addStudentToGroup" />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                        <div>
                            <br />
                        </div>
                             <button type="button" class="collapsible">Manage Reports</button>
                        <div class="content">
                            <p>Here you can view and manage all Reports</p>
                            <asp:Button CssClass="button" ID="loadReports" runat="server" Text="Load All Reports" OnClick="LoadReports_Click" />
                            
                            <asp:Button CssClass="button spcBtn" ID="Button10" runat="server" Text="Hide Table" OnClick="hideTbl3_Click" />
                            <br />
                            <asp:CheckBox ID="loadAllReports" runat="server" Text="Load Only Current Committee Reports"/>
                            <br />
                            <asp:PlaceHolder runat="server" ID="PlaceHolder4"></asp:PlaceHolder>
                            <br />
                             <div align="center">
                                <button type="button" class="collapsible">
                                    Add Report (load first)
                                </button>
                                <div class="content">

                                    <div style="border: 1px solid #555;">
                                        <p>
                                            Details:
                    <asp:TextBox ID="reportDetails" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            <asp:Button ID="createReportButton" runat="server" Text="Create Report" OnClick="createReport_Click" />
                                        </p>
                                    </div>
                                </div>
                        </div>
                            <br />
                                  <div align="center">
                                <button type="button" class="collapsible">
                                    Edit Report
                                </button>
                                <div class="content">

                                    <div style="border: 1px solid #555;">
                                        <p>
                                            Report ID:
                    <asp:TextBox ID="getReportIDToEdit" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            Details:&nbsp;
                    <asp:TextBox ID="getNewDetails" runat="server"></asp:TextBox>
                                        </p>
                                        <p>
                                            <asp:Button ID="UpdateDetailsOfReport" runat="server" Text="Update" OnClick="updateReport_Click" />
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
