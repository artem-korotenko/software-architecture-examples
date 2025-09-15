using DI.Core;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);

var instance = di.Resolve<IFirstInterface>();
var instance2 = di.Resolve<IFirstInterface>();
var instance3 = di.Resolve<ISecondInterface>();
Console.WriteLine();

public interface IFirstInterface
{
    
}

public class FirstImplementation : IFirstInterface
{
    public override string ToString()
    {
        return $"First{GetHashCode()}";
    }
}

public interface ISecondInterface
{
    
}

public class SecondImplementation : ISecondInterface
{
    private IFirstInterface firstInterface;
    
    public SecondImplementation(IFirstInterface firstInterface)
    {
        
    }
}