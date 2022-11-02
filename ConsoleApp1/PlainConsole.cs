using Data;

namespace ConsoleApp;

public class PlainConsole : IConsole
{
    public string? ReadLine() => Console.ReadLine();

    public void Write(string message, params object?[] args) => Console.WriteLine(message, args);

    public void WriteLine(string message, params object?[] args) => Console.Write(message, args);
}
