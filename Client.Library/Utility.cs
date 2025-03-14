namespace Client.Library;

public static class Utility
{
    private readonly static string keyboard = """
        1 2 3 4 5 6 7 8 9 0
        q w e r t y u i o p
         a s d f g h j k l
          z x c v b n m
          [ s p a c e ]
        """;
        
    public static void Draw(ConsoleKeyInfo? info = null)
    {
        var lines = keyboard.Split("\n");

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            Print(line, 0, i);

            if (info is not null)
            {
                var space = info.Value.Key == ConsoleKey.Spacebar;
                var last = i == 4;

                if (space && last)
                {
                    Print(line.Trim(), 2, i, ConsoleColor.Black, ConsoleColor.White);
                }
                else if (!space && !last)
                {
                    Highlight(info.Value.KeyChar, i, line);
                }
            }
        }
    }

    private static void Highlight(char c, int y, string line)
    {
        if (line.Contains(c, StringComparison.OrdinalIgnoreCase))
        {
            var index = line.IndexOf(c, StringComparison.OrdinalIgnoreCase);
            Print(c.ToString()!, index, y, ConsoleColor.Black, ConsoleColor.White);
        }
    }

    private static void Print(string text, int x, int y, ConsoleColor? foreground = null, ConsoleColor? background = null)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = foreground ?? Console.ForegroundColor;
        Console.BackgroundColor = background ?? Console.BackgroundColor;
        Console.Write(text);
        Console.ResetColor();
    }
}
