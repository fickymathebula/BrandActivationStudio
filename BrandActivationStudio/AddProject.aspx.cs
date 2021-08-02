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
    public partial class AddProject : System.Web.UI.Page
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
                // Lets have start and end date ppulated, atleast using current date
                txtStartDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            // These are our defaut values when creating ne project (current date, active flag true and userid as currently logged in user)
            DateTime today = DateTime.Now;
            bool active = true;
            int userid = (int)Session["UserId"];

            //DateTime inStartDate = (DateTime);
            //DateTime inEndDate = (DateTime)txtEndDate.Value.ToString();


            if (!txtProjectCode.Value.Equals("") && !txtProjectName.Value.Equals(""))
            {
                using (SqlConnection con = new SqlConnection(strConnection))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("AddTProject", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", userid);
                        cmd.Parameters.AddWithValue("@ProjectCode", txtProjectCode.Value);
                        cmd.Parameters.AddWithValue("@Projectname", txtProjectName.Value);
                        cmd.Parameters.AddWithValue("@ProjectDescription", txtProjectDescription.Value);
                        cmd.Parameters.AddWithValue("@Datetimeloaded", today);
                        cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Value);
                        cmd.Parameters.AddWithValue("@Active", active);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        addmsgbox.InnerHtml = "<p class='alert alert-info'>Project added successfully!</p>";
                    }
                    catch (Exception ex)
                    {
                    }
                }
            } else
            {
                addmsgbox.InnerHtml = "<p class='alert alert-danger'>Something went wrong, make sure to fill all required fields.</p>";
            }
        }
    }
}