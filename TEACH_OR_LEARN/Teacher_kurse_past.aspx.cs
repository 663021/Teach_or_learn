using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class Teacher_kurse_past : System.Web.UI.Page
    {
        protected void EditCourse(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Response.Redirect("~/Teacher_kurse_edit.aspx?userID=" +Request.QueryString["userID"] + "&kurseID=" + button.ID, false);
        }

        protected void NewCourse(object sender, EventArgs e)
        {
            Response.Redirect("~/Teacher_kurse_creat.aspx?userID=" + Request.QueryString["userID"], false);
        }

        protected void HomeWork(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Response.Redirect("~/Home_work.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + button.SkinID, false);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            OleDbConnection SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);

            sqlReader = command.ExecuteReader();

            int buff = 0;

            while (sqlReader.Read())
            {
                if(Request.QueryString["userID"] == Convert.ToString(sqlReader["Код учителя"]))
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
                    btn.Text = "Редактировать курс";
                    btn.ID = Convert.ToString(sqlReader["Код"]);
                    btn.CssClass = "btn btn-default";
                    btn.Attributes.CssStyle.Add("margin-top", "10px");
                    btn.Click += EditCourse;
                    Panel4.Controls.Add(btn);

                    btn = new Button();
                    btn.Text = "Проверить домашнюю работу";
                    btn.SkinID = Convert.ToString(sqlReader["Код"]);
                    btn.CssClass = "btn btn-default";
                    btn.Attributes.CssStyle.Add("margin-top", "10px");
                    btn.Click += HomeWork;
                    Panel6.Controls.Add(btn);

                    buff++;
                }
            }

            Button btn1 = new Button();
            btn1.Text = "Создать курс";
            btn1.CssClass = "btn btn-primary btn-lg";
            btn1.Attributes.CssStyle.Add("margin-top", "10%");
            btn1.Click += NewCourse;
            Panel5.Controls.Add(btn1);
            
            
            if (buff == 0)
            {
                cancel1.Visible = false;
                cancel2.Visible = true;
                cancel2.InnerText = "У вас нету своих курсов!";
                cancel2.Attributes.CssStyle.Add("margin-left", "40%");
                cancel2.Attributes.CssStyle.Add("color-text", "red");
            }
            else
            {
                cancel1.Visible = true;
                cancel2.Visible = false;
            }
        }
    }
}