using System;
using System.Data;

namespace WpfApp.Model
{
    public class Worker
    {
        /// PROPERTIES

        /// <summary>
        /// Numbers of atributes of worker
        /// </summary>
        public static int parameters {
            get {
                return parameters;
            }
            private set {
                parameters = value;
            }
        }
        /// <summary>
        /// Identificator of worker
        /// </summary>
        public int ID {
            get;
            private set;
        }

        /// FIELDS

        public string Imie;
        public string Nazwisko;
        public Double[] oceny = new Double[parameters];

        ///CONSTRUCTOR

        /// <summary>
        /// Basic construcor for Worker
        /// </summary>
        /// <param name="dataRow">Data Row containing info about Worker</param>
        public Worker(DataRow dataRow)
        {
            parameters = 7;
            this.ID = Int32.Parse(dataRow["ID"].ToString());
            this.Imie = dataRow["Imie"].ToString();
            this.Nazwisko = dataRow["Nazwisko"].ToString();
            this.oceny[0] = Int32.Parse(dataRow["Ilosc_zakonczonych_projektow"].ToString());
            this.oceny[1] = Int32.Parse(dataRow["Napisano_kodu"].ToString());
            this.oceny[2] = Int32.Parse(dataRow["Obslozono_issue"].ToString());
            this.oceny[3] = Int32.Parse(dataRow["Ocena_charakteru"].ToString());
            this.oceny[4] = Int32.Parse(dataRow["Przeczytanych_ksiazek"].ToString());
            this.oceny[5] = Int32.Parse(dataRow["Spoznienia"].ToString());
            this.oceny[6] = Int32.Parse(dataRow["Blendow_w_kodzie"].ToString());
        }
        /// <summary>
        /// Secondary constructor using egzisting worker for creatin new one.
        /// Used in childern class
        /// </summary>
        /// <param name="worker"></param>
        protected Worker(Worker worker)
        {
            this.ID = worker.ID;
            this.Imie = worker.Imie;
            this.Nazwisko = worker.Nazwisko;
            this.oceny = worker.oceny;
        }

        ///METHODS AND FUNCTIONS

        /// <summary>
        /// Short description of Worker
        /// </summary>
        /// <returns>Description of Worker</returns>
        public new String ToString()
        {
            return "" +
                "Id = " + this.ID + " " +
                "Imie = " + this.Imie + " " +
                "Nazwisko = " + this.Nazwisko + " ";
        }
    }
}
