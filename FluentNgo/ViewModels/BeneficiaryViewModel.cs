using FluentNgo.Core;
using FluentNgo.Models;
using FluentNgo.Views.Components;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Effects;

namespace FluentNgo.ViewModels
{
    public class BeneficiaryViewModel : ObservableObject
    {
        private ICollectionView _beneficiariesCollection;

        public ICollectionView BeneficiariesCollection
        {
            get { return _beneficiariesCollection; }
            set { _beneficiariesCollection = value; }
        }

        private ObservableCollection<Beneficiary> _beneficiaries;
        public ObservableCollection<Beneficiary> Beneficiaries
        {
            get { return _beneficiaries; }
            set
            {
                if (value == _beneficiaries)
                    return;
                _beneficiaries = value;
                OnPropertyChanged("Beneficiaries");
            }
        }

        private bool _anyRowSelected;
        public bool AnyRowSelected
        {
            get { return _anyRowSelected; }
            set
            {
                if (value == _anyRowSelected) return;
                _anyRowSelected = value;
                OnPropertyChanged("AnyRowSelected");
            }
        }

        private string FilterString { get; set; }

        public BeneficiaryViewModel()
        {
            Beneficiaries = new ObservableCollection<Beneficiary>(Beneficiary.BeneficiaryGetAll());

            AnyRowSelected = false;

            BeneficiariesCollection = CollectionViewSource.GetDefaultView(Beneficiaries);
        }

        public void AddBeneficiary()
        {
            var beneficiaryForm = new BeneficiaryForm();
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);
            rootWindow.MainGrid.Effect = new BlurEffect();
            beneficiaryForm.Owner = rootWindow;

            if ((bool)beneficiaryForm.ShowDialog())
            {
                Beneficiary oBeneficiary = beneficiaryForm.beneficiary;
                if (oBeneficiary.BeneficiarySave())
                {
                    Beneficiaries.Add(oBeneficiary);
                } else
                {
                    MessageBox.Show("Unable to save data, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            rootWindow.MainGrid.Effect = null;
        }

        public void RemoveBeneficiary(Beneficiary beneficiary)
        {
            if (beneficiary.BeneficiaryDelete())
            {
                Beneficiaries.Remove(beneficiary);
            }
        }

        public void EditBeneficiary(Beneficiary beneficiary)
        {
            var beneficiaryForm = new BeneficiaryForm(beneficiary);
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);

            rootWindow.MainGrid.Effect = new BlurEffect();
            beneficiaryForm.Owner = rootWindow;

            if ((bool)beneficiaryForm.ShowDialog())
            {
                Beneficiary oBeneficiary = beneficiaryForm.beneficiary;
                if (!oBeneficiary.BeneficiaryUpdate())
                {
                    MessageBox.Show("Unable to save data, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            rootWindow.MainGrid.Effect = null;
        }

        public void FilterDataGrid(string query)
        {

            FilterString = query;

            if (FilterString == "")
            {
                BeneficiariesCollection.Filter = null;
            }
            else
            {
                BeneficiariesCollection.Filter = new System.Predicate<object>(FilterBeneficiaries);
            }
        }

        private bool FilterBeneficiaries(object bene)
        {
            Beneficiary? beneficiary = bene as Beneficiary;
            
            //  REMOVE ToLower() TO MAKE IT CASE SENSITIVE
            bool nameFilter = beneficiary.Name != null ? beneficiary.Name.ToLower().Contains(FilterString.ToLower()) : false;
            bool idFilter = beneficiary.BeneficiaryID.ToString().Contains(FilterString.ToLower());
            
            return nameFilter || idFilter;
        }
    }
}
