using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System;

namespace FluentNgo.Models
{
    public class Student
    {
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
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                var output = Connection.Query<Student>("SELECT * FROM Students", new DynamicParameters());

                return output.AsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return new List<Student>();
        }

        public static Student StudentGetById(int Id)
        {
            using (var Connection = new SQLiteConnection(App.ConnectionString))
            {
                var output = Connection.Query<Student>($"SELECT * FROM Students WHERE GrNo = {Id}", new DynamicParameters()).First();

                return output;
            }
        }
    }
}

