using FluentNgo.Models;
using FluentNgo.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FluentNgo.Views.Pages;

public partial class BeneficiaryView
{
    BeneficiaryViewModel BeneficiaryVM { get; set; }
    public BeneficiaryView()
    {
        InitializeComponent();
        BeneficiaryVM = (BeneficiaryViewModel)this.DataContext;
    }

    private void BeneficiarysDG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
        var view = CollectionViewSource.GetDefaultView(BeneficiarysDG.ItemsSource);
        view?.SortDescriptions.Clear();

        foreach (var column in BeneficiarysDG.Columns)
        {
            column.SortDirection = null;
        }
        BeneficiarysDG.UnselectAll();
        SearchBox.Text = "";
    }

    private void BeneficiarysDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender != null)
        {
            DataGrid dg = (DataGrid)sender;
            BeneficiaryVM.AnyRowSelected = dg.SelectedItems.Count > 0;
        }

    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        BeneficiaryVM.AddBeneficiary();
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        BeneficiaryVM.RemoveBeneficiary(BeneficiarysDG.SelectedItem as Beneficiary);
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        BeneficiaryVM.EditBeneficiary(BeneficiarysDG.SelectedItem as Beneficiary);
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        BeneficiaryVM.FilterDataGrid(((TextBox)sender).Text);
    }
}
