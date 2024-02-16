using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Settimana_15_Esercizio_FInale
{
    public partial class dettaglio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
                nel Page_Load come prima cosa viene verificata la presenza di una queryString che identifichi il prodotto dal nome, in alternativa si viene rimandati alla home,
                una volta identificato il prodotto la pagina viene riempita con i suoi dati e mostrata all'utente
             */

            string nomeArticolo = Request.QueryString["articolo"];
            if (nomeArticolo != null)
            {
                nomeArticolo.Replace("%20", " ");
                Articoli articoloSelezionato = new Articoli();
                foreach (Articoli articolo in Articoli.listaProdotti)
                {
                    if (articolo.nome == nomeArticolo)
                    {
                        articoloSelezionato = articolo;
                    }
                }

                nomeProdotto.InnerHtml = articoloSelezionato.nome;

                immagineProdotto.InnerHtml =
                    $"<img src=\"{articoloSelezionato.immagine}\" class=\"img-fluid border border-success rounded-2\" alt=\"immagineProdotto\"/>";

                string ContentOfDescrizioneProdotto = "";
                ContentOfDescrizioneProdotto +=
                    $"<p class=\"m-0 px-2\">{articoloSelezionato.descrizione}</p>";
                ContentOfDescrizioneProdotto +=
                    $"<p class=\"display-6 text-end\">€{articoloSelezionato.prezzo}</p>";
                descrizioneProdotto.InnerHtml = ContentOfDescrizioneProdotto;

                Button btn1 = new Button();
                btn1.CssClass = "btn btn-success rounded-pill";
                btn1.Text = "Aggiungi al Carrello";
                btn1.Click += AggiungiAlCarrello;

                Button btn2 = new Button();
                btn2.CssClass = "btn btn-outline-primary rounded-pill mx-4";
                btn2.Text = "Ritorna alla Home";
                btn2.Click += RitornaAllaHome;

                Button btn3 = new Button();
                btn3.CssClass = "btn btn-outline-primary rounded-pill";
                btn3.Text = "Vai al Carrello";
                btn3.Click += VaiAlCarrello;

                divAggiungiAlCarrello.Controls.Add(btn1);
                divAggiungiAlCarrello.Controls.Add(btn2);
                divAggiungiAlCarrello.Controls.Add(btn3);
            }
            else
            {
                Response.Redirect("default");
            }
        }

        protected void AggiungiAlCarrello(object sender, EventArgs e)
        {
            /*
                verifica se esiste già un cookie chiamato carrello, se si aggiunge alla stringa il nuovo elemento, altrimenti crea il cookie carrello e lo popola con l'elemento aggiunto
             */

            string nomeArticolo = Request.QueryString["articolo"];
            nomeArticolo.Replace("%20", " ");
            HttpCookie c = Request.Cookies["Carrello"];
            if (c == null)
            {
                HttpCookie carrello = new HttpCookie("Carrello");
                carrello.Values["Articoli"] = nomeArticolo;
                carrello.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(carrello);
            }
            else
            {
                string stringaCarrello = c.Values["Articoli"];
                stringaCarrello += "," + nomeArticolo;
                HttpCookie carrello = new HttpCookie("Carrello");
                carrello.Values["Articoli"] = stringaCarrello;
                carrello.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(carrello);
            }
        }

        protected void RitornaAllaHome(object sender, EventArgs e)
        {
            Response.Redirect("default");
        }

        protected void VaiAlCarrello(object sender, EventArgs e)
        {
            Response.Redirect("carrello");
        }
    }
}
