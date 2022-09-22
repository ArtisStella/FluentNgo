using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows;
using System;

namespace FluentNgo.Models
{
    public class Donor
    {
        public int DonorID { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DonationDescription { get; set; }

        public static List<Donor> DonorGetAll()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                var output = Connection.Query<Donor>("SELECT * FROM Donors", new DynamicParameters());

                return output.AsList();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                return new List<Donor>();
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool DonorSave()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("INSERT INTO Donors (DonorID, Name, Organization, Address, PhoneNumber, Email, DonationDescription) " +
                                   "VALUES (@DonorID, @Name, @Organization, @Address, @PhoneNumber, @Email, @DonationDescription)", this);
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

        public bool UpdateDonor()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("UPDATE Donors SET Name = @Name, Organization = @Organization, Address = @Address, PhoneNumber = @PhoneNumber, Email = @Email, DonationDescription = @DonationDescription WHERE DonorID = @DonorID", this);
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

        public bool DeleteDonor()
        {
            var Connection = new SQLiteConnection(App.ConnectionString);
            Connection.Open();
            try
            {
                Connection.Execute("DELETE FROM Donors WHERE DonorID  = @DonorID", this);
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


