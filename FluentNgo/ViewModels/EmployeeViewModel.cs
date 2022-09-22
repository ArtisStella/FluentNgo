using FluentNgo.Core;
using FluentNgo.Models;
using FluentNgo.Views.Components;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Effects;

namespace FluentNgo.ViewModels
{
    public class EmployeeViewModel : ObservableObject
    {
        private ICollectionView _employeesCollection;

        public ICollectionView EmployeesCollection
        {
            get { return _employeesCollection; }
            set { _employeesCollection = value; }
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                if (value == _employees)
                    return;
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        private bool _anyRowSelected;
        public bool AnyRowSelected
        {
            get { return _anyRowSelected; }
            set
            {
                if (value == _anyRowSelected) return;
                _anyRowSelected = value;
                OnPropertyChanged("AnyRowSelected");
            }
        }

        private string FilterString { get; set; }

        public EmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>(Employee.EmployeeGetAll());

            AnyRowSelected = false;

            EmployeesCollection = CollectionViewSource.GetDefaultView(Employees);
        }

        public void AddEmployee()
        {
            var employeeForm = new EmployeeForm();
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);

            rootWindow.MainGrid.Effect = new BlurEffect();
            employeeForm.Owner = rootWindow;

            if ((bool)employeeForm.ShowDialog())
            {
                Employee oEmployee = employeeForm.employee;
                if (oEmployee.EmployeeSave())
                {
                    Employees.Add(oEmployee);
                } else
                {
                    MessageBox.Show("Unable to save data, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            rootWindow.MainGrid.Effect = null;
        }

        public void RemoveEmployee(Employee employee)
        {
            if (employee.DeleteEmployee())
            {
                Employees.Remove(employee);
            }
        }

        public void EditEmployee(Employee employee)
        {
            var employeeForm = new EmployeeForm(employee);
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);

            rootWindow.MainGrid.Effect = new BlurEffect();
            employeeForm.Owner = rootWindow;

            if ((bool)employeeForm.ShowDialog())
            {
                Employee oEmployee = employeeForm.employee;
                if (!oEmployee.UpdateEmployee())
                {
                    MessageBox.Show("Unable to save data, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            rootWindow.MainGrid.Effect = null;
        }

        public void FilterDataGrid(string query)
        {

            FilterString = query;
            bool containsInt = FilterString.Any(char.IsDigit);


            if (FilterString == "")
            {
                EmployeesCollection.Filter = null;
            }
            else
            {
                EmployeesCollection.Filter = new System.Predicate<object>(FilterEmployees);
            }
        }

        private bool FilterEmployees(object emp)
        {
            Employee? employee = emp as Employee;
            
            bool nameFilter = employee.Name == null ? false : employee.Name.ToLower().Contains(FilterString.ToLower());
            bool idFilter = employee.EmployeeID.ToString().Contains(FilterString.ToLower());

            return nameFilter || idFilter;
        }
    }
}
