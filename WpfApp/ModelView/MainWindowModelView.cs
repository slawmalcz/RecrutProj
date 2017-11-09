using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp.ModeViev
{
    class MainWindowModelView : INotifyPropertyChanged
    {
        // FIELDS

        public event PropertyChangedEventHandler PropertyChanged = null;
        private List<UserControl> _PossibleCandidates;

        // PROPERTIES

        public ICommand AskNeural { get; set; }
        public List<UserControl> PossibleCandidates {
            get {
                return _PossibleCandidates; ;
            }

            set {
                _PossibleCandidates = value;
                OnPropertyChanged("PossibleCandidates");
            }
        }

        //CONSTRUCTOR

        /// <summary>
        /// Main constructor for MainWindow
        /// </summary>
        public MainWindowModelView()
        {
            AskNeural = new RelayCommand(pars => GenerateOutput());
            PossibleCandidates =  WorkerOfTheMonth.getInstance().FillStackPanel();
        }

        // METHODS ADS FUNCTIONS
        /// <summary>
        /// Ask for final candidate of NeuronNetwork
        /// </summary>
        public void GenerateOutput()
        {
            MessageBox.Show(WorkerOfTheMonth.getInstance().getWorkerOfTheMonth().ToString());
        }

        virtual protected void OnPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
