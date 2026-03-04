var integrator = new Integrator();

Console.WriteLine(integrator.Integrate(0, 1, 0.0001, x=> x * x));
Console.WriteLine(integrator.Integrate(0, 1, 0.0001, x => Math.Sin(x)));
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


