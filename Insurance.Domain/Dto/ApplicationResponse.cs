namespace Insurance.Domain.Dto;

public class ApplicationResponse<T>: ApplicationResponse
{
    public ApplicationResponse()
    {
        
    }

    public ApplicationResponse(T result)
    {
        Result = result;
        IsSuccess = true;

    }

    public T Result { get;set; }
}
public class ApplicationResponse
{
    public ApplicationResponse(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
    
    public ApplicationResponse(bool isSuccess , string errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage=errorMessage;  
    }

    public ApplicationResponse()
    {
        
    }

    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
}