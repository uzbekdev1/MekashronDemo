namespace MekashronDomain.Models
{
    public class ResponseDto<T> : ResultDto where T : class
    {

        public bool IsSuccess { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public T ResultData { get; set; }

    }
}