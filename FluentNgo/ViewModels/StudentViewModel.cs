using FluentNgo.Core;
using FluentNgo.Models;
using FluentNgo.Views;
using FluentNgo.Views.Components;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace FluentNgo.ViewModels
{
    public class StudentViewModel : ObservableObject
    {
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
        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>(Student.StudentGetAll());
            AnyRowSelected = false;
        }

        public void AddStudent()
        {
            var studentForm = new StudentForm();
            var rootWindow = (Container)Window.GetWindow(Application.Current.MainWindow);
            rootWindow.MainGrid.Effect = new BlurEffect();
            studentForm.Owner = rootWindow;

            if ((bool)studentForm.ShowDialog())
            {
                Student oStudent = studentForm.student;
                oStudent.StudentSave();
                Students.Add(oStudent);
            }
            

            // MessageBox.Show(studentForm.student.GrNo.ToString());
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
            var rootWindow = (Container)Window.GetWindow(Application.Current.MainWindow);



            rootWindow.MainGrid.Effect = new BlurEffect();
            studentForm.Owner = rootWindow;

            if ((bool)studentForm.ShowDialog())
            {
                Student oStudent = studentForm.student;
                oStudent.UpdateStudent();
            }


            // MessageBox.Show(studentForm.student.GrNo.ToString());
            rootWindow.MainGrid.Effect = null;
        }
    }
}
