using System;

public class Gadget
{
    // Private fields
    private string _brand;
    private string _model;
    private DateTime _releaseDate;
    private double _price;

    public Gadget(string brand, string model, DateTime releaseDate, double price)
    {
        _brand = brand;
        _model = model;
        _releaseDate = releaseDate;
        _price = price;
    }

    public int AgeInYears
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - _releaseDate.Year;
            if (_releaseDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public bool IsWarrantyValid
    {
        get
        {
            return DateTime.Today <= _releaseDate.AddYears(2);
        }
    }

    public double DiscountedPrice
    {
        get
        {
            if (AgeInYears > 3)
            {
                return _price * (1 - 0.12);
            }
            else if (AgeInYears > 1)
            {
                return _price * (1 - 0.05);
            }
            else
            {
                return _price;
            }
        }
    }

    public string UniqueCode
    {
        get
        {
            string brandPart = _brand.Length >= 3 ? _brand.Substring(0, 3).ToLower() : _brand.ToLower();
            string modelPart = _model.Length >= 2 ? _model.Substring(_model.Length - 2).ToLower() : _model.ToLower();
            string yearPart = _releaseDate.Year.ToString().Substring(2);

            return $"{brandPart}{modelPart}{yearPart}";
        }
    }

    public string Brand => _brand;
    public string Model => _model;
    public double Price => _price;

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"\n--- {Brand} {Model} (Gadget Details) ---");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Age In Years: {AgeInYears}");
        Console.WriteLine($"Is Warranty Valid: {IsWarrantyValid}");
        Console.WriteLine($"Discounted Price: {DiscountedPrice:C}");
        Console.WriteLine($"Unique Code: {UniqueCode}");
    }
}

public class Smartphone : Gadget
{
    public int RAM { get; set; }
    public int Storage { get; set; }
    public double CameraMP { get; set; }

    public Smartphone(string brand, string model, DateTime releaseDate, double price, int ram, int storage, double cameraMp)
        : base(brand, model, releaseDate, price)
    {
        RAM = ram;
        Storage = storage;
        CameraMP = cameraMp;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("\n  --- Smartphone Specifics ---");
        Console.WriteLine($"  RAM: {RAM} GB");
        Console.WriteLine($"  Storage: {Storage} GB");
        Console.WriteLine($"  Camera: {CameraMP} MP");
    }
}

public class Laptop : Gadget
{
    public int RAM { get; set; }
    public string Processor { get; set; }
    public double BatteryBackupHours { get; set; }

    public Laptop(string brand, string model, DateTime releaseDate, double price, int ram, string processor, double batteryBackupHours)
        : base(brand, model, releaseDate, price)
    {
        RAM = ram;
        Processor = processor;
        BatteryBackupHours = batteryBackupHours;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("\n  --- Laptop Specifics ---");
        Console.WriteLine($"  RAM: {RAM} GB");
        Console.WriteLine($"  Processor: {Processor}");
        Console.WriteLine($"  Battery Backup: {BatteryBackupHours} hours");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Smartphone myPhone = new Smartphone("Samsung", "GalaxyS21", new DateTime(2021, 1, 29), 799.99, 12, 256, 12.0);

        Laptop myLaptop = new Laptop("Dell", "XPS13", new DateTime(2024, 4, 15), 1200.00, 16, "Intel Core i7", 10.5);

        myPhone.DisplayDetails();
        myLaptop.DisplayDetails();
    }
}
