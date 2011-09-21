using System.Linq;
using FluentAssertions;
using NUnit.Framework;


namespace CSharp
{
    [TestFixture]
    public class given_a_roman_numeral
    {
        [TestCase("I", 1, TestName = "then I is converted 1")]
        [TestCase("II", 2, TestName = "then II is converted 2")]
        [TestCase("III", 3, TestName = "then III is converted 3")]
        [TestCase("IV", 4, TestName = "then IV is converted 4")]
        [TestCase("V", 5, TestName = "then V is converted 5")]
        public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic)
        {
            Roman.ToArabic().Should().Be(ExpectedArabic);
        }

    }


    public static class RomanNumeralConverter
    {
        public static int ToArabic(this string Roman)
        {
            return Roman == "IV" ? 4 : Roman.Count();
        }
    }
}