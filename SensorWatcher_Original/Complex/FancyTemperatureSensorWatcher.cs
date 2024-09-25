namespace SensorExample;

using Sensor;

public class FancyTemperatureSensorWatcher
{
    private readonly ViberUserNotifier viberUserNotifier = new();

    private readonly SmsUserNotifier smsUserNotifier = new();
    
    private readonly XiaomiTemperatureSensor sensor = new();
    
    private int maxDegrees;
    
    public void SetMaximumTemperature(int degrees)
    {
        maxDegrees = degrees;
    }
    
    public void Check()
    {
        var degrees = sensor.CurrentTemperature;
        if (degrees >= maxDegrees)
        {
            if (viberUserNotifier.IsOnline)
            {
                viberUserNotifier.NotifyAboutTemperature(degrees, maxDegrees);
            }
            else
            {
                smsUserNotifier.NotifyAboutTemperature(degrees, maxDegrees);
            }
        }
    }
}