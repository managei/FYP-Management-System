using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// imports
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace FYP_Management_System_DB_Final_Project
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Role"] != "FACULTY")
                {
                    Response.Redirect("Login.aspx");
                }
                    LoadUserName();
                    role.Text = "Faculty";
            }
        }
        protected void LoadUserName()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;

            string queryLogin = "SELECT * FROM FACULTY WHERE email='" + Session["Email"].ToString() + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    userName.Text = reader.GetValue(5).ToString();
                    //}
                }
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void loadTable(string query)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();

                    //PlaceHolder1.Controls.Clear();
                    //Table start.
                    html.Append("<table border = '1'>");


                    int index = 1;
                    while (sdr.Read())
                    {
                        if (index == 1)
                        {
                            html.Append("<tr>");
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                html.Append("<td>");
                                html.Append(sdr.GetName(i));
                                html.Append("</td>");
                            }
                            html.Append("</tr>");
                        }
                        index++;

                        html.Append("<tr>");
                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            html.Append("<td>");
                            html.Append(sdr.GetValue(i));
                            html.Append("</td>");
                        }
                        html.Append("</tr>");
                    }

                    html.Append("</table>");
                    html.Append("<br/>");
                    //Table end.


                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                    con.Close();
                }
            }
        }
        protected void LoadUsers_Click(object sender, EventArgs e)
        {
            loadTable("SELECT email FROM Users ");
        }
        protected void LoadStudents_Click(object sender, EventArgs e)
        {
            loadTable("SELECT student_id as id, student_name as Name, email as Email, group_id as GroupID FROM STUDENT");
        }
        protected void LoadFaculty_Click(object sender, EventArgs e)
        {
            loadTable("SELECT id, name as Name, email as Email, panel_id as PanelID,committee_id as CommitteeID FROM FACULTY");
        }

    }
}