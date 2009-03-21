namespace TextualView
{
    public interface IGameView
    {
        void Print(string i_String);
        void PrintLine(string i_String);

        string ReadLine();
    }
}
