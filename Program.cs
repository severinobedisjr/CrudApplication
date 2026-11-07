using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

public class Student
{
    public int Id {get;set;}
    public string Name { get; set;} = string.Empty;
    public string Course {get; set;} = string.Empty;
    public int Age { get; set;}
}

class Program  {
private static List<Student> students = new List<Student>();
private static int nextId = 1;

static void Main(String[] args)
{
    bool running = true;

    while(running)
    {
        Console.Clear();
        Console.WriteLine("Student Management System");
        Console.WriteLine("1. Add New Student");
        Console.WriteLine("2. View All Students");
        Console.WriteLine("3. Update Student");
        Console.WriteLine("4. Delete Student");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option (1-5)");

        switch(Console.ReadLine())
            {
                case "1": CreateStudent(); break;
                case "2": ViewStudent(); break;
                case "3": UpdateStudent(); break;
                case "4": DeleteStudent(); break;
                case "5": running = false; break;
                default: 
                    Console.WriteLine("Invalid option!");

                    Console.ReadLine();
                    break;
            }
        
    }
}

static void CreateStudent()
    {
        Console.Clear();
        Console.WriteLine("Add new Student");   
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Student Course: ");
        string course = Console.ReadLine() ?? "";

        Console.Write("Enter Student Age: ");
        int.TryParse(Console.ReadLine(), out int age);

        Student newStudent = new Student
        {
            Id = nextId++,
            Name = name,
            Course = course,
            Age = age
        };

        students.Add(newStudent);
        Console.WriteLine("\n Student created successfully");
        Console.WriteLine("Press Enter to return to Main Menu");
        Console.ReadLine();
    }

    
    static void ViewStudent()
    {
        Console.Clear();

        Console.WriteLine("----- Student List -------");

        if(students.Count == 0)
        {
            Console.WriteLine("No student records found");
        } else
        {
            Console.WriteLine("{0, -5} {1, -50} {2, -50} {3, -5}", 
            "ID", "Name", "Course", "Age");

            Console.WriteLine(new string('-', 50));

            foreach (var s in students)
            {
                Console.WriteLine("{0, -5} {1, -50} {2, -50} {3, -5}",
                s.Id, s.Name, s.Course, s.Age);
            }
        }
        Console.WriteLine("Press Enter to return to Main Menu");
        Console.ReadLine();
        
    }

    static void UpdateStudent()
    {
        Console.Clear();
        Console.WriteLine("-------Update Student-----");
        Console.Write("Student ID to update");

        if(int.TryParse(Console.ReadLine(), out int id))
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.Write($"Enter New Name: (Current: {student.Name})");
                string NewName = Console.ReadLine();

                if(!string.IsNullOrWhiteSpace(NewName)) student.Name = NewName;

                Console.Write($"Enter New Course (Current: {student.Course})");
                string NewCourse = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(NewCourse)) student.Course = NewCourse;

                Console.Write($"Enter New Age (Current: {student.Age})");
                string ageInput = Console.ReadLine();
                if(int.TryParse(ageInput, out int newAge)) student.Age = newAge;

                Console.WriteLine("\n Studnet record updated sucessfully"); 

            }  
            else
            {
                Console.WriteLine("Student ID not found");
            }      
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }

        Console.WriteLine("Press Enter to return to Main Menu");
        Console.ReadLine();
    }

    static void DeleteStudent()
    {
        Console.Clear();
        Console.WriteLine("------Delete Student");
        Console.Write("Enter Student ID to delete: ");

        if(int.TryParse(Console.ReadLine(), out int id))
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if(student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Student ID {id} removed successfully. ");
            } else
            {
                Console.WriteLine("Student ID not found");
            }
        } else
        {
        Console.WriteLine("Invalid ID format.");
        }

        Console.WriteLine("Press Enter to return to Main Menu");
        Console.ReadLine();
    }
}

