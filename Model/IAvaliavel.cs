namespace ScreenSound.Model;

internal interface IAvaliavel
{
    void AdicionarNota(Avaliacao nota);
    
    double Media { get; }
}
