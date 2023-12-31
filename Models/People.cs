using System;
using System.Collections.Generic;

namespace ObjectsComparator.Models
{
    public class People
    {
        public People(string name, string lastName, DateTime birthDate, int age, decimal weight, List<int> numbers, Adress adress, List<Contact> contacts)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Age = age;
            Weight = weight;
            Numbers = numbers;
            Adress = adress;
            Contacts = contacts;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public List<int> Numbers { get; set; }
        public Adress Adress { get; set; }
        public List<Contact> Contacts { get; set; }        
    }


    
}
