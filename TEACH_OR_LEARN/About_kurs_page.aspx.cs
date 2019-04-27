using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1All\Work\Дипломы\TEACH_OR_LEARN\tol_db.mdb";


        protected async void Page_Load(object sender, EventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            string kurseID = Request.QueryString["kurseID"];

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if(kurseID == Convert.ToString(sqlReader["Код"]))
                {
                    Label1.Text = "Наименование курса: " + Convert.ToString(sqlReader["Наименование"]);
                    Label2.Text = "Направление: " + Convert.ToString(sqlReader["Направление"]);
                    Label3.Text = "Продолжительность: " + Convert.ToString(sqlReader["Продолжительность"]);
                    Label4.Text = "Сложность: " + Convert.ToString(sqlReader["Сложность"]) + " из 7";
                    Label5.Text = "Описание: " + Convert.ToString(sqlReader["Информация"]);
                    Label6.Text = "Руководитель: " + Convert.ToString(sqlReader["Руководитель"]);

                    string for_buff = Convert.ToString(sqlReader["Код"]);

                    OleDbDataReader sqlReader1 = null;

                    OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Задания курсов]", SqlConnection);

                    sqlReader1 = command1.ExecuteReader();

                    int for_kol = 0;

                    while (sqlReader1.Read())
                    {
                        if (for_buff == Convert.ToString(sqlReader1["Код курса"]))
                            for_kol++;
                    }

                    sqlReader1.Close();

                    Label7.Text = "Количество заданий: " + Convert.ToString(for_kol);
                }
            }

            sqlReader.Close();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Kurses_page_past.aspx?userID=" + Request.QueryString["userID"], false);
            return;
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("INSERT INTO [Курсы учеников] ([Код ученика],[Код курса])VALUES(@1,@2)", SqlConnection);
            command.Parameters.AddWithValue("@1", Request.QueryString["userID"]);
            command.Parameters.AddWithValue("@2", Request.QueryString["kurseID"]);
            await command.ExecuteNonQueryAsync();


            Response.Redirect("/Kurses_page_past.aspx?userID=" + Request.QueryString["userID"], false);
            return;
        }
    }
}