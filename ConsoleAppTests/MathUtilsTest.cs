using ConsoleApp;

namespace ConsoleAppTests;

internal class MathUtilsTest
{
    [TestCase(8, 21)]
    [TestCase(9, 34)]
    [TestCase(6, 8)]
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(14, 377)]
    [TestCase(22, 17711)]
    public void FibonacciInputValue0_ReturnsValue1(int input, int output)
    {
        // Assign
        MathUtils mathUtils = new MathUtils();

        // Act
        var result = mathUtils.Fibonacci(input);

        // Assert
        Assert.That(result, Is.EqualTo(output));
    }
}
