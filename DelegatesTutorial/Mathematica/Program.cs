var integrator = new Integrator();

Console.WriteLine(integrator.Integrate(0, 1, 0.0001, x=> x * x));
Console.WriteLine(integrator.Integrate(0, 1, 0.0001, x => Math.Sin(x)));

var myNumbers = new List<int> { 1, 2, 3, 4, 5, 10 };

var doubled = TransformNumbers(myNumbers, x => x * 2);
Console.WriteLine("Doubled numbers: " + string.Join(", ", doubled));

var evens = FilterNumbers(myNumbers, x => x % 2 == 0);
Console.WriteLine("Even numbers: " + string.Join(", ", evens));

var sum = AggregateNumbers(myNumbers, 0, (acc, n) => acc + n);
Console.WriteLine("Total sum: " + sum);

Repeat(3, () => Console.WriteLine("Action"));

var multiplyBy5 = CreateMultiplier(5);
Console.WriteLine(multiplyBy5(10));

List<int> TransformNumbers(List<int> numbers, Func<int, int> transformer)
{
    List<int> result = new List<int>();
    foreach (int n in numbers)
    {
        result.Add(transformer(n));
    }
    return result;
}

List<int> FilterNumbers(List<int> numbers, Func<int, bool> condition)
{
    List<int> result = new List<int>();
    foreach (int n in numbers)
    {
        if (condition(n))
        {
            result.Add(n);
        }
    }
    return result;
}

int AggregateNumbers(List<int> numbers, int initialValue, Func<int, int, int> aggregator)
{
    int result = initialValue;
    foreach (int n in numbers)
    {
        result = aggregator(result, n);
    }
    return result;
}

void Repeat(int times, Action action)
{
    for (int i = 0; i < times; i++)
    {
        action();
    }
}

Func<int, int> CreateMultiplier(int factor)
{
    return (int n) => n * factor;
}

public delegate double Integrable(double x);
public class Integrator
{
    public double Integrate(double start, double end, double step, Func<double, double> function)
    {
        var sum = 0.0;

        for (var x = start; x < end; x += step)
        {
            var y = function(x);
            sum += y * step;
        }

        return sum;
    }
}