using System;

namespace WpfApp.Model
{
    public class Candidate:Worker
    {
        /// FIELDS

        /// <summary>
        /// Initializing Fields for genereting Candidate
        /// </summary>
        private double output=0;
        /// <summary>
        /// Colection of Strings used for generating toString()
        /// </summary>
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

        ///PROPERTIES

        /// <summary>
        /// Number of neuron witch choose this worker
        /// </summary>
        public int Neuron {
            get;
            private set;
        }

        /// CONSTRUCTORS

        /// <summary>
        /// Constructor for Candidate class
        /// </summary>
        /// <param name="worker">Worker witch has beed choosen to become candidate</param>
        /// <param name="output">Output for neuron witch choose this worker</param>
        /// <param name="neuron">Number of neuron witch choose this worker</param>
        public Candidate(Worker worker,double output,int neuron) : base(worker)
        {
           this.output = output;
            this.Neuron = neuron;
        }

        /// METHODS AND FUNCTIONS

        /// <summary>
        /// Generate Short Description of instance state
        /// </summary>
        /// <returns>Instance value state</returns>
        public new String ToString()
        {
            return "" +
                "Id = " + this.ID + " " +
                "Imie = " + this.Imie + " " +
                "Nazwisko = " + this.Nazwisko + " " +
                "Neuron = "+ this.Neuron+ " " +
                "Output = "+ this.output;
        }

        /// <summary>
        /// Generate long Description of instance state .Used for recomendation
        /// </summary>
        /// <returns></returns>
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
