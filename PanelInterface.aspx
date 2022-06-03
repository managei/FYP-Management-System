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
                            <div align="center">
                                <asp:Button CssClass="button" ID="LoadFYP" runat="server" Text="Load Unassigned FYP's" OnClick="LoadFYP_Click" />
                                <asp:Button CssClass="button" ID="LoadGroup" runat="server" Text="Load Ongoing Groups" OnClick="LoadGroup_Click" />
                                <asp:Button CssClass="button spcBtn" ID="HideTable1" runat="server" Text="Hide Table" />
                                <asp:PlaceHolder ID="PlaceHolderGroup" runat="server"></asp:PlaceHolder>
                                <p></p>
                                <button type="button" class="collapsible">Add FYP to Group</button>
                                <div class="content">
                                    <p>
                                        Select FYP: 
                                        <asp:TextBox ID="TB_slcFYP" runat="server"></asp:TextBox>
                                    </p>
                                    <p>
                                        Select Group: 
                                        <asp:TextBox ID="TB_slcGrp" runat="server"></asp:TextBox>
                                    </p>
                                    <p>
                                        <asp:Button CssClass="button sucBtn" ID="sbmtSlcFYP" runat="server" Text="Submit" OnClick="sbmtSlcFYP_Click" />
                                    </p>
                                </div>
                                <p></p>
                            </div>
                            <p></p>
                            <button type="button" class="collapsible">Evalaute Group</button>
                            <div class="content">
                                <p>Lorem ipsum...</p>
                                <div align="center">
                                    <p>
                                        Group Id:
                                    <asp:TextBox ID="TB_Groupid" runat="server"></asp:TextBox>
                                    </p>
                                    <hr />
                                    <p>
                                        1. FYP Poster
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        2. Iteration Definition, FYP Plan, Work Breakdown 
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        3. Work completed for the iterations(s) including design and implementation
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        4. Slide Design and Content Quality
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        5. Style (Delivery, Confidence, Clarity)
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        6. Clarity of Project Scope
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        7. Definition of Project Features
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        8. Team Dynamics( Coordination among Team Members)
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        9. Timing of Presentation
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        10. Implementation Work Completion
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        11. Overall Work Completion
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        12. Code Quality
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        13. Level of Code Integration
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        14. Class Diagram/DFD (provided in the report) correctly maps to Code Implementated 
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList14" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>
                                        15. Handling Of Questions
                                    </p>
                                    <p>
                                        Min
                                <asp:RadioButtonList ID="RadioButtonList15" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="0" Value="0" Selected="True" />
                                    <asp:ListItem Text="1" Value="1" />
                                    <asp:ListItem Text="2" Value="2" />
                                    <asp:ListItem Text="3" Value="3" />
                                    <asp:ListItem Text="4" Value="4" />
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="6" Value="6" />
                                    <asp:ListItem Text="7" Value="7" />
                                    <asp:ListItem Text="8" Value="8" />
                                    <asp:ListItem Text="9" Value="9" />
                                    <asp:ListItem Text="10" Value="10" />
                                </asp:RadioButtonList>
                                        Max
                                    </p>
                                    <hr />
                                    <p>Details:</p>
                                    <asp:TextBox Width="75%" Height="100px" ID="evalFormDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <hr />
                                    <asp:Button CssClass="button sucBtn" ID="SubmitEvaluation" runat="server" Text="Submit Evaluation" OnClick="SubmitEvaluation_Click" />
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
