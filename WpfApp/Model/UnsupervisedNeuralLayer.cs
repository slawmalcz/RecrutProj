using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace WpfApp.Model
{
    class UnsupervisedNeuralLayerNeuralLayer:NeuralLayer
    {
        ///CONSTRUCTORS

        /// <summary>
        /// Constructor For unsupervised neural layer
        /// </summary>
        /// <param name="pathToFile">Path to neurons weiht file</param>
        public UnsupervisedNeuralLayerNeuralLayer(String pathToFile) : base(pathToFile)
        {
            candidates = new List<Candidate>();
        }

        ///METHODS AND FUNCTIONS

        /// <summary>
        /// Function for asking networ for candidate
        /// </summary>
        /// <param name="dt">Data Table containing Workwes</param>
        /// <returns>List of possible candidate</returns>
        public override List<Candidate> AskPreNeuralForCandidate(DataTable dt)
        {
            double maxWeigh = Double.NegativeInfinity;
            int neuron = 0;
            Worker maxID = null;
            for (int i = 0; i < NeuralLayer.neuronNum; i++)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Worker temp = new Worker(dr);
                    if (this.GetNeuron(i).generateOutput(temp) > maxWeigh)
                    {
                        neuron = i;
                        maxID = temp;
                        maxWeigh = this.GetNeuron(i).generateOutput(temp);
                    }
                }
            }
            candidates.Add(new Candidate(maxID, maxWeigh, neuron));
            return candidates;
        }
        /// <summary>
        /// Used to seave neuron  weights to file
        /// </summary>
        protected override void saveProgres()
        {
            using (StreamWriter writetext = new StreamWriter("unsupervisedNeuralBrain.txt"))
            {
                for (int i = 0; i < neuronNum; i++)
                {
                    mainLayer[i] = new Neuron();
                    writetext.WriteLine(mainLayer[i].generateWeightView());
                }
            }
        }
        /// <summary>
        /// Used for lerning the winning neuron
        /// </summary>
        /// <param name="candidate">Winning candidat</param>
        public override void TeachPreNeural(Candidate candidate)
        {
            this.mainLayer[candidate.Neuron].DeltaRegule(candidate);
            this.saveProgres();
        }
    }
}
