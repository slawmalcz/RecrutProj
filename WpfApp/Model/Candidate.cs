using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    class Candidate:Worker
    {
        private double output=0;
        private int Neuron=0;

        public Candidate(DataRow dataRow) : base(dataRow)
        {
        }
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
    }
}
