using FluentAssertions;
using NUnit.Framework;


namespace CSharp
{
    [TestFixture]
    public class given_a_roman_numeral
    {
        [TestCase("I", 1, TestName = "then I is converted 1")]
        [TestCase("II", 2, TestName = "then II is converted 2")]
        public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic)
        {
            Roman.ToArabic().Should().Be(ExpectedArabic);
        }

    }


    public static class RomanNumeralConverter
    {
        public static int ToArabic(this string Roman)
        {
            return 1;
        }
    }
}