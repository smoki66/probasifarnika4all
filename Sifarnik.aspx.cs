using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProbaSifarnika
{
    public partial class Koverat : System.Web.UI.Page
    {
        string tabela;
        protected void Page_Load(object sender, EventArgs e)
        {
            tabela = Request.QueryString["tabela"];
            SqlConnection conn = konekcija.Connect();
            SqlCommand komanda = new SqlCommand("SELECT * FROM "+tabela, conn);
            conn.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                TableRow TR = new TableRow();
                    for (int i = 0; i < citac.FieldCount; i++)
                    {
                        TableCell TD = new TableCell();
                        TD.Text = citac[i].ToString();
                        TR.Cells.Add(TD);
                    }
                    Table1.Rows.Add(TR);
            }
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals("")){
                Response.Write("Ne moze prazno!");
            }
            else
            {
                SqlConnection conn = konekcija.Connect();
                SqlCommand komanda = new SqlCommand("SELECT * FROM " + tabela + " WHERE naziv='"+TextBox1.Text+"'", conn);
                conn.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    Response.Write("Takav postoji!");
                }
                else
                {
                    conn.Close();
                    SqlCommand komanda2 = new SqlCommand("INSERT INTO " + tabela + "(naziv) VALUES ('" + TextBox1.Text + "')", conn);
                    conn.Open();
                    int ubacio = komanda2.ExecuteNonQuery();
                    Response.Write("Ubacio " + ubacio + " novih redova");
                }
                conn.Close();
            }
        }
    }
}