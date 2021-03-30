using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Kontroller
{
    public class Rukzak
    {
        public static List<int> knapsack(int[] weights, int[] costs, int needed)
        {
            List<int> rukzak = new List<int>();
            int n = weights.Length;
            int[,] dp = new int[needed + 1, n + 1];
            for (int j = 1; j <= n; j++)
            {
                for (int w = 1; w <= needed; w++)
                {
                    if (weights[j - 1] <= w)
                    {
                        dp[w, j] = Math.Max(dp[w, j - 1], dp[w - weights[j - 1], j - 1] + costs[j - 1]);
                    }
                    else
                    {
                        dp[w, j] = dp[w, j - 1];
                    }
                }
            }
            int res = dp[needed, n], a = needed;
            for (int i = n; i >= 0; i--) 
            {
                if (res <= 0) 
                    break;
                if (res == dp[a,i - 1]) 
                    continue;
                else
                {
                  rukzak.Add(i-1);
                  res -= costs[i - 1]; 
                  a -= weights[i - 1];  }
            }
            rukzak.Add(dp[needed, n]);
            return rukzak;
        } 
    }
}
