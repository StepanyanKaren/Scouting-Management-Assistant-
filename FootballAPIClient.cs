using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class FootballApiClient
{

    private readonly HttpClient _httpClient;
    private const string ApiKey = "7f47ace0ebmsh41c04e5753f4d9fp165ec4jsn4a14aec0a376"; 
    public FootballApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api-football-v1.p.rapidapi.com/v3/timezone");
    }

    public async Task<string[]> GetLeagues()
    {
        string url = $"api/v1/leagues?apikey={ApiKey}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        JObject responseObject = JObject.Parse(responseBody);
        JArray leaguesArray = responseObject.Value<JArray>("data");
        string[] leagues = leaguesArray.Select(l => l.Value<string>("name")).ToArray();
        return leagues;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        FootballApiClient client = new FootballApiClient();
        string[] leagues = await client.GetLeagues();

        Console.WriteLine("Football Leagues:");
        foreach (string league in leagues)
        {
            Console.WriteLine(league);
        }
    }
}
