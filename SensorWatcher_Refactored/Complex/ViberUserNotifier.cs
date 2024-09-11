namespace SensorExample;

public class ViberUserNotifier
{
    public bool IsOnline { get; }
    
    public void NotifyAboutTemperature(int degrees, int max)
    {
        Console.WriteLine($"Sending message directly to a viber");
    }
}