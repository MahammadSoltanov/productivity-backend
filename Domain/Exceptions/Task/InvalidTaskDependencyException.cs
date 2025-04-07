namespace Domain.Exceptions.Task;
public class InvalidTaskDependencyException : Exception
{
    public InvalidTaskDependencyException(string message) : base(message) { }
}
