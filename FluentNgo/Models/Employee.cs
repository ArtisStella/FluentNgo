using System;
using System.Collections.Generic;
using System.Text;

namespace FluentNgo.Models
{
    public class Employee
    {
        public Employee() { }

        public Employee(int id, string name, string f_name, string m_name, string sp_name, string dob,
            string address, string phone_no, string religion, string cnic, int t_family_members,
            int initial_salary, int current_salary, string email, string academic_qual, string prof_qual,
            string occupation, int t_experience_yrs, string cert_n_skills)
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
            InitialSalary = initial_salary;
            CurrentSalary = current_salary;
            Email = email;
            AcademicQualifs = academic_qual;
            ProfessionalQualifs = prof_qual;
            Occupation = occupation;
            TotalExperienceYrs = t_experience_yrs;
            CertificationSkills = cert_n_skills;
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
        public int InitialSalary { get; set; }
        public int CurrentSalary { get; set; }
        public string Email { get; set; }
        public string AcademicQualifs { get; set; }
        public string ProfessionalQualifs { get; set; }
        public string Occupation { get; set; }
        public int TotalExperienceYrs { get; set; }
        public string CertificationSkills { get; set; }
    }
}
