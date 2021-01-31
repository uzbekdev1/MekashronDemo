namespace MekashronDomain.Models
{
    public class ResponseDto<T> where T : class
    {

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public T ResultData { get; set; }

    }
}