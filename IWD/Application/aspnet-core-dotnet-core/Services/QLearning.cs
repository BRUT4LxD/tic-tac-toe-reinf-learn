using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public static class QLearning
{
    private static readonly HttpClient HttpClient = new HttpClient();
    private const string PythonServer = "http://127.0.0.1:5000/";
    private const string MoveEndpoint = "move";
    private const string StartEndpoint = "start";
    private const string AIStartEndpoint = "aistart";

    public static async Task<string> Move(string positionToPost)
    {
        var dict = new Dictionary<string, string>
        {
            {"position", positionToPost}
        };
        var jsonObject = JsonConvert.SerializeObject(dict);

        var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await HttpClient.PostAsync(PythonServer + MoveEndpoint, content);
        var plainResponse = await response.Content.ReadAsStringAsync();
        var actualPosition = "";
        if (plainResponse != null)
        {
            for (var i = 14; i <= 22; i++)
            {
                actualPosition += plainResponse[i];

            }
        }
        return actualPosition;
    }

    public static async Task<string> Start()
    {
        var response = await HttpClient.GetAsync(StartEndpoint);
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<string> AIStart()
    {
        var response = await HttpClient.GetAsync(AIStartEndpoint);
        return await response.Content.ReadAsStringAsync();
    }
}