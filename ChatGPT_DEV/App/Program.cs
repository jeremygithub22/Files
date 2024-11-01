// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.IO;
class Program
{
    static async Task Main (string[] args)
    {
        var apiKey = "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";
        var chatClient = new ChatGPTCLient(apiKey);

        Console.WriteLine("Enter your questions: ");
        var userInput = Console.ReadLine();

        var response = await chatClient.GetChatGPTResponse(userInput);

        StreamWriter sw = new StreamWriter(@"C:\Users\JEREMIAH\Desktop\ChatGPT_DEV\App\bin\Debug\net6.0\log\output.txt",true);
        sw.WriteLine($"{DateTime.Now.ToShortDateString() +" " + DateTime.Now.ToLongTimeString()} Enter your questions:");
        sw.WriteLine($"{DateTime.Now.ToShortDateString() +" " + DateTime.Now.ToLongTimeString()} Input: {userInput}");
        sw.WriteLine($"{DateTime.Now.ToShortDateString() +" " + DateTime.Now.ToLongTimeString()} ChatGPT response: {response}");
        sw.Close();

        Console.WriteLine($"ChatGPT: {response}");
        Console.ReadKey();
    }
}