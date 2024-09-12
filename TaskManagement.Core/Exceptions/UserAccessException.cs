namespace TaskManagement.Core.Exceptions;

public class UserAccessException : Exception
{
    public UserAccessException(string message) : base(message) { }

}
