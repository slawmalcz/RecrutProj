using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Model
{
    class NeuralLayer
    {
        private const int neuronNum = 10;
        private CasificationNeuron[] mainLayer = new CasificationNeuron[neuronNum];

        public NeuralLayer()
        {
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, "weightInit.txt");
            if (!File.Exists(filePath)){
                using (StreamWriter writetext = new StreamWriter("weightInit.txt"))
                {
                    for (int i = 0; i < neuronNum; i++)
                    {
                        mainLayer[i] = new CasificationNeuron();
                        MessageBox.Show(mainLayer[i].generateWeightView());
                        writetext.WriteLine(mainLayer[i].generateWeightView());
                    }
                }
            }
            else
            {
                using (StreamReader readtext = new StreamReader("weightInit.txt"))
                {
                    for (int i = 0; i < neuronNum; i++)
                    {
                        string []readMeText = readtext.ReadLine().Split(',');
                        double[] sendToNeuron = new Double [Worker.parameters];
                        for(int j = 0; j < Worker.parameters; j++)
                        {
                            sendToNeuron[j] = Double.Parse(readMeText[j]);
                        }
                        mainLayer[i] = new CasificationNeuron(sendToNeuron);
                    }
                }
            }

        }

        public CasificationNeuron GetNeuron(int index)
        {
            return mainLayer[index];
        }
    }
}
