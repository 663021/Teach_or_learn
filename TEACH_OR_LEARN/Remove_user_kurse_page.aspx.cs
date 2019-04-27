using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1All\Work\Дипломы\TEACH_OR_LEARN\tol_db.mdb";

        protected async void Page_Load(object sender, EventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if (Request.QueryString["kurseID"] == Convert.ToString(sqlReader["Код"]))
                {
                    for_h2.InnerText = Convert.ToString(sqlReader["Наименование"]).ToUpper(); ; 
                }
            }
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("DELETE * FROM [Курсы учеников] WHERE [Код ученика]=@1 AND [Код курса]=@2", SqlConnection);
            command.Parameters.AddWithValue("@1", Request.QueryString["userID"]);
            command.Parameters.AddWithValue("@2", Request.QueryString["kurseID"]);
            await command.ExecuteNonQueryAsync();
            await command.ExecuteNonQueryAsync();

            Response.Redirect("~/User_kurse_past.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["pageID"] == "1")
            {
                Response.Redirect("~/User_kurse_past.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
                return;
            }else
            {
                Response.Redirect("~/Kurse_work_page.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
                return;
            }
        }
    }
}