using DuckCoin.Dto;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace DuckCoin.Wallet.HttpClients
{
    public class FullNodeHttpClient : IFullNodeHttpClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string FullNodeUrlSettingName = "fullNodeUrl";

        public FullNodeHttpClient()
        {
            _httpClient.BaseAddress = new Uri(Program.Configuration.GetValue<string>(FullNodeUrlSettingName));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task PostTransactionAsync(TransactionDto transactionDto)
        {
            var transactionDtoString = JsonSerializer.Serialize(transactionDto);
            var requestContent = new StringContent(transactionDtoString, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("transaction", requestContent).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
        
        public async Task PostAccountAsync(string accountAddress)
        {
            var requestContent = new StringContent(accountAddress, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("account", requestContent).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<OperationDto>> GetAllAccountOperationsAsync(string accountAddress)
        {
            var response = await _httpClient.GetAsync($"transactions/getOperationsByAccountId/{accountAddress}");
            response.EnsureSuccessStatusCode();
            var stringContent = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<IEnumerable<OperationDto>>(stringContent);
        }
    }
}
