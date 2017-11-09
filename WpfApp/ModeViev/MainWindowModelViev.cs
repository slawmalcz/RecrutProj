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
    class MainWindowModelViev : INotifyPropertyChanged
    {
        public MainWindowModelViev()
        {
            AskNeural = new RelayCommand(pars => GenerateOutput());
            PossibleCandidates =  WorkerOfTheMonth.getInstance().FillStackPanel();
        }

        public event PropertyChangedEventHandler PropertyChanged = null;
        public ICommand AskNeural { get; set; }

        private List<UserControl> _PossibleCandidates;
        public List<UserControl> PossibleCandidates {
            get {
                return _PossibleCandidates; ;
            }

            set {
                _PossibleCandidates = value;
                OnPropertyChanged("PossibleCandidates");
            }
        }

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
