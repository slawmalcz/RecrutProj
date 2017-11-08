using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Model;
using WpfApp.Viev;

namespace WpfApp.ModeViev
{
    class WorkerOfTheMonth
    {
        private DataTable workersEwaluationData;
        private NeuralLayer supervisedNeuralNetwork;
        private NeuralLayer unsupervisedNeuralNetwork;

        private List<Candidate> candidates = new List<Candidate>();



        public WorkerOfTheMonth()
        {
            //Ladowanie danuch do tabeli
            workersEwaluationData = LoadData();
            //Tworzenie sieci neuronowej
            LoadNeuralNetwork();
            //odpytywanie danych
            candidates = supervisedNeuralNetwork.AskPreNeuralForCandidate(workersEwaluationData);
            unsupervisedNeuralNetwork.AskPreNeuralForCandidate(workersEwaluationData);
            MessageBox.Show(
                supervisedNeuralNetwork.ToString+
                "\n"+
                unsupervisedNeuralNetwork.ToString);
        }

        private DataTable LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da.SelectCommand = new SqlCommand(@"SELECT * FROM ViewWorkersProgres ", new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\Mindi\Desktop\PracProj\RecrutProj\WpfApp\MyDatabase.mdf; Integrated Security = True"));
            da.Fill(ds, "ViewWorkersProgres");
            dt = ds.Tables["ViewWorkersProgres"];

            return dt;
        }

        public void LoadNeuralNetwork()
        {
            this.supervisedNeuralNetwork = new SupervisedNeuralLayer("supervisedNeuralBrain.txt");
            this.unsupervisedNeuralNetwork = new UnsupervisedNeuralLayerNeuralLayer("unsupervisedNeuralBrain.txt");
        }

        private void FillStackPanel(List<Candidate> listCandidates,StackPanel stackPanel)
        {
            foreach(Candidate toAdd in listCandidates)
            {
                stackPanel.Children.Add((new CandidateModelViev(toAdd)).candidateViev);
            }
        }

        public void FillStackPanel(StackPanel stackPanel)
        {
            FillStackPanel(candidates,stackPanel);
        }
    }
}
