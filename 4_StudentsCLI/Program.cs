var executor = new CommandsFactory().CreateExecutor();
var loop = new CommandsLoop(executor);
loop.Run();