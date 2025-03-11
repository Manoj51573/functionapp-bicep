using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace function
{
    public class MyFunction
    {
        private readonly ILogger _logger;

        public MyFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MyFunction>();
        }

        [Function("MyFunction")]
        public void Run([QueueTrigger("myqueue-items", Connection = "")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
