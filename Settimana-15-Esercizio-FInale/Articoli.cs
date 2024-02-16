using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Caching;

namespace Settimana_15_Esercizio_FInale
{
    public class Articoli
    {
        public string nome { get; set; }
        public string descrizione { get; set; }
        public string immagine { get; set; }
        public double prezzo { get; set; }

        public Articoli(string nome, string descrizione, string immagine, double prezzo)
        {
            this.nome = nome;
            this.descrizione = descrizione;
            this.immagine = immagine;
            this.prezzo = prezzo;
        }

        public Articoli() { }

        public static List<Articoli> listaProdotti = new List<Articoli>
        {
            /*
                crea una lista di articoli che si usa come base per popolare il negozio
             */

            new Articoli(
                "Cubo di Rubik 3x3x3",
                "Il rompicapo più famoso del mondo, nella sua versione originale, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il cubo di Rubik ha una dimensione di 3×3×3 cubetti. Su ognuna delle sue sei facce compaiono 9 quadrati che possono essere di 6 colori differenti. In partenza ogni faccia ha tutti i nove quadrati dello stesso colore. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale.",
                "https://m.media-amazon.com/images/I/61G8HE5T84L.__AC_SX300_SY300_QL70_ML2_.jpg",
                16.00
            ),
            new Articoli(
                "Cubo di Rubik 2x2x2",
                "Il rompicapo più famoso del mondo, nella versione 2x2x2, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il cubo di Rubik ha una dimensione di 2×2×2 cubetti. Su ognuna delle sue sei facce compaiono 4 quadrati che possono essere di 6 colori differenti. In partenza ogni faccia ha tutti i quattro quadrati dello stesso colore. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale.",
                "https://m.media-amazon.com/images/I/61wno-JlgRL._AC_SX679_.jpg",
                13.00
            ),
            new Articoli(
                "Cubo di Rubik 4x4x4",
                "Il rompicapo più famoso del mondo, nella versione 4x4x4, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il cubo di Rubik ha una dimensione di 4×4×4 cubetti. Su ognuna delle sue sei facce compaiono 16 quadrati che possono essere di 6 colori differenti. In partenza ogni faccia ha tutti i sedici quadrati dello stesso colore. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale.",
                "https://m.media-amazon.com/images/I/61ux4HBUJ-L.__AC_SX300_SY300_QL70_ML2_.jpg",
                19.00
            ),
            new Articoli(
                "Cubo di Rubik 5x5x5",
                "Il rompicapo più famoso del mondo, nella versione 5x5x5, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il cubo di Rubik ha una dimensione di 5×5×5 cubetti. Su ognuna delle sue sei facce compaiono 25 quadrati che possono essere di 6 colori differenti. In partenza ogni faccia ha tutti i venticinque quadrati dello stesso colore. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale.",
                "https://m.media-amazon.com/images/I/71T6-HYbiRL.__AC_SX300_SY300_QL70_ML2_.jpg",
                25.00
            ),
            new Articoli(
                "Pyramix Cube",
                "Il rompicapo più famoso del mondo, nella versione tetraedrica, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il pyramix cube ha una forma tetraedrica. Su ognuna delle sue quattro facce compaiono 9 quadrati che possono essere di 4 colori differenti. In partenza ogni faccia ha tutti i nove quadrati dello stesso colore. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale.",
                "https://m.media-amazon.com/images/I/61ohLun1qoL.__AC_SX300_SY300_QL70_ML2_.jpg",
                8
            ),
            new Articoli(
                "Megamix Cube",
                "Il rompicapo più famoso del mondo, nella versione dodecaedrica, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il megamix cube ha una forma dodecaedrica. Su ognuna delle sue dodici facce compaiono 11 quadrati che possono essere di 12 colori differenti. In partenza ogni faccia ha tutti gli undici quadrati dello stesso colore. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale.",
                "https://m.media-amazon.com/images/I/71ud575jspL.__AC_SX300_SY300_QL70_ML2_.jpg",
                23
            ),
            new Articoli(
                "Mirror Cube",
                "Il rompicapo più famoso del mondo, nella versione mirror, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il mirror cube ha una forma cubica. Su ognuna delle sue 6 facce compaiono 9 rettangoli che possono essere di forme differenti. In partenza ogni faccia è di forma quadrata regolare. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale. A differenza degli altri cubi di rubik a cambiare non sono i colori bensì la forma del cubo.",
                "https://m.media-amazon.com/images/I/715ZMN3EhTL.__AC_SX300_SY300_QL70_ML2_.jpg",
                14
            ),
            new Articoli(
                "Windmill Cube",
                "Il rompicapo più famoso del mondo, nella versione windmill, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il windmill cube ha una forma cubica. Su ognuna delle sue 6 facce compaiono 9 pezzi di forme e colori differenti. In partenza ogni faccia è di forma quadrata regolare e di colore uniforme. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale. A differenza degli altri cubi di rubik anche la forma del cubo cambia.\r\n",
                "https://m.media-amazon.com/images/I/71Hkv+IM65L._AC_SX679_.jpg",
                21
            ),
            new Articoli(
                "Gear Cube",
                "Il rompicapo più famoso del mondo, nella versione gear, solido e compatto, con un nuovo meccanismo più scorrevole e senza adesivi per una maggiore resistenza. Il gear cube ha una forma cubica. Su ognuna delle sue 6 facce compaiono 9 pezzi di forme e colori differenti. In partenza ogni faccia è di colore uniforme. Il rompicapo consiste nel mischiare le facce e poi provare a riportare il cubo nella configurazione originale. A differenza degli altri cubi di rubik il movimento di un pezzo condiziona il movimento dei pezzi adiacenti grazie alla presenza degli ingranaggi.",
                "https://m.media-amazon.com/images/I/61V3EzHdW8L._AC_SX679_.jpg",
                17
            )
        };
    }
}
