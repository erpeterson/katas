using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp.AttemptThree {
  [TestFixture]
  public class given_a_roman_numeral {
    [TestCase("I", 1, TestName = "then I is converted to 1")]
    [TestCase("II", 2, TestName = "then II is converted to 2")]
    [TestCase("III", 3, TestName = "then III is converted to 3")]
    [TestCase("IV", 4, TestName = "then IV is converted to 4")]
    [TestCase("V", 5, TestName = "then V is converted to 5")]
    [TestCase("VI", 6, TestName = "then VI is converted to 6")]
    [TestCase("VII", 7, TestName = "then VII is converted to 7")]
    [TestCase("VIII", 8, TestName = "then VIII is converted to 8")]
    [TestCase("IX", 9, TestName = "then IX is converted to 9")]
    [TestCase("X", 10, TestName = "then X is converted to 10")]
    [TestCase("XI", 11, TestName = "then XI is converted to 11")]
    [TestCase("XII", 12, TestName = "then XII is converted to 12")]
    [TestCase("XIII", 13, TestName = "then XIII is converted to 13")]
    [TestCase("XIV", 14, TestName = "then XIV is converted to 14")]
    [TestCase("XV", 15, TestName = "then XV is converted to 15")]
    [TestCase("XL", 40, TestName = "then XL is converted to 40")]
    [TestCase("L", 50, TestName = "then L is converted to 50")]
    [TestCase("XC", 90, TestName = "then XC is converted to 90")]
    [TestCase("C", 100, TestName = "then C is converted to 100")]
    [TestCase("CCCLXIX", 369, TestName = "then CCCLXIX is converted to 369")]
    [TestCase("CD", 400, TestName = "then CD is converted to 400")]
    [TestCase("D", 500, TestName = "then D is converted to 500")]
    [TestCase("CM", 900, TestName = "then CM is converted to 900")]
    [TestCase("M", 1000, TestName = "then M is converted to 1000")]
    [TestCase("MCMXCVIII", 1998, TestName = "then MCMXCVIII is converted to 1998")]
    public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic) {
      Roman.ToArabic().Should().Be(ExpectedArabic);
    }
  }

  public static class RomanNumeralConverter {
    static readonly IDictionary<string, int> Conversions
      = new Dictionary<string, int> {
        {"M", 1000}, {"CM", 900}, {"D", 500}, {"CD", 400}, 
        {"C", 100}, {"XC", 90}, {"L", 50}, {"XL", 40}, 
        {"X", 10}, {"IX", 9}, {"V", 5}, {"IV", 4}, {"I", 1}};

    public static int ToArabic(this string Roman) {      
      if (string.IsNullOrEmpty(Roman)) return 0;
      var Match = Conversions.First(x => Roman.StartsWith(x.Key));     
      return  Match.Value + Roman.Substring(Match.Key.Length).ToArabic();
    }
  }
}