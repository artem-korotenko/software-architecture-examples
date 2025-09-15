using System;
using System.Collections.Generic;

public sealed class Context
{
    private readonly Dictionary<string, ICommandDefinition> Definitions = new(StringComparer.OrdinalIgnoreCase);

    private interface ITypedHandler
    {
        void Handle(IRequest request);
    }

    private sealed class TypedHandler<TRequest>(IRequestHandler<TRequest> inner) : ITypedHandler
        where TRequest : IRequest
    {

        public void Handle(IRequest request)
        {
            inner.Handle((TRequest)request);
        }
    }

    private readonly Dictionary<Type, ITypedHandler> Handlers = new Dictionary<Type, ITypedHandler>();

    public void Register<TRequest>(ICommandDefinition definition, IRequestHandler<TRequest> handler)
        where TRequest : IRequest
    {
        Definitions[definition.Name] = definition;
        Handlers[typeof(TRequest)] = new TypedHandler<TRequest>(handler);
    }

    public IEnumerable<ICommandDefinition> All => Definitions.Values;

    public bool TryHandle(string[] args, out string error)
    {
        error = null;

        if (args.Length == 0)
        {
            error = "Empty command";
            return false;
        }

        string name = args[0];

        if (!Definitions.TryGetValue(name, out ICommandDefinition def))
        {
            error = "ERR unknown command";
            return false;
        }

        if (!def.TryParse(args, out IRequest request, out string parseError))
        {
            error = parseError;
            return false;
        }

        Type t = request.GetType();

        if (!Handlers.TryGetValue(t, out ITypedHandler boxed))
        {
            error = $"No handler registered for {t.Name}";
            return false;
        }

        boxed.Handle(request);
        return true;
    }
}
