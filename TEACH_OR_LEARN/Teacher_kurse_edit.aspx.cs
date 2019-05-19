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

        public string curretCourse = null;

        private async void NewClick(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbCommand command = new OleDbCommand("UPDATE [Курсы] SET Наименование = @panel1 , Направление = @panel2 , Продолжительность = @panel3 , Информация = @panel4 , Сложность = @panel5 WHERE Код = @id", SqlConnection);
            
            command.Parameters.AddWithValue("@panel1", TextBox1.Text);
            command.Parameters.AddWithValue("@panel2", TextBox2.Text);
            command.Parameters.AddWithValue("@panel3", TextBox3.Text);
            command.Parameters.AddWithValue("@panel4", TextBox4.Text);
            command.Parameters.AddWithValue("@panel5", TextBox5.Text);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["kurseID"]));

            await command.ExecuteNonQueryAsync();

            int i = 0;

            try
            {
                i = await command.ExecuteNonQueryAsync();
                //Response.Write("<script>alert('" + i+ TextBox1.Text + "');</script>");
            }
            catch(Exception ex)
            {
               //Response.Write("<script>alert('"+ex.Message.ToString()+"..."+ex.Source.ToString()+"');</script>");
            }
            SqlConnection.Close();
        }

        protected async void DelClick(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            OleDbCommand command = new OleDbCommand("DELETE * FROM Курсы WHERE Код = @id",SqlConnection);
            command.Parameters.AddWithValue("@id",Request.QueryString["kurseID"]);

            await command.ExecuteNonQueryAsync();
            Response.Redirect("~/Teacher_kurse_past.aspx?userID=" + Request.QueryString["userID"], false);

            SqlConnection.Close();
        }

        protected async void DelClick_1(object sender, EventArgs e)
        {
            if (Request.QueryString["questID"] != null)
            {

                string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

                OleDbConnection SqlConnection = new OleDbConnection(connectString);
                await SqlConnection.OpenAsync();

                OleDbCommand command = new OleDbCommand("DELETE * FROM [Задания курсов] WHERE Код = @id", SqlConnection);
                command.Parameters.AddWithValue("@id", Request.QueryString["questID"]);

                try
                {
                    await command.ExecuteNonQueryAsync();
                    Response.Redirect("~/Teacher_kurse_edit.aspx?userID=" + Request.QueryString["userID"]+"&kurseID=" + Request.QueryString["kurseID"], false);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message.ToString() + "..." + ex.Source.ToString() + "');</script>");
                }

                SqlConnection.Close();
            }
        }

        protected async void AddQuest(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();

            string fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
            string SaveLocation = Server.MapPath("Content") + "\\" +TextBox1.Text+"_"+ TextBox6.Text+".docx";
            try
            {
                File2.PostedFile.SaveAs(SaveLocation);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }

            TextBox8.Text = fn;

            OleDbCommand command = new OleDbCommand("INSERT INTO [Задания курсов] (Тема,Задание,Файл,[Код курса]) VALUES (@theme,@quest,@file,@course)", SqlConnection);
            command.Parameters.AddWithValue("@theme", TextBox6.Text);
            command.Parameters.AddWithValue("@quest", TextBox7.Text);
            command.Parameters.AddWithValue("@file", TextBox1.Text + "_" + TextBox6.Text + ".docx");
            command.Parameters.AddWithValue("@course", Request.QueryString["kurseID"]);

            await command.ExecuteNonQueryAsync();

            SqlConnection.Close();
        }

        protected void UpdateQuest(Object sender, EventArgs e)
        {

            string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
            string SaveLocation = Server.MapPath("Content") + "\\" + TextBox1.Text + "_" + TextBox9.Text + ".docx";
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
                SqlConnection.OpenAsync();

                OleDbCommand command = new OleDbCommand("UPDATE [Задания курсов] SET Тема = @theme , Задание = @quest , Файл = @file WHERE Код = @id", SqlConnection);

                command.Parameters.AddWithValue("@theme", TextBox9.Text);
                command.Parameters.AddWithValue("@quest", TextBox10.Text);
                command.Parameters.AddWithValue("@file", TextBox1.Text + "_" + TextBox9.Text + ".docx");
                command.Parameters.AddWithValue("@id", Convert.ToString(Request.QueryString["questID"]));

                int i = 0;

                try
                {
                    i = command.ExecuteNonQuery();

                    Response.Write("<script>alert('" + i + "')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message.ToString() + "..." + ex.Source.ToString() + "');</script>");
                }

        }

        protected void Vision(object sender,EventArgs e)
        {
            if (addquest.Visible != true)
            {
                addquest.Visible = true;
            }
            else
            {
                addquest.Visible = false;
            }
        }

        protected void Vision1(object sender, EventArgs e)
        {
            Div1.Visible = true;

            var button = (Button)sender;

            curretCourse = button.ID;

            Response.Redirect("~/Teacher_kurse_edit.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + Request.QueryString["kurseID"] + "&questID=" + button.ID, false);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            Button4.Click += DelClick_1;

            if (Request.QueryString["questID"] != null)
            {
                Div1.Visible = true;
                string connectString1 = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

                OleDbConnection SqlConnection1 = new OleDbConnection(connectString1);
                await SqlConnection1.OpenAsync();
                OleDbDataReader sqlReader1 = null;

                OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Задания курсов] WHERE Код = @id",SqlConnection1);

                command1.Parameters.AddWithValue("@id",Request.QueryString["questID"]);

                try
                {
                    sqlReader1 = command1.ExecuteReader();

                    while (sqlReader1.Read())
                    {
                        if (TextBox9.Text != Convert.ToString(sqlReader1["Тема"]) && TextBox10.Text != Convert.ToString(sqlReader1["Задание"]) && TextBox11.Text != Convert.ToString(sqlReader1["Задание"]))
                        {
                            TextBox9.Text = Convert.ToString(sqlReader1["Тема"]);
                            TextBox10.Text = Convert.ToString(sqlReader1["Задание"]);
                            TextBox11.Text = Convert.ToString(sqlReader1["Файл"]);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message.ToString() + "..." + ex.Source.ToString() + "');</script>");
                }
            }

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
                    if (TextBox1.Text != Convert.ToString(sqlReader["Наименование"]))
                    {
                        if (TextBox2.Text != Convert.ToString(sqlReader["Направление"]))
                        {
                            if (TextBox3.Text != Convert.ToString(sqlReader["Продолжительность"]))
                            {
                                if (TextBox4.Text != Convert.ToString(sqlReader["Информация"]))
                                {
                                    if (TextBox5.Text != Convert.ToString(sqlReader["Сложность"]))
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
                }
            }
            SqlConnection.Close();
            sqlReader.Close();
            SqlConnection.Open();
            command.Cancel();

            command = new OleDbCommand("SELECT * FROM [Задания курсов] WHERE [Код курса] = @courseid ",SqlConnection);

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
                    btn1.Click += Vision1;
                    btn1.CssClass = "btn btn-default";
                    btn1.Attributes.CssStyle.Add("margin-top", "10px");
                    btn1.Attributes.CssStyle.Add("margin-left", "70px");
                    btn1.Attributes.CssStyle.Add("max-width", "470px");
                    btn1.Attributes.CssStyle.Add("min-width", "470px");
                    Panel2.Controls.Add(btn1);
                }
            }
            SqlConnection.Close();

            Button btn = new Button();
            btn.Text = "Добавить задание";
            btn.CssClass = "btn btn-default";
            btn.Attributes.CssStyle.Add("margin-top", "10px");
            btn.Attributes.CssStyle.Add("margin-left", "70px");
            btn.Attributes.CssStyle.Add("max-width", "470px");
            btn.Attributes.CssStyle.Add("min-width", "470px");
            btn.Click += Vision;
            Panel2.Controls.Add(btn);
        }

    }
}