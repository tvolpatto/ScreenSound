using ScreenSound.Model; 
using OpenAI.Responses;
using OpenAI;
#pragma warning disable OPENAI001

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);

        banda.Resumo = ObterResumoDaBanda(nomeDaBanda) ?? "Resumo indisponível.";
        bandasRegistradas.Add(nomeDaBanda, banda);
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    }

    private static string? ObterResumoDaBanda(string nomeDaBanda)
    {
        try
        {
            string? key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new InvalidOperationException("A variável OPENAI_API_KEY não está configurada.");
            }

            ResponsesClient client = new(key);
            var response = client.CreateResponseAsync(
                "gpt-6-astra",
                $"Summarize in 2 sentences the band {nomeDaBanda}").GetAwaiter().GetResult();

            return response.ToString();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Não foi possível obter o resumo da banda: {ex.Message}");
            return null;
        }
    }

}
