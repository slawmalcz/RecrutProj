using System;
using System.Collections.Generic;
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

namespace WpfApp.Viev
{
    /// <summary>
    /// Interaction logic for CandidatePreviev.xaml
    /// </summary>
    public partial class CandidatePreviev : UserControl
    {
        private Candidate Candidate;

        public CandidatePreviev(Candidate candidate)
        {
            InitializeComponent();
            this.Candidate = candidate;
            ListTable.Items.Add(candidate.PrintOutputForView());
        }

        private void ChooseCandidate_Click(object sender, RoutedEventArgs e)
        {
            WorkerOfTheMonth.getInstance().setSupervisorChoosen(Candidate);
        }
    }
}
