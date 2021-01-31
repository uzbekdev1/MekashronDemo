using System;
using System.Threading.Tasks;
using MekashronDomain.Models;
using Newtonsoft.Json;
using ServiceReference1; 

namespace MekashronDomain.Services
{
    /// <summary>
    /// Account service
    /// </summary>
    public class AccountService
    {
        /// <summary>
        /// SOAP instance
        /// </summary>
        private readonly ICUTechClient _client;

        public AccountService()
        {
            _client = new ICUTechClient();
        }

        /// <summary>
        /// Login request
        /// </summary>
        /// <param name="request">Customer entity</param>
        /// <returns></returns>
        public async Task<ResponseDto<EntityResponse>> Login(Models.LoginRequest request)
        {
            try
            {
                var response = await _client.LoginAsync(request.UserName, request.Password, request.IPs);
                var result = new ResponseDto<EntityResponse>();

                if (string.IsNullOrWhiteSpace(response.@return))
                {
                    result.ErrorMessage = "Internal Server Error";
                }
                else
                {
                    if (response.@return.Contains("ResultCode") && response.@return.Contains("ResultMessage"))
                    {
                        var errorResult = JsonConvert.DeserializeObject<ResultDto>(response.@return);

                        result.ErrorMessage = errorResult.ResultMessage;
                    }
                    else
                    {
                        var resultData = JsonConvert.DeserializeObject<EntityResponse>(response.@return);

                        result.IsSuccess = true;
                        result.ResultData = resultData;
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                return new ResponseDto<EntityResponse>
                {
                    ErrorMessage = exception.Message 
                };
            }
        }

    }
}
