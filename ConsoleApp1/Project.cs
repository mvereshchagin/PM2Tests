using Data;

namespace ConsoleApp;

public class Project
{
    private readonly IConsole _console;

    public Project(IConsole console)
    {
        _console = console;
    }

    public void Start()
    {
        _console.WriteLine("Добро пожаловать, супермега приложение");
        _console.WriteLine("Как тебя зовут?");
        var name = _console.ReadLine();
        _console.WriteLine($"Тебя зовут {name}");
    }

    public int AskAge()
    {
        do
        {
            _console.WriteLine("Сколько тебе лет?");
            var strAge = _console.ReadLine();
            int age;
            if (Int32.TryParse(strAge, out age))
                return age;

            _console.WriteLine("Неправильный ввод");
        }
        while (true);
    }
}
