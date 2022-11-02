namespace ConsoleApp;

public class MathUtils
{
    public int Fibonacci(int number)
    {
        if (number == 0)
            return 0;
        if (number == 1)
            return 1;

        return Fibonacci(number - 1) + Fibonacci(number - 2);
    }
}
