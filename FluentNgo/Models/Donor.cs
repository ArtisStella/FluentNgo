using System;
using System.Collections.Generic;
using System.Text;

namespace FluentNgo.Models
{
    public class Donor
    {
        public Donor() { }

        public Donor(int id, string name, string org, string address,
            string phone_no, string email, string donation_desc)
        {
            ID = id;
            Name = name;
            Organization = org;
            Address = address;
            PhoneNumber = phone_no;
            Email = email;
            DonationDescrip = donation_desc;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DonationDescrip { get; set; }
    }
}


