using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Task6
{
    class Program
    {
        public class Student
        {
            [JsonPropertyName("FullName")]
            public string Name { get; set; }
            [JsonPropertyName("AvgMark")]

            public double Rating { get; set; }
            public string GroupName { get; set; }

        }
        public class Group
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Popularity { get; set; }
        }
        public static string CreateGroups(List<Student> students, List<Group> groups)
        {
            var output = groups.GroupJoin(students,
                                grp => grp.Name,
                                std => std.GroupName,
                                (grp, students) => new
                                {
                                    group = grp.Name,
                                    description = grp.Description,
                                    rating = students.Average(std=>std.Rating),
                                    students = students.Select(std => new
                                    {
                                        FullName = std.Name,
                                        AvgMark = std.Rating
                                    }
                                    )});


            var jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreNullValues = true,
            };
            return JsonSerializer.Serialize(output, jsonOptions);
        }
        static void Main(string[] args)
        {
            List<Group> groups = new List<Group>() { new Group { Name = "test", Description = "test", Popularity = 3 },
                                                     new Group { Name = "test1", Description = "test", Popularity = 3 },
                                                     new Group { Name = "test2", Description = "test", Popularity = 3 }};
            List<Student> students = new List<Student>() { new Student { Name = "test",  GroupName = "test", Rating = 3 },
                                                     new Student { Name = "asds", GroupName = "test", Rating = 3 },
                                                     new Student { Name = "fda", GroupName = "test1", Rating = 4 },
                                                     new Student { Name = "testasf", GroupName = "test1", Rating = 1 },
                                                     new Student { Name = "asf", GroupName = "test", Rating = 6 },
                                                     new Student { Name = "sdf", GroupName = "test2", Rating = 7 }};
            Console.WriteLine(CreateGroups(students, groups));
        }
    }
}
