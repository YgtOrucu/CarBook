using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace CarBook.Application.Base;
public class BaseResult<T>
{
    public T? Data { get; set; }
    public IEnumerable<Error>? Errors { get; set; }
    public string Message { get; set; }
    public bool Status { get; set; }

    [JsonIgnore]
    public bool IsSuccess => Errors == null || !Errors.Any();

    [JsonIgnore]
    public bool IsFailure => !IsSuccess;

    public static BaseResult<T> Success(T data)
    {
        return new BaseResult<T>
        {
            Data = data,
            Status = true,
            Message = "Operation successful."
        };
    }

    public static BaseResult<T> Success(bool status, string message)
    {
        return new BaseResult<T>
        {
            Status = status,
            Message = message
        };
    }

    public static BaseResult<T> Failure(string message)
    {
        return new BaseResult<T> { Errors = [new Error { ErrorMessage = message }] };
    }

    public static BaseResult<T> Failure(IEnumerable<IdentityError> errors)
    {
        return new BaseResult<T>
        {
            Status = false,
            Errors = errors.Select(e => new Error { Code = e.Code, ErrorMessage = e.Description })
        };
    }
}
public class Error
{
    public string? Code { get; set; }
    public string? ErrorMessage { get; set; }
}


