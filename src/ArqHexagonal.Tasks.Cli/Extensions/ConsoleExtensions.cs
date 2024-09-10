namespace ArqHexagonal.Tasks.Cli.Extensions;

public static class ConsoleExtensions
{
    public static string[] ParseArguments(string input)
    {
        var result = new List<string>();
        var argument = "";
        var inQuotes = false;

        foreach (var ch in input)
        {
            if (ch == '"')
            {
                inQuotes = !inQuotes;
                if (!inQuotes && argument.Length > 0)
                {
                    result.Add(argument);
                    argument = "";
                }
            }
            else if (ch == ' ' && !inQuotes)
            {
                if (argument.Length > 0)
                {
                    result.Add(argument);
                    argument = "";
                }
            }
            else
            {
                argument += ch;
            }
        }

        if (argument.Length > 0)
        {
            result.Add(argument);
        }

        return result.ToArray();
    }
}
