using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp.Model;
using WpfApp.ModeViev;

class CandidatePreviewModel : INotifyPropertyChanged
{

    /// FIELDS

    public event PropertyChangedEventHandler PropertyChanged = null;
    private Candidate _CandidateInfo;

    /// Properties

    public ICommand ChooseCmd { get; set; }
    public String CandidateInfo { get; set; }

    /// CONSTRUCTORS

    /// <summary>
    /// Main Constructor for CandidateModelView
    /// </summary>
    /// <param name="candidate">Candidate to show in Viev</param>
    public CandidatePreviewModel(Candidate candidate)
    {
        this._CandidateInfo = candidate;
        CandidateInfo = candidate.PrintOutputForView();
        ChooseCmd = new RelayCommand(pars => ChooseCandidate());
    }

    ///FUNCTIONS AND METHODS
    
    /// <summary>
    /// Passing candidate as Choosen to NeuralNetwork
    /// </summary>
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
