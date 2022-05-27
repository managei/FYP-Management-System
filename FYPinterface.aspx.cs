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

            //getUserTable();
        }

    private void getUserTable()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name, Country FROM Customers"))
            {

                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.
                html.Append("<table border = '1'>");


                html.Append("<table>");
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
                //Table end.


                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                con.Close();
            }
        }
    }
    }
}