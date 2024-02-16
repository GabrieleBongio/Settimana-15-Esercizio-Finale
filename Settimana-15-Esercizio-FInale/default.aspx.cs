using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Settimana_15_Esercizio_FInale
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
                popola dinamicamente la pagina prendendo gli articoli dalla lista inserita in Articoli.cs, in futuro si potrà aggiungere una pagina di back-office dove poter aggiungere altri articoli
             */

            string ContentOfListaArticoli = "";

            foreach (Articoli articolo in Articoli.listaProdotti)
            {
                ContentOfListaArticoli += "<div class=\"col\">";
                ContentOfListaArticoli += "<div class=\"card\">";
                ContentOfListaArticoli +=
                    $"<img src={articolo.immagine} class=\"card-img-top\" alt=\"immagine prodotto\"/>";
                ContentOfListaArticoli += "<div class=\"card-body\">";
                ContentOfListaArticoli += $"<h5 class=\"card-title\">{articolo.nome}</h5>";
                ContentOfListaArticoli += $"<p class=\"card-text\">€{articolo.prezzo}</p>";
                ContentOfListaArticoli +=
                    $"<a href=\"dettaglio?articolo={articolo.nome}\" class=\"btn btn-info\">Vai al dettaglio</a>";
                ContentOfListaArticoli += "</div>";
                ContentOfListaArticoli += "</div>";
                ContentOfListaArticoli += "</div>";
            }

            listaArticoli.InnerHtml = ContentOfListaArticoli;
        }
    }
}
