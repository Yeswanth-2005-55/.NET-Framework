using System;


public class Calculator
{
 
    public int Add(int a, int b)
    {
        Console.WriteLine($"Adding two integers: {a} + {b}");
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        Console.WriteLine($"Adding three integers: {a} + {b} + {c}");
        return a + b + c;
    }

    public double Add(double a, double b)
    {
        Console.WriteLine($"Adding two doubles: {a} + {b}");
        return a + b;
    }

    public double Add(double a, double b, double c)
    {
        Console.WriteLine($"Adding three doubles: {a} + {b} + {c}");
        return a + b + c;
    }


    public int Multiply(int a, int b)
    {
        Console.WriteLine($"Multiplying two integers: {a} * {b}");
        return a * b;
    }

    public int Multiply(int a, int b, int c)
    {
        Console.WriteLine($"Multiplying three integers: {a} * {b} * {c}");
        return a * b * c;
    }

    public double Multiply(double a, double b)
    {
        Console.WriteLine($"Multiplying two doubles: {a} * {b}");
        return a * b;
    }

    public float Subtract(float a, float b)
    {
        Console.WriteLine($"Subtracting two Singles/Floats: {a} - {b}");
        return a - b;
    }

 
    public double Subtract(double a, double b)
    {
        Console.WriteLine($"Subtracting two doubles: {a} - {b}");
        return a - b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();

        Console.WriteLine("--- Testing Add Overloads ---");
        Console.WriteLine($"Result: {calc.Add(5, 10)}\n");
        Console.WriteLine($"Result: {calc.Add(5, 10, 2)}\n");

        Console.WriteLine($"Result: {calc.Add(5.5d, 10.2d)}\n");
        Console.WriteLine($"Result: {calc.Add(5.5d, 10.2d, 1.1d)}\n");

        Console.WriteLine("--- Testing Multiply Overloads ---");
        Console.WriteLine($"Result: {calc.Multiply(5, 10)}\n");
        Console.WriteLine($"Result: {calc.Multiply(5, 10, 2)}\n");
        Console.WriteLine($"Result: {calc.Multiply(5.5d, 10.2d)}\n");

        Console.WriteLine("--- Testing Subtract Overloads ---");
        Console.WriteLine($"Result: {calc.Subtract(20.5f, 10.2f)}\n");
        Console.WriteLine($"Result: {calc.Subtract(20.5d, 10.2d)}\n");
    }
}