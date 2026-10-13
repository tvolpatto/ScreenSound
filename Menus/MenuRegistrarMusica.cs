using ScreenSound.Model;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica: Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o nome da banda que deseja registrar a música: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            List<Album> albunsDaBanda = (List<Album>)banda.Albuns;
            for (int i = 0; i < albunsDaBanda.Count; i++)
            {
                Album album = albunsDaBanda[i];
                Console.WriteLine($"{i + 1} - {album.Nome}");
            }
            Console.Write($"Digite número do album que deseja registrar a música: ");
            int numeroDoAlbum = int.Parse(Console.ReadLine()!) -1;
            if (numeroDoAlbum < 0 || numeroDoAlbum >= albunsDaBanda.Count)
            {
                Console.WriteLine("Álbum inválido.");
                
            }
            else
            {
                Console.Write($"Digite o nome da música do {albunsDaBanda[numeroDoAlbum].Nome}: ");
                string nomeDaMusica = Console.ReadLine()!;
                Musica musica = new Musica(banda, nomeDaMusica);
                albunsDaBanda[numeroDoAlbum].AdicionarMusica(musica);
                Console.WriteLine($"A música {nomeDaMusica} foi registrada com sucesso para o album {albunsDaBanda[numeroDoAlbum].Nome}!");
            }
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
