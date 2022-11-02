using Data;

namespace ConsoleAppTests;

internal class ConsoleStub : IConsole
{
    public event EventHandler<TextChangedEventArgs>? OnTextChanged;

    public class TextChangedEventArgs : EventArgs
    {
        public TextChangedEventArgs(string? text)
        {
            Text = text;
        }

        public string? Text { get; init; }
    }

    private List<string?> _inputs = new List<string?>();
    private int _inputPosition = 0;

    public ConsoleStub()
    {
        
    }

    public void SetInputs(params string?[] inputs)
    {
        _inputs.AddRange(inputs);
    }

    public string? ReadLine()
    {
        var input = _inputs[_inputPosition];
        _inputPosition++;

        OnTextChanged?.Invoke(this, new TextChangedEventArgs(input + "\r\n"));

        return input;
    }

    public void Write(string message, params object?[] args)
    {
        var output = String.Format(message, args);
        OnTextChanged?.Invoke(this, new TextChangedEventArgs(output));
    }

    public void WriteLine(string message, params object?[] args)
    {
        var output = String.Format(message, args);
        OnTextChanged?.Invoke(this, new TextChangedEventArgs(output + "\r\n"));
    }
}
