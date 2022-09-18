using FluentNgo.Models;
using System.Windows;
using System.Windows.Input;

namespace FluentNgo.Views.Components
{
    /// <summary>
    /// Interaction logic for DonorForm.xaml
    /// </summary>
    
    public partial class DonorForm : Window
    {

        public Donor donor { get; set; }
        public DonorForm()
        {
            InitializeComponent();
            donor = new Donor();
            DataContext = this;
        }

        public DonorForm(Donor donr)
        {
            InitializeComponent();
            donor = donr;
            DataContext = this;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SubmitForm(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void DF_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RootGrid.Focus();
        }
    }
}
