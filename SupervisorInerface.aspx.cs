﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;
namespace FYP_Management_System_DB_Final_Project
{
    public partial class SupervisorInerface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Role"].ToString() != "SUPERVISOR")
                {
                    Response.Redirect("Login.aspx");
                }
                LoadUserName();
                role.Text = "Supervisor";
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
                    Session["Sup_id"] = reader.GetValue(2).ToString();
                    userName.Text = reader.GetValue(5).ToString();
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
                        case 2:
                            PlaceHolder7.Controls.Add(new Literal { Text = html.ToString() });
                            break;
                        default:
                            break;
                    }
                    con.Close();
                }
            }
        }
        protected void LoadGroups_Click(object sender, EventArgs e)
        {
            loadTable("select pg.* from PROJECT_GROUP pg inner join SUPERVISOR s on pg.supervisor_id=s.faculty_id where s.faculty_id=" + Session["Sup_id"].ToString(), 1);
        }

        protected void LoadReviews_Click(object sender, EventArgs e)
        {
            loadTable("SELECT* from REVIEWS where supervisor_id = " + Session["Sup_id"].ToString(), 1);
        }

        protected void HideT1_Click(object sender, EventArgs e)
        {
            PlaceHolderGroup.Controls.Clear();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorInerface.aspx");
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("Login.aspx");
        }
        protected void BtnAddReview_Click(object sender, EventArgs e)
        {
            string grpID = TB_grpId.Text.ToString();
            string revdet = TB_reviewDetail.Text.ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            string queryLogin = "INSERT INTO REVIEWS (detail,group_id,supervisor_id) VALUES ('" + revdet + "'," + grpID + "," + Session["Sup_id"].ToString() + ")";
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            cmL.Dispose();
            conn.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            loadTable("select group_id as GroupSentTo,details as Details from Notifications where supervisor_id=" + Session["Sup_id"].ToString(), 2);
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            PlaceHolder7.Controls.Clear();
        }

        protected void Button15_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString); //Connection String
            conn.Open();
            SqlCommand cmL;
            SqlCommand cmS;
            string G_id = TextBox6.Text.ToString();
            string details = TextBox5.Text.ToString();
            string queryLogin = "select * from PROJECT_GROUP where group_id=" + G_id;
            cmL = new SqlCommand(queryLogin, conn);
            SqlDataReader reader = cmL.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    cmL.Dispose();
                    reader.Close();
                    string querySign = "insert Notifications(group_id,supervisor_id,details) VALUES (" + G_id + "," + Session["Sup_id"].ToString() + ",'" + details + "')";
                    cmS = new SqlCommand(querySign, conn);
                    cmS.ExecuteNonQuery();
                    cmS.Dispose();
                }
                else
                {
                    cmL.Dispose();
                    conn.Close();
                }
            }
        }
    }
}