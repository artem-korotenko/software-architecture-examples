namespace Commands;

public interface ICommand
{
    bool TryExecuteInput(string input);
}

public abstract class InputCommand : ICommand
{
    public bool TryExecuteInput(string input)
    {
        var split = input.Split(" ");
        if (split.Length < 1)
        {
            return false;
        }

        if (split[0] != CommandName)
        {
            return false;
        }
        
        Execute(split[1..]);
        return true;
    }
    
    protected abstract string CommandName { get; }

    protected abstract void Execute(string[] args);
}