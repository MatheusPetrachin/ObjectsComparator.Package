using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectsComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa1 = new Pessoa()
            {
                Name = "Matheus",
                LastName = "Petrachin",
                DataNascto = new DateTime(1998,06,15),
                Idade = 25,
                Peso = 125M,
                Endereco = new Endereco()
                {
                    StreetName = "Calendulas",
                    Number = "405"
                },
                Contatos = new List<Contato>()
                {
                    new Contato()
                    {
                        Type = "1",
                        Number = "XXX"
                    },
                    new Contato()
                    {
                        Type = "2",
                        Number = "XXXX"
                    }
                }
            };

            Pessoa pessoa2 = new Pessoa()
            {
                Name = "Matheus",
                LastName = "Petrachin",
                DataNascto = new DateTime(1998, 06, 15),
                Idade = 25,
                Peso = 125M,
                Endereco = new Endereco()
                {
                    StreetName = "Calendulas",
                    Number = "405"
                },
                Contatos = new List<Contato>()
                {
                    new Contato()
                    {
                        Type = "1",
                        Number = "XXX"
                    },
                    new Contato()
                    {
                        Type = "2",
                        Number = "XXXX"
                    }
                }
            };

            Console.WriteLine(ObjectsAreEquals(pessoa1, pessoa2));
        }

        public static void Test()
        {
            
        }

        public static bool ObjectsAreEquals<T>(T entity1, T entity2) where T : class
        {
            var props = entity1.GetType().GetProperties().ToList();

            foreach (var prop in props)
            {
                if (prop.PropertyType.IsNested)
                {
                    if (!ObjectsAreEquals(prop.GetValue(entity1), prop.GetValue(entity2))) return false;
                }
                else if ((prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) ||
                        prop.PropertyType.IsArray)
                {
                    var childPropsEntity1 = entity1.GetType().GetProperty(prop.Name);
                    var childPropsEntity2 = entity2.GetType().GetProperty(prop.Name);

                    object test = childPropsEntity1.GetValue(entity1);
                    object test2 = childPropsEntity2.GetValue(entity2);

                    var list = test as List<Contato>;
                    var list2 = test2 as List<Contato>;

                    for (int i = 0; i < list.ToArray().Length; i++)
                    {
                        if (!ObjectsAreEquals(list.ToArray()[i], list2.ToArray()[i])) return false;
                    }
                }
                else if (!prop.GetValue(entity1).Equals(prop.GetValue(entity2)))
                {
                    return false;
                }
            }

            return true;
        }

        public class Pessoa
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime DataNascto { get; set; }
            public int Idade { get; set; }
            public decimal Peso { get; set; }
            public Endereco Endereco { get; set; }
            public List<Contato> Contatos { get; set; }
        }

        public class Endereco
        {
            public string StreetName { get; set; }
            public string Number { get; set; }
        }

        public class Contato
        {
            public string Type { get; set; }
            public string Number { get; set; }
        }
    }
}
