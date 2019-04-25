using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=tol_db.mdb";

        public void about_click(object sender, EventArgs e)
        {
            string for_user_id = Request.QueryString["userID"];
            var button = (Button)sender;
            Response.Redirect("~/About_kurs_page.aspx?userID=" + for_user_id + "&kurseID=" + button.ID, false);
            return;
        }

        public async void about_click_1(object sender, EventArgs e)
        {
            var button = (Button)sender;

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("INSERT INTO [Курсы учеников] ([Код ученика],[Код курса])VALUES(@1,@2)", SqlConnection);
            command.Parameters.AddWithValue("@1", Request.QueryString["userID"]);
            command.Parameters.AddWithValue("@2", button.SkinID);
            await command.ExecuteNonQueryAsync();


            Response.Redirect("/Kurses_page_past.aspx?userID=" + Request.QueryString["userID"], false);
            return;
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                TextBox lab = new TextBox();
                lab.Text = Convert.ToString(sqlReader["Наименование"]);
                lab.CssClass = "form-control";
                lab.Attributes.CssStyle.Add("margin-top", "10px");
                lab.Attributes.CssStyle.Add("width", "220px");
                lab.ReadOnly = true;
                Panel2.Controls.Add(lab);

                lab = new TextBox();
                lab.Text = Convert.ToString(sqlReader["Продолжительность"]);
                lab.CssClass = "form-control";
                lab.Attributes.CssStyle.Add("margin-top", "10px");
                lab.Attributes.CssStyle.Add("width", "220px");
                lab.ReadOnly = true;
                Panel3.Controls.Add(lab);

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

                lab = new TextBox();
                lab.Text = Convert.ToString(for_kol);
                lab.CssClass = "form-control";
                lab.Attributes.CssStyle.Add("margin-top", "10px");
                lab.Attributes.CssStyle.Add("width", "220px");
                lab.ReadOnly = true;
                Panel1.Controls.Add(lab);

                Button btn = new Button();
                btn.Text = "Подробнее";
                btn.ID = Convert.ToString(sqlReader["Код"]);
                btn.CssClass = "btn btn-default";
                btn.Attributes.CssStyle.Add("margin-right", "20px");
                btn.Click += about_click;
                Panel4.Controls.Add(btn);

                btn = new Button();
                btn.Text = "Записатся";
                btn.SkinID = Convert.ToString(sqlReader["Код"]);
                btn.CssClass = "btn btn-default";
                btn.Click += about_click_1;
                Panel4.Controls.Add(btn);
            }

            sqlReader.Close();
        }
    }
}