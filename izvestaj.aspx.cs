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
    public partial class izvestaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["ime"]);
            if (Session["korisnik"].Equals("dusan"))
            {
                string naredba = "select * FROM adresar";
                SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
                DataTable adresar = new DataTable();
                da.Fill(adresar);
                StringBuilder red = new StringBuilder("<table class=\"tabela\"> <caption>Izvestaj</caption>");
                Response.Write(red);
                red.Clear();
                int BrRedova = adresar.Rows.Count;
                for (int i = 0; i < BrRedova; i++)
                {
                    red.Append("<tr>");
                    Response.Write(red);
                    red.Clear();
                    red.Append("<td>" + adresar.Rows[i]["naziv"] + "</td>");
                    red.Append("<td>" + adresar.Rows[i]["ulica"] + "</td>");
                    red.Append("<td>" + adresar.Rows[i]["mesto_id"] + "</td>");
                    Response.Write(red);
                    red.Clear();
                }
                Response.Write("</table>");
            }
            else
            {
                SqlConnection conn = konekcija.Connect();
                SqlCommand komanda = new SqlCommand("SELECT ID,Naziv,Ulica,Broj FROM ADRESAR", conn);
                conn.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    TableRow TR = new TableRow();
                    if (citac[2].ToString().Length != 0)
                    {
                        for (int i = 0; i < citac.FieldCount; i++)
                        {
                            TableCell TD = new TableCell();
                            TD.Text = citac[i].ToString();
                            TR.Cells.Add(TD);
                        }
                        Table1.Rows.Add(TR);
                    }
                }
                conn.Close();
            }
        }
    }
}