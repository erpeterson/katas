using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp.AttemptThree {
  [TestFixture]
  public class given_a_roman_numeral {
    [TestCase("", 0, TestName = "then '' is converted to 0")]
    [TestCase("I", 1, TestName = "then I is converted to 1")]
    [TestCase("II", 2, TestName = "then II is converted to 2")]
    [TestCase("III", 3, TestName = "then III is converted to 3")]
    [TestCase("IV", 4, TestName = "then IV is converted to 4")]
    [TestCase("V", 5, TestName = "then V is converted to 5")]    
    public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic) {
      Roman.ToArabic().Should().Be(ExpectedArabic);
    }
  }

  public static class RomanNumeralConverter {   
    static readonly IDictionary<string, int> Conversions = new Dictionary<string, int>{{"V", 5}, {"IV", 4}, {"I", 1}};

    public static int ToArabic(this string Roman) {      
      if (string.IsNullOrEmpty(Roman)) return 0;
      var Match = Conversions.FirstOrDefault(x => x.Key.Equals(Roman));
      if (!string.IsNullOrEmpty(Match.Key)) return Match.Value;

      return  1 + Roman.Substring(1).ToArabic();
    }
  }
}