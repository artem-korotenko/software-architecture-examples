namespace SensorExample;

using Watcher;

public class UserHttpNotifier : IUserNotifier
{
    private int timeout;

    private int retries;

    public UserHttpNotifier(int timeout, int retries)
    {
        this.timeout = timeout;
        this.retries = retries;
    }

    public bool IsReady => true;

    public void NotifyAboutTemperature(int degrees, int max)
    {
        // some http-specific logic
        Console.WriteLine($"The temperature has reached {degrees} (with max {max}) degrees!");
    }
}