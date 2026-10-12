using ScreenSound.Model;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    override public void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar álbum");
        Console.Write("Digite o nome da banda que deseja avaliar o álbum: ");
        string nomeBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeBanda))
        {
            Banda banda = bandasRegistradas[nomeBanda];
            Console.Write("Digite o nome do álbum que deseja avaliar: ");
            string nomeAlbum = Console.ReadLine()!;
            if (banda.Albuns.Any(a=> a.Nome.Equals(nomeAlbum, StringComparison.OrdinalIgnoreCase)))
            {
               Album albumSelecionado = banda.Albuns.First(a => a.Nome.Equals(nomeAlbum, StringComparison.OrdinalIgnoreCase));
                Console.Write($"Digite a nota para o álbum {albumSelecionado.Nome}:");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                    albumSelecionado.AdicionarNota(nota);
                    Console.WriteLine($"Nota {nota.Nota} adicionada ao álbum {albumSelecionado.Nome}.");
               
            }
            else
            {
                Console.WriteLine($"O álbum {nomeAlbum} não está cadastrado para a banda {nomeBanda}.");
            }
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não está cadastrada.");
        }
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
     
    }
}
