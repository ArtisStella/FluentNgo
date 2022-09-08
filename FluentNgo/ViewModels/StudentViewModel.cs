using FluentNgo.Core;
using FluentNgo.Models;
using System.Collections.ObjectModel;

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

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>(Student.StudentGetAll());
        }
    }
}
