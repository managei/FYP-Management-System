using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace FYP_Management_System_DB_Final_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void clearbutton_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        protected void submitButton_Click(object sender, EventArgs e)
        {
            //Connection String
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            string email = TextBox1.Text;
            string pass = TextBox2.Text;
            string role;

            string queryLogin;
            queryLogin = "select role from USERS where email='" + email + "' and password='" + pass + "'";

            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    //user exists
                    //goto Rent Car Page
                    role = reader.GetValue(0).ToString();
                    cmL.Dispose();
                    conn.Close();
                    Session["Email"] = email;
                    Session["Role"] = role;
                    if (role == "COMMITTEE")
                    {
                        Response.Redirect("FYPinterface.aspx");
                    }
                    else if (role == "STUDENT") 
                    {
                        Response.Redirect("StudentInterface.aspx");
                    }
                    else if (role == "PANEL")
                    {
                        Response.Redirect("PanelInterface.aspx");
                    }
                    else 
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Not assigned to any Role current Role : " + role + " ); ", true);
                    }
                }
            }
        }
    }
}