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
        

        public SupervisedNeuralLayer(String pathToFile) : base(pathToFile)
        {
            candidates = new List<Candidate>();
        }

        public override List<Candidate> AskPreNeuralForCandidate(DataTable dt)
        {
            List<Candidate> candidatesTemp = new List<Candidate>();
            for (int i = 0; i < NeuralLayer.neuronNum; i++)
            {
                double maxWeigh = -70;//(SCALE FROM 1-10)*(RANDOM FROM -1...1)*(7 NUMBERS OF PARAMETERS)
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

        protected override void saveProgres()
        {
            using (StreamWriter writetext = new StreamWriter("supervisedNeuralBrain.txt"))
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
