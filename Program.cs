﻿namespace Primes2;
using Deveel.Math;
public class Program
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
        for (long i = 3; i <= m; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }
    static IEnumerable<long> NextPrime()
    {
        yield return 2;
        for (long i = 3; ; i += 2)
            if (IsPrime(i))
                yield return i;
    }

    /// <summary>
    /// sqrt((2*3*5*7...)^2-1)/(2*3*5*7...) = i=(i+11)/12
    /// </summary>
    static void DoTest()
    {
        var i = BigDecimal.Zero;
        var vs = BigDecimal.One;
        var pp = vs;
        BigDecimal eleven = new(11.0);
        BigDecimal twelve = new(12.0);
        var lvs = new List<BigDecimal>();
        int c = 0;
        using var @out = new StreamWriter("result.txt");
        foreach (var v in NextPrime())
        {
            lvs.Add(v);
            pp *= v;
            vs *= (v - 1) * (v - 1);
            var vsm = vs - 1; 
            var s = vsm.Sqrt() / pp;
           
            i = (i+ eleven) / twelve;
            var d = s - i;
            @out.WriteLine($"v={v}\ns={s}\ni={i}\nd={d}");
            if (c++ == 20) break;
        }
    }
    public static void Main(string[] args)
    {
        DoTest();
    }
}
