using Wpf.Ui.Controls;

namespace FluentNgo.Views
{
    /// <summary>
    /// Interaction logic for Container.xaml
    /// </summary>
    public partial class Container : UiWindow
    {
        public Container()
        {
            InitializeComponent();
        }

        private void UiWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainGrid.Focus();
        }
    }
}
