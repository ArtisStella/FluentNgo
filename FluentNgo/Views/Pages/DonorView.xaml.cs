using FluentNgo.Models;
using FluentNgo.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FluentNgo.Views.Pages;

public partial class DonorView
{
    DonorViewModel DonorVM { get; set; }
    public DonorView()
    {
        InitializeComponent();
        DonorVM = (DonorViewModel)this.DataContext;
    }

    private void DonorDG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (sender != null)
        {
            (sender as DataGrid)?.UnselectAll(); ;
        }
    }

    private void Row_Click(object sender, MouseButtonEventArgs e)
    {

    }

    private void RefreshButton_Click(object sender, RoutedEventArgs e)
    {
        var view = CollectionViewSource.GetDefaultView(DonorDG.ItemsSource);
        view?.SortDescriptions.Clear();

        foreach (var column in DonorDG.Columns)
        {
            column.SortDirection = null;
        }
        DonorDG.UnselectAll();
        SearchBox.Text = "";
    }

    private void DonorDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender != null)
        {
            DataGrid dg = (DataGrid)sender;
            DonorVM.AnyRowSelected = dg.SelectedItems.Count > 0;
        }

    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        DonorVM.AddDonor();
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        DonorVM.RemoveDonor(DonorDG.SelectedItem as Donor);
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        DonorVM.EditDonor(DonorDG.SelectedItem as Donor);
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        DonorVM.FilterDataGrid(((TextBox)sender).Text);
    }
}
