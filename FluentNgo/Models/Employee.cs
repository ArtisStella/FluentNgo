using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows;
using System;

namespace FluentNgo.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Religion { get; set; }
        public string CNIC { get; set; }
        public int TotalFamilyMembers { get; set; }
        public int InitialSalary { get; set; }
        public int CurrentSalary { get; set; }
        public string Email { get; set; }
        public string AcademicQualifications { get; set; }
        public string ProfessionalQualifications { get; set; }
        public string Occupation { get; set; }
        public int TotalYearsOfExperience { get; set; }
        public string CertificationSkills { get; set; }

        public static List<Employee> EmployeeGetAll()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                var output = Connection.Query<Employee>("SELECT * FROM Employees", new DynamicParameters());

                return output.AsList();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                return new List<Employee>();
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool EmployeeSave()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("INSERT INTO Employees (EmployeeID, Name, FatherName, MotherName, SpouseName, DOB, Address, PhoneNumber, Religion, CNIC, TotalFamilyMembers, InitialSalary, CurrentSalary, Email, AcademicQualifications, ProfessionalQualifications, Occupation, TotalYearsOfExperience, CertificationSkills) " +
                    "VALUES (@EmployeeID, @Name, @FatherName, @MotherName, @SpouseName, @DOB, @Address, @PhoneNumber, @Religion, @CNIC, @TotalFamilyMembers, @InitialSalary, @CurrentSalary, @Email, @AcademicQualifications, @ProfessionalQualifications, @Occupation, @TotalYearsOfExperience, @CertificationSkills)", this);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                Connection.Close();
            };
        }

        public bool UpdateEmployee()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("UPDATE Employees SET Name = @Name, FatherName = @FatherName, FatherName = @FatherName, SpouseName = @SpouseName, DOB = @DOB, Address = @Address, PhoneNumber = @PhoneNumber, Religion = @Religion, CNIC = @CNIC, TotalFamilyMembers = @TotalFamilyMembers, InitialSalary = @InitialSalary, CurrentSalary = @CurrentSalary, Email = @Email, AcademicQualifications = @AcademicQualifications, ProfessionalQualifications = @ProfessionalQualifications, Occupation = @Occupation, TotalYearsOfExperience = @TotalYearsOfExperience, CertificationSkills = @CertificationSkills WHERE EmployeeID = @EmployeeID", this);
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

        public bool DeleteEmployee()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", this);
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
