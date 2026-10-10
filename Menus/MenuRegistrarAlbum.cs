using ScreenSound.Model;

namespace ScreenSound.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de álbuns");
        Console.Write("Digite o nome da banda que deseja registrar o álbum: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write($"Digite o nome do álbum da banda {nomeDaBanda}: ");
            string nomeDoAlbum = Console.ReadLine()!;
            Album album = new Album(nomeDoAlbum);
            banda.AdicionarAlbum(album);
            Console.WriteLine($"O álbum {nomeDoAlbum} foi registrado com sucesso para a banda {nomeDaBanda}!");
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
