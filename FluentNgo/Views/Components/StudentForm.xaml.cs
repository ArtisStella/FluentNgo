using FluentNgo.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.Ui.Controls;

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
            student.GrNo = 1234;
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
    }
}
