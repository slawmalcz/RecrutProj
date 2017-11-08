using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        protected override void saveProgres()
        {
            using (StreamWriter writetext = new StreamWriter("unsupervisedNeuralBrain.txt"))
            {
                for (int i = 0; i < neuronNum; i++)
                {
                    mainLayer[i] = new CasificationNeuron();
                    writetext.WriteLine(mainLayer[i].generateWeightView());
                }
            }
        }

        public override void TeachPreNeural(Candidate candidate)
        {
            this.mainLayer[candidate.GetNeuron()].DeltaRegule(candidate);
            this.saveProgres();
        }
    }
}
