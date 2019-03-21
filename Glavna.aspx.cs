using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProbaSifarnika
{
    public partial class Glavna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write(Session["ime"]);
                if (!Session["tip"].Equals("A"))
                {
                    MenuItem stavka = Menu1.FindItem("Stampa/Korisnik_P");
                    MenuItem roditelj = Menu1.FindItem("Stampa");
                    if (stavka != null) roditelj.ChildItems.Remove(stavka);
                }
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string vrednost = e.Item.Value;
            string sifarnik = vrednost.Substring(0, vrednost.Length - 2);
            // pregled troskova: stampa/pregled troskova
            if (vrednost.Equals("PT"))
            {
                Response.Redirect("izvestaj.aspx");
            }
            if (vrednost.Substring(vrednost.Length-1, 1).Equals("P"))
            {
                Global.stampaj = sifarnik;
                if (sifarnik.Equals("Adresa"))
                {
                    Response.Redirect("Adresa.aspx");
                }
                else
                {
                    Response.Redirect("Sifarn_P.aspx");
                }
            }
            if (vrednost.Substring(vrednost.Length - 1, 1).Equals("I"))
            {
                if (sifarnik.Equals("Adresa"))
                {
                }
                else
                {
                    Response.Redirect("Sifarnik.aspx?tabela=" + sifarnik);
                }
            }
            if (vrednost.Substring(vrednost.Length - 1, 1).Equals("U"))
            {
                if (sifarnik.Equals("Adresa"))
                {
                }
                else
                {
                    Session["tekuci"] = 0;
                    Response.Redirect("SifarnikU.aspx?tabela=" + sifarnik);
                }
            }
            if (vrednost.Substring(vrednost.Length - 1, 1).Equals("S"))
            {
                Response.Redirect("SifarnikS.aspx?tabela=" + sifarnik);
            }



        }
    }
}