using System;

namespace WpfApp.Model
{
    class Neuron
    {
        ///FIELDS

        /// <summary>
        /// Constant number telling how fast neural network shoud learn
        /// </summary>
        private const double accelerationRate = 0.1;
        /// <summary>
        /// Weight matrix
        /// </summary>
        private Double[] weight;

       ///CONSTRUCTORS 
       
       /// <summary>
       /// Generating new neuron with random rate from range -1 to 1
       /// </summary>
       public Neuron()
        {
            System.Threading.Thread.Sleep(20);
            weight = new Double[Worker.parameters];
            Random rngGod = new Random();
            for(int i=0;i<Worker.parameters;i++)
            {
                weight[i] = (rngGod.NextDouble() * 2) - 1.0;
            }
        }

        /// <summary>
        /// Generating new neuron with known weight
        /// </summary>
        /// <param name="sendToNeuron">Array of new weight wector</param>
        public Neuron(double[] sendToNeuron)
        {
            this.weight = sendToNeuron;
        }

        ///METHODS AND FUNCTIONS

        /// <summary>
        /// Calculate output for neural network
        /// </summary>
        /// <param name="worker">Worker for witch neuron output will be created</param>
        /// <returns>Double neuron</returns>
        public double generateOutput(Worker worker)
        {
            double output = 0;
            for (int i = 0; i < Worker.parameters; i++)
            {
                output = weight[i] * worker.oceny[i];
            }
            return output;
        }
        /// <summary>
        /// Initiate delta learning model for neuron
        /// </summary>
        /// <param name="worker">Worker witch'll have influence on lerning</param>
        public void DeltaRegule(Worker worker)
        {
            for(int i = 0; i < Worker.parameters; i++)
            {
                weight[i] = weight[i] + (accelerationRate * (worker.oceny[i] - weight[i]));
            }
        }
        /// <summary>
        /// Simple to string method for printing weight
        /// </summary>
        /// <returns>Detalis of Weight String</returns
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
