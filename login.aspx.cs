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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("korisnik="+Session["korisnik"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string FRMpass = TextBox2.Text;

            string naredba = "select * FROM korisnik WHERE username='" + username + "'";
            SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
            DataTable korisnik = new DataTable();
            da.Fill(korisnik);
            if (korisnik.Rows.Count == 0)
            {
                Response.Write("Nema ga");
            }
            else
            {
                string DBpass = korisnik.Rows[0]["pass"].ToString();
                if (!FRMpass.Equals(DBpass) )
                {
                    Response.Write("Los password");
                }
                else
                {
                    // UPISI U SQL PODATKE O LOGOVANJU Time, Date...
                    Session["korisnik"] = username;
                    Session["tip"] = korisnik.Rows[0]["tip_korisnika"].ToString();
                    Session["ime"] = korisnik.Rows[0][3].ToString();

                    SqlConnection conn = konekcija.Connect();
                    SqlCommand komanda2 = new SqlCommand("update korisnik set login_date = GETDATE() where username = '"+TextBox1.Text + "'", conn);
                    SqlCommand komanda3 = new SqlCommand("UPDATE KORISNIK SET login_time = CONVERT( TIME, concat(datepart(hour, getdate()), ':',datepart(minute, getdate()), ':',datepart(SECOND, getdate()))) where username = '" + TextBox1.Text + "'", conn);
                    conn.Open();
                    komanda2.ExecuteNonQuery();
                    komanda3.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("Glavna.aspx");
                }  

            }
        }
    }
}