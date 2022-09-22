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
    public class DonorViewModel : ObservableObject
    {
        private ICollectionView _donorsCollection;

        public ICollectionView DonorsCollection
        {
            get { return _donorsCollection; }
            set { _donorsCollection = value; }
        }

        private ObservableCollection<Donor> _donors;
        public ObservableCollection<Donor> Donors
        {
            get { return _donors; }
            set
            {
                if (value == _donors)
                    return;
                _donors = value;
                OnPropertyChanged("Donors");
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

        public DonorViewModel()
        {
            Donors = new ObservableCollection<Donor>(Donor.DonorGetAll());

            AnyRowSelected = false;

            DonorsCollection = CollectionViewSource.GetDefaultView(Donors);
        }

        public void AddDonor()
        {
            var donorForm = new DonorForm();
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);
            rootWindow.MainGrid.Effect = new BlurEffect();
            donorForm.Owner = rootWindow;

            if ((bool)donorForm.ShowDialog())
            {
                Donor oDonor = donorForm.donor;
                if (oDonor.DonorSave())
                {
                    Donors.Add(oDonor);
                } else
                {
                    MessageBox.Show("Unable to save data, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            rootWindow.MainGrid.Effect = null;
        }

        public void RemoveDonor(Donor donor)
        {
            if (donor.DeleteDonor())
            {
                Donors.Remove(donor);
            }
        }

        public void EditDonor(Donor donor)
        {
            var donorForm = new DonorForm(donor);
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);



            rootWindow.MainGrid.Effect = new BlurEffect();
            donorForm.Owner = rootWindow;

            if ((bool)donorForm.ShowDialog())
            {
                Donor oDonor = donorForm.donor;
                if (!oDonor.UpdateDonor())
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
                DonorsCollection.Filter = null;
            }
            else
            {
                DonorsCollection.Filter = new System.Predicate<object>(FilterByName);
            }
        }

        private bool FilterByName(object stud)
        {
            //  REMOVE ToLower() TO MAKE IT CASE SENSITIVE
            Donor? donor = stud as Donor;
            if (donor.Name == null)
            {
                return false;
            }
            return donor.Name.ToLower().Contains(FilterString.ToLower());
        }
    }
}
