using FluentNgo.Models;
using FluentNgo.ViewModels;
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
        // StudentsDG.ItemsSource = new ObservableCollection<Student>(Student.StudentGetAll());
        // MessageBox.Show("Student First");
    }

    private void StudentsDG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
        var view = CollectionViewSource.GetDefaultView(StudentsDG.ItemsSource);
        view?.SortDescriptions.Clear();

        foreach (var column in StudentsDG.Columns)
        {
            column.SortDirection = null;
        }
        StudentsDG.UnselectAll();
        SearchBox.Text = "";
    }

    private void StudentsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender != null)
        {
            StudentViewModel studentVm = (StudentViewModel)this.DataContext;
            DataGrid dg = (DataGrid)sender;
            studentVm.AnyRowSelected = dg.SelectedItems.Count > 0;
        }

    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        StudentViewModel studentVm = (StudentViewModel)this.DataContext;
        studentVm.AddStudent();
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        StudentViewModel studentVm = (StudentViewModel)this.DataContext;
        studentVm.RemoveStudent(StudentsDG.SelectedItem as Student);
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        StudentViewModel studentVm = (StudentViewModel)this.DataContext;
        studentVm.EditStudent(StudentsDG.SelectedItem as Student);
    }
}
