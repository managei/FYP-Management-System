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
        //protected bool ReportsLoadedState = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Role"].ToString() != "COMMITTEE")
                {
                    Response.Redirect("Login.aspx");
                }
                LoadUserName();

                LoadCommittee();
                role.Text = "COMMITTEE Member";
                getReportCount();
            }
        }
        protected void LoadCommittee()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;

            string queryLogin = "SELECT fc.comittee_name,fc.committee_id from FACULTY f,FYP_COMMITTEE fc where f.committee_id=fc.committee_id and f.email='" + Session["Email"].ToString() + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    LabelCommName.Text = reader.GetValue(0).ToString();
                    Session["CommitteeID"]=reader.GetValue(1).ToString();
                }
            }
        }
        protected void LoadUserName()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            //SqlCommand cmS;

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

        protected bool checkQueryIsNull(string q)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            //string q = "select s.student_id from STUDENT s where email='" + Session["Email"] + "'";
            SqlCommand cmL = new SqlCommand(q, conn);

            if (cmL.ExecuteScalar() == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No Data');", true);
                return true;
            }
            conn.Close();
            return false;
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void createReport_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Loading Reports First');", true);
            getReportCount();
            //LoadReports_Click();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;

            string details = reportDetails.Text;
            int reportID = int.Parse(Session["ReportCount"].ToString())+1;
            if (reportID < 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error in insertion');", true);
                return;
            }
            string q1 = "INSERT INTO REPORTS (comittee_id,report_id,detail) VALUES (" + Session["CommitteeID"] + "," + reportID + ",'" + details +"')";

            cmL = new SqlCommand(q1, conn);
            
            if (details == "")
            {
                conn.Close();
                return;
            }

            int affected = cmL.ExecuteNonQuery();
            if (affected > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Report Added');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error in insertion');", true);
            }
            LoadReports_Click();
            conn.Close();
        }

        protected void getReportCount()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            string q2 = "select count(r.report_id) from reports r inner join FACULTY f on f.committee_id=r.comittee_id where f.email='" + Session["Email"] + "'";
            cmL = new SqlCommand(q2, conn);
            
            if (cmL.ExecuteScalar()==null)
            {
                Session["ReportCount"] = 0;
            }
            else
            {
                Session["ReportCount"]= cmL.ExecuteScalar().ToString();
            }
            conn.Close ();
        }

        protected void ClearDMLLog_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            string q2 = "truncate table AuditLog";
            cmL = new SqlCommand(q2, conn);
            cmL.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Cleared DML Log');", true);
            conn.Close();
        }
        protected void LoadReports_Click(object sender, EventArgs e)
        {
            getReportCount();
            if (loadAllReports.Checked == false)
            {
                string q = "select* from reports";
                if(checkQueryIsNull(q)==false)
                loadTable(q, 4);
            }
            else
            {
                string q = "select r.* from reports r inner join FACULTY f on f.committee_id=r.comittee_id where f.email='" + Session["Email"] + "'";
                if (checkQueryIsNull(q) == false)
                    loadTable(q, 4);
            }
        }

        protected void LoadDMLLog_Click(object sender, EventArgs e)
        { 
           string q = "select* from AuditLOG";
           if (checkQueryIsNull(q) == false)
               loadTable(q, 8);
        }

        protected void LoadDDLLog_Click(object sender, EventArgs e)
        {
            string q = "select* from AUDIT_LOG_DDL";
            if (checkQueryIsNull(q) == false)
                loadTable(q, 8);
        }


        protected void LoadReports_Click()
        {
            getReportCount();
            if (loadAllReports.Checked == false)
            {
                loadTable("select* from reports", 4);
            }
            else
            {
                string q = "select r.* from reports r inner join FACULTY f on f.committee_id=r.comittee_id where f.email='" + Session["Email"] + "'";
                loadTable(q, 4);
            }
        }

        protected void updateReport_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            string rID = getReportIDToEdit.Text;
            string details = getNewDetails.Text;
            string q= "update REPORTS set detail = '"+ details +"' where report_id = '"+rID+"' and comittee_id = '"+Session["CommitteeID"] + "'";
            cmL = new SqlCommand(q, conn);
            if(rID=="" || details == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Incorrect Data');", true);
                return;
            }
            if (cmL.ExecuteNonQuery() > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update Error');", true);

            }
            conn.Close();
        }
        protected void addStudentToGroup(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL, cmL2, cmL3;
            string studentID = getStudentID.Text;
            string groupID = getGroupID.Text;

            if (studentID == "" || groupID == "")
            {
                conn.Close();
                return;
            }

            string q1 = "select student_id from STUDENT where student_id=" + studentID;
            string q2 = "select group_id from PROJECT_GROUP where group_id=" + groupID;
            string queryLogin = "update STUDENT set group_id =" + groupID + "where student_id =" + studentID;

            cmL = new SqlCommand(queryLogin, conn);
            cmL2 = new SqlCommand(q1, conn);
            cmL3 = new SqlCommand(q2, conn);

            if (cmL2.ExecuteScalar() == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No such Student ID');", true);
                conn.Close();
                return;
            }
            else if (cmL3.ExecuteScalar() == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No such Group ID');", true);
                conn.Close();
                return;
            }

            int affected = cmL.ExecuteNonQuery();
            if (affected > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Student Added');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error in update');", true);
            }
            conn.Close();

        }

        protected void createGroup(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL, cmL2, cmL3, cmL4;
            string Gname = GroupNameBox.Text;
            string G_PID = GroupPanelIDBox.Text;
            string G_SID = GroupSuperID.Text;
            string G_CID = GroupCommitteeID.Text;

            string q1 = "select panel_id from panel where panel_id=" + G_PID;
            string q2 = "select committee_id from FYP_COMMITTEE where committee_id=" + G_CID;
            string q3 = "select faculty_id from supervisor where faculty_id=" + G_SID;

            cmL2 = new SqlCommand(q1, conn);
            cmL3= new SqlCommand(q2, conn);
            cmL4= new SqlCommand(q3, conn);

            if (G_PID == "" || G_SID == "" || G_CID == "")
            {
                conn.Close();
                return;
            }

            if (cmL2.ExecuteScalar() == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No such Panel ID');", true);
                conn.Close();
                return;
            }else if (cmL3.ExecuteScalar() == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No such Committee ID');", true);
                conn.Close();
                return;
            }else if (cmL4.ExecuteScalar() == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No such Supervisor ID');", true);
                conn.Close();
                return;
            }

            string queryLogin = "INSERT INTO PROJECT_GROUP(group_name,panel_id, supervisor_id, committee_id) values ('" + GroupNameBox.Text.ToString() + "'," + GroupPanelIDBox.Text.ToString() + "," + GroupSuperID.Text.ToString() + "," + GroupCommitteeID.Text.ToString() + ");";
            cmL = new SqlCommand(queryLogin, conn);
            int affected = cmL.ExecuteNonQuery();
            if (affected >0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Group Added');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error in insertion');", true);
            }
            conn.Close();
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
                            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 3:
                            PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 4:
                            PlaceHolder4.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 5:
                            PlaceHolder5.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 6:
                            PlaceHolderSuprv.Controls.Add(new Literal { Text = html.ToString() });
                            break ;
                        case 7:
                            PlaceHolderCommitee.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        case 8:
                            PlaceHolder6.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        default:
                            break;
                    }
                   // PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
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
        protected void loadCommites_Click(object sender, EventArgs e)
        {
            loadTable("select committee_id as ID,comittee_name as Committee_Name from FYP_COMMITTEE", 7);
        }
        protected void LoadGroups_Click(object sender, EventArgs e)
        {
            loadTable("SELECT* from Project_Group", 3);
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
        protected void Button7_Click(object sender, EventArgs e)
        {
            loadTable("select fyp_Id as Id,Title,Deadline,Grade,Comment from FYP", 2);
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            loadTable("select panel_id as Id,panel_name as Panel_Name from PANEL", 5);
        }

        protected void loadSupervisor_Click(object sender, EventArgs e)
        {
            loadTable("select s.faculty_id as SupervisorID,f.name,f.email,f.panel_id,f.committee_id from SUPERVISOR s inner join FACULTY f on s.faculty_id=f.id", 6);
        }
        protected void addUserBtn(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            SqlCommand cmS2;
            string uName = TextBox1.Text.ToString();
            string email = TextBox2.Text.ToString();
            string pass = TextBox3.Text.ToString();

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
        protected void addFacultyBtn(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            SqlCommand cmS2;
            string uName = F_UName.Text.ToString();
            string email = F_Email.Text.ToString();
            string pass = F_Pass.Text.ToString();

            string queryLogin = "select * from Faculty where email='" + email + "'";
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
                    string querySign = "INSERT INTO USERS (email,password) VALUES ('" + email + "','" + pass + "')";
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    cmS.Dispose();

                    string querySign2 = "INSERT INTO Faculty(email, password, name) VALUES('" + email + "', '" + pass + "','" + uName + "')";
                    cmS2 = new SqlCommand(querySign2, conn);
                    cmS2.ExecuteNonQuery();
                    cmS2.Dispose();
                    conn.Dispose();
                    //goto Rent Car Page
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Added in Database.');", true);
                }
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            string cName = commNameText.Text.ToString();

            string queryLogin = "select * from FYP_COMMITTEE where comittee_name='" + cName + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    cmL.Dispose();
                    conn.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Allready in Database');", true);
                }
                else if (cName != "")
                {
                    cmL.Dispose();
                    reader.Close();
                    string querySign = "INSERT INTO FYP_COMMITTEE (comittee_name) VALUES ('" + cName + "')";
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    cmS.Dispose();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Comitte added Added in Database.');", true);
                }
            }
        }
        //add Committe Member
        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            int F_id = int.Parse(TB_addMemComm2.Text);
            int FC_id = int.Parse(TB_addMemComm1.Text);

            string queryLogin = "update FACULTY set committee_id=" + FC_id + " where id=" + F_id;
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update not possible');", true);
                    cmL.Dispose();
                    conn.Close();
                }
                else
                {
                    cmL.Dispose();
                    reader.Close();
                    string querySign = "update USERS set role='COMMITTEE' from USERS u,Faculty f where u.email=f.email AND f.id=" + F_id;
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    cmS.Dispose();
                    conn.Close();
                }
            }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            string Fyp_Name = TextBox4.Text.ToString();
            DateTime date = Calendar1.SelectedDate;
            string queryLogin = "select * from FYP where Title='" + Fyp_Name + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    cmL.Dispose();
                    conn.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('FYP allready exist with this name');", true);
                }
                else if (Fyp_Name != "")
                {
                    cmL.Dispose();
                    reader.Close();
                    string querySign = "insert INTO FYP (Title,Deadline) VALUES('" + Fyp_Name + "','" + date + "')";
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    cmS.Dispose();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('FYP Added in Database.');", true);
                }
            }
        }
        protected void Button12_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            string PanelName = TB_addPanelName.Text.ToString();
            string queryLogin = "select * from PANEL where panel_name='" + PanelName + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    cmL.Dispose();
                    conn.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('FYP allready exist with this name');", true);
                }
                else if (PanelName != "")
                {
                    cmL.Dispose();
                    reader.Close();
                    string querySign = "insert INTO PANEL (panel_name) VALUES('" + PanelName + "')";
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    cmS.Dispose();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Panel Added in Database.');", true);
                }
            }
        }
        // add panel member
        protected void Button13_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            int F_id = int.Parse(TB_addMemPanel2.Text);
            int P_id = int.Parse(TB_addMemPanel1.Text);

            string queryLogin = "update FACULTY set panel_id=" + P_id + " where id=" + F_id;
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update not possible');", true);
                    cmL.Dispose();
                    conn.Close();
                }
                else
                {
                    cmL.Dispose();
                    reader.Close();
                    string querySign = "update USERS set role='PANEL' from USERS u,Faculty f where u.email=f.email AND f.id=" + F_id;
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added user: " + F_id + " to panel: " + P_id + "');", true);

                    cmS.Dispose();
                    conn.Close();
                }

            }
        }

        //Add supervisor
        protected void BTNsubmitSuprv_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            int F_id = int.Parse(TB_setSuprv.Text);

            string queryLogin = "insert SUPERVISOR (faculty_id) values('"+F_id+"')";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            cmL.Dispose();
            reader.Close();
            conn.Close();
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
        protected void HideComms_Click(object sender, EventArgs e)
        {
            PlaceHolderCommitee.Controls.Clear();
        }
        protected void Button11_Click(object sender, EventArgs e)
        {
            PlaceHolder5.Controls.Clear();
        }

    }
}