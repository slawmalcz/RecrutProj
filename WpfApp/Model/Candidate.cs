using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Candidate:Worker
    {
        private double output=0;
        private int Neuron=0;
        private String[] ConcatenatingString = 
        {
            "Ocena ilosci projektow",
            "Ocena szybkosci pisania kodu",
            "Ocena obslugi issue",
            "Ocena charakteru",
            "Ocena samokształcenia",
            "Punktualnosc",
            "Poprawnosc kodu"
        };

        public Candidate(Worker worker,double output,int neuron) : base(worker)
        {
            this.output = output;
            this.Neuron = neuron;
        }

        public void FillCandidate(int Neuron, double output)
        {
            this.Neuron = Neuron;
            this.output = output;
        }

        public new String ToString()
        {
            return "" +
                "Id = " + this.ID + " " +
                "Imie = " + this.Imie + " " +
                "Nazwisko = " + this.Nazwisko + " " +
                "Neuron = "+ this.Neuron+ " " +
                "Output = "+ this.output;
        }

        public int GetNeuron()
        {
            return Neuron;
        }

        public String PrintOutputForView()
        {
            String output =
                "Imie = " + this.Imie + " " +
                "Nazwisko = " + this.Nazwisko + " ";
            int Maxint = 0;
            for(int i = 0; i < this.oceny.Length; i++)
            {
                if (this.oceny[i] > this.oceny[Maxint])
                {
                    Maxint = i;
                }
            }
            output += "Rekomendowany za: "+ ConcatenatingString[Maxint];
            return output;
        }

    }
}
