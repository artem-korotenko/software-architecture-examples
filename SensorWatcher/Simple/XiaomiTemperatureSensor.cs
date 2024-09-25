namespace SensorExample;

using Watcher;

public class XiaomiTemperatureSensor : ITemperatureSensor
{
    private readonly Random random = new Random();

    public int CurrentTemperature => random.Next(18, 26);
}