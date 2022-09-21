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
        //Test 1
        [Theory]
        [InlineData(2, "1,1")]
        [InlineData(3, "2,1")]
        public void ReturnNumberGivenCommaSeparatedNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
        //Test 2
        [Theory]
        [InlineData(10, "1,2,3,4")]
        [InlineData(6, "2,2,2")]
        public void ReturnNumberGivenSeveralCommaSeparatedNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
        //Test 3
        [Theory]
        [InlineData(10, "1\n2,3,4")]
        [InlineData(10, "1\n2\n3\n4")]
        public void ReturnNumberGivenNewLineSeparators(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
        //Test 4
        [Theory]
        [InlineData(3, "//;\n1;2")]
        public void ReturnNumberGivenCustomDelimiter(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
        //Test 5
        [Fact]
        public void GivenMultipleNegativeNumberThrowException()
        {
            var calculator = new Calculator();

            Action action = () => Calculator.Add("-1,6,-8");

            var ex = Assert.Throws<Exception>(action);

            Assert.Equal("Negatives not allowed: -1,-8", ex.Message);
        }
        //Test 6
        [Theory]
        [InlineData(5, "5, 1001")]
        [InlineData(4, "1001, 4")]
        public void IgnoreNumbersGivenNumbersAbove1000(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
        //Test 7
        [Theory]
        [InlineData(6, "//[***]\n1***2***3")]
        public void AllowMulticharacterDelimiters(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
        //Test 8 && 9
        [Fact]
        public void ReturnSumGivenTheStringHasLengthtyDelimitor()
        {
            var result = Calculator.Add("//[Tedo$]\n3Tedo$1Tedo$5");

            Assert.Equal(9, result);
        }

        [Fact]
        public void ReturnSumGivenTheStringHasMultipleDelimiterOfMultipleLenght()
        {
            var stringCalculator = new Calculator();
            var result = Calculator.Add("//[**][%%]\n1**2%%3");

            Assert.Equal(6, result);
        }

    }
}