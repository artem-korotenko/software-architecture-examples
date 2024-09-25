namespace SensorWatcher_Refactored.Simple;

using SensorExample.Watcher;

public class CompoundNotifier : IUserNotifier
{
    private readonly List<IUserNotifier> notifiers;

    public CompoundNotifier(List<IUserNotifier> notifiers)
    {
        this.notifiers = notifiers;
    }

    public bool IsReady => notifiers.Any(notifier => notifier.IsReady);

    public void NotifyAboutTemperature(int degrees, int max)
    {
        notifiers.First(notifier => notifier.IsReady).NotifyAboutTemperature(degrees, max);
    }
}