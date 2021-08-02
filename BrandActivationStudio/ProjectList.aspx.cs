using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandActivationStudio
{
    public partial class ProjectList : System.Web.UI.Page
    {
        string strConnection = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login");
            }
            else
            {
                // create dynamic table to display on screen
                string tabledata = "<table class='table'><thead>" +
                                  "<tr><th>Project Code</th>" +
                                  "<th>Project Name</th>" +
                                  "<th>Start Date</th>" +
                                  "<th>End Date</th>" +
                                  "<th></th></tr></thead><tbody>";

                using (SqlConnection con = new SqlConnection(strConnection))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("GetAllTProject", con);
                        cmd.Parameters.AddWithValue("@UserId", Session["UserId"]);
                        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                        dataadapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime startdate = (DateTime)reader["StartDate"];
                            DateTime enddate = (DateTime)reader["EndDate"];
                            
                            tabledata += "<tr>" +
                                        "<td>" + reader["ProjectCode"].ToString() + "</td>" +
                                        "<td>" + reader["Projectname"].ToString() + "</td>" +
                                        "<td>" + startdate.ToString("dd-MM-yyyy") + "</td>" +
                                        "<td>" + enddate.ToString("dd-MM-yyyy") + "</td>" +
                                        "<td>" +
                                        "<a href='EditProject?ProjectId=" + reader["ProjectId"] + "'>" +
                                        "<span class='glyphicon glyphicon-pencil'></span> Edit</a> | " +
                                        "<a href='DeleteProject?ProjectId=" + reader["ProjectId"] + "'>" +
                                        "<span class='glyphicon glyphicon-trash'></span> Delete</a>" +
                                        "</td>" +
                                        "</tr>";

                        }

                        tabledata += "</tbody></table>"; // Close dynamic table
                        divProjects.InnerHtml = tabledata;

                    }
                    catch (Exception)
                    {
                    }
                }
            }

        }


        // This section exports data to excel
        protected void ExportCSV(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                // We will only export active projects
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tProject WHERE UserId = '" + Session["UserId"]+"' AND Active = 1"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the CSV file data as a Comma separated string.
                            string csv = string.Empty;

                            foreach (DataColumn column in dt.Columns)
                            {
                                //Add the Header row for CSV file.
                                csv += column.ColumnName + ',';
                            }

                            //Add new line.
                            csv += "\r\n";

                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    //Add the Data rows.
                                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                                }

                                //Add new line.
                                csv += "\r\n";
                            }

                            //Download the CSV file.
                            Response.Clear();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", "attachment;filename=ProjectList.csv");
                            Response.Charset = "";
                            Response.ContentType = "application/text";
                            Response.Output.Write(csv);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }
    }
}