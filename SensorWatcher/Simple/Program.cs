using SensorExample;
using SensorExample.Watcher;
using SensorWatcher_Refactored.Simple;

var watcher = new TemperatureSensorWatcher(new CompoundNotifier(new List<IUserNotifier>(){new UserHttpNotifier(1200, 20)}), new XiaomiTemperatureSensor());
while (true)
{
    Thread.Sleep(1000);
    watcher.Check();
}