namespace JazaniT1.Api.Exceptions
{
    public class ErrorResponse
    {
        public string? Message { get; set; }
        public IList<ErrorValidationModel> Errors { get; set; }
    }
}
