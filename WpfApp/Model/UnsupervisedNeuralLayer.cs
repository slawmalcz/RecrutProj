using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    class UnsupervisedNeuralLayerNeuralLayer:NeuralLayer
    {
        public UnsupervisedNeuralLayerNeuralLayer(String pathToFile) : base(pathToFile)
        {
            candidates = new List<Candidate>();
        }

        public override List<Candidate> AskPreNeuralForCandidate(DataTable dt)
        {
            double maxWeigh = -70;//(SCALE FROM 1-10)*(RANDOM FROM -1...1)*(7 NUMBERS OF PARAMETERS)
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

        public override void TeachPreNeural(Candidate candidate)
        {
            this.mainLayer[candidate.GetNeuron()].DeltaRegule(candidate);
        }
    }
}
