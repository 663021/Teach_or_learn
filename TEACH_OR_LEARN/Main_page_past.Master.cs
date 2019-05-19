using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class Main_page_past : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for_linc.HRef = "~/Default_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc1.HRef = "~/Information_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc2.HRef = "~/Other_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc3.HRef = "~/Kurses_page_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc4.HRef = "~/User_kurse_past.aspx?userID=" + Request.QueryString["userID"];
            for_linc5.HRef = "~/Default_page_past.aspx?userID=" + Request.QueryString["userID"];

            if (Request.QueryString["userID"] != null)
            {
                string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

                OleDbConnection SqlConnection = new OleDbConnection(connectString);
                SqlConnection.OpenAsync();
                OleDbDataReader sqlReader = null;

                OleDbCommand command = new OleDbCommand("SELECT Статус FROM [Пользователи] WHERE Код = @id", SqlConnection);

                command.Parameters.AddWithValue("@id", Request.QueryString["userID"]);

                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    if (Convert.ToString(sqlReader["Статус"]) == "Учитель")
                    {
                        for_linc4.HRef = "~/Teacher_kurse_past.aspx?userID=" + Request.QueryString["userID"];
                    }
                }
            }
        }
    }
}