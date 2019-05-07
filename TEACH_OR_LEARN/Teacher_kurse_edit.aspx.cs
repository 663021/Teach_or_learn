using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class Teacher_kurse_edit : System.Web.UI.Page
    {
        private async void NewClick(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbCommand command = new OleDbCommand("UPDATE Курсы SET Наименование = @panel1 , Направление = @panel2 , Продолжительность = @panel3 , Информация = @panel4 , Сложность = @panel5 WHERE Код = @id", SqlConnection);

            command.Parameters.AddWithValue("@panel1", TextBox1.Text);
            command.Parameters.AddWithValue("@panel2", TextBox2.Text);
            command.Parameters.AddWithValue("@panel3", TextBox3.Text);
            command.Parameters.AddWithValue("@panel4", TextBox4.Text);
            command.Parameters.AddWithValue("@panel5", TextBox5.Text);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["kurseID"]));

            int i = 0;

            try
            {
                i = await command.ExecuteNonQueryAsync();
                Response.Write("<script>alert('" + i+ TextBox1.Text + "');</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message.ToString()+"..."+ex.Source.ToString()+"');</script>");
            }
        }

        protected async void DelClick(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbCommand command = new OleDbCommand("DELETE * FROM Курсы WHERE Код = @id",SqlConnection);
            command.Parameters.AddWithValue("@id",Request.QueryString["kurseID"]);

            await command.ExecuteNonQueryAsync();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            Button btn1 = new Button();
            btn1.Text = "Обновить";
            btn1.CssClass = "btn btn-primary btn-lg";
            btn1.Click += NewClick;
            Panel5.Controls.Add(btn1);

            btn1 = new Button();
            btn1.Text = "Удалить";
            btn1.CssClass = "btn btn-primary btn-lg";
            btn1.Click += DelClick;
            Panel1.Controls.Add(btn1);

            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);
            command.Parameters.AddWithValue("@id",Request.QueryString["kurseID"]);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if (Request.QueryString["kurseID"] == Convert.ToString(sqlReader["Код"]) && Request.QueryString["userID"] == Convert.ToString(sqlReader["Код учителя"])) 
                {
                    TextBox1.Text = Convert.ToString(sqlReader["Наименование"]);
                    TextBox2.Text = Convert.ToString(sqlReader["Направление"]);
                    TextBox3.Text = Convert.ToString(sqlReader["Продолжительность"]);
                    TextBox4.Text = Convert.ToString(sqlReader["Информация"]);
                    TextBox5.Text = Convert.ToString(sqlReader["Сложность"]);
                }
            }
        }
    }
}