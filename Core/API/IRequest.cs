public interface IRequest
{
}

public interface IRequestHandler<TRequest> where TRequest : IRequest
{
    void Handle(TRequest request);
}

public interface ICommandDefinition
{
    string Name { get; }
    string Usage { get; }
    bool TryParse(string[] args, out IRequest request, out string error);
}