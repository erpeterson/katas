using FluentAssertions;
using NUnit.Framework;



namespace CSharp
{
    [TestFixture]
    public class given_a_roman_numeral
    {
        [TestCase("I", 1, TestName = "then I is converted to 1")]
        public void when_converting_to_an_arabic(string Roman, int ExpectedArabic)
        {
            Roman.ToArabic().Should().Be(ExpectedArabic);
        }

    }


    public static class RomanToArabicConverter
    {
        public static int ToArabic(this string Romain)
        {
            return 0;
        }
    }
}
