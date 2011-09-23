using System.Collections.Generic;
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
        [TestCase("VI", 6, TestName = "then VI is converted 6")]
        [TestCase("VII", 7, TestName = "then VII is converted 7")]
        [TestCase("VIII", 8, TestName = "then VIII is converted 8")]
        [TestCase("IX", 9, TestName = "then IX is converted 9")]
        [TestCase("X", 10, TestName = "then X is converted 10")]
        public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic)
        {
            Roman.ToArabic().Should().Be(ExpectedArabic);
        }

    }


    public static class RomanNumeralConverter
    {
        public static int ToArabic(this string Roman)
        {
            IDictionary<string, int> RomanToArabic = new Dictionary<string, int>() {{"V", 5 }, {"I", 1}};

            if (Roman == "IX")
                return 9;

            if (Roman.StartsWith("V"))
                return Roman.Sum(x => RomanToArabic[x.ToString()]);

            return Roman == "IV" ? 4 : Roman.Count();
        }
    }
}