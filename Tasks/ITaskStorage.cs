namespace Tasks;

public interface ITaskStorage
{
    void AddTask(ToDoTask task);

    void Remove(int index);

    List<ToDoTask> GetAll();
}