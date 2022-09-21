using FluentNgo.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FluentNgo.Views.Components
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        public Employee employee { get; set; }
        public EmployeeForm()
        {
            InitializeComponent();
            employee = new Employee();
            DataContext = this;
        }

        public EmployeeForm(Employee stud)
        {
            InitializeComponent();
            employee = stud;
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

        private void EF_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void Religion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? selectedItem = ((ComboBox)sender).SelectedItem as ComboBoxItem;
            // MessageBox.Show(selectedItem.Content.ToString());
            employee.Religion = selectedItem.Content.ToString();
        }
    }
}
