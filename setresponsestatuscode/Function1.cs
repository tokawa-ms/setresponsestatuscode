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

            //code に入っている値を HTTP ステータスコードとしてパース
            if (int.TryParse(code, out int statusCode))
            {
                //パース出来たらそのままステータスコードを返す
                return new StatusCodeResult(statusCode);
            }
            else
            {
                //パース出来なかったら BadRequest を返す
                return new BadRequestObjectResult("Please pass a status code on the query string");
            }
        }
    }
}
