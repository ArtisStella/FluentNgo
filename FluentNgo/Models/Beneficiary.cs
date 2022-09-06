using System;
using System.Collections.Generic;
using System.Text;

namespace FluentNgo.Models
{
    public class Beneficiary
    {
        public Beneficiary() { }

        public Beneficiary(int id, string name, string f_name, string m_name, string sp_name, string dob,
            string address, string phone_no, string religion, string cnic, int t_family_members,
            string employment_status, string occupation, string email, string academic_qual, string prof_qual,
            int income, string help_desc)
        {
            ID = id;
            Name = name;
            FatherName = f_name;
            MotherName = m_name;
            SpouseName = sp_name;
            DOB = dob;
            Address = address;
            PhoneNumber = phone_no;
            Religion = religion;
            CNIC = cnic;
            TotalFamilyMembers = t_family_members;
            EmploymentStatus = employment_status;
            Occupation = occupation;
            Email = email;
            AcademicQualifs = academic_qual;
            ProfessionalQualifs = prof_qual;
            Income = income;
            HelpDescrip = help_desc;
        }

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
        public string EmploymentStatus { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string AcademicQualifs { get; set; }
        public string ProfessionalQualifs { get; set; }
        public int Income { get; set; }
        public string HelpDescrip { get; set; }
    }
}

