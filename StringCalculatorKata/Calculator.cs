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
            string [] strings = numbers.Split(',', '\n');
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
    }
}
