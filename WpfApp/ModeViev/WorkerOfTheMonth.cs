using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Model;

namespace WpfApp.ModeViev
{
    class WorkerOfTheMonth
    {
        private DataTable workersEwaluationData;
        private SupervisedNeuralLayer supervisedNeuralNetwork;
        private NeuralLayer unsupervisedNeuralNetwork;



        public WorkerOfTheMonth()
        {
            //Ladowanie danuch do tabeli
            workersEwaluationData = LoadData();
            //Tworzenie sieci neuronowej
            LoadNeuralNetwork();
            //odpytywanie danych
            
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
            this.unsupervisedNeuralNetwork = new NeuralLayer("unsupervisedNeuralBrain.txt");
        }

    }
}
