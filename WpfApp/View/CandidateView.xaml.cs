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

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for CandidateViev.xaml
    /// </summary>
    public partial class CandidateViev : UserControl
    {
        public CandidateViev(Candidate candidate)
        {
            InitializeComponent();
            this.DataContext = new CandidatePreviewModel(candidate);
        }
    }
}
