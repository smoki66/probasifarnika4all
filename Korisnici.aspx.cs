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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string naredba = "select * FROM korisnik";
            SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
            DataTable adresar = new DataTable();
            da.Fill(adresar);
            GridView1.DataSource = adresar;
            GridView1.DataBind();
        }
    }
}