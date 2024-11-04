using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TransactionService.Models;

public class AccountClient
{
    private readonly HttpClient _client;

    public AccountClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<Account?> GetAccountByNumberAsync(string accountNumber)
    {
        var response = await _client.GetAsync($"/api/account/{accountNumber}");
        response.EnsureSuccessStatusCode();
        
        var account = await response.Content.ReadFromJsonAsync<Account>();
        return account ?? null;
    }

}
