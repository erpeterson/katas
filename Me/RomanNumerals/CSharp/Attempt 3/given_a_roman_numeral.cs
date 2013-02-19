using FluentAssertions;
using NUnit.Framework;

namespace CSharp.AttemptThree {
  [TestFixture]
  public class given_a_roman_numeral {
    [TestCase("", 0, TestName = "then '' is converted to 0")]
    [TestCase("I", 1, TestName = "then I is converted to 1")]
    public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic) {
      Roman.ToArabic().Should().Be(ExpectedArabic);
    }
  }

  public static class RomanNumeralConverter {   
    public static int ToArabic(this string Roman) {
      return 0;
    }
  }
}