namespace DI.Core;

public interface IDiContainer
{
    void Register<TInterface, TImplementation>(Scope scope) 
        where TImplementation : TInterface;

    T Resolve<T>();
}

public enum Scope
{
    Singleton, Transient
}

public class DiContainer : IDiContainer
{
    private readonly Dictionary<Type, Binding> typesToImplementation = new();
    
    private readonly Dictionary<Type, object> typesToObjects = new();

    public void Register<TInterface, TImplementation>(Scope scope) 
        where TImplementation : TInterface
    {
        typesToImplementation[typeof(TInterface)] = new Binding()
        {
            ImplementationType = typeof(TImplementation),
            Scope = scope
        };

    }

    public object Resolve(Type type)
    {
        throw new NotImplementedException();
    }

    public T Resolve<T>()
    {
        var binding = typesToImplementation[typeof(T)];
        var implementationType = binding.ImplementationType;
        var constructor = implementationType.GetConstructors().First();
        var args = new List<object>();
        foreach (var parameter in constructor.GetParameters())
        {
            args.Add(Resolve(parameter.ParameterType));
        }
        
        if (binding.Scope == Scope.Transient)
        {
            return (T)constructor.Invoke(args.ToArray());
        }
        if (typesToObjects.TryGetValue(typeof(T), out var result))
        {
            return (T)result;
        }

        var instance = (T)constructor.Invoke(args.ToArray());
        typesToObjects[typeof(T)] = instance;
        return instance;

    }
    
    private class Binding
    {
        public Type InterfaceType { get; set; }
        
        public Type ImplementationType { get; set; }

        public Scope Scope;
    }
}