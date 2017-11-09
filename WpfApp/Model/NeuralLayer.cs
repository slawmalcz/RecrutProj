using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Model
{
    abstract class NeuralLayer
    {
        ///FIELDS

        /// <summary>
        /// Constant value defining number of neurons
        /// </summary>
        public static int neuronNum = 5;
        /// <summary>
        /// Main neural layer containin all neurons
        /// </summary>
        protected Neuron[] mainLayer = new Neuron[neuronNum];

        ///PROPERITES

        /// <summary>
        /// List of candidates selected by neurons in neural layer
        /// </summary>
        public List<Candidate> candidates {
            get;
            protected set;
        }

        /// <summary>
        /// Main constructor for all neural layer, with saving data to file named like the parameter or read data.
        /// </summary>
        /// <param name="initiateFileName">File name to save instance or read</param>
        public NeuralLayer(String initiateFileName)
        {
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, initiateFileName);
            if (!File.Exists(filePath)){
                using (StreamWriter writetext = new StreamWriter(initiateFileName))
                {
                    for (int i = 0; i < neuronNum; i++)
                    {
                        mainLayer[i] = new Neuron();
                        writetext.WriteLine(mainLayer[i].generateWeightView());
                    }
                }
            }
            else
            {
                using (StreamReader readtext = new StreamReader(initiateFileName))
                {
                    for (int i = 0; i < neuronNum; i++)
                    {
                        string []readMeText = readtext.ReadLine().Split(',');
                        double[] sendToNeuron = new Double [Worker.parameters];
                        for(int j = 0; j < Worker.parameters; j++)
                        {
                            sendToNeuron[j] = Double.Parse(readMeText[j]);
                        }
                        mainLayer[i] = new Neuron(sendToNeuron);
                    }
                }
            }

        }
        /// <summary>
        /// Generate short description for layer
        /// </summary>
        public new String ToString {
            get {
                String Test = "";
                foreach (Candidate a in candidates)
                {
                    Test += a.ToString() + "\n";
                }
                return Test;
            }
        }
        /// <summary>
        /// Function for extracting neurons from layer
        /// </summary>
        /// <param name="index">Inex number of neuron</param>
        /// <returns>Requested Neuron</returns>
        protected Neuron GetNeuron(int index)
        {
            return mainLayer[index];
        }


        /// ABSTRACT METHOD AND FUNCTION

        public abstract List<Candidate> AskPreNeuralForCandidate(DataTable dt);
        public abstract void TeachPreNeural(Candidate candidate);
        protected abstract void saveProgres();
    }
}
