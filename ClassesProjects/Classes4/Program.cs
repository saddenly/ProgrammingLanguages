using System.Net.WebSockets;

namespace A;

internal class Program
{
    public static void Main(string[] args)
    {
        //var calculator = new Calculator(new Parser(new ValueReader()));

        //var result = calculator.Calculate();

        //Console.WriteLine(result);

        var student = new Student("James", "Bond", 50);

        //This is old school - without deconstruction
        //var name = student.Name;
        //var lastName = student.LastName;
        //var age= student.Age;
        // and then you work with them
        // 

        //with deconstruction you do it quicker
        var (name, lastName, age) = student;

        //now reminder about out parameters (don't use them ! - but you should know them - once upon a time they were common)

        int result ;
        var success = Divide(10, 2, out result);

        Console.WriteLine(success);
        Console.WriteLine(result);


        DateTime parseResult;
        var successOfParsing = DateTime.TryParse("2024-01-01", null, out parseResult);

        var s1 = new Student()
        {
            Age = 20,
            LastName = "Mr.",
            Name = "Bean"
        };

        var newStudent = s1 with { Name = "John", LastName = "Bean" };

        //a homework: 
        //pattern matching

        int i = 10;
        object x = i;

        if (x is int a)
        {
            Console.WriteLine(2 + a);
        }


        int? maybe = 12;

        if (maybe is int number)
        {
            Console.WriteLine($"The nullable int 'maybe' has the value {}");
        }
        else
        {
            Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
        }
    }
    string WaterStateOldSchool(int tempInFahrenheit)
    {
        var result = string.Empty;
        if (tempInFahrenheit > 32 && tempInFahrenheit < 212)
            return "liquid";


    }
     

    string WaterState(int tempInFahrenheit) =>
    tempInFahrenheit switch
    {
        (> 32) and (< 212) => "liquid",
        < 32 => "solid",
        > 212 => "gas",
        32 => "solid/liquid transition",
        212 => "liquid / gas transition",
    };
    //some example method with out
    public static bool Divide(int a, int b, out int result)
    {
        if (b == 0)
        {
            result = 0;
            return false;
        }
        result = a / b;
        return true;
    }

    //private static void Main(string[] args)
    //{
    //    Console.WriteLine("What is the name");
    //    var name = Console.ReadLine();

    //    try
    //    {
    //        var a = new Student(name);
    //    }
    //    catch (ArgumentNullException)
    //    {
    //        Console.WriteLine("Something went wrong - ARGUMENT null");
    //    }
    //    catch (ArgumentException e)
    //    {
    //        Console.WriteLine(e);

    //        Console.WriteLine("Something went wrong - argument invalid");
    //    }
    //    catch (Exception)
    //    {
    //        Console.WriteLine("Something really unexpected happened");
    //    }
    //    finally 
    //    { 
    //        Console.WriteLine(); 
    //    }
    //}

    //private static void Main(string[] args)
    //{
    //    Console.WriteLine("Hello, World!");

    //    using var a = new Student("James");

    //    Console.WriteLine(a is IDisposable);

    //    Console.ReadKey();
    //}
}

public record Student : IDisposable
{
    //Cool stuff in modern C#
    public void Deconstruct(out string name, out string lastName, out int age)
    {
        name = Name;
        lastName = LastName;
        age = Age;
    }

    public string Name { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
    public Student()
    {

    }
    public Student(string name, string lastName, int age)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        } 
        else if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(nameof(name));
        }
        Name = name;
        LastName = lastName;
        Age = age;
    }

    public void Dispose()
    {
        Console.WriteLine("Now Dispose is working");
    }
}