﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

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
                        //case 2:
                        //    PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
                        //    break;
                        //case 3:
                        //    PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
                        //    break;
                        //case 4:
                        //    PlaceHolderCommitee.Controls.Add(new Literal { Text = html.ToString() });
                        //    break;
                        //case 5:
                        //    PlaceHolder5.Controls.Add(new Literal { Text = html.ToString() });
                        //    break;
                        default:
                            break;
                    }
                    con.Close();
                }
            }
        }
        protected void LoadGroup_Click(object sender, EventArgs e)
        {
            loadTable("select", 1);
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