using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MekashronDomain.Models;
using Newtonsoft.Json;
using ServiceReference1;
using LoginRequest = MekashronDomain.Models.LoginRequest;

namespace MekashronDomain.Services
{
    public class AccountService
    {

        private readonly ICUTechClient _client;

        public AccountService()
        {
            _client = new ICUTechClient();
        }

        public async Task<ResponseDto<EntityResponse>> Login(LoginRequest request)
        {
            try
            {
                var response = await _client.LoginAsync(request.UserName, request.Password, request.IPs);
                var result = new ResponseDto<EntityResponse>();

                if (string.IsNullOrWhiteSpace(response.@return))
                {
                    result.ErrorCode = 500;
                    result.ErrorMessage = "Internal Server Error";
                }
                else
                {
                    if (response.@return.Contains("ResultCode") && response.@return.Contains("ResultMessage"))
                    {
                        var errorResult = JsonConvert.DeserializeObject<ResultDto>(response.@return);

                        result.ErrorCode = errorResult.ResultCode;
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
                    ErrorMessage = exception.Message,
                    ErrorCode = -1
                };
            }
        }

    }
}
