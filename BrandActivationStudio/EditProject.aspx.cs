using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandActivationStudio
{
    public partial class EditProject : System.Web.UI.Page
    {
        string strConnection = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login");
            }

            if(!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(strConnection))
                {
                    try
                    {
                        // Lets auto populate the input-boxes
                        if (Request.QueryString["ProjectId"].ToString() != null)
                        txtProjectId.Value = Request.QueryString["ProjectId"].ToString();

                        con.Open();
                        SqlCommand cmd = new SqlCommand("GetSelectedTProject", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProjectId", txtProjectId.Value);
                        
                        SqlDataReader reader  = cmd.ExecuteReader();
                        if(reader.Read())
                        {
                            DateTime startdate = (DateTime)reader["StartDate"];
                            DateTime enddate = (DateTime)reader["EndDate"];

                            txtEditProjectCode.Value = reader["ProjectCode"].ToString();
                            txtEditProjectName.Value = reader["Projectname"].ToString();
                            txtEditProjectDescription.Value = reader["ProjectDescription"].ToString();
                            txtEditStartDate.Value = startdate.ToString("yyyy-MM-dd");
                            txtEditEndDate.Value = enddate.ToString("yyyy-MM-dd");
                        }

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        protected void btnEditProject_Click(object sender, EventArgs e)
        {

            if (!txtEditProjectCode.Value.Equals("") && !txtEditProjectName.Value.Equals(""))
            {
                using (SqlConnection con = new SqlConnection(strConnection))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UpdateTProject", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ProjectId", txtProjectId.Value);
                        cmd.Parameters.AddWithValue("@ProjectCode", txtEditProjectCode.Value);
                        cmd.Parameters.AddWithValue("@Projectname", txtEditProjectName.Value);
                        cmd.Parameters.AddWithValue("@ProjectDescription", txtEditProjectDescription.Value);
                        cmd.Parameters.AddWithValue("@StartDate", txtEditStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", txtEditEndDate.Value);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        // Once we reach here the project is successfully created, redirect to project list                        
                        editmsgbox.InnerHtml = "<p class='alert alert-info'>Project updated successfully!</p>";
                        Response.Redirect("~/ProjectList");
                    }
                    catch (Exception ex)
                    {
                    }
                }
            } else
            {
                editmsgbox.InnerHtml = "<p class='alert alert-danger'>Something went wrong, make sure to fill all required fields.</p>";
            }
        }
    }
}