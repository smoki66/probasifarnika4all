using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProbaSifarnika
{
    public partial class Sifarn_P : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tabela = Global.stampaj;

            SqlConnection conn = konekcija.Connect();
            SqlCommand komanda = new SqlCommand("SELECT * FROM " + tabela, conn);
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
    }
}