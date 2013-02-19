using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp.AttemptTwo {
  [TestFixture]
  public class given_a_roman_numeral {
    [TestCase("I", 1, TestName = "then I is converted to 1")]
    [TestCase("II", 2, TestName = "then II is converted to 2")]
    [TestCase("III", 3, TestName = "then III is converted to 3")]
    [TestCase("IV", 4, TestName = "then IV is converted to 4")]
    [TestCase("V", 5, TestName = "then V is converted to 5")]
    [TestCase("VI", 6, TestName = "then VI is converted to 6")]
    [TestCase("IX", 9, TestName = "then IX is converted to 9")]
    public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic) {
      Roman.ToArabic().Should().Be(ExpectedArabic);
    }
  }

  public static class RomanNumeralConverter {
    static readonly IDictionary<string, int> Conversions 
      = new Dictionary<string, int> { { "IX", 9 }, { "V", 5 }, { "IV", 4 }, { "I", 1 } };
   
    public static int ToArabic(this string Roman) {
      if (string.IsNullOrEmpty(Roman)) return 0;
      var Match = Conversions.FirstOrDefault(x => Roman.StartsWith(x.Key));

      return Match.Value + Roman.Substring(Match.Key.Length).ToArabic();
    }
  }
}