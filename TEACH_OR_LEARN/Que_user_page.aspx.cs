using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

namespace TEACH_OR_LEARN
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1All\Work\Дипломы\TEACH_OR_LEARN\tol_db.mdb";

        public string for_name = "";
        public string for_code;

        public async void about_click(object sender, EventArgs e)
        {
            string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
            string SaveLocation = Server.MapPath("Ready") + "\\" + fn;
            try
            {
                File1.PostedFile.SaveAs(SaveLocation);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("INSERT INTO [Задания учеников] ([Код ученика],[Код задания],[Наименование файла],[Код курса])VALUES(@1,@2,@3,@4)", SqlConnection);
            command.Parameters.AddWithValue("@1", Request.QueryString["userID"]);
            command.Parameters.AddWithValue("@2", Request.QueryString["queID"]);
            command.Parameters.AddWithValue("@3", fn);
            command.Parameters.AddWithValue("@4", Request.QueryString["kurseID"]);
            await command.ExecuteNonQueryAsync();

            File1.Visible = false;
            Submit1.Visible = false;
            Button2.Visible = true;
            Label1.Text = "Задание сдано";
            for_div.Attributes.CssStyle.Add("background-color", "#cef3c0");
        }

        public async void about_click_1(object sender, EventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Задания учеников]", SqlConnection);

            sqlReader = command.ExecuteReader();

            string for_name = "fd";

            while (sqlReader.Read())
            {
                if (Request.QueryString["queID"] == Convert.ToString(sqlReader["Код задания"]))
                {
                    if (Request.QueryString["userID"] == Convert.ToString(sqlReader["Код ученика"]))
                    {
                        System.IO.File.Delete(Server.MapPath("Ready") + "\\" + Convert.ToString(sqlReader["Наименование файла"]));
                        OleDbCommand command1 = new OleDbCommand("DELETE * FROM [Задания учеников] WHERE [Код]=@1", SqlConnection);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(sqlReader["Код"]));
                        await command1.ExecuteNonQueryAsync();
                    }
                }
            }

            sqlReader.Close();

            File1.Visible = true;
            Submit1.Value = "Загрузить";
            Button2.Visible = false;
            Submit1.Visible = true;
            Label1.Text = "Сдать задание";
            for_div.Attributes.CssStyle.Add("background-color", "#eeeeee");
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            File1.Visible = true;
            Submit1.ServerClick += about_click;
            Submit1.Value = "Загрузить";
            Button2.Visible = false;
            Label1.Text = "Сдать задание";
            for_div.Attributes.CssStyle.Add("background-color", "#eeeeee");

            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

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
                    for_name = Convert.ToString(sqlReader["Тема"]);
                    for_code = Convert.ToString(sqlReader["Код курса"]);
                }
            }

            sqlReader.Close();

            command = new OleDbCommand("SELECT * FROM [Задания учеников]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if (Request.QueryString["queID"] == Convert.ToString(sqlReader["Код задания"]))
                {
                    if (Request.QueryString["userID"] == Convert.ToString(sqlReader["Код ученика"]))
                    {
                        File1.Visible = false;
                        Submit1.Visible = false;
                        Button2.Visible = true;
                        Label1.Text = "Задание сдано";
                        for_div.Attributes.CssStyle.Add("background-color", "#cef3c0");
                    }
                }
            }

            sqlReader.Close();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Kurse_work_page.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
            return;
        }

        protected async void Unnamed4_Click1(object sender, EventArgs e)
        {
            string for_kurse_name = "";

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if (for_code == Convert.ToString(sqlReader["Код"]))
                {
                    for_kurse_name = Convert.ToString(sqlReader["Наименование"]);
                }
            }

            sqlReader.Close();

            var relativePath = @"~/Content/" + for_kurse_name + "_" + for_name + ".docx";
            var absolutePath = Server.MapPath(relativePath);
            if (System.IO.File.Exists(absolutePath))
            {
                Response.Redirect(@"~/Content/" + for_kurse_name + "_" + for_name + ".docx", false);
            }
            else
            {
                Response.Write("<script>alert('Файла курса не существует');</script>");
            }
        }
    }
}