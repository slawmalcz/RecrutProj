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
using WpfApp.View;

namespace WpfApp.ModeViev
{
    class WorkerOfTheMonth
    {
        private DataTable workersEwaluationData;
        private NeuralLayer supervisedNeuralNetwork;
        private NeuralLayer unsupervisedNeuralNetwork;

        private List<Candidate> candidates = new List<Candidate>();

        private static WorkerOfTheMonth instance;

        public static WorkerOfTheMonth getInstance()
        {
            if (instance == null)
            {
                instance = new WorkerOfTheMonth();
            }
            return instance;

        }

        private WorkerOfTheMonth()
        {
            //Ladowanie danuch do tabeli
            workersEwaluationData = LoadData();
            //Tworzenie sieci neuronowej
            LoadNeuralNetwork();
            //odpytywanie danych
            candidates = supervisedNeuralNetwork.AskPreNeuralForCandidate(workersEwaluationData);
            unsupervisedChoosen =  unsupervisedNeuralNetwork.AskPreNeuralForCandidate(workersEwaluationData)[0];
        }

        public Candidate getWorkerOfTheMonth()
        {
            return new FinalNeuron(superviverChoosen.oceny, unsupervisedChoosen.oceny).AskPreNeuralForCandidate(this.LoadData());
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

        private List<UserControl> FillStackPanel(List<Candidate> listCandidates)
        {
            List<UserControl> tempList = new List<UserControl>();
            foreach(Candidate toAdd in listCandidates)
            {
                tempList.Add(new CandidateView(toAdd));
            }
            return tempList;
        }

        public List<UserControl> FillStackPanel()
        {
            return FillStackPanel(candidates);
        }

        // COŚ tam dalej

        private Candidate superviverChoosen;
        private Candidate unsupervisedChoosen;

        public void setSupervisorChoosen(Candidate candidate)
        {
            this.superviverChoosen = candidate;
            supervisedNeuralNetwork.TeachPreNeural(candidate);
            MessageBox.Show("I get :" + candidate.ToString());
            //this.stackPanel.Children.Clear();

        }
    }
}
