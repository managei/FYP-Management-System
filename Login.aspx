<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FYP_Management_System_DB_Final_Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            font-weight: bold;
            margin-top: 0px;
            margin-bottom: 1px;
            text-align:center;
        }

        #Select1 {
            width: 114px;
        }

    </style>
</head>
<body>
        <form id="form1" runat="server">
         <div style=" margin: auto;
          width: 50%;
          border: 3px solid #000000;
          background: #F6F5FC;
          padding: 10px;">
            <h1>Login</h1>
            <div align="center" style="margin:auto; width:90%">
                <p>-----------------------------------------</p>
                <p>Insert Required Data :</p>
                <p>
                    Select User:

                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="FACULTY">Faculty Member</asp:ListItem>
                        <asp:ListItem Value="STUDENT">Student</asp:ListItem>
                    </asp:DropDownList>

                </p>
                <p>Email:
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </p>
                <p>Password:
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </p>
                
                <p style="text-align:center">
                    <asp:Button ID="clearbutton" runat="server" OnClientClick="return false;" OnClick="clearbutton_Click" Text="Clear" />
                    <asp:Button ID="submitButton" runat="server"  Text="Submit" OnClick="submitButton_Click"  />
                </p>
            </div>
        </div>
    </form>
</body>
</html>
