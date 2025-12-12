using System;

public class GeometryTool
{

    public double Perimeter(double side)
    {
        Console.WriteLine($"Calculating Perimeter of a Square with side {side}");
        return 4 * side;
    }

    public double Perimeter(double length, double breadth)
    {
        Console.WriteLine($"Calculating Perimeter of a Rectangle with length {length} and breadth {breadth}");
        return 2 * (length + breadth);
    }

    public double Perimeter(double a, double b, double c)
    {
        Console.WriteLine($"Calculating Perimeter of a Triangle with sides {a}, {b}, and {c}");
        return a + b + c;
    }

    public double Perimeter(double radius, bool isCircle)
    {
        if (isCircle)
        {
            Console.WriteLine($"Calculating Circumference of a Circle with radius {radius}");

            return 2 * Math.PI * radius;
        }
        else
        {

            throw new ArgumentException("The second parameter must be true to indicate a Circle calculation.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GeometryTool tool = new GeometryTool();

        Console.WriteLine("--- Testing Perimeter Method Overloads ---");

        double squarePerimeter = tool.Perimeter(5.0);

        double rectanglePerimeter = tool.Perimeter(4.0, 10.0);
        Console.WriteLine($"Result: {rectanglePerimeter}\n");

        double trianglePerimeter = tool.Perimeter(3.0, 4.0, 5.0); 
      double circleCircumference = tool.Perimeter(7.0, true);
        Console.WriteLine($"Result: {circleCircumference:F2}\n"); 
    }
}