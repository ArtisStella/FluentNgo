using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows;
using System;

namespace FluentNgo.Models
{
    public class Beneficiary
    {
        public int BeneficiaryID { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public int TotalFamilyMembers { get; set; }
        public string EmploymentStatus { get; set; }
        public string Occupation { get; set; }
        public string AcademicQualifications { get; set; }
        public string ProfessionalQualifications { get; set; }
        public int Income { get; set; }
        public string HelpDescription { get; set; }

        public static List<Beneficiary> BeneficiaryGetAll()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                var output = Connection.Query<Beneficiary>("SELECT * FROM Beneficiaries", new DynamicParameters());

                return output.AsList();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                return new List<Beneficiary>();
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool BeneficiarySave()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("INSERT INTO Beneficiaries (BeneficiaryID, Name, FatherName, MotherName, SpouseName, DOB, Address, PhoneNumber, Religion, CNIC, TotalFamilyMembers, EmploymentStatus, Occupation, Email, AcademicQualifications, ProfessionalQualifications, Income, HelpDescription) " +
                                   "VALUES (@BeneficiaryID, @Name, @FatherName, @MotherName, @SpouseName, @DOB, @Address, @PhoneNumber, @Religion, @CNIC, @TotalFamilyMembers, @EmploymentStatus, @Occupation, @Email, @AcademicQualifications, @ProfessionalQualifications, @Income, @HelpDescription)", this);
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
            }
        }

        public bool BeneficiaryUpdate()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("UPDATE Beneficiaries SET Name = @Name, FatherName = @FatherName, MotherName = @MotherName, SpouseName = @SpouseName, DOB = @DOB, Address = @Address, PhoneNumber = @PhoneNumber, Religion = @Religion, CNIC = @CNIC, TotalFamilyMembers = @TotalFamilyMembers, EmploymentStatus = @EmploymentStatus, Occupation = @Occupation, Email = @Email, AcademicQualifications = @AcademicQualifications, ProfessionalQualifications = @ProfessionalQualifications, Income = @Income, HelpDescription = @HelpDescription WHERE BeneficiaryID = @BeneficiaryID", this);
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

        public bool BeneficiaryDelete()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("DELETE FROM Beneficiaries WHERE BeneficiaryID = @BeneficiaryID", this);
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

