using FluentNgo.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FluentNgo.Views.Components
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        public Student student { get; set; }
        public StudentForm()
        {
            InitializeComponent();
            student = new Student();
            DataContext = this;
        }

        public StudentForm(Student stud)
        {
            InitializeComponent();
            student = stud;
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

        private void SF_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void SchoolingType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? selectedItem = ((ComboBox)sender).SelectedItem as ComboBoxItem;
            // MessageBox.Show(selectedItem.Content.ToString());
            student.SchoolingType = selectedItem.Content.ToString();
        }

        private void Religion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? selectedItem = ((ComboBox)sender).SelectedItem as ComboBoxItem;
            // MessageBox.Show(selectedItem.Content.ToString());
            student.Religion = selectedItem.Content.ToString();
        }
    }
}
