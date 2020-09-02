using ppedv.DiagnoseTool.Logik;
using ppedv.DiagnoseTool.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.DiagnoseTool.UI.WPF.ViewModels
{
    class PatientenViewModel : INotifyPropertyChanged
    {
        Core core = new Core(new Data.Ef.EfRepository());
        private Patient selectedPatient;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Patient> PatientenListe { get; set; }

        public Patient SelectedPatient
        {
            get => selectedPatient;
            set
            {
                selectedPatient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPatient)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public string Alter
        {
            get
            {
                if (SelectedPatient == null)
                    return "---";

                return $"Alter: {CalcAge(SelectedPatient.GebDatum)}";
            }
        }

        int CalcAge(DateTime gebDatum)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - gebDatum.Year;

            // Go back to the year the person was born in case of a leap year
            if (gebDatum.Date > today.AddYears(-age)) age--;

            return age;
        }

        public PatientenViewModel()
        {
            PatientenListe = new List<Patient>(core.Repository.GetAll<Patient>());
        }
    }
}
