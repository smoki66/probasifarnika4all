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
    public partial class SifarnikS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tabela = Request.QueryString["tabela"];
            SqlConnection conn = konekcija.Connect();
            SqlCommand komanda = new SqlCommand("SELECT * FROM " + tabela, conn);
            conn.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            Response.Write("INSERT INTO " + tabela + "(naziv) VALUES ");
            while (citac.Read())
            {
                Response.Write("(' " + citac[1].ToString() + "'),<BR>");
            }
            conn.Close();
        }
    }
}