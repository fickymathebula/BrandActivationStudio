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
    public partial class DeleteProject : System.Web.UI.Page
    {
        string strConnection = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login");
            }

            if (!IsPostBack)
            {
                int projectid = Convert.ToInt32(Request.QueryString["ProjectId"].ToString());
                txtProjectId.Value = projectid.ToString();
            }
        }

        protected void btnDeleteProject_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteTProject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectId", txtProjectId.Value); // Project Id
                    
                    cmd.ExecuteNonQuery();
                    con.Close();

                    // Close modal or redirect to Project List
                    Response.Redirect("~/ProjectList");

                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}