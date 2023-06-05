namespace FinishLine.Services.Models;

public class ValidationModel<T> where T : class
{
    public T Object { get; set; }
    public List<String> Errors { get; set; }
    public bool Success => Errors?.Count == 0;
}