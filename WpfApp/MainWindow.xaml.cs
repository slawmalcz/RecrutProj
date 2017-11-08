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
        WorkerOfTheMonth temp;

        public MainWindow()
        {
            InitializeComponent();
            WorkerOfTheMonth temp = WorkerOfTheMonth.getInstance(this);
            temp.FillStackPanel(candidatesStackPanel);
        }

        private void BTNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(WorkerOfTheMonth.getInstance().getWorkerOfTheMonth().ToString());
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BTDelete_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
 