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
    }
}