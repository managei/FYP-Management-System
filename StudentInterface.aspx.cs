using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;


namespace FYP_Management_System_DB_Final_Project
{
    public partial class StudentInterface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Role"].ToString() != "STUDENT")
                {
                    Response.Redirect("Login.aspx");
                }
            }
            LoadUserName();
            LoadStudentID();
            //if (Session["GroupID"] != null)
            //    GetFYPDeadlines();
            role.Text = "STUDENT";


        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (!IsPostBack)
            {
                if (checkQueryIsNull("select s.group_id from STUDENT s where email='" + Session["Email"] + "'"))
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
                    conn.Open();
                    string q = "SELECT Deadline,Title from FYP inner join PROJECT_GROUP on FYP.fyp_Id=PROJECT_GROUP.fyp_id where group_id=" + Session["GroupID"].ToString();
                    SqlCommand cmL = new SqlCommand(q, conn);
                    SqlDataReader reader = cmL.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            DateTime date = (DateTime)reader.GetValue(0);
                            Label label1 = new Label();
                            label1.Text = "<br />" + reader.GetValue(1).ToString();
                            if (date == e.Day.Date)
                            {
                                e.Cell.BackColor = System.Drawing.Color.Red;
                                e.Cell.Font.Italic = true;
                                e.Cell.Font.Size = FontUnit.Small;
                                e.Cell.Controls.Add(label1);
                            }

                        }
                    }
                    conn.Close();
                }
            }

        }
        protected void LoadstudentNotify_Click(object sender, EventArgs e)
        {
            string q = "select n.group_id from Notifications n inner join STUDENT s on n.group_id=s.group_id where email='" + Session["Email"] + "'";
            if (checkQueryIsNull(q))
                loadTable(q, 1);
        }

        protected void LoadstudentReview_Click(object sender, EventArgs e)
        {
            string q = "select r.supervisor_id,f.name,r.detail from REVIEWS r inner join STUDENT s on r.group_id=s.group_id inner join FACULTY f on r.supervisor_id=f.id where s.email='" + Session["Email"] + "'";
            if (checkQueryIsNull(q))
                loadTable(q, 1);
        }

        protected void LoadStudentID()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            string q = "select s.student_id, s.group_id from STUDENT s where email='" + Session["Email"] + "'";
            SqlCommand cmL = new SqlCommand(q, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    Session["StudentID"] = reader.GetValue(0).ToString();
                    Session["GroupID"] = reader.GetValue(1).ToString();
                    //}
                }
            }
            conn.Close();
        }
        protected void LoadUserName()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;

            string queryLogin = "SELECT * FROM STUDENT WHERE email='" + Session["Email"].ToString() + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    userName.Text = reader.GetValue(4).ToString();
                }
            }
        }

        protected void LoadstudentData_Click(object sender, EventArgs e)
        {
            string q = "select s.student_id,s.email,s.student_name,s.group_id from STUDENT s where email='" + Session["Email"] + "'";
            if (checkQueryIsNull(q))
                loadTable(q, 1);
        }

        protected void LoadstudentFYPData_Click(object sender, EventArgs e)
        {
            string q = "select f.* from FYP f inner join PROJECT_GROUP g on f.fyp_Id=g.fyp_id inner join STUDENT s on s.group_id=g.group_id where email='" + Session["Email"] + "'";
            if (checkQueryIsNull(q))
                loadTable(q, 1);
        }

        protected void LoadstudentGroupData_Click(object sender, EventArgs e)
        {
            string q = "select g.* from PROJECT_GROUP g inner join STUDENT s on s.group_id=g.group_id where email='" + Session["Email"] + "'";
            if (checkQueryIsNull(q))
                loadTable(q, 1);
        }

        protected void LoadstudentGroupMembersData_Click(object sender, EventArgs e)
        {
            string q = "select s.student_id,s.student_name,s.email,s.group_id,g.group_name from STUDENT s inner join PROJECT_GROUP g on s.group_id=g.group_id where s.group_id=(select group_id from STUDENT where email='" + Session["Email"] + "')";
            if (checkQueryIsNull(q))
                loadTable(q, 1);
        }

        protected void hideTbl_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Controls.Clear();
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
            //Response.Redirect("")
        }

        protected bool checkQueryIsNull(string q)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            //string q = "select s.student_id from STUDENT s where email='" + Session["Email"] + "'";
            SqlCommand cmL = new SqlCommand(q, conn);
            object temp = cmL.ExecuteScalar();
            if (temp != null && temp.GetType() != typeof(DBNull))
            {
                return true;
            }
            conn.Close();
            return false;
        }

        protected void loadTable(string query, int placeholderID)
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
                            //PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 3:
                            //PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 4:
                            //PlaceHolder4.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        default:
                            break;
                    }
                    // PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                    con.Close();
                }
            }
        }

    }
}