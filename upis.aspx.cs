using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ProbaSifarnika
{
    public partial class upis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               string ime = Request.Form["ime"];
               string prezime = Request.Form["prezime"];
               string datum = Request.Form["datum"];
               string email = Request.Form["email"];
               string username = Request.Form["username"];
               string password = Request.Form["password"];
               string password2 = Request.Form["password2"];
               // Response.Write(ime +prezime+ datum+ email +username +password + password2);
            
            string naredba = "select * FROM korisnik WHERE username='"+username+"'";
            SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
            DataTable korisnik = new DataTable();
            da.Fill(korisnik);
            
            if (korisnik.Rows.Count == 0  )
            {
                Response.Write("Nema ga");
                string sad_d = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime sad = DateTime.Now;
                string sad_v = sad.Hour.ToString()+":" + sad.Minute.ToString();
                StringBuilder Naredba = new StringBuilder("INSERT INTO ");
                Naredba.Append(" KORISNIK (");
                Naredba.Append("username,pass,ime,prezime ,datum_rodj ");
                Naredba.Append(",login_date,login_time ,tip_korisnika )");
                Naredba.Append($"VALUES('{username}','{password}','{ime}','{prezime}','{datum}','{sad_d}','{sad_v}','K')");
                Response.Write(Naredba.ToString());
                
                SqlConnection conn = konekcija.Connect();
                SqlCommand Komanda = new SqlCommand(Naredba.ToString(), conn);
                conn.Open();
                Komanda.ExecuteNonQuery();
                conn.Close();   
            }
            else
            {
                Response.Write("Ima ga");
            }

        }
    }
}