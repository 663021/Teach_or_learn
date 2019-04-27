using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TEACH_OR_LEARN
{
    public partial class Teacher_page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for_linc.HRef = "~/Default_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc1.HRef = "~/Information_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc2.HRef = "~/Other_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc3.HRef = "~/Kurses_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc4.HRef = "~/User_kurse_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc5.HRef = "~/Default_page_past.aspx?userID=" + Request.QueryString["userID"];
        }
    }
}