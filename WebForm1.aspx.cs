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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string naredba = "select * FROM vlasnik";
            SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
            DataTable dtKov2 = new DataTable();
            da.Fill(dtKov2);
            DropDownList1.DataSource = dtKov2;
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "Naziv";
            DropDownList1.DataBind();
        }
    }
}