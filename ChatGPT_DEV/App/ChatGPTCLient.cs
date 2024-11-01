using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class ChatGPTCLient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public ChatGPTCLient(string apiKey)
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
    
    }

    public async Task<string> GetChatGPTResponse(string prompt)
    {
        var requestContent = new 
        {
            //model = "gpt-4", //Use the desired model here
            model = "gpt-3.5-turbo", //Use the desired model here
            messages = new[]
            {
                new { role = "user", content = prompt}
                //new { role = "user", content = "Advance Database research"}
            },
            max_tokens = 50 //Limit response length (optional)
        };

        //var content = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");

        var content = new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        //var response = await _httpClient.PostAsync("https://platform.openai.com/playground/complete", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

        var responseString = await response.Content.ReadAsStringAsync();

        var responseObject = System.Text.Json.JsonSerializer.Deserialize<ChatGPTResponse>(responseString);

        return responseObject?.choices[0].message.content.Trim() ?? "No response";
    }
}

public class ChatGPTResponse
{
    public Choice[] choices { get; set; }
}

public class Choice
{
    public Message message { get; set; }
}

public class Message
{
    public string content { get; set; }
}