using FluentNgo.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FluentNgo.Views.Pages;

public partial class StudentView
{
    public StudentView()
    {
        InitializeComponent();
        StudentsDG.ItemsSource = new ObservableCollection<Student>(Student.StudentGetAll());
        // MessageBox.Show("Student First");
    }

    private void StudentsDG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (sender != null)
        {
            DataGrid? dataGrid = (sender as DataGrid);
            dataGrid.UnselectAll();
        }
    }

    private void Row_Click(object sender, MouseButtonEventArgs e)
    {

    }

    private void RefreshButton_Click(object sender, RoutedEventArgs e)
    {
        var view = CollectionViewSource.GetDefaultView(StudentsDG.ItemsSource);
        view?.SortDescriptions.Clear();

        foreach (var column in StudentsDG.Columns)
        {
            column.SortDirection = null;
        }
        StudentsDG.UnselectAll();
        SearchBox.Text = "";
    }
}
