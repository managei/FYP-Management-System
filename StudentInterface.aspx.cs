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
    public partial class StudentInterface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Role"]!="STUDENT")
                {
                    Response.Redirect("Login.aspx");
                }
            }
                    LoadUserName();
                    role.Text = "Student";
        }
        protected void LoadUserName()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;

            string queryLogin = "SELECT * FROM STUDENT WHERE email='" + Session["Email"].ToString() + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                        userName.Text = reader.GetValue(4).ToString();
                    //}
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentInterface.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {

        }
    }
}