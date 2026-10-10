using ScreenSound.Model;

namespace ScreenSound.Menus;

internal class MenuMostrarBandas : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Bandas registradas");
        foreach (var banda in bandasRegistradas)
        {
            Console.WriteLine($"Banda: {banda.Key}");
            Console.WriteLine("Álbuns:");
            foreach (var album in banda.Value.Albuns)
            {
                Console.WriteLine($"  - {album.Nome}");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

