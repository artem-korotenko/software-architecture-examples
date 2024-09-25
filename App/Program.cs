using Commands;
using Commands.Content;
using Task.FileStorage;

var taskStorage = new InMemoryTaskStorage();
var handler = new CommandHandler(new List<ICommand>()
{
    new AddCommand(taskStorage), new RemoveCommand(taskStorage), new ListCommand(taskStorage)
});
handler.StartListeningToCommands();