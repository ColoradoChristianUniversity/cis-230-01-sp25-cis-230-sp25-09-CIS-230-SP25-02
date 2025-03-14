using Client.Library;

internal class Program
{
    static Program()
    {
        Console.CursorVisible = false;
    }

    private static void Main(string[] args)
    {
        while (true)
        {
            var info = Console.ReadKey(intercept: true);
            Utility.Draw(info);
        }
    }
}