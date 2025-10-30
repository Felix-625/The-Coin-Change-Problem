using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'getWays' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. LONG_INTEGER_ARRAY c
     */

    public static long getWays(int n, List<long> c)
    {
        // Create a DP table where dp[i] represents the number of ways to make amount i
    long[] dp = new long[n + 1];
    
    // Base case: There's 1 way to make amount 0 (by using no coins)
    dp[0] = 1;
    
    // Sort the coins (not strictly necessary but good practice)
    c.Sort();
    
    // For each coin, update the DP table
    foreach (long coin in c)
    {
        // For each amount from coin value to n
        for (long amount = coin; amount <= n; amount++)
        {
            // Add the number of ways to make (amount - coin) to current amount
            dp[amount] += dp[amount - coin];
        }
    }
    
    return dp[n];

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();

        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'

        long ways = Result.getWays(n, c);

        textWriter.WriteLine(ways);

        textWriter.Flush();
        textWriter.Close();
    }
}
