using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using ProjetoMVC;
using System.Text.Json;
using TravelMakerII.Contracts;
using TravelMakerII.Interfaces;
using TravelMakerII.Models;

namespace TravelMakerII.Services;

public class IaService : IIaService
{
    private readonly AzureAICredentials _config;
    public IaService(IOptions<AzureAICredentials> options)
    {
        _config = options.Value;
    }
   

    public List<MecanicSolutionModel> GetMecanic(ProblemsRequestModel request)
    {
        OpenAIClient client = new(new Uri(_config.Endpoint), new AzureKeyCredential(_config.Key));

        IList<ChatMessage> messages = new List<ChatMessage>();

        messages.Add(new ChatMessage(ChatRole.System, PromptConstants.MecanicQuestion));
        string question = $"tenho um veículo modelo: {request.VehicleModel} com o problema {request.Problem} ";

        messages.Add(new ChatMessage(ChatRole.User, question));

        var chatCompletionsOptions = new ChatCompletionsOptions(messages);

        Response<ChatCompletions> response = client.GetChatCompletions(
            deploymentOrModelName: _config.DeploymentModel,
            chatCompletionsOptions);

        Console.WriteLine(response.Value.Choices[0].Message.Content);
        var jsonResponse = JsonSerializer.Deserialize<List<MecanicSolutionModel>>(response.Value.Choices[0].Message.Content);
        return jsonResponse;
    }

    
}
