// Main
Student st1 = new Student();
Student st2 = new Student("ali", 20);
Student st3 = new Student("sara", 22, "A");
Console.WriteLine($" student 1 : \n {st1.name} \n {st1.age} \n {st1.grade}");
Console.WriteLine($" student 2 : \n {st2.name} \n {st2.age} \n {st2.grade}");  // No grade provided so it will be "" , not "N/A" 
Console.WriteLine($" student 3 : \n {st3.name} \n {st3.age} \n {st3.grade}");

// class
class Student
{
    public string name { get; set; }
    public int age { get; set; }
    public string grade { get; set; }

    // default constructor
    public Student()
    {
        name = "UnKnown";
        age = 0;
        grade = "N/A";
    }
    // parameterized constructor with 2 parameters
    public Student(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    // parameterized constructor with 3 parameters
    public Student(string name, int age, string grade)
    {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }
}

// the question is :
/*
  Assignment 1: Constructor Overloading
Title:
Student Class with Constructor Overloading
Problem Definition:
Write a Java program that defines a class Student with the following features:
- Data members: name, age, and grade.
- Constructors:
  1. Default constructor — sets default values ("Unknown", 0, "N/A").
  2. Constructor with two parameters — sets name and age.
  3. Constructor with three parameters — sets all attributes.

In the main() method:
1. Create three Student objects, each using a different constructor.
2. Display all student information using a method displayInfo().
Expected Output Example:
Student 1:
Name: Unknown
Age: 0
Grade: N/A

Student 2:
Name: Ali
Age: 20
Grade: N/A

Student 3:
Name: Sara
Age: 22
Grade: A
Illustration:
You will create a Student class demonstrating the use of multiple constructors with different parameter lists. This shows how constructor overloading works
*/