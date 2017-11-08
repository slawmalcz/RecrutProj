using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    class FinalNeuron
    {
        private Double[] weight = new Double[7];
        public FinalNeuron(Double [] supervised,Double [] unsupervised)
        {
            for(int i = 0; i < supervised.Length; i++)
            {
                this.weight[i] = (supervised[i] + unsupervised[i]) / 2;
            }
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

        public  Candidate AskPreNeuralForCandidate(DataTable dt)
        {
            double maxWeigh = -70;//(SCALE FROM 1-10)*(RANDOM FROM -1...1)*(7 NUMBERS OF PARAMETERS)
            int neuron = 0;
            Worker maxID = null;
            for (int i = 0; i < NeuralLayer.neuronNum; i++)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Worker temp = new Worker(dr);
                    if (generateOutput(temp) > maxWeigh)
                    {
                        neuron = i;
                        maxID = temp;
                        maxWeigh = generateOutput(temp);
                    }
                }
            }
            return new Candidate(maxID, maxWeigh, neuron);
        }
    }
}
