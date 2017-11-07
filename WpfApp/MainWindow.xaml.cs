using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApp.PracownicyDataSet pracownicyDataSet = ((WpfApp.PracownicyDataSet)(this.FindResource("pracownicyDataSet")));
            // Load data into the table Pracownicy. You can modify this code as needed.
            WpfApp.PracownicyDataSetTableAdapters.PracownicyTableAdapter pracownicyDataSetPracownicyTableAdapter = new WpfApp.PracownicyDataSetTableAdapters.PracownicyTableAdapter();
            pracownicyDataSetPracownicyTableAdapter.Fill(pracownicyDataSet.Pracownicy);
            ////
        }

        private void BTNew_Click(object sender, RoutedEventArgs e)
        {
            WpfApp.PracownicyDataSet pracownicyDataSet = ((WpfApp.PracownicyDataSet)(this.FindResource("pracownicyDataSet")));
            pracownicyDataSet.Pracownicy.AddPracownicyRow(
                imieTextBox.Text, nazwiskoTextBox.Text,
                data_urodzeniaDatePicker.SelectedDate.Value.Date,
                adresTextBox.Text,
                pracownicyDataSet.Pracownicy[Int32.Parse(szef_IDTextBox.Text)],
                Int32.Parse(dzial_IDTextBox.Text),
                Int32.Parse(stanowisko_IDTextBox.Text),
                Decimal.Parse(placaTextBox.Text));

            MessageBox.Show("Poszlo");

        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da.SelectCommand = new SqlCommand(@"SELECT * FROM ViewWorkersProgres ",new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\Mindi\Desktop\PracProj\RecrutProj\WpfApp\MyDatabase.mdf; Integrated Security = True") );
            da.Fill(ds, "ViewWorkersProgres");
            dt = ds.Tables["ViewWorkersProgres"];

            foreach (DataRow dr in dt.Rows)
            {
                Worker temp = new Worker(dr);
                MessageBox.Show( temp.ToString());
            }
        }

        private void BTDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da.SelectCommand = new SqlCommand(@"SELECT * FROM ViewWorkersProgres ", new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\Mindi\Desktop\PracProj\RecrutProj\WpfApp\MyDatabase.mdf; Integrated Security = True"));
            da.Fill(ds, "ViewWorkersProgres");
            dt = ds.Tables["ViewWorkersProgres"];

            NeuralLayer neuralLayer = new NeuralLayer();
            MessageBox.Show(neuralLayer.GetNeuron(0).generateWeightView());

            foreach (DataRow dr in dt.Rows)
            {
                Worker temp = new Worker(dr);
                MessageBox.Show(temp.ToString());
                neuralLayer.GetNeuron(0).generateOutput(temp.oceny);
                neuralLayer.GetNeuron(0).DeltaRegule(temp.oceny);
                neuralLayer.GetNeuron(0).generateOutput(temp.oceny);
            }
        }
    }
}
