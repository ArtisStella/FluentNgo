using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;
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
                // MessageBox.Show(ex.ToString());
                return new List<Student>();
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool StudentSave()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("INSERT INTO Students (GrNo, Name, FatherName, MotherName, Class, DOB, Address, PhoneNumber, Religion, NIC, DateOfAdmission, TotalFamilyMembers, FathersOccupation, FirstAdmittedClass, Grades, SchoolingType, Email) " +
                    "VALUES (@GrNo, @Name, @FatherName, @MotherName, @Class, @DOB, @Address, @PhoneNumber, @Religion, @NIC, @DateOfAdmission, @TotalFamilyMembers, @FathersOccupation, @FirstAdmittedClass, @Grades, @SchoolingType, @Email)", this);
                return true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool UpdateStudent()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("UPDATE Students SET Name = @Name, FatherName = @FatherName, FatherName = @FatherName, Class = @Class, DOB = @DOB, Address = @Address, PhoneNumber = @PhoneNumber, Religion = @Religion, NIC = @NIC, DateOfAdmission = @DateOfAdmission, TotalFamilyMembers = @TotalFamilyMembers, FathersOccupation = @FathersOccupation, FirstAdmittedClass = @FirstAdmittedClass, Grades = @Grades, SchoolingType = @SchoolingType, Email = @Email WHERE GrNo = @GrNo", this);
                return true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        
        public bool DeleteStudent()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("DELETE FROM Students WHERE GrNo = @GrNo", this);
                return true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}

