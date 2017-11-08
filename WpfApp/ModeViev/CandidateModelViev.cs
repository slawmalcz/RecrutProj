using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;
using WpfApp.Viev;

namespace WpfApp.ModeViev
{
    class CandidateModelViev
    {
        private Candidate candidate;
        public CandidatePreviev candidateViev;

        public CandidateModelViev( Candidate candidate)
        {
            this.candidate = candidate;
            candidateViev = new CandidatePreviev(candidate);
        }
    }

    public class Test
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ilosc_kodu { get; set; }
        public string O_issue { get; set; }
        public string O_character { get; set; }
        public string Spoznienia { get; set; }
        public string B_wKodzie { get; set; }
        public string Samodoskonal { get; set; }
        public string End_proj { get; set; }
    }
}
