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
            List<int> numberList = new List<int>();
            foreach (var s in strings)
            {
                if (int.TryParse(s, out int number))
                {
                    numberList.Add(number);
                }
            }
            CheckForNegativeNumbers(numberList);
            return numberList.Sum();
        }

        private static void CheckForNegativeNumbers(List<int> numberList)
        {
            var negativeNumbers = numberList.Where(x => x < 0).ToList();
            if (negativeNumbers.Count > 0)
            {
                throw new NegativesNotAllowedException(negativeNumbers);
            }
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
