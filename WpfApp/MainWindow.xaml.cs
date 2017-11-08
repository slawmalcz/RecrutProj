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
using WpfApp.ModeViev;

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

        private void BTNew_Click(object sender, RoutedEventArgs e)
        {

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
            WorkerOfTheMonth temp =  new WorkerOfTheMonth();
            temp.FillStackPanel(candidatesStackPanel);
        }
    }
}
 