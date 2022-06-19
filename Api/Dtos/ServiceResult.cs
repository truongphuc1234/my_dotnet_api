namespace Api.Dtos;

public class ServiceResult<T> {
    public bool IsSuccess {get;set;}
    public T? Result {get; set;}
    public string StatusCode {get;set;} = string.Empty;
}