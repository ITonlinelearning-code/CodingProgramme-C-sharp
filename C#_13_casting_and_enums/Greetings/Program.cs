﻿
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        
        Person person = new Person(string.Empty, 0);
        Car car = new Car();
        int newAge;
        Car.MakesOfCars makesOfCars = new Car.MakesOfCars();
        bool optionSelected = false;

        Console.WriteLine("Please enter your name:");
        person.Name = Console.ReadLine();

        Console.WriteLine("Please enter your age:");
        while (!int.TryParse(Console.ReadLine(),out newAge))
        {
            Console.WriteLine("Please enter a valid number for your age:");
        }

        Console.WriteLine();


        Console.WriteLine("What is the make of your car?");
        Console.WriteLine("Please enter one of the options below:");
        Console.WriteLine("0 for Mercedes");
        Console.WriteLine("1 for BMW");
        Console.WriteLine("2 for LandRover");
        Console.WriteLine("3 for Toyota");
        Console.WriteLine("4 for Ford");
        do
        {
            switch (Console.ReadLine())
            {
                case "0":
                    car.Make = Car.MakesOfCars.Mercedes;
                    Console.WriteLine("You selected: " + Car.MakesOfCars.Mercedes.ToString());
                    optionSelected = true;
                    break;
                case "1":
                    car.Make = Car.MakesOfCars.BMW;
                    Console.WriteLine("You selected: " + Car.MakesOfCars.BMW.ToString());
                    optionSelected = true;
                    break;
                case "2":
                    car.Make = Car.MakesOfCars.LandRover;
                    Console.WriteLine("You selected: " + Car.MakesOfCars.LandRover.ToString());
                    optionSelected = true;
                    break;
                case "3":
                    car.Make = Car.MakesOfCars.Toyota;
                    Console.WriteLine("You selected: " + Car.MakesOfCars.Toyota.ToString());
                    optionSelected = true;
                    break;
                case "4":
                    car.Make = Car.MakesOfCars.Ford;
                    Console.WriteLine("You selected: " + Car.MakesOfCars.Ford.ToString());
                    optionSelected = true;
                    break;
                default:
                    Console.WriteLine("Your selection was invalid, Please try again:");
                    break;
            }
        } while (!optionSelected);

        Console.WriteLine();
        Console.WriteLine("What model is your car?");
        car.Model = Console.ReadLine();

        newAge = person.AgeXYearsFromNow(5);

        Console.WriteLine("Hello " + person.Name);
        Console.WriteLine("You are " + person.Age + " years old,");
        Console.WriteLine("In five years you will be " + newAge);
        Console.WriteLine("In ten years you will be " + person.AgeXYearsFromNow(10));
        Console.WriteLine("Someone double your age is " + person.TwiceAge() + " years old");

        Console.WriteLine("let's hope your " + car.Make + " " + car.Model + " is still going strong when you are " + (person.Age + 7) + " years old.");

        person.YearsHistory();
    }
}

// Define the Person class
public class Person
{
    // Public property for Name
    public string? Name { get; set; }

    // Private property for Age
    public int Age { get; set; }    


    // Constructor to initialize Name and Age
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Hello" + Name);
        Console.WriteLine("You are " + Age + "years old.");
    }

    public string GetDetailsToDisplay()
    {
        string returnValue = string.Empty;

        returnValue = "Hello" + Name + Environment.NewLine;
        returnValue = "You are " + Age + "years old.";

        return returnValue;
    }

    public int AgeXYearsFromNow(int yearsToAdd)
    {
        int newAge = Age + yearsToAdd;
        return newAge;
    }

    public decimal TwiceAge()
    {
        
        return Age * 2;
        
    }

    public void YearsHistory() 
    {
        int year = DateAndTime.Now.AddYears(Age * -1).Year;

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(" You were born in the year: " + year);
        Console.WriteLine("Here are the years of your life so far.");

        Console.WriteLine();

        if(Age < 17)
            Console.WriteLine("You are too young to own a car");
        else
            Console.WriteLine("You are of legal driving age");


        for (int i = 0; i < Age; i++)
        {            
            year++;            

            Console.WriteLine("In " + year + " you turned " + (i + 1));

            switch(i)
            {
                case < 10:
                    Console.WriteLine("You were a child");
                    break;
                case < 20:
                    Console.WriteLine("You were a teenager");
                    break;
                case < 60:
                    Console.WriteLine("You were a grown up");
                    break;
                case > 59:
                    Console.WriteLine("You are old");
                    break;
            }
        }

    }

}

// Define the Car class
public class Car
{
    public enum MakesOfCars
    {
        Mercedes,
        BMW,
        LandRover,
        Toyota,
        Ford
    }

    // Public properties for Car's Make and Model
    public MakesOfCars Make { get; set; }
    public string? Model { get; set; }

    // Method to display car information
    public void DisplayCarInfo()
    {
        Console.WriteLine($"Car: {Make} {Model}");
    }
}

public class Family
{
    public Person[] Members { get; set;}
    public List<Car> Vehicles { get; set;}

    public Family()
    {
        Members = new Person[0];
        Vehicles = new List<Car>();
    }
    
}

