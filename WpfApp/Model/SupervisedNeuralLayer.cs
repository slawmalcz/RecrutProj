using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    class SupervisedNeuralLayer:NeuralLayer
    {
        ///CONSTRUCTORS

        /// <summary>
        /// Constructor for Supervised
        /// </summary>
        /// <param name="pathToFile">Path to Supervised neural weight</param>
        public SupervisedNeuralLayer(String pathToFile) : base(pathToFile)
        {
            candidates = new List<Candidate>();
        }

        /// METHODS AND FUNCTIONS

        /// <summary>
        /// Function for asking network for candidate
        /// </summary>
        /// <param name="dt">Data Table containing Workwes</param>
        /// <returns>List of possible candidate</returns>
        public override List<Candidate> AskPreNeuralForCandidate(DataTable dt)
        {
            List<Candidate> candidatesTemp = new List<Candidate>();
            for (int i = 0; i < NeuralLayer.neuronNum; i++)
            {
                Double maxWeigh = Double.NegativeInfinity;
                Worker maxID = null;
                foreach (DataRow dr in dt.Rows)
                {
                    Worker temp = new Worker(dr);
                    if (this.GetNeuron(i).generateOutput(temp) > maxWeigh)
                    {
                        maxID = temp;
                        maxWeigh = this.GetNeuron(i).generateOutput(temp);
                    }
                }
                candidatesTemp.Add(new Candidate(maxID, maxWeigh, i));
            }
            foreach (Candidate a in candidatesTemp)
            {
                bool test = true;
                foreach (Candidate b in candidates)
                {
                    if (b.ID == a.ID)
                    {
                        test = false;
                        break;
                    }
                }
                if (test) candidates.Add(a);
            }
            return candidates;
        }
        /// <summary>
        /// Used to seave neuron  weights to file
        /// </summary>
        protected override void saveProgres()
        {
            using (StreamWriter writetext = new StreamWriter("supervisedNeuralBrain.txt"))
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
