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
        private StackPanel stackPanel;

        private static WorkerOfTheMonth instance;

        public static WorkerOfTheMonth getInstance(MainWindow mainWindow)
        {
            if (instance == null)
            {
                instance = new WorkerOfTheMonth(mainWindow);
            }
            return instance;

        }
        public static WorkerOfTheMonth getInstance()
        {
            return instance;
        }

        private WorkerOfTheMonth(MainWindow mainWindow)
        {
            try
            {
                stackPanel = mainWindow.candidatesStackPanel;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

        private void FillStackPanel(List<Candidate> listCandidates,StackPanel stackPanel)
        {
            foreach(Candidate toAdd in listCandidates)
            {
                stackPanel.Children.Add(new CandidateViev(toAdd));
            }
        }

        public void FillStackPanel(StackPanel stackPanel)
        {
            FillStackPanel(candidates,stackPanel);
        }

        // COŚ tam dalej

        private Candidate superviverChoosen;
        private Candidate unsupervisedChoosen;

        public void setSupervisorChoosen(Candidate candidate)
        {
            this.superviverChoosen = candidate;
            supervisedNeuralNetwork.TeachPreNeural(candidate);
            MessageBox.Show("I get :" + candidate.ToString());
            this.stackPanel.Children.Clear();

        }
    }
}
