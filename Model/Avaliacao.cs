namespace ScreenSound.Model;

internal class Avaliacao
{

    public Avaliacao(int nota)
    {   
        Nota = nota;
    }

    public int Nota { get; }

    /**
     * Method to parse a string representation of a note into an Avaliacao object. usning the static method Parse.
     * @param notaString the string representing the note.
     * @return  an Avaliacao object.
     */
    public static Avaliacao Parse(string notaString)
    {
        int nota = int.Parse(notaString);
        return new Avaliacao(nota);
    }
}
