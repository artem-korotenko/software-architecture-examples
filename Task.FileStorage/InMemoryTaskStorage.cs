namespace Task.FileStorage;

using Tasks;

public class InMemoryTaskStorage : ITaskStorage
{
    private readonly List<ToDoTask> tasks = new List<ToDoTask>();

    public void AddTask(ToDoTask task)
    {
        tasks.Add(task);
    }

    public void Remove(int index)
    {
        tasks.RemoveAt(index);
    }

    public List<ToDoTask> GetAll()
    {
        return tasks.ToList();
    }


}