using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ProbaSifarnika
{
    public partial class SifarnikU : System.Web.UI.Page
    {
        
        DataTable podaci;
        string tabela;
        void osvezi()
        {
            tabela = Request.QueryString["tabela"];
            SqlConnection conn = konekcija.Connect();
            string naredba = "SELECT * FROM " + tabela;
            SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
            podaci = new DataTable();
            da.Fill(podaci);
            Table1.Rows.Clear();
            TableRow TR = new TableRow();
            TableCell TD = new TableCell();
            TD.Text = "== Rb ==";
            TR.Cells.Add(TD);
            TD = new TableCell();
            TD.Text = "== Naziv ==";
            TR.Cells.Add(TD);
            Table1.Rows.Add(TR);
            for (int red = 0; red < podaci.Rows.Count; red++)
            {
                TR = new TableRow();
                for (int i = 0; i <= 1; i++)
                {
                    TD = new TableCell();
                    TD.Text = podaci.Rows[red][i].ToString();
                    TR.Cells.Add(TD);
                }
                Table1.Rows.Add(TR);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            tabela = Request.QueryString["tabela"];
            Label1.Text = tabela;
            osvezi();
            int tekuci = int.Parse(Session["tekuci"].ToString());
            if (TextBox1.Text == "")
            {
                TextBox1.Text = podaci.Rows[tekuci][0].ToString();
                TextBox2.Text = podaci.Rows[tekuci][1].ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int tekuci = int.Parse(Session["tekuci"].ToString());
            if (tekuci<podaci.Rows.Count-1) tekuci++;
            TextBox1.Text = podaci.Rows[tekuci][0].ToString();
            TextBox2.Text = podaci.Rows[tekuci][1].ToString();
            Session["tekuci"] = tekuci;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int tekuci = int.Parse(Session["tekuci"].ToString());
            if (tekuci>0) tekuci--;
            TextBox1.Text = podaci.Rows[tekuci][0].ToString();
            TextBox2.Text = podaci.Rows[tekuci][1].ToString();
            Session["tekuci"] = tekuci;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ID_new = TextBox1.Text;
            string naziv1 = TextBox2.Text;
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + naziv1 + "');", true);
            SqlConnection conn = konekcija.Connect();
            string naredba = "UPDATE " + tabela + " SET NAZIV='" + naziv1 + "' WHERE ID=" + ID_new;
            SqlCommand comm = new SqlCommand(naredba, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            osvezi();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Equals(""))
            {
                Response.Write("Ne moze prazno!");
            }
            else
            {
                SqlConnection conn = konekcija.Connect();
                SqlCommand komanda = new SqlCommand("SELECT * FROM " + tabela + " WHERE naziv='" + TextBox2.Text + "'", conn);
                conn.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    Response.Write("Takav postoji!");
                }
                else
                {
                    conn.Close();
                    SqlCommand komanda2 = new SqlCommand("INSERT INTO " + tabela + "(naziv) VALUES ('" + TextBox2.Text + "')", conn);
                    conn.Open();
                    int ubacio = komanda2.ExecuteNonQuery();
                    // Response.Write("Ubacio " + ubacio + " novih redova");
                }
                conn.Close();
            }
            osvezi();
            int tekuci = podaci.Rows.Count - 1;
            TextBox1.Text = podaci.Rows[tekuci][0].ToString();
            TextBox2.Text = podaci.Rows[tekuci][1].ToString();
            Session["tekuci"] = tekuci;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // Button BRISI
            SqlConnection conn = konekcija.Connect();
            SqlCommand komanda = new SqlCommand("DELETE FROM " + tabela + " WHERE ID='" + TextBox1.Text + "'", conn);
            conn.Open();
            komanda.ExecuteNonQuery();
            conn.Close();
            osvezi();
            int tekuci = int.Parse(Session["tekuci"].ToString());
            if (tekuci > podaci.Rows.Count-1) tekuci--;
            TextBox1.Text = podaci.Rows[tekuci][0].ToString();
            TextBox2.Text = podaci.Rows[tekuci][1].ToString();
            Session["tekuci"] = tekuci;
        }
    }
}