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

        
    }
}