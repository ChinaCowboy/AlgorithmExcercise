using System;

namespace Bent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string str = "1211918";
            int n = 2;
            var results = RemoveNumberForSmallest.buildLowestNumber(str, n);
            Console.WriteLine(results);
            Console.ReadLine();
        }
    }

    public class RemoveNumberForSmallest
    {
       // public static string results = "";
        public static string buildLowestNumber(string str, int n)
        {
            var results = "";
            if (n == 0)
            {
                results += str;
                return results;
            }
            int len = str.Length;

            if (len <= n)
            {
                return results;
            }

            int minIndex = 0;
            // Find the smallest character among  
            // first (n+1) characters of str.

            for (int i = 1; i <=n ; i++)
            {
                if (str[i] < str[minIndex])
                    minIndex = i;

            }
            // Append the smallest character to result  
            results += str[minIndex];

            string new_string = str.Substring(minIndex + 1);

            results+= buildLowestNumber(new_string, n - minIndex);

            return results;
        }



    }
}
