namespace StringCalculatorKata
{
    public class CalculatorTest
    {
        [Fact]
        public void Return0GivenEmptyString()
        {
            int result = Calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(2, "1,1")]
        [InlineData(3, "2,1")]
        public void ReturnNumberGivenCommaSeparatedNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, "1,2,3,4")]
        [InlineData(6, "2,2,2")]
        public void ReturnNumberGivenSeveralCommaSeparatedNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, "1\n2,3,4")]
        [InlineData(10, "1\n2\n3\n4")]
        public void ReturnNumberGivenNewLineSeparators(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, "//;\n1;2")]
        public void ReturnNumberGivenCustomDelimiter(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThrowExceptionGivenNegativeNumbers()
        {
            void TestCode() => Calculator.Add("-1,-4,7");
            var exception = Assert.Throws
                <NegativesNotAllowedException>((Action)TestCode);

            Assert.Contains("-1", exception.Message);
            Assert.Contains("-4", exception.Message);
            Assert.DoesNotContain("7", exception.Message);
        }
        [Theory]
        [InlineData(5, "5, 1001")]
        [InlineData(4, "1001, 4")]
        public void IgnoreNumbersGivenNumbersAbove1000(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(6, "//[***]\n1***2***3")]
        public void AllowMulticharacterDelimiters(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
    }
}