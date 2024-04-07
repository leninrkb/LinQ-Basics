public class Exercises
{
    public void evenNumbers(int[] numbers)
    {
        var even = numbers.Where(p => (
            p % 2 == 0
        ));
        Console.WriteLine(string.Join(", ", even));
    }

    public void square(List<Object> obs)
    {
        var squares = obs.Where(p => (
            p is int
        )).Select(p => new
        {
            number = p,
            square = Math.Pow((int)p, 2)
        });
        foreach (var item in squares)
        {
            Console.WriteLine($"number:{item.number} square:{item.square}");
        }
    }

    public void numberFrequency(int[] numbers)
    {
        var frequency = numbers.GroupBy(p => p).Select(p => new
        {
            number = p.Key,
            frequency = p.Count()
        });
        foreach (var item in frequency)
        {
            Console.WriteLine($"number:{item.number} frequency:{item.frequency}");
        }

    }

    public void numberTimesFrequency(int[] numbers)
    {
        var frequency = numbers.GroupBy(p => p).Select(p => new
        {
            number = p.Key,
            frequency = p.Count(),
            times = p.Key * p.Count(),
        });
        foreach (var item in frequency)
        {
            Console.WriteLine($"{item.number} {item.times} {item.frequency}");
        }

    }

    public void strinStartEndWith(string[] strs, char start, char end){
        var str = strs.Where(p => (
            p.StartsWith(start) && p.EndsWith(end)
        ));
        foreach (var item in str)
        {
            Console.WriteLine(item);
        }
    }

    public Func<string> Greetings(string s){
        return () => (s);
    }
}