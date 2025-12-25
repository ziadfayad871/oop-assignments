// MAIN 
using System;
using System.Collections.Generic;
using System.Linq; // for Average calculation

school sch = new school();

Student s1 = new Student(1, "Ali", Department.CS, new int[] { 80, 85, 90 });
Student s2 = new Student(2, "Mona", Department.IT, new int[] { 70, 88, 95 });
Student s3 = new Student(3, "Omar", Department.MATH, new int[] { 60, 75, 85 });
Student s4 = new Student(4, "Sara", Department.IT, new int[] { 90, 93, 88 });
Student s5 = new Student(5, "Ehab", Department.PHYSICS, new int[] { 78, 82, 80 });

sch.AddStudent(s1);
sch.AddStudent(s2);
sch.AddStudent(s3);
sch.AddStudent(s4);
sch.AddStudent(s5);
sch.DisplayAll();
sch.TopPerformer();
sch.DisplayByDepartment(Department.IT);
Student.DisplayTotal();



public enum Department
{
    CS,
    IT,
    MATH,
    PHYSICS
};
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Department Dept { get; set; }
    public int[] Grades { get; set; } = new int[3];


    public static int totalStudents { get; set; } = 0;

    public Student(int id, string name, Department dept, int[] grades)
    {
        Id = id;
        Name = name;
        Dept = dept;
        Grades = grades;
        totalStudents++;
    }

    // Method 
    public double GetAverage()
    {
        return Grades.Average();
    }
    public void Display()
    {
        Console.WriteLine($"{Name} ({Dept}) - Grades: {string.Join(" ", Grades)} - Avg: {GetAverage():0.0}");
    }
    public static void DisplayTotal()
    {
        Console.WriteLine($"Total Students: {totalStudents}");
    }
}

public class school
{
 List<Student> students = new List<Student>();
    public void AddStudent(Student s)
    {
        students.Add(s);
    }
    public void DisplayAll()
    {
        Console.WriteLine("All Students:");
        foreach (var student in students)
            student.Display();
    }
    public void TopPerformer()
    {
        var topStudent = students
            .OrderByDescending(s => s.GetAverage())
            .FirstOrDefault();

        if (topStudent != null)
        {
            Console.WriteLine($"\nTop Performer: {topStudent.Name} ({topStudent.Dept}) with average {topStudent.GetAverage():0.0}");
        }
    }
    public void DisplayByDepartment(Department d)
    {
        Console.WriteLine($"\nStudents in {d} Department:");
        foreach (var student in students.Where(s => s.Dept == d))
            Console.WriteLine($"{student.Name} ({student.Dept})");
    }
}

// question is :
/*
 Java OOP Assignment 6: Student Management System (Combined Concepts)
Objective: Apply knowledge of static variables, arrays, ArrayLists, and enums to build a mini OOP system.
Problem Description
Design a small Student Management System for a school. Each student belongs to a Department, has a list of Grades, and the school tracks all students using an ArrayList.
Specifications

1️⃣ Create an enum Department:
   - CS, IT, MATH, PHYSICS

2️⃣ Create a class Student:
   - Instance variables: name, id, department, grades (int[3])
   - Static variable: totalStudents (to track how many students were created)
   - Constructor: initializes all attributes and increments totalStudents
   - Methods:
       • getAverage() – returns average grade
       • display() – prints all details
       • displayTotal() – prints total students

3️⃣ Create a class School:
   - Uses an ArrayList<Student> to store all students
   - Methods:
       • addStudent(Student s) – adds a new student
       • displayAll() – shows all students
       • topPerformer() – finds and prints the student with the highest average
       • displayByDepartment(Department d) – shows all students in a given department


Task for Students

1. Create at least 5 students from different departments.
2. Display all students.
3. Print the top performer.
4. Display all students in the IT department.
5. Show total number of students using the static variable.


Expected Output Example

All Students:
Ali (CS) - Grades: 80 85 90
Mona (IT) - Grades: 70 88 95
Omar (MATH) - Grades: 60 75 85
Sara (IT) - Grades: 90 93 88
Ehab (PHYSICS) - Grades: 78 82 80

Top Performer: Sara (IT) with average 90.3
Students in IT Department:
Mona (IT)
Sara (IT)
Total Students: 5
*/