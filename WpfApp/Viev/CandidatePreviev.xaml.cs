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
        public CandidatePreviev(Candidate candidate)
        {
            InitializeComponent();
            ListTable.Items.Add(candidate.PrintOutputForView());
        }
    }
}
