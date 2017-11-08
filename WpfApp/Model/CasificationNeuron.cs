using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Model
{
    class CasificationNeuron
    {
        private const double accelerationRate = 0.1; 
        private Double[] weight;

        public CasificationNeuron()
        {
            System.Threading.Thread.Sleep(15);
            weight = new Double[Worker.parameters];
            Random rngGod = new Random();
            for(int i=0;i<Worker.parameters;i++)
            {
                weight[i] = (rngGod.NextDouble() * 2) - 1.0;
            }
        }

        public CasificationNeuron(double[] sendToNeuron)
        {
            this.weight = sendToNeuron;
        }

        public double generateOutput(Worker worker)
        {
            double output = 0;
            for (int i = 0; i < Worker.parameters; i++)
            {
                output = weight[i] * worker.oceny[i];
            }
            return output;
        }

        public void DeltaRegule(Worker worker)
        {
            for(int i = 0; i < Worker.parameters; i++)
            {
                weight[i] = weight[i] + (accelerationRate * (worker.oceny[i] - weight[i]));
            }
        }

        public string generateWeightView()
        {
            string output = "";
            for (int i = 0; i < Worker.parameters; i++)
            {
                output += weight[i].ToString() + ((i == Worker.parameters - 1) ? "":",");
            }
            return output;
        }
    }
}
