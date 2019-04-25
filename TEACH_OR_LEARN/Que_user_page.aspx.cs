using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=tol_db.mdb";

        protected async void Page_Load(object sender, EventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Задания курсов]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if (Request.QueryString["queID"] == Convert.ToString(sqlReader["Код"]))
                {
                    H2.InnerText = Convert.ToString(sqlReader["Тема"]);
                    Label5.Text = "Задание: " + Convert.ToString(sqlReader["Задание"]);
                }
            }

            sqlReader.Close();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Kurse_work_page.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
            return;
        }
    }
}