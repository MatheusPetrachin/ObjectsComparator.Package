using ObjectsComparator.Models;
using System;
using System.Collections.Generic;

namespace ObjectsComparator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            People pessoa1 = new People(
                "Matheus",
                "Petrachin",
                new DateTime(1998, 06, 15),
                25,
                125M,
                new Adress()
                {
                    StreetName = "Calendulas",
                    Number = "405"
                },
                new List<Contact>()
                {
                    new Contact()
                    {
                        Type = "1",
                        Number = "XXX"
                    },
                    new Contact()
                    {
                        Type = "2",
                        Number = "XXX"
                    }
                }
            );

            People pessoa2 = new People(
                "Matheus",
                "Petrachin",
                new DateTime(1998, 06, 15),
                25,
                125M,
                new Adress()
                {
                    StreetName = "Calendulas",
                    Number = "405"
                },
                new List<Contact>()
                {
                    new Contact()
                    {
                        Type = "1",
                        Number = "XXX"
                    },
                    new Contact()
                    {
                        Type = "2",
                        Number = "XXX"
                    }
                }
            );

            Console.WriteLine("Iguais: " + ObjectsComparator.ObjectsAreEquals(pessoa1, pessoa2));

            People pessoa3 = new People(
                "Matheus",
                "Petrachin",
                new DateTime(1998, 06, 15),
                25,
                125M,
                new Adress()
                {
                    StreetName = "Calendulas",
                    Number = "405"
                },
                new List<Contact>()
                {
                    new Contact()
                    {
                        Type = "1",
                        Number = "XXX"
                    },
                    new Contact()
                    {
                        Type = "2",
                        Number = "YYY"
                    }
                }
            );

            Console.WriteLine("Iguais: " + ObjectsComparator.ObjectsAreEquals(pessoa1, pessoa3));
        }


       
    }
}
