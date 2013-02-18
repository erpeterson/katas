using FluentAssertions;
using NUnit.Framework;

namespace CSharp.AttemptTwo {
  [TestFixture]
  public class given_a_roman_numeral {
    [TestCase("I", 1, TestName = "then I is converted to 1")]
    [TestCase("IV", 4, TestName = "then IV is converted to 4")]
    public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic) {
      Roman.ToArabic().Should().Be(ExpectedArabic);
    }
  }

  public static class RomanNumeralConverter {
    public static int ToArabic(this string Roman) {
      return Roman == "I" ? 1 : 4;
    }
  }
}