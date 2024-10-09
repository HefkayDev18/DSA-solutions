using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNthFibonacci
{
    public class FibonacciEquivalent
    {
        public static int Fib(int n)
        {
            if(n == 0) return 0;
            if(n <= 2) return 1;

            int[] memo = new int[n + 1];
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
