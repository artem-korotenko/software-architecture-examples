namespace SensorExample.Sensor;


public class XiaomiTemperatureSensor
{
    private readonly Random random = new Random();

    public int CurrentTemperature => random.Next(18, 26);
}