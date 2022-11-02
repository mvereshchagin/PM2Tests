using ConsoleApp;
using Data;
using NSubstitute;
using System.Text;

namespace ConsoleAppTests;

public class ProjectTest
{
    private ConsoleStub console;
    private Project project;
    private StringBuilder sb;

    [SetUp]
    public void Setup()
    {
        sb = new StringBuilder();

        console = new ConsoleStub();
        console.OnTextChanged += (sender, e) =>
        {
            sb.Append(e.Text);
        };

        project = new Project(console);
    }

    [Test]
    public void StartUserInputsVasya_ReturnsYourNameIsVasya()
    {
        // Arrange
        string name = "Vasya";

        string?[] outputs = { 
            "Добро пожаловать, супермега приложение\r\n",
            "Как тебя зовут?\r\n",
            name + "\r\n", 
            $"Тебя зовут {name}\r\n"
        };

        console.SetInputs(name);

        // Act
        project.Start();

        // Assert
        //Assert.AreEqual(expected: String.Join(separator: "/r/n", outputs), actual: sb.ToString());
        Assert.That(actual: sb.ToString(), expression: Is.EqualTo(String.Join(separator: "", outputs)));
    }

    [TestCase("Вася")]
    [TestCase("Петя")]
    [TestCase("Люба")]
    public void StartUserInputsName_ReturnsYourNameIsName(string name)
    {
        // Arrange
        string?[] outputs = {
            "Добро пожаловать, супермега приложение\r\n",
            "Как тебя зовут?\r\n",
            name + "\r\n",
            $"Тебя зовут {name}\r\n"
        };

        console.SetInputs(name);

        // Act
        project.Start();

        // Assert
        //Assert.AreEqual(expected: String.Join(separator: "/r/n", outputs), actual: sb.ToString());
        Assert.That(actual: sb.ToString(), expression: Is.EqualTo(String.Join(separator: "", outputs)));
    }

    public void StartUserInputsPetya_ReturnsYourNameIsPetya()
    {
        // Arrange
        string?[] outputs = {
            "Добро пожаловать, супермега приложение\r\n",
            "Как тебя зовут?\r\n",
            "Петя" + "\r\n",
            $"Тебя зовут Петя\r\n"
        };
        var console = new ConsoleForPetya();
        var project = new Project(console);

        // Act
        project.Start();

        // Assert
        Assert.That(actual: console.Output, expression: Is.EqualTo(String.Join(separator: "", outputs)));
    }

    private class ConsoleForPetya : IConsole
    {
        public string Output
        {
            get
            {
                return "Добро пожаловать, супермега приложение\r\n" +
                    "Как тебя зовут?\r\n" +
                    "Петя\r\n" +
                    $"Тебя зовут Петя\r\n";
            }
        }

        public string? ReadLine()
        {
            return "Петя";
        }

        public void Write(string message, params object?[] args)
        {
            
        }

        public void WriteLine(string message, params object?[] args)
        {
            
        }
    }

    [Test]
    public void AskAge_UserInput_Vasya_Petya_32_LoopThenReturns32()
    {
        // Arrange
        string?[] outputs = {
            "Сколько тебе лет?\r\n",
            //"Вася\r\n",
            "Неправильный ввод\r\n",
            "Сколько тебе лет?\r\n",
            //"Петя\r\n",
            "Неправильный ввод\r\n",
            "Сколько тебе лет?\r\n",
            //$"32\r\n",
        };

        StringBuilder sb = new StringBuilder();
        var console = Substitute.For<IConsole>();
        console.ReadLine().Returns("Вася", "Петя", "32");
            //.AndDoes(x => sb.AppendLine("Вася"));
        console.When(x => x.WriteLine(Arg.Any<string>()))
            .Do(x => sb.AppendLine(x.Arg<string>()));
        //console.When(x => x.ReadLine())
        //    .Do(x => console.WriteLine(Arg.Any<string>()));

        var project = new Project(console);

        // Act
        project.AskAge();

        // Assert
        Assert.That(actual: sb.ToString(), expression: Is.EqualTo(String.Join(separator: "", outputs)));
    }

 }