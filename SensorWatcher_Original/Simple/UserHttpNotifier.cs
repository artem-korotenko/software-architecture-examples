namespace SensorExample.Http;


public class UserHttpNotifier 
{
    private int timeout;

    private int retries;

    public void SetTimeOutAndRetries(int timeout, int retries)
    {
        this.timeout = timeout;
        this.retries = retries;
    }

    public void NotifyAboutTemperature(int degrees, int max)
    {
        // some http-specific logic
        Console.WriteLine($"The temperature has reached {degrees} (with max {max}) degrees!");
    }
}