using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class Teacher_kurse_creat : System.Web.UI.Page
    {
        protected async void CreatClick(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbCommand command = new OleDbCommand("INSERT INTO Курсы (Наименование,Направление,Продолжительность,Информация,Сложность,Руководитель,Количество,[Код учителя]) VALUES (@naim,@naprav,@prodol,@info,@sloj,@teacher,@counter,@code)", SqlConnection);

            command.Parameters.AddWithValue("@naim", Name.Text);
            command.Parameters.AddWithValue("@naprav", Naprav.Text);
            command.Parameters.AddWithValue("@prodol", Count.Text);
            command.Parameters.AddWithValue("@info", Info.Text);
            command.Parameters.AddWithValue("@sloj", Convert.ToInt32(Sloj.Text));
            command.Parameters.AddWithValue("@teacher", Teacher.Text);
            command.Parameters.AddWithValue("@counter", 0);
            command.Parameters.AddWithValue("@code", Request.QueryString["userID"]);

            int i = 0;

            i = await command.ExecuteNonQueryAsync();

            Response.Write("<script>alert('" + i + Name.Text + "');</script>");
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbDataReader reader = null;

            OleDbCommand command = new OleDbCommand("SELECT ФИО FROM Пользователи WHERE Код = @id",SqlConnection);

            command.Parameters.AddWithValue("@id",Request.QueryString["userID"]);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Teacher.Text = Convert.ToString(reader["ФИО"]);
            }
        }
    }
}