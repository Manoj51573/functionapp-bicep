using System.Net;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Insight.InsightPath
{
    public class ValidateEnvironmentDns
    {
        private readonly ILogger _logger;

        public ValidateEnvironmentDns(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ValidateEnvironmentDns>();
        }

        [Function("ValidateEnvironmentDns")]
         public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function ValidateEnvironmentDns processed a request.");

            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"), 
                new XElement("test-run",
                new XElement("test-suite", new XAttribute("type", "TestFixture"), new XAttribute("name", "ValidateEnvironmentDns"))
            ));

            var dnsEntries = BuildHostnames();

            foreach (string dnsEntry in dnsEntries)
            {
                var result = await CallDnsAndLogResultAsync(_logger, dnsEntry);
                var testCase = new XElement("test-case",
                    new XAttribute("name", $"DNS lookup for {dnsEntry}"),
                    new XAttribute("result", result ? "Passed" : "Failed")
                );
                doc.Root.Element("test-suite").Add(testCase);
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/xml");
            response.WriteString(doc.ToString());

            return response;
        }
        
        private static async Task<bool> CallDnsAndLogResultAsync(ILogger logger, string dnsEntry)
        {
            logger.LogInformation($"Checking DNS entry for {dnsEntry}.");
            try
            {
                var addresses = await Dns.GetHostAddressesAsync(dnsEntry);
                logger.LogInformation($"DNS lookup for {dnsEntry} succeeded with {addresses.Length} addresses.");
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"DNS lookup for {dnsEntry} failed.");
                return false;
            }
        }

        /// <summary>
        /// Build the list of hostnames to check.
        /// </summary>
        /// <returns></returns>
        private static List<string> BuildHostnames()
        {
            return new List<string> {
                GetEnvironmentVariable("APP_ENVIRONMENT_NAME"),
                GetEnvironmentVariable("APIM_GATEWAY_NAME"),
                string.Format($"{GetEnvironmentVariable("SERVICE_BUS_NAMESPACE_NAME")}.servicebus.windows.net"),
                string.Format($"{GetEnvironmentVariable("SERVICE_BUS_NAMESPACE_NAME")}.privatelink.servicebus.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.blob.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.privatelink.blob.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.queue.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.privatelink.queue.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.table.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.privatelink.table.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.file.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_DATA_NAME")}.privatelink.file.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.blob.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.privatelink.blob.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.queue.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.privatelink.queue.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.table.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.privatelink.table.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.file.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("STORAGE_ACCOUNT_TEL_NAME")}.privatelink.file.core.windows.net"),
                string.Format($"{GetEnvironmentVariable("KEY_VAULT_SHARED_NAME")}.vault.azure.net"),
                string.Format($"{GetEnvironmentVariable("KEY_VAULT_SHARED_NAME")}.privatelink.vaultcore.azure.net"),
                string.Format($"{GetEnvironmentVariable("KEY_VAULT_APIM_NAME")}.vault.azure.net"),
                string.Format($"{GetEnvironmentVariable("KEY_VAULT_APIM_NAME")}.privatelink.vaultcore.azure.net"),
            };
        }

        private static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process) ?? "";
        }
    }
}
