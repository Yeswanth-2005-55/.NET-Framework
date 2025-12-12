using System;
using System.Collections.Generic;


public class Notification
{
   
    public virtual void Send(string message)
    {
        Console.WriteLine($"Sending notification: {message}");
    }
}


public class EmailNotification : Notification
{
   
    public override void Send(string message)
    {
        Console.WriteLine($"Email sent to registered address: '{message}'");
    }
}


public class SmsNotification : Notification
{
    public override void Send(string message)
    {
        Console.WriteLine($"SMS sent to mobile number: '{message}'");
    }
}


public class PushNotification : Notification
{
    public override void Send(string message)
    {
        Console.WriteLine($"Push notification delivered to device: '{message}'");
    }
}

class Program
{
    static void Main(string[] args)
    {
    
        Notification notificationSender;

        Console.WriteLine("--- Demonstrating Polymorphic Notification System ---");

        notificationSender = new EmailNotification();
        notificationSender.Send("Your password reset link is here.");

  
        notificationSender = new SmsNotification();
        notificationSender.Send("Your 2FA code is 12345.");


        notificationSender = new PushNotification();
        notificationSender.Send("A new message has arrived in your inbox.");

        Console.WriteLine("\n--- Demonstration Complete ---");

    
        List<Notification> allChannels = new List<Notification>
        {
            new EmailNotification(),
            new SmsNotification(),
            new PushNotification()
       
        };

        Console.WriteLine("\n--- Processing all channels using a single loop (Uniform handling) ---");
        foreach (var channel in allChannels)
        {

            channel.Send("Urgent system alert!");
        }
    }
}