using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1All\Work\Дипломы\TEACH_OR_LEARN\tol_db.mdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";
        }

        protected async void Unnamed6_Click(object sender, EventArgs e)
        {
            int for_danger = 0;

            if (Names.Text == "")
            {
                Response.Write("<script>alert('Все поля должны быть заполнены!');</script>");
                return;
            }
            if (Email.Text == "")
            {
                Response.Write("<script>alert('Все поля должны быть заполнены!');</script>");
                return;
            }
            if (Login.Text == "")
            {
                Response.Write("<script>alert('Все поля должны быть заполнены!');</script>");
                return;
            }
            if (Password.Text == "")
            {
                Response.Write("<script>alert('Все поля должны быть заполнены!');</script>");
                return;
            }
            if (ConfirmPassword.Text == "")
            {
                Response.Write("<script>alert('Все поля должны быть заполнены!');</script>");
                return;
            }

            if (for_danger == 0)
            {
                SqlConnection = new OleDbConnection(connectString);
                await SqlConnection.OpenAsync();
                OleDbDataReader sqlReader = null;

                OleDbCommand command = new OleDbCommand("INSERT INTO [Пользователи] ([ФИО],[Адрес электронной почты],[Пароль],Логин,Статус)VALUES(@1,@2,@3,@4,@5)", SqlConnection);
                command.Parameters.AddWithValue("@1", Names.Text);
                command.Parameters.AddWithValue("@2", Email.Text);
                command.Parameters.AddWithValue("@3", Password.Text);
                command.Parameters.AddWithValue("@4", Login.Text);
                command.Parameters.AddWithValue("@5", "Ученик");

                OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Пользователи]", SqlConnection);

                sqlReader = command1.ExecuteReader();

                while (sqlReader.Read())
                {
                    if (Login.Text == Convert.ToString(sqlReader["Логин"]))
                    {
                        Response.Write("<script>alert('Пользователь с таким логином заргестрирован');</script>");
                        return;
                    }
                }

                sqlReader.Close();
                await command.ExecuteNonQueryAsync();

                string for_id = "1";

                command = new OleDbCommand("SELECT * FROM [Пользователи]", SqlConnection);

                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    if (Login.Text == Convert.ToString(sqlReader["Логин"]))
                    {
                        for_id = Convert.ToString(sqlReader["Код"]);
                    }
                }

                Response.Redirect("~/Default_page_past.aspx?userID=" + for_id, false);
                return;
            }
        }
    }
}