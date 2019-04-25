using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=tol_db.mdb";

        public void start_click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Response.Redirect("~/Que_user_page.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"] + "&queID=" + button.ID, false);
            return;
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Задания курсов]", SqlConnection);

            sqlReader = command.ExecuteReader();

            int for_buff = 0;

            while (sqlReader.Read())
            {
                if (Request.QueryString["kurseID"] == Convert.ToString(sqlReader["Код курса"]))
                {
                    for_buff++;
                    Button btn = new Button();
                    btn.Text = "Задание №" + Convert.ToString(for_buff) + ": " + Convert.ToString(sqlReader["Тема"]);
                    btn.ID = Convert.ToString(sqlReader["Код"]);
                    btn.CssClass = "btn btn-default";
                    btn.Attributes.CssStyle.Add("margin-top", "10px");
                    btn.Attributes.CssStyle.Add("margin-left", "70px");
                    btn.Attributes.CssStyle.Add("max-width", "470px");
                    btn.Attributes.CssStyle.Add("min-width", "470px");
                    btn.Click += start_click;
                    Panel2.Controls.Add(btn);
                }
            }

            sqlReader.Close();

            string kurseID = Request.QueryString["kurseID"];

            command = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if (kurseID == Convert.ToString(sqlReader["Код"]))
                {
                    Label1.Text = "Наименование курса: " + Convert.ToString(sqlReader["Наименование"]);
                    Label2.Text = "Направление: " + Convert.ToString(sqlReader["Направление"]);
                    Label3.Text = "Продолжительность: " + Convert.ToString(sqlReader["Продолжительность"]);
                    Label4.Text = "Сложность: " + Convert.ToString(sqlReader["Сложность"]) + " из 7";
                    Label6.Text = "Руководитель: " + Convert.ToString(sqlReader["Руководитель"]);
                }
            }

            sqlReader.Close();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User_kurse_past.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
            return;
        }
    }
}