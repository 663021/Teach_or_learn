﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace TEACH_OR_LEARN
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        OleDbConnection SqlConnection;

        public string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\1All\Work\Дипломы\TEACH_OR_LEARN\tol_db.mdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\')) + @"\tol_db.mdb";
        }

        protected async void Unnamed4_Click(object sender, EventArgs e)
        {
            SqlConnection = new OleDbConnection(connectString);
            await SqlConnection.OpenAsync();
            OleDbDataReader sqlReader = null;

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Пользователи]", SqlConnection);

            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                if(Login.Text == Convert.ToString(sqlReader["Логин"]))
                {
                    if (Password.Text == Convert.ToString(sqlReader["Пароль"]))
                    {
                        if (Convert.ToString(sqlReader["Статус"]) == "Ученик")
                        {
                            Response.Redirect("~/Default_page_past.aspx?userID=" + Convert.ToString(sqlReader["Код"]), false);
                            return;
                        }else
                        {
                            Response.Redirect("~/Teacher_kurse_past.aspx?userID=" + Convert.ToString(sqlReader["Код"]), false);
                            return;
                        }
                    }
                }
            }

            for_pass.Visible = true;
        }
    }
}