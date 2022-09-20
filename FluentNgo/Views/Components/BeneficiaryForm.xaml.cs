using FluentNgo.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FluentNgo.Views.Components
{
    /// <summary>
    /// Interaction logic for BeneficiaryForm.xaml
    /// </summary>
    public partial class BeneficiaryForm : Window
    {
        public Beneficiary beneficiary { get; set; }

        public BeneficiaryForm()
        {
            InitializeComponent();
            beneficiary = new Beneficiary();
            DataContext = this;
        }

        public BeneficiaryForm(Beneficiary beneficiary)
        {
            InitializeComponent();
            this.beneficiary = beneficiary;
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

        private void BF_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RootGrid.Focus();
        }

        private void HandleExpanders(object sender, RoutedEventArgs e)
        {
            foreach (var child in ExpanderPannel.Children)
            {
                if (child is Expander && child != sender as Expander)
                    ((Expander)child).IsExpanded = false;
            }
        }
    }
}
