namespace SensorExample;

using Watcher;

public class FancyTemperatureSensorWatcher
{
    private readonly List<IUserNotifier> notifiers;
    
    private readonly ITemperatureSensor sensor;
    
    private int maxDegrees;

    public FancyTemperatureSensorWatcher(List<IUserNotifier> notifiers, ITemperatureSensor sensor)
    {
        this.sensor = sensor;
        this.notifiers = notifiers;
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
            notifiers.First(notifier => notifier.IsReady).NotifyAboutTemperature(degrees, maxDegrees);
        }
    }
}