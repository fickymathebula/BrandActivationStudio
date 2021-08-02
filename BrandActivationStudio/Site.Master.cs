using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandActivationStudio
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {                
                if (Session["UserName"] == null)
                {
                    lblLoginOrLogout.InnerHtml = "<a href='Login'>Login</a>"; // Only display Login when user is not yet logged in    
                }
                else
                {
                    // Custom display of menu
                    divUser.InnerHtml = "";
                    divUser.InnerHtml = "<a href='ProjectList'>Projects</a>";
                }
            }
        }

        // Release all sessions and show login page
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login");
        }
    }
}