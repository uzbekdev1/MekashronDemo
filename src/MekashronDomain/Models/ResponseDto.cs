namespace MekashronDomain.Models
{
    /// <summary>
    /// General rest response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDto<T> where T : class
    {

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public T ResultData { get; set; }

    }
}