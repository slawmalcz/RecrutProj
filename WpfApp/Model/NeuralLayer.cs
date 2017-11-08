﻿using System;
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
        public static int neuronNum = 5;
        private CasificationNeuron[] mainLayer = new CasificationNeuron[neuronNum];

        public NeuralLayer(String initiateFileName)
        {
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, initiateFileName);
            if (!File.Exists(filePath)){
                using (StreamWriter writetext = new StreamWriter(initiateFileName))
                {
                    for (int i = 0; i < neuronNum; i++)
                    {
                        mainLayer[i] = new CasificationNeuron();
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
                        mainLayer[i] = new CasificationNeuron(sendToNeuron);
                    }
                }
            }

        }

        protected CasificationNeuron GetNeuron(int index)
        {
            return mainLayer[index];
        }
    }
}
