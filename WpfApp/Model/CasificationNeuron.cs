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
            Random rngGod = new Random();
            weight = new Double[Worker.parameters];
            for(int i=0;i<Worker.parameters;i++)
            {
                weight[i] = rngGod.NextDouble();
            }
        }

        public CasificationNeuron(double[] sendToNeuron)
        {
            this.weight = sendToNeuron;
        }

        public double generateOutput(Double [] input)
        {
            double output = 0;
            for (int i = 0; i < Worker.parameters; i++)
            {
                output = weight[i] * input[i];
            }
            MessageBox.Show(output.ToString());
            return output;
        }

        public void DeltaRegule(Double[] input)
        {
            for(int i = 0; i < Worker.parameters; i++)
            {
                weight[i] = weight[i] + (accelerationRate * (input[i] - weight[i]));
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
