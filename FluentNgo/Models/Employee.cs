﻿using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows;
using System;

namespace FluentNgo.Models
{
    public class Employee
    {
        public int ID { get; set; }
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
        public string AcademicQualifs { get; set; }
        public string ProfessionalQualifs { get; set; }
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
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return new List<Employee>();
        }

        public bool EmployeeSave()
        {
            bool result = false;
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("INSERT INTO Employees (ID, Name, FatherName, MotherName, SpouseName, DOB, Address, PhoneNumber, Religion, CNIC, TotalFamilyMembers, InitialSalary, CurrentSalary, Email, AcademicQualifs, ProfessionalQualifs, Occupation, TotalYearsOfExperience, CertificationSkills) " +
                    "VALUES (@ID, @Name, @FatherName, @MotherName, @SpouseName, @DOB, @Address, @PhoneNumber, @Religion, @CNIC, @TotalFamilyMembers, @InitialSalary, @CurrentSalary, @Email, @AcademicQualifs, @ProfessionalQualifs, @Occupation, @TotalYearsOfExperience, @CertificationSkills)", this);
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = false;
            }
            finally
            {
                Connection.Close();
            }
            return result;
        }

        public bool UpdateEmployee()
        {
            bool result = false;
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("UPDATE Employees SET Name = @Name, FatherName = @FatherName, FatherName = @FatherName, SpouseName = @SpouseName, DOB = @DOB, Address = @Address, PhoneNumber = @PhoneNumber, Religion = @Religion, CNIC = @CNIC, TotalFamilyMembers = @TotalFamilyMembers, InitialSalary = @InitialSalary, CurrentSalary = @CurrentSalary, Email = @Email, AcademicQualifs = @AcademicQualifs, ProfessionalQualifs = @ProfessionalQualifs, Occupation = @Occupation, TotalYearsOfExperience = @TotalYearsOfExperience, CertificationSkills = @CertificationSkills WHERE ID = @ID", this);
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = false;
            }
            finally
            {
                Connection.Close();
            }
            return result;
        }

        public bool DeleteEmployee()
        {
            bool result = false;
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("DELETE FROM Employees WHERE ID = @ID", this);
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = false;
            }
            finally
            {
                Connection.Close();
            }
            return result;

        }
    }
}
