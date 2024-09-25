namespace SensorExample;

using Http;
using Sensor;

public class TemperatureSensorWatcher
{
    private readonly UserHttpNotifier notifier;

    private readonly XiaomiTemperatureSensor sensor;

    private int maxDegrees;

    public TemperatureSensorWatcher()
    {
        notifier = new UserHttpNotifier();
        notifier.SetTimeOutAndRetries(1200, 20);

        sensor = new XiaomiTemperatureSensor();
    }

    public void SetMaximumTemperature(int degrees)
    {
        maxDegrees = degrees;
    }

    public void Check()
    {
        var degrees = sensor.CurrentTemperature;
        if (degrees >= maxDegrees)
        {
            notifier.NotifyAboutTemperature(degrees, maxDegrees);
        }
    }
}