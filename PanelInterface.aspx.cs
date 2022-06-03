using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace FYP_Management_System_DB_Final_Project
{
    public partial class PanelInterface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Role"].ToString() != "PANEL")
                {
                    Response.Redirect("Login.aspx");
                }
                LoadUserName();
                LoadPanel();
                role.Text = "PANEL Member";

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
                    userName.Text = reader.GetValue(5).ToString();
                }
            }
        }

        protected void LoadPanel()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;

            string queryLogin = "SELECT P.panel_name,P.panel_id from FACULTY f,PANEL P where f.panel_id=P.panel_id and f.email='" + Session["Email"].ToString() + "'";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    LabelPanelName.Text = reader.GetValue(0).ToString();
                    Session["PanelId"] = reader.GetValue(1).ToString();
                }
            }
        }

        protected int calculateEvaluation()
        {

            int sum = 0;
            sum += (int.Parse(RadioButtonList1.SelectedValue));
            sum += (int.Parse(RadioButtonList2.SelectedValue));
            sum += (int.Parse(RadioButtonList3.SelectedValue));
            sum += (int.Parse(RadioButtonList4.SelectedValue));
            sum += (int.Parse(RadioButtonList5.SelectedValue));
            sum += (int.Parse(RadioButtonList6.SelectedValue));
            sum += (int.Parse(RadioButtonList7.SelectedValue));
            sum += (int.Parse(RadioButtonList8.SelectedValue));
            sum += (int.Parse(RadioButtonList9.SelectedValue));
            sum += (int.Parse(RadioButtonList10.SelectedValue));
            sum += (int.Parse(RadioButtonList11.SelectedValue));
            sum += (int.Parse(RadioButtonList12.SelectedValue));
            sum += (int.Parse(RadioButtonList13.SelectedValue));
            sum += (int.Parse(RadioButtonList14.SelectedValue));
            sum += (int.Parse(RadioButtonList15.SelectedValue));
            return sum;
        }
        protected string calculateGade(int marks)
        {
            string grade;
            if (marks < 75)
            {
                grade = "F";
            }
            else if (marks < 80)
            {
                grade = "D-";
            }
            else if (marks < 85)
            {
                grade = "D";
            }
            else if (marks < 90)
            {
                grade = "D+";
            }
            else if (marks < 95)
            {
                grade = "C-";
            }
            else if (marks < 100)
            {
                grade = "C";
            }
            else if (marks < 105)
            {
                grade = "C+";
            }
            else if (marks < 110)
            {
                grade = "B-";
            }
            else if (marks < 115)
            {
                grade = "B";
            }
            else if (marks < 120)
            {
                grade = "B+";
            }
            else if (marks < 130)
            {
                grade = "A-";
            }
            else if (marks < 140)
            {
                grade = "A";
            }
            else
            {
                grade = "A+";
            }
            return grade;
        }
        protected void SubmitEvaluation_Click(object sender, EventArgs e)
        {
            string grpId = TB_Groupid.Text.ToString();
            if (grpId != null)
            {

                int marks = calculateEvaluation();
                string grade = calculateGade(marks);
                string details = evalFormDetails.Text.ToString();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
                conn.Open();
                SqlCommand cmL;
                SqlCommand cmS;
                SqlCommand cm3;
                string queryLogin = "SELECT * from EVALUATIONS where panel_id=" + Session["PanelId"].ToString() + " and group_id=" + grpId;
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
                    else
                    {
                        cmL.Dispose();
                        reader.Close();
                        string querySign = "INSERT into EVALUATIONS (detail,group_id,panel_id,marks,grade) values('" + details + "'," + grpId + "," + Session["PanelId"].ToString() + "," + marks + ",'" + grade + "')";
                        cmS = new SqlCommand(querySign, conn);
                        if (cmS.ExecuteNonQuery() > 0)
                        {
                            string query3 = "update fyp SET Grade='" + grade + "' from FYP f,PROJECT_GROUP pg where f.fyp_Id=pg.fyp_id AND pg.group_id=" + grpId;
                            cm3 = new SqlCommand(query3, conn);
                            cm3.ExecuteNonQuery();
                            cm3.Dispose();
                        }
                        cmS.Dispose();
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Evaluation Done: Marks = " + marks + " out of 150 grade = '" + grade + ");", true);
                    }
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
                            PlaceHolderGroup.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        default:
                            break;
                    }
                    con.Close();
                }
            }
        }
        protected void LoadGroup_Click(object sender, EventArgs e)
        {
            loadTable("select g.group_id as GroupID,g.group_name as GroupName,e.marks as EvaluationMarks,e.grade as Grade,e.detail  from PROJECT_GROUP g inner join PANEL p on g.panel_id=p.panel_id left join EVALUATIONS e on e.group_id=g.group_id where p.panel_id=" + Session["PanelId"].ToString() + " order by g.group_id", 1);
        }

        protected void LoadFYP_Click(object sender, EventArgs e)
        {
            loadTable("SELECT f.* FROM FYP f LEFT JOIN PROJECT_GROUP pg ON pg.fyp_id= f.fyp_Id WHERE pg.fyp_id IS NULL", 1);
        }
        // add fyp to group
        protected void sbmtSlcFYP_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            int F_id = int.Parse(TB_slcFYP.Text);
            int G_id = int.Parse(TB_slcGrp.Text);

            string queryLogin = "update PROJECT_GROUP set fyp_id=" + F_id + " where group_id=" + G_id;
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            cmL.Dispose();
            reader.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added FYP to Group');", true);
            conn.Close();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelInterface.aspx");
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("Login.aspx");
        }

    }
}