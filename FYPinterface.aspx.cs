using System;
using System.Configuration;
using System.Data.SqlClient;
// imports
using System.Text;
using System.Web.UI.WebControls;

namespace FYP_Management_System_DB_Final_Project
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Role"].ToString() != "COMMITTEE")
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
                    html.Append("<table style=\"width:100%; border-collapse: collapse;\">");

                    int index = 1;
                    while (sdr.Read())
                    {
                        if (index == 1)
                        {
                            html.Append("<tr>");
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                html.Append("<th style=\"padding-top: 12px; padding-bottom: 12px; color:white; background-color:#645F88; color:white;\">");
                                html.Append(sdr.GetName(i));
                                html.Append("</th>");
                            }
                            html.Append("</tr>");
                        }
                        index++;

                        string temp;
                        html.Append("<tr>");
                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            temp = sdr.GetValue(i).ToString();
                            html.Append("<td style=\"border: 1px solid #ddd; padding: 8px;\">");
                            if (temp == "")
                                html.Append("Not Assigned");
                            else
                                html.Append(temp);
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

        protected void loadTable(string query,int placeholderID)
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
                    html.Append("<table style=\"width:100%; border-collapse: collapse;\">");

                    int index = 1;
                    while (sdr.Read())
                    {
                        if (index == 1)
                        {
                            html.Append("<tr>");
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                html.Append("<th style=\"padding-top: 12px; padding-bottom: 12px; color:white; background-color:#645F88; color:white;\">");
                                html.Append(sdr.GetName(i));
                                html.Append("</th>");
                            }
                            html.Append("</tr>");
                        }
                        index++;

                        string temp;
                        html.Append("<tr>");
                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            temp = sdr.GetValue(i).ToString();
                            html.Append("<td style=\"border: 1px solid #ddd; padding: 8px;\">");
                            if (temp == "")
                                html.Append("Not Assigned");
                            else
                                html.Append(temp);
                            html.Append("</td>");
                        }
                        html.Append("</tr>");
                    }

                    html.Append("</table>");
                    html.Append("<br/>");
                    //Table end.


                    //Append the HTML string to Placeholder.
                    switch (placeholderID)
                    {
                        case 1:
                            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 2:
                            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 3:
                            PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                            default:
                            break;
                    }
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                    con.Close();
                }
            }
        }
        protected void LoadUsers_Click(object sender, EventArgs e)
        {
            loadTable("SELECT f.name as Name, f.email as Email, u.role from USERS u inner join FACULTY F on F.email = u.email UNION SELECT s.student_name as Name, s.email as Email, u.role from USERS u inner join STUDENT s on s.email = u.email ORDER by u.role");
        }
        protected void LoadStudents_Click(object sender, EventArgs e)
        {
            loadTable("SELECT student_id as id, student_name as Name, email as Email, group_id as GroupID FROM STUDENT");
        }
        protected void LoadFaculty_Click(object sender, EventArgs e)
        {
            loadTable("SELECT id, name as Name, email as Email, panel_id as PanelID,committee_id as CommitteeID FROM FACULTY");
        }

        protected void LoadGroups_Click(object sender, EventArgs e)
        {
            loadTable("SELECT* from Project_Group",3);
        }

        protected void LoadGroupFYP_Click(object sender, EventArgs e)
        {
            loadTable("SELECT group_id,g.group_name,f.* from Project_Group g inner join FYP f on g.fyp_id=f.fyp_Id", 3);
        }

        protected void LoadGroupMembers_Click(object sender, EventArgs e)
        {
            loadTable("select s.student_id,s.student_name,g.group_id,g.group_name from STUDENT s inner join PROJECT_GROUP g on s.group_id=g.group_id order by g.group_id", 3);
        }
        protected void LoadGroupSuper_Click(object sender, EventArgs e)
        {
            loadTable("select s.faculty_id as SupervisorId,g.group_id,f.name from SUPERVISOR s inner join PROJECT_GROUP g on s.faculty_id=g.supervisor_id inner join FACULTY f on s.faculty_id=f.id union select c.co_supervisor_id  as SupervisorId ,g.group_id,f.name from CO_SUPERVISOR c inner join PROJECT_GROUP g on c.group_id=g.group_id inner join FACULTY f on c.co_supervisor_id=f.id", 3);
        }
        protected void LoadGroupPanel_Click(object sender, EventArgs e)
        {
            loadTable("select g.group_id,g.group_name,p.* from PROJECT_GROUP g inner join PANEL p on g.panel_id=p.panel_id order by g.group_id", 3);
        }
        protected void addUserBtn(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            SqlCommand cmS2;
            string uName= TextBox1.Text.ToString();
            string email= TextBox2.Text.ToString();
            string pass= TextBox3.Text.ToString();

            string queryLogin = "select * from Student where email='" + email + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    //user Exist
                    cmL.Dispose();
                    conn.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Allready in Database');", true);
                }
                else if (email != "" && pass != "" && uName != "")
                {
                    cmL.Dispose();
                    reader.Close();
                    //user does not
                    //Create new User
                    string querySign = "INSERT INTO USERS (email,password,role) VALUES ('" + email + "','" + pass + "','STUDENT')";
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    cmS.Dispose();

                    string querySign2 = "INSERT INTO Student(email, password, student_name) VALUES('" + email + "', '" + pass + "','" + uName + "')";
                    cmS2 = new SqlCommand(querySign2, conn);
                    cmS2.ExecuteNonQuery();
                    cmS2.Dispose();
                    conn.Dispose();
                    //goto Rent Car Page
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Added in Database.');", true);
                }
            }
        }

        protected void hideTbl_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Controls.Clear();
        }
        protected void hideTbl2_Click(object sender, EventArgs e)
        {
            PlaceHolder2.Controls.Clear();
        }
        protected void hideTbl3_Click(object sender, EventArgs e)
        {
            PlaceHolder3.Controls.Clear();
        }
    }
}