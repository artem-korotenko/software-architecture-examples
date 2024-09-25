using SensorExample;

var watcher = new TemperatureSensorWatcher();
watcher.SetMaximumTemperature(35);
while (true)
{
    Thread.Sleep(1000);
    watcher.Check();
}