using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    internal class NegativesNotAllowedException : Exception
    {

        public NegativesNotAllowedException(IEnumerable<int> negativeNumbers)
            : base($"Negatives not allowed: {string.Join(',', negativeNumbers)}")
        {

        }
    }
}
