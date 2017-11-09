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
        /// This class is a bridge betwean NeuronNetwork and
        /// functionality of app


        // FIELDS
        private DataTable workersEwaluationData;
        private NeuralLayer supervisedNeuralNetwork;
        private NeuralLayer unsupervisedNeuralNetwork;
        private Candidate superviverChoosen;
        private Candidate unsupervisedChoosen;
        private List<Candidate> candidates = new List<Candidate>();

        // SINGLETON IMPLEMENTATION
        //Only one allowed for compiuting power ristriction 

        private static WorkerOfTheMonth instance;
        public static WorkerOfTheMonth getInstance()
        {
            if (instance == null)
            {
                instance = new WorkerOfTheMonth();
            }
            return instance;

        }

        // CONSTRUCTOR
        /// <summary>
        /// Main constructor for Worker Of The Month Class
        /// </summary>
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

        // METHODS AND FUNCTIONS

        /// <summary>
        /// Ask NeuronNetwork for final candidate
        /// </summary>
        /// <returns>Ultimate Worker Of The Month</returns>
        public Candidate getWorkerOfTheMonth()
        {
            return new FinalNeuron(superviverChoosen.oceny, unsupervisedChoosen.oceny).AskPreNeuralForCandidate(this.LoadData());
        }

        /// <summary>
        /// Loads Data from database to data table containing workers
        /// </summary>
        /// <returns>DataTables of Workers</returns>
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

        /// <summary>
        /// Loads weights to layers of neural network
        /// </summary>
        public void LoadNeuralNetwork()
        {
            this.supervisedNeuralNetwork = new SupervisedNeuralLayer("supervisedNeuralBrain.txt");
            this.unsupervisedNeuralNetwork = new UnsupervisedNeuralLayerNeuralLayer("unsupervisedNeuralBrain.txt");
        }

        /// <summary>
        /// Generates User controll from given Candidates
        /// </summary>
        /// <param name="listCandidates">Candidate of Supervised Network</param>
        /// <returns>List of UserControl for candidate</returns>
        private List<UserControl> GetUserControlCandidates(List<Candidate> listCandidates)
        {
            List<UserControl> tempList = new List<UserControl>();
            foreach(Candidate toAdd in listCandidates)
            {
                tempList.Add(new CandidateView(toAdd));
            }
            return tempList;
        }

        /// <summary>
        /// Passes request to GetUserControlCandidates(List<Candidate> listCandidates) function
        /// </summary>
        /// <returns>List of UserControl for candidate</returns>
        public List<UserControl> GetUserControlCandidates()
        {
            return GetUserControlCandidates(candidates);
        }

        /// <summary>
        /// Set one of the dandidates as chooden by supervisor
        /// </summary>
        /// <param name="candidate">Choosen Candidate</param>
        public void setSupervisorChoosen(Candidate candidate)
        {
            this.superviverChoosen = candidate;
            supervisedNeuralNetwork.TeachPreNeural(candidate);
        }
    }
}
