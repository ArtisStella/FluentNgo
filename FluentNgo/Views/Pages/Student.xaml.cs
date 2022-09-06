using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FluentNgo.Views.Pages;

public partial class Student
{
    public Student()
    {
        InitializeComponent();
        MessageBox.Show("Student!");
    }

    private void StudentsDG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {

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
    }
}
