namespace Primes2;

public class Program2
{
    public static bool IsPrime(long n)
    {
        switch (n)
        {
            case 0:
            case 1:
                return false;
            case 2:
                return true;
            default:
                if (n % 2 == 0) return false;
                break;
        }
        var m = Math.Sqrt(n);
        for (long i = 3; i <= m; i+=2)
        {
            if(n%i==0) return false;
        }
        return true;
    }
    static IEnumerable<long> NextPrime()
    {
        yield return 2;
        for(long i = 3; ;i += 2)
            if(IsPrime(i))
                yield return i;
    }
    static void DoTest()
    {
        double i = 0;
        var vs = 1.0;
        long pp = 1;
        var lvs = new List<long>();
        int c = 0;
        foreach (var v in NextPrime())
        {
            lvs.Add(v);
            pp *= v;
            vs *= ((v) * (v));

            var s = Math.Sqrt(vs - 1) / pp;
            i = (i + 11.0) / 12.0;
            var d = s - i;
            Console.WriteLine($"v={v} s={s},i={i},d={d}");
            if (d == 0||c++>=20) break;
        }
        i = 0;
        for (long v = 2; v <= lvs.Max(); v++)
        {
            pp *= v;
            vs *= (v * v);

            var s = Math.Sqrt(vs - 1) / pp;
            i = (i + 11.0) / 12.0;
            Console.WriteLine($"v={v} s={s},i={i},d={s - i}");
        }

    }
    static void Main2(string[] args)
    {
        DoTest();
    }
}