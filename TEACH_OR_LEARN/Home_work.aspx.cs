using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class home_work : System.Web.UI.Page
    {
        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1All\Work\Дипломы\TEACH_OR_LEARN\tol_db.mdb";

        public class Ratings
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        IEnumerable<Ratings> companies = new List<Ratings>
        {
            new Ratings { Id = 5, Name = "5 (Отлично)" },
            new Ratings { Id = 4, Name = "4 (Хорошо)" },
            new Ratings { Id = 3, Name = "3 (Удовлетворительно)" },
            new Ratings { Id = 2, Name = "2 (Плохо)" },
            new Ratings { Id = 1, Name = "1 (Очень плохо)" },
            new Ratings { Id = 0, Name = "Отсутсвует" }
        };

        protected void Vision1(object sender, EventArgs e)
        {
            if (Window.Visible == false)
            {
                var button = (Button)sender;

                string[] s = button.ID.Split('.');

                id.Text = s[0];

                Window.Visible = true;

                if (button.Text == "Загрузить")
                {
                    button1.Visible = false;
                    button2.Visible = true;
                    name.InnerText = "Выберите файл для загрузки";
                    File1.Visible = true;
                    TextBox.Visible = false;
                }
                else
                {
                    button1.Visible = true;
                    button2.Visible = false;
                    name.InnerText = "Изменение оценки, введите значение";
                    File1.Visible = false;
                    TextBox.Visible = true;
                }
            }
            else
            {
                Window.Visible = false;
            }
        }

        protected async void UpdateQuest(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);

            await SqlConnection.OpenAsync();

            OleDbCommand command = new OleDbCommand("UPDATE [Задания учеников] SET Оценка = @ratings WHERE Код = @id", SqlConnection);

            command.Parameters.AddWithValue("@ratings", TextBox.Text);
            command.Parameters.AddWithValue("@id", id.Text);

            //Response.Write("<script>alert('" + id.Text + "');</script>");

            int i = 0;

            try
            {
                i = command.ExecuteNonQuery();
                Response.Redirect("~/Home_work.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
                //Response.Write("<script>alert('" + i +"');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.ToString() + "..." + ex.Source.ToString() + "');</script>");
            }

        }

        protected async void LoadQuest(object sender, EventArgs e)
        {
            string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
            string SaveLocation = Server.MapPath("Ready") + "\\" + "Пр_" + fn;
            try
            {
                File1.PostedFile.SaveAs(SaveLocation);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }

            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);

            await SqlConnection.OpenAsync();

            OleDbCommand command = new OleDbCommand("UPDATE [Задания учеников] SET [Наименование файла] = @ratings WHERE Код = @id", SqlConnection);

            command.Parameters.AddWithValue("@ratings","Пр_" + fn);
            command.Parameters.AddWithValue("@id", id.Text);

            //Response.Write("<script>alert('" + id.Text + "');</script>");

            int i = 0;

            try
            {
                i = command.ExecuteNonQuery();
                Response.Redirect("~/Home_work.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"], false);
                //Response.Write("<script>alert('" + i +"');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.ToString() + "..." + ex.Source.ToString() + "');</script>");
            }
        }

        protected async void Download(object sender, EventArgs e)
        {
            var button = (Button)sender;

            string[] s = button.ID.Split('.');

            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);

            await SqlConnection.OpenAsync();

            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT [Наименование файла] FROM [Задания учеников] WHERE Код = @id ", SqlConnection);

            command.Parameters.AddWithValue("@id", s[0]);

            try
            {
                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    var relativePath = @"~/Ready/" + Convert.ToString(sqlReader["Наименование файла"]);
                    var absolutlePath = Server.MapPath(relativePath);
                    if (System.IO.File.Exists(absolutlePath))
                    {
                        Response.Redirect(@"~/Ready/" + Convert.ToString(sqlReader["Наименование файла"]), false);
                    }
                    else
                    {
                        Response.Write("<script>alert('Файла не существует');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.ToString() + "..." + ex.Source.ToString() + "');</script>");
            }
        }

        protected void Vision(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Quest.Visible = true;
            Response.Redirect("~/Home_work.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"] + "&questID=" + button.ID, false);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);

            await SqlConnection.OpenAsync();

            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Задания курсов] WHERE [Код курса] = @courseid ", SqlConnection);

            command.Parameters.AddWithValue("@courseid", Request.QueryString["kurseID"]);

            int count = 0;

            if (Request.QueryString["kurseID"] != null)
            {
                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    count++;

                    Button btn1 = new Button();
                    btn1.Text = "Задание №" + Convert.ToString(count) + ": " + Convert.ToString(sqlReader["Тема"]);
                    btn1.ID = Convert.ToString(sqlReader["Код"]);
                    btn1.Click += Vision;
                    btn1.CssClass = "btn btn-default";
                    btn1.Attributes.CssStyle.Add("margin-top", "10px");
                    btn1.Attributes.CssStyle.Add("margin-left", "30%");
                    btn1.Attributes.CssStyle.Add("max-width", "470px");
                    btn1.Attributes.CssStyle.Add("min-width", "470px");
                    Panel1.Controls.Add(btn1);
                }
            }
            SqlConnection.Close();

            if (Request.QueryString["questID"] != null)
            {
                Quest.Visible = true;

                SqlConnection = new OleDbConnection(connectString);

                OleDbConnection SqlConnection1 = new OleDbConnection(connectString);

                SqlConnection.OpenAsync();

                await SqlConnection1.OpenAsync();

                sqlReader = null;

                OleDbDataReader sqlReader1 = null;

                command = new OleDbCommand("SELECT * FROM [Задания учеников] WHERE [Код задания] = @quest", SqlConnection);

                command.Parameters.AddWithValue("@quest", Request.QueryString["questID"]);

                try
                {
                    sqlReader = command.ExecuteReader();

                    while (sqlReader.Read())
                    {

                        command = new OleDbCommand("SELECT ФИО FROM Пользователи WHERE Код = @id", SqlConnection1);
                        command.Parameters.AddWithValue("@id", Convert.ToString(sqlReader["Код ученика"]));

                        sqlReader1 = command.ExecuteReader();

                        while (sqlReader1.Read())
                        {
                            Label label = new Label();
                            label.CssClass = "col-md-4";
                            label.Attributes.CssStyle.Add("margin-top", "15px");
                            label.Attributes.CssStyle.Add("width", "320px");
                            label.Text = Convert.ToString(sqlReader1["ФИО"]);
                            Label1.Controls.Add(label);
                        }
                        sqlReader1.Close();

                        Label label1 = new Label();
                        label1.ID = Convert.ToString(sqlReader["Код"]) + ".4";
                        label1.CssClass = "col-md-2";
                        label1.Attributes.CssStyle.Add("margin-top", "15px");
                        label1.Attributes.CssStyle.Add("width", "260px");
                        label1.Text = Convert.ToString(sqlReader["Оценка"]);
                        Label2.Controls.Add(label1);

                        Label label2 = new Label();
                        label2.CssClass = "col-md-3";
                        label2.Attributes.CssStyle.Add("margin-top", "15px");
                        label2.Attributes.CssStyle.Add("width", "320px");
                        label2.Text = Convert.ToString(sqlReader["Наименование файла"]);
                        Label3.Controls.Add(label2);

                        Button btn = new Button();
                        btn.ID = Convert.ToString(sqlReader["Код"]) + ".-1";
                        btn.Click += Vision1;
                        btn.CssClass = "btn btn-default";
                        btn.Attributes.CssStyle.Add("margin-top", "25px");
                        btn.Attributes.CssStyle.Add("width", "160px");
                        btn.Text = "Изменить оценку";
                        Label4.Controls.Add(btn);

                        Button btn1 = new Button();
                        btn1.ID = Convert.ToString(sqlReader["Код"]) + ".1";
                        btn1.Click += Vision1;
                        btn1.CssClass = "btn btn-default";
                        btn1.Attributes.CssStyle.Add("margin-top", "25px");
                        btn1.Attributes.CssStyle.Add("width", "120px");
                        btn1.Text = "Загрузить";
                        Label5.Controls.Add(btn1);

                        Button btn2 = new Button();
                        btn2.Click += Download;
                        btn2.ID = Convert.ToString(sqlReader["Код"]) + ".2";
                        btn2.CssClass = "btn btn-default";
                        btn2.Attributes.CssStyle.Add("margin-top", "25px");
                        btn2.Attributes.CssStyle.Add("width", "120px");
                        btn2.Text = "Скачать";
                        Label6.Controls.Add(btn2);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message.ToString() + "..." + ex.Source.ToString() + "');</script>");
                }
                //sqlReader.Close();
            }
        }
    }
}