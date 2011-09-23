using System.Linq;
using FluentAssertions;
using NUnit.Framework;



namespace CSharp
{
    [TestFixture]
    public class given_a_roman_numeral
    {
        [TestCase("I", 1, TestName = "then I is converted to 1")]
        [TestCase("II", 2, TestName = "then II is converted to 2")]
        [TestCase("III", 3, TestName = "then III is converted to 3")]
        public void when_converting_to_an_arabic(string Roman, int ExpectedArabic)
        {
            Roman.ToArabic().Should().Be(ExpectedArabic);
        }
        
    }

    public static class RomanToArabicConverter
    {
        public static int ToArabic(this string Roman)
        {
            return Roman.Count();
        }
    }
}