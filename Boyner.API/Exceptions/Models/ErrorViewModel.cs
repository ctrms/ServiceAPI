using Boyner.API.Results;

namespace Boyner.API.Exceptions.Models
{
    public class ErrorViewModel : ErrorResult
    {
        public ErrorViewModel(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; set; }
    }
}
