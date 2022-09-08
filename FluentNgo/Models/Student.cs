using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;

namespace FluentNgo.Models
{
    public class Student
    {
        public Student() { }

        public Student(int gr_no, string name, string f_name, string m_name, string grade_class,
            string dob, string address, string phone_no, string religion, string nic, string admission_date,
            int t_family_members, string f_occupation, string first_admitted_class, string email,
            string schooling_type, string grades_results)
        {
            GrNo = gr_no;
            Name = name;
            FatherName = f_name;
            MotherName = m_name;
            Class = grade_class;
            DOB = dob;
            Address = address;
            PhoneNumber = phone_no;
            Religion = religion;
            NIC = nic;
            DateOfAdmission = admission_date;
            TotalFamilyMembers = t_family_members;
            FathersOccupation = f_occupation;
            FirstAdmittedClass = first_admitted_class;
            Email = email;
            SchoolingType = schooling_type;
            Grades = grades_results;
        }

        public int GrNo { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Class { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Religion { get; set; }
        public string NIC { get; set; }
        public string DateOfAdmission { get; set; }
        public int TotalFamilyMembers { get; set; }
        public string FathersOccupation { get; set; }
        public string FirstAdmittedClass { get; set; }
        public string Email { get; set; }
        public string SchoolingType { get; set; }
        public string Grades { get; set; }


        public static List<Student> StudentGetAll()
        {
            using (var Connection = new SQLiteConnection(App.ConnectionString))
            {
                var output = Connection.Query<Student>("SELECT * FROM Students", new DynamicParameters());

                return output.AsList();
            }
        }
    }
}

