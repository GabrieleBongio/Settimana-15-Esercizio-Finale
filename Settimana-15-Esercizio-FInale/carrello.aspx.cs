using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Settimana_15_Esercizio_FInale
{
    public partial class carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
                innanzitutto verifica che esista il cookie Carrello, se non esiste scrive a schermo: non ci sono elementi nel carrello.
                la stringa del cookie viene poi separata nei singoli articoli (salvati separati da virgole), il programma poi recupera i dati di ogni singolo articolo e
                li mosra a schermo, dopodichè inserisce il recap con il totale e il pulsante svuota carrello
             */

            HttpCookie c = Request.Cookies["Carrello"];
            if (c != null)
            {
                string[] nomiArticoli = c.Values["Articoli"].Split(',');
                double totaleCarrello = 0;
                for (int i = 0; i < nomiArticoli.Length; i++)
                {
                    Articoli articoloSelezionato = new Articoli();
                    foreach (Articoli articolo in Articoli.listaProdotti)
                    {
                        if (articolo.nome == nomiArticoli[i])
                        {
                            articoloSelezionato = articolo;
                        }
                    }
                    Panel singoloArticolo = new Panel();
                    singoloArticolo.CssClass = "border-top border-bottom container";

                    Panel panel = new Panel();
                    panel.CssClass = "d-flex align-items-center py-2";

                    Image img = new Image();
                    img.ImageUrl = articoloSelezionato.immagine;
                    img.AlternateText = articoloSelezionato.nome + " immagine";
                    img.Height = 75;

                    Label nome = new Label();
                    nome.Text = articoloSelezionato.nome;
                    nome.CssClass = "m-0 fs-5 fw-lighter";

                    Label prezzo = new Label();
                    prezzo.Text = articoloSelezionato.prezzo.ToString() + "€";
                    prezzo.CssClass = "ms-auto fw-lighter fs-5";

                    Button btn = new Button();
                    btn.Text = "Rimuovi dal carrello";
                    btn.CommandArgument = i.ToString();
                    btn.CssClass = "ms-3 btn btn-outline-danger";
                    btn.Click += Rimuovi;

                    panel.Controls.Add(img);
                    panel.Controls.Add(nome);
                    panel.Controls.Add(prezzo);
                    panel.Controls.Add(btn);

                    singoloArticolo.Controls.Add(panel);
                    contenitore.Controls.Add(singoloArticolo);

                    totaleCarrello += articoloSelezionato.prezzo;
                }

                Panel resoconto = new Panel();
                resoconto.CssClass = "border-top border-2 pt-3 pb-5 container";

                Panel panelR = new Panel();
                panelR.CssClass = "d-flex align-items-center py-2";

                Label nomeR = new Label();
                nomeR.Text = "Totale:";
                nomeR.CssClass = "m-0 fs-3 fw-lighter";

                Label prezzoR = new Label();
                prezzoR.Text = totaleCarrello.ToString() + "€";
                prezzoR.CssClass = "ms-auto fw-lighter fs-3";

                Button btnR = new Button();
                btnR.Text = " Svuota il carrello ";
                btnR.CssClass = "ms-3 btn btn-outline-danger";
                btnR.Click += SvuotaCarrello;

                panelR.Controls.Add(nomeR);
                panelR.Controls.Add(prezzoR);
                panelR.Controls.Add(btnR);

                resoconto.Controls.Add(panelR);
                contenitore.Controls.Add(resoconto);
            }
            else
            {
                contenitore.InnerHtml =
                    "<div class=\"container\"><h3 class=\"display-6\">Non ci sono articoli nel carrello</h3></div>";
            }
        }

        protected void Rimuovi(object sender, EventArgs e)
        {
            /*
                questa funzione separa il cookie in singole stringhe di articolo, poi crea una stringa con tutti gli articoli tranne quello che corrisponde all'index
                importato come parametro dal bottone, infine crea un nuovo cookie con la stringa sistemata e ricarica la pagina
             */

            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.CommandArgument);
            HttpCookie c = Request.Cookies["Carrello"];
            string[] nomiArticoli = c.Values["Articoli"].Split(',');
            string nuovoCarrello = "";
            for (int i = 0; i < nomiArticoli.Length; i++)
            {
                if (i != index)
                {
                    if ((i == 0 && index != 0) || (index == 0 && i == 1))
                    {
                        nuovoCarrello += nomiArticoli[i];
                    }
                    else
                    {
                        nuovoCarrello += "," + nomiArticoli[i];
                    }
                }
            }
            HttpCookie carrello = new HttpCookie("Carrello");
            carrello.Values["Articoli"] = nuovoCarrello;
            carrello.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(carrello);
            Response.Redirect("carrello");
        }

        protected void SvuotaCarrello(object sender, EventArgs e)
        {
            /*
                elimina il cookie Carrello e ricarica la pagina
             */

            HttpCookie carrello = new HttpCookie("Carrello");
            carrello.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(carrello);
            Response.Redirect("carrello");
        }
    }
}
