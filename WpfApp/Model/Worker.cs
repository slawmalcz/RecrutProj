using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Model
{
    class Worker
    {
        public static int parameters {
            get {
                return 7;
            }
        }
        public int ID {
            get;
            private set;
        }
        protected string Imie;
        protected string Nazwisko;
        public Double[] oceny = new Double[parameters];

        public Worker(DataRow dataRow)
        {
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
        protected Worker(Worker worker)
        {
            this.ID = worker.ID;
            this.Imie = worker.Imie;
            this.Nazwisko = worker.Nazwisko;
            this.oceny = worker.oceny;
        }

        public new String ToString()
        {
            return "" +
                "Id = " + this.ID + " " +
                "Imie = " + this.Imie + " " +
                "Nazwisko = " + this.Nazwisko + " ";
        }
    }
}
