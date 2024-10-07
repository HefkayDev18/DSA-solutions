using System.Data;

namespace LongestSubstring
{
    public class StringAlgorithm()
    {
        public static string CommonSubstring(string text1, string text2)
        {
            int n = text1.Length;
            int m = text2.Length;

            int[,] dp = new int[n + 1, m + 1];

            int max_length = 0;
            int end_position = 0;

            for(int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;

                        if (dp[i, j] > max_length)
                        {
                            max_length = dp[i, j];
                            end_position = i;
                        }
                    }
                }
            }

            return text1.Substring(end_position - max_length, max_length);
        }

        static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            string text1 = "abcdef";
            string text2 = "defabc";

            string longestCommonSubstring = CommonSubstring(text1, text2);

            Console.WriteLine($"The longest common substring between '{text1}' and '{text2}' is: '{longestCommonSubstring}'");

            text1 = "hello";
            text2 = "world";

            longestCommonSubstring = CommonSubstring(text1, text2);

            Console.WriteLine($"The longest common substring between '{text1}' and '{text2}' is: '{longestCommonSubstring}'");
        }
    }
}