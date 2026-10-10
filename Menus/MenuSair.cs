using ScreenSound.Model;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        
        ExibirTituloDaOpcao("Saindo do prorama");
        Console.WriteLine("Obrigado por utilizar o ScreenSound!");
        
    }
}
