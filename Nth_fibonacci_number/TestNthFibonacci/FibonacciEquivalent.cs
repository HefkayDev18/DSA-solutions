using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNthFibonacci
{
    public class FibonacciEquivalent
    {
        public static long Fib(int n)
        {
            if(n == 0) return 0;
            if(n <= 2) return 1;

            long[] memo = new long[n + 1];
            memo[0] = 0;
            memo[1] = 1;

            for(int i = 2; i <= n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];

            }

            return memo[n];
        }
    }
}
