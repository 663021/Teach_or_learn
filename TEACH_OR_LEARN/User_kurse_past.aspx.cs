using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1All\Work\Дипломы\TEACH_OR_LEARN\tol_db.mdb";

        public void start_click(object sender, EventArgs e)
        {
            string for_user_id = Request.QueryString["userID"];
            var button = (Button)sender;
            Response.Redirect("~/Kurse_work_page.aspx?userID=" + for_user_id + "&kurseID=" + button.ID, false);
            return;
        }

        public void remove_click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Response.Redirect("~/Remove_user_kurse_page.aspx?userID=" + Request.QueryString["userID"] + "&kurseID=" + button.SkinID + "&pageID=1", false);
            return;
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";

            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Курсы учеников]", SqlConnection);

            sqlReader = command.ExecuteReader();

            int for_buff = 0;

            while (sqlReader.Read())
            {
                if (Request.QueryString["userID"] == Convert.ToString(sqlReader["Код ученика"]))
                {
                    string for_kurse = Convert.ToString(sqlReader["Код курса"]);

                    OleDbDataReader sqlReader1 = null;

                    OleDbCommand command1 = new OleDbCommand("SELECT * FROM [Курсы]", SqlConnection);

                    sqlReader1 = command1.ExecuteReader();

                    while (sqlReader1.Read())
                    {
                        if (for_kurse == Convert.ToString(sqlReader1["Код"]))
                        {
                            TextBox lab = new TextBox();
                            lab.Text = Convert.ToString(sqlReader1["Наименование"]);
                            lab.CssClass = "form-control";
                            lab.Attributes.CssStyle.Add("margin-top", "10px");
                            lab.Attributes.CssStyle.Add("width", "220px");
                            lab.ReadOnly = true;
                            Panel2.Controls.Add(lab);

                            lab = new TextBox();
                            lab.Text = Convert.ToString(sqlReader1["Продолжительность"]);
                            lab.CssClass = "form-control";
                            lab.Attributes.CssStyle.Add("margin-top", "10px");
                            lab.Attributes.CssStyle.Add("width", "220px");
                            lab.ReadOnly = true;
                            Panel3.Controls.Add(lab);

                            Button btn = new Button();
                            btn.Text = "Приступить к выполнению";
                            btn.ID = Convert.ToString(sqlReader1["Код"]);
                            btn.CssClass = "btn btn-default";
                            btn.Attributes.CssStyle.Add("margin-right", "20px");
                            btn.Click += start_click;
                            Panel4.Controls.Add(btn);

                            btn = new Button();
                            btn.Text = "Отписатся";
                            btn.SkinID = Convert.ToString(sqlReader1["Код"]);
                            btn.CssClass = "btn btn-default";
                            btn.Click += remove_click;
                            Panel4.Controls.Add(btn);

                            for_buff++;
                        }
                    }

                    sqlReader1.Close();
                }



                if (for_buff == 0)
                {
                    for_h3_1.Visible = false;
                    for_h3_2.InnerText = "Вы не записаны на курсы";
                }else
                {
                    for_h3_1.Visible = true;
                    for_h3_2.InnerText = "Выполнено заданий";
                }
            }

            sqlReader.Close();
        }
    }
    }
