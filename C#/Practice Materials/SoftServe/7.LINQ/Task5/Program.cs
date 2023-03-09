using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Task5
{
    class Program
    {
        public class Department
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public Worker Manager { get; set; }

            public Department(string name, int id, Worker manager)
            {
                this.Name = name;
                this.Id = id;
                this.Manager = manager;
            }
        }

        public class Worker
        {
            [JsonPropertyName("Full name")]public string Name { get; set; }
            [JsonIgnore]public int Id { get; set; }
            public decimal Salary { get; set; }
            public Department Department { get; set; }

            public Worker(string name, decimal salary, Department department)
            {
                this.Name = name;
                this.Salary = salary;
                this.Department = department;
            }
            public string Serialize()
            {
                var jsonOptions = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    IgnoreNullValues = true
                };
                return JsonSerializer.Serialize(this,jsonOptions);
            }
            public static Worker Deserialize(string input)
            {
                Worker? worker =
                   JsonSerializer.Deserialize<Worker>(input);
                return worker;
            }
        }

        static void Main(string[] args)
        {
            Worker w = new Worker("Anna", 700, new Department("Mechanics", 1, new Worker("Tom", 600, null)));
            var serial = w.Serialize();
            Console.WriteLine(serial);
        }
    }
}
