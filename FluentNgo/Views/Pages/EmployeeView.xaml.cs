using FluentNgo.Models;
using FluentNgo.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FluentNgo.Views.Pages;

public partial class EmployeeView
{
    EmployeeViewModel EmployeeVM { get; set; }
    public EmployeeView()
    {
        InitializeComponent();
        EmployeeVM = (EmployeeViewModel)this.DataContext;
    }

    private void EmployeesDG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
        var view = CollectionViewSource.GetDefaultView(EmployeesDG.ItemsSource);
        view?.SortDescriptions.Clear();

        foreach (var column in EmployeesDG.Columns)
        {
            column.SortDirection = null;
        }
        EmployeesDG.UnselectAll();
        SearchBox.Text = "";
    }

    private void EmployeesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender != null)
        {
            DataGrid dg = (DataGrid)sender;
            EmployeeVM.AnyRowSelected = dg.SelectedItems.Count > 0;
        }

    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        EmployeeVM.AddEmployee();
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        EmployeeVM.RemoveEmployee(EmployeesDG.SelectedItem as Employee);
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        EmployeeVM.EditEmployee(EmployeesDG.SelectedItem as Employee);
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        EmployeeVM.FilterDataGrid(((TextBox)sender).Text);
    }
}
