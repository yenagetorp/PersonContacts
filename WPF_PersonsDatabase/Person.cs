﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PersonsDatabase
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string SSN { get; set; }
        public List<string> PhoneNumbers { get; set; }

        public Person(string firstName, string lastName, string emailAddress, string ssn)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            SSN = ssn;
            PhoneNumbers = new List<string>();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
