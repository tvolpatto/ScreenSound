using ScreenSound.Menus;
using ScreenSound.Model;

Banda ira = new("Ira!");
ira.AdicionarNota(new Avaliacao(10));
ira.AdicionarNota(new Avaliacao(8));
ira.AdicionarNota(new Avaliacao(9));

Banda linkinPark = new("Linkin Park"); 
linkinPark.AdicionarNota(new Avaliacao(10));
linkinPark.AdicionarNota(new Avaliacao(9));
linkinPark.AdicionarNota(new Avaliacao(10));

Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(ira.Nome, ira);
bandasRegistradas.Add(linkinPark.Nome, linkinPark);

Dictionary<int, Menu> menus = new Dictionary<int, Menu>();
menus.Add(1, new MenuRegistrarBanda());
menus.Add(2, new MenuRegistrarAlbum());
menus.Add(3, new MenuMostrarBandas());
menus.Add(4, new MenuAvaliarBanda());
menus.Add(5, new MenuAvaliarAlbum());
menus.Add(6, new MenuExibirDetalhes());
menus.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um álbum");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    

    if ( menus.ContainsKey(opcaoEscolhidaNumerica) )
    {
        Menu menuOption = menus[opcaoEscolhidaNumerica];
        menuOption.Executar(bandasRegistradas);
        if(opcaoEscolhidaNumerica > 0)
        {
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine("Opção inválida");
        ExibirOpcoesDoMenu();
    }

    
}

ExibirOpcoesDoMenu();