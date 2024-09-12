namespace TaskManagement.Core.Exceptions;

public class MaxWorkItemException : Exception
{
    public MaxWorkItemException(string message) : base(message) { }

}
