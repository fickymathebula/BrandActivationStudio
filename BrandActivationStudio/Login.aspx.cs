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
    public partial class Login : System.Web.UI.Page
    {
        string strConnection = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Always clear login message
            loginMsg.InnerHtml = "";

            // Login inputs
            string username = txtUsername.Value;
            string password = txtPassword.Value;
            int userid = 0;
            bool loginValid = false;

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("LoginUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username); // Username
                    cmd.Parameters.AddWithValue("@password", password); // Password

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Once we reach here we know a usr matching username and password has been found in the db
                        userid = (int)reader["UserId"];
                        username = reader["username"].ToString();
                        loginValid = true;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                }
            }


            if (loginValid == true)
            {
                // Begin loadin sessions and redirect to home page
                Session["UserName"] = username;
                Session["UserId"] = userid;
                Response.Redirect("~/ProjectList");
            }
            else
            {
                // Remain in login page and show error message
                loginMsg.InnerHtml = "<p class='alert alert-danger'> Username or password incorrect.</p>";
            }

        }
    }
}