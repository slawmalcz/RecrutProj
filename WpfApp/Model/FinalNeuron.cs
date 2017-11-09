using System;
using System.Data;

namespace WpfApp.Model
{
    class FinalNeuron
    {
        ///     WARNING
        ///This neural class don't contain learning method
        ///It inherits weights as mediun valuu from supervisedNeuralLayer
        ///and unsupervisedNeuralLayer
        ///This neuron ust once again get all Workers to choose form.

        ///FIELDS

        /// <summary>
        /// Weiht for final neuron
        /// </summary>
        private Double[] weight = new Double[7];

        ///CONSTRUCTOR

        /// <summary>
        /// Constructor for final neuron for final choosing of candidate
        /// </summary>
        /// <param name="supervised">Weight from wining supervised neuron</param>
        /// <param name="unsupervised">Weight from wining unsupervised neuron</param>
        public FinalNeuron(Double [] supervised,Double [] unsupervised)
        {
            for(int i = 0; i < supervised.Length; i++)
            {
                this.weight[i] = (supervised[i] + unsupervised[i]) / 2;
            }
        }

        ///METHODS AND FUNCTIONS

        /// <summary>
        /// Generate output for given worker
        /// </summary>
        /// <param name="worker">Worker to calculate output with</param>
        /// <returns>Double: neuron response for worker</returns>
        private double generateOutput(Worker worker)
        {
            double output = 0;
            for (int i = 0; i < Worker.parameters; i++)
            {
                output = weight[i] * worker.oceny[i];
            }
            return output;
        }
        /// <summary>
        /// Method asking neuron for worker with best neuralResponse
        /// </summary>
        /// <param name="dt">Data Table containnig all workers</param>
        /// <returns>Final candidate</returns>
        public  Candidate AskPreNeuralForCandidate(DataTable dt)
        {
            double maxWeigh = Double.NegativeInfinity;
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
