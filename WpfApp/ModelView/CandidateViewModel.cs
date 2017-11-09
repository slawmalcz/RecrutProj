using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp.Model;
using WpfApp.ModeViev;

class CandidatePreviewModel : INotifyPropertyChanged
{
    public CandidatePreviewModel(Candidate candidate)
    {
        this._CandidateInfo = candidate;
        CandidateInfo = candidate.PrintOutputForView();
        ChooseCmd = new RelayCommand(pars => ChooseCandidate());
    }

    public event PropertyChangedEventHandler PropertyChanged = null;
    public ICommand ChooseCmd { get; set; }

    private Candidate _CandidateInfo;
    public String CandidateInfo { get; set; }

    public void ChooseCandidate()
    {
        MessageBox.Show("Wybrano tego kolesia " + _CandidateInfo.PrintOutputForView());
        WorkerOfTheMonth.getInstance().setSupervisorChoosen(_CandidateInfo);
    }

    virtual protected void OnPropertyChanged(String propName)
    {
        if(PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
