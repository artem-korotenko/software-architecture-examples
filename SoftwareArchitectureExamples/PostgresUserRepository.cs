namespace SoftwareArchitectureExamples;

public class PostgresUserRepository
{
    private static PostgresUserRepository? instance;

    public static PostgresUserRepository GetInstance()
    {
        if (instance == null)
        {
            instance = new PostgresUserRepository();
        }

        return instance;
    }
}

public class AddUserCommand
{
    public void Execute()
    {
       var repo = PostgresUserRepository.GetInstance();
    }
}