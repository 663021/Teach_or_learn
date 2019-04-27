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

        }

        protected async void Unnamed6_Click(object sender, EventArgs e)
        {
            int for_danger = 0;

            if (Names.Text == "")
            {
                for_name.Visible = true;
                for_danger++;
            }
            if (Email.Text == "")
            {
                for_email.Visible = true;
                for_danger++;
            }
            if (Login.Text == "")
            {
                for_login.Visible = true;
                for_danger++;
            }
            if (Password.Text == "")
            {
                for_pass.Visible = true;
                for_danger++;
            }
            if (ConfirmPassword.Text == "")
            {
                for_confirm_pass.Visible = true;
                for_danger++;
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
                command.Parameters.AddWithValue("@5", Login.Text);
                await command.ExecuteNonQueryAsync();

                Response.Redirect("~/Default_page_past.aspx?userID=" + Login.Text, false);
                return;
            }
        }

        protected void Names_TextChanged(object sender, EventArgs e)
        {
            for_name.Visible = false;
        }

        protected void Email_TextChanged(object sender, EventArgs e)
        {
            for_email.Visible = false;
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
            for_pass.Visible = false;
        }

        protected void ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            for_confirm_pass.Visible = false;
        }

        protected void Login_TextChanged(object sender, EventArgs e)
        {
            for_login.Visible = false;
        }
    }
}