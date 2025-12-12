// See https://aka.ms/new-console-template for more information
using System;

class Person
{

    private string FirstName;
    private string LastName;
    private string EmailAddress;
    private DateTime DateOfBirth;

    public Person(string firstName, string lastName, string email, DateTime dob)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = email;
        DateOfBirth = dob;
    }

    public bool IsAdult
    {
        get
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Now.AddYears(-age))
                age--;
            return age >= 18;
        }
    }

    public string SunSign
    {
        get
        {
            int day = DateOfBirth.Day;
            int month = DateOfBirth.Month;

            return month switch
            {
                1 => (day <= 20) ? "Capricorn" : "Aquarius",
                2 => (day <= 19) ? "Aquarius" : "Pisces",
                3 => (day <= 20) ? "Pisces" : "Aries",
                4 => (day <= 20) ? "Aries" : "Taurus",
                5 => (day <= 21) ? "Taurus" : "Gemini",
                6 => (day <= 21) ? "Gemini" : "Cancer",
                7 => (day <= 22) ? "Cancer" : "Leo",
                8 => (day <= 23) ? "Leo" : "Virgo",
                9 => (day <= 23) ? "Virgo" : "Libra",
                10 => (day <= 23) ? "Libra" : "Scorpio",
                11 => (day <= 22) ? "Scorpio" : "Sagittarius",
                12 => (day <= 21) ? "Sagittarius" : "Capricorn",
                _ => "Unknown"
            };
        }
    }

    public bool IsBirthDay
    {
        get
        {
            return DateTime.Now.Month == DateOfBirth.Month &&
                   DateTime.Now.Day == DateOfBirth.Day;
        }
    }

    public string ScreenName
    {
        get
        {
            string fn = FirstName.ToLower().Substring(0, 2);
            string ln = LastName.ToLower().Substring(0, 2);
            string dob = DateOfBirth.ToString("MMddyy");
            return $"{fn}{ln}{dob}";
        }
    }
}

class Employee : Person
{
    public double Salary { get; set; }

    public Employee(string first, string last, string email, DateTime dob, double salary)
        : base(first, last, email, dob)
    {
        Salary = salary;
    }
}

class HourlyEmployee : Person
{
    public double HoursWorked { get; set; }
    public double PayPerHour { get; set; }

    public HourlyEmployee(string first, string last, string email, DateTime dob,
                           double hours, double rate)
        : base(first, last, email, dob)
    {
        HoursWorked = hours;
        PayPerHour = rate;
    }

    public double TotalPay => HoursWorked * PayPerHour;
}

class PermanentEmployee : Person
{
    public double HRA { get; set; }
    public double DA { get; set; }
    public double Tax { get; set; }

    public double TotalPay => HRA + DA;
    public double NetPay => TotalPay - Tax;

    public PermanentEmployee(string first, string last, string email, DateTime dob,
                             double hra, double da, double tax)
        : base(first, last, email, dob)
    {
        HRA = hra;
        DA = da;
        Tax = tax;
    }
}

class Program
{
    static void Main()
    {

        Employee emp = new Employee("Hari", "Joe", "hari@gmail.com",
                                    new DateTime(1980, 5, 25), 50000);

        Console.WriteLine("=== Employee Info ===");
        Console.WriteLine("Is Adult: " + emp.IsAdult);
        Console.WriteLine("Sun Sign: " + emp.SunSign);
        Console.WriteLine("Is Birthday: " + emp.IsBirthDay);
        Console.WriteLine("Screen Name: " + emp.ScreenName);
        Console.WriteLine("Salary: " + emp.Salary);

        HourlyEmployee hEmp = new HourlyEmployee("John", "Doe", "john@gmail.com",
                                                 new DateTime(2000, 3, 15),
                                                 40, 200);

        Console.WriteLine("\n=== Hourly Employee Info ===");
        Console.WriteLine("Hours Worked: " + hEmp.HoursWorked);
        Console.WriteLine("Pay Per Hour: " + hEmp.PayPerHour);
        Console.WriteLine("Total Pay: " + hEmp.TotalPay);

        PermanentEmployee pEmp = new PermanentEmployee(
            "Sam", "Wilson", "sam@gmail.com",
            new DateTime(1995, 10, 10),
            hra: 10000,
            da: 5000,
            tax: 2000
        );

        Console.WriteLine("\n=== Permanent Employee Info ===");
        Console.WriteLine("HRA: " + pEmp.HRA);
        Console.WriteLine("DA: " + pEmp.DA);
        Console.WriteLine("Tax: " + pEmp.Tax);
        Console.WriteLine("Total Pay: " + pEmp.TotalPay);
        Console.WriteLine("Net Pay: " + pEmp.NetPay);
    }
}
