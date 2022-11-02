
namespace Data;

public interface IConsole
{
    void WriteLine(string message, params object?[] args);
    void Write(string message, params object?[] args);

    string? ReadLine();
}
