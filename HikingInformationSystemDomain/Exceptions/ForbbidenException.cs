namespace HikingInformationSystemDomain.Exceptions;

public class ForbbidenException : Exception
{
    public ForbbidenException(string? message) : base(message)
    {
    }
}