namespace FinishLine.Services.Models;

public class ValidationModel<T> where T : class
{
    public T Object { get; set; }
    public List<string>? Errors { get; set; }
    public bool Success => Errors == null || Errors.Count == 0 ;
}