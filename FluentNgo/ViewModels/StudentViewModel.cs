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
    public class StudentViewModel : ObservableObject
    {
        private ICollectionView _studentsCollection;

        public ICollectionView StudentsCollection
        {
            get { return _studentsCollection; }
            set { _studentsCollection = value; }
        }

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                if (value == _students)
                    return;
                _students = value;
                OnPropertyChanged("Students");
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

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>(Student.StudentGetAll());
            
            AnyRowSelected = false;

            StudentsCollection = CollectionViewSource.GetDefaultView(Students);
        }

        public void AddStudent()
        {
            var studentForm = new StudentForm();
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);
            rootWindow.MainGrid.Effect = new BlurEffect();
            studentForm.Owner = rootWindow;

            if ((bool)studentForm.ShowDialog())
            {
                Student oStudent = studentForm.student;
                if (oStudent.StudentSave())
                {
                    Students.Add(oStudent);
                } else
                {
                    MessageBox.Show("Unable to save data, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            rootWindow.MainGrid.Effect = null;
        }

        public void RemoveStudent(Student student)
        {
            if (student.DeleteStudent())
            {
                Students.Remove(student);
            }
        }

        public void EditStudent(Student student)
        {
            var studentForm = new StudentForm(student);
            var rootWindow = (Views.Container)Window.GetWindow(Application.Current.MainWindow);

            rootWindow.MainGrid.Effect = new BlurEffect();
            studentForm.Owner = rootWindow;

            if ((bool)studentForm.ShowDialog())
            {
                Student oStudent = studentForm.student;
                if (!oStudent.UpdateStudent())
                {
                    MessageBox.Show("Unable to save data, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            rootWindow.MainGrid.Effect = null;
        }

        public void FilterDataGrid(string query) {

            FilterString = query;
            bool containsInt = FilterString.Any(char.IsDigit);


            if (FilterString== "")
            {
                StudentsCollection.Filter = null;
            }
            else if(containsInt == false)
            {
                StudentsCollection.Filter = new System.Predicate<object>(FilterByName);
            }
            else
            {
                StudentsCollection.Filter = new System.Predicate<object>(FilterByGrNo);
            }
        }

        private bool FilterByName(object stud)
        {
            //  REMOVE ToLower() TO MAKE IT CASE SENSITIVE
            Student? student = stud as Student;
            if (student.Name == null)
            {
                return false;
            }
            return student.Name.ToLower().Contains(FilterString.ToLower());
        }

        private bool FilterByGrNo(object stud)
        {
            Student? student = stud as Student;
            return student.GrNo.ToString().Contains(FilterString);
        }

    }
}
