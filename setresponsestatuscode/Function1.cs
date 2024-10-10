using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace setresponsestatuscode
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get",Route = "{code}")] HttpRequest req, string code)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            //code �ɓ����Ă���l�� HTTP �X�e�[�^�X�R�[�h�Ƃ��ăp�[�X
            if (int.TryParse(code, out int statusCode))
            {
                //�p�[�X�o�����炻�̂܂܃X�e�[�^�X�R�[�h��Ԃ�
                return new StatusCodeResult(statusCode);
            }
            else
            {
                //�p�[�X�o���Ȃ������� BadRequest ��Ԃ�
                return new BadRequestObjectResult("Please pass a status code on the query string");
            }
        }
    }
}
