using Newtonsoft.Json;

namespace HikingInformationSystem.ExceptionHandling;

public class ExceptionResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public ExceptionResponse(int statusCode, string? message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}