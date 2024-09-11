using SensorExample;

var watcher = new TemperatureSensorWatcher();
while (true)
{
    Thread.Sleep(1000);
    watcher.Check();
}