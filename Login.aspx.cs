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

            string queryLogin;
            if (DropDownList1.Text == "FACULTY")
                queryLogin = "select * from FACULTY where email='" + email + "' and password='" + pass + "'";
            else
                queryLogin = "select * from Student where email='" + email + "' and password='" + pass + "'";

            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    //user exists
                    //goto Rent Car Page
                    cmL.Dispose();
                    conn.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Logged In.');", true);
                    Session["Email"] = email;
                    Session["Role"] = DropDownList1.Text;
                    if (DropDownList1.Text == "FACULTY")
                    {
                        Response.Redirect("FYPinterface.aspx");
                    }
                    else
                    {
                        Response.Redirect("StudentInterface.aspx");

                    }

                }
            }
        }
    }
}