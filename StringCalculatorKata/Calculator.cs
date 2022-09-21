using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    internal class Calculator
    {
        internal static int Add(string numbers)
        {
            char[] delimiters = GetDelimiters(numbers);
            string [] strings = numbers.Split(delimiters);
            int sum = 0;
            foreach (var s in strings)
            {
                if (int.TryParse(s, out int number))
                {
                    sum += number;
                }
            }
            
            return sum;
        }

        private static char[] GetDelimiters(string numbers)
        {
            var delimiters = new List<char> { ',', '\n' };
            if (numbers.StartsWith("//"))
            {
                string delimiterDeclaration = numbers.Split('\n').First();
                char delimiter = delimiterDeclaration.Substring(2,1).Single();
                delimiters.Add(delimiter);
            }
            return delimiters.ToArray();
        }
    }
}
