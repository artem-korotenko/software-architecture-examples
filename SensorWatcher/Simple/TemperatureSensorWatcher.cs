namespace SensorExample.Watcher;

public class TemperatureSensorWatcher
{
    private readonly IUserNotifier notifier;

    private readonly ITemperatureSensor sensor;

    private int maxDegrees;

    public TemperatureSensorWatcher(IUserNotifier notifier,  ITemperatureSensor sensor)
    {
        this.notifier = notifier;
        this.sensor = sensor;
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

public interface IUserNotifier
{
    bool IsReady { get; }
    void NotifyAboutTemperature(int degrees, int max);
}

public interface ITemperatureSensor
{
    int CurrentTemperature { get; }
}