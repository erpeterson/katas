using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CSharp {
  [TestFixture]
  public class given_a_roman_numeral {
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
    [TestCase("XI", 11, TestName = "then XI is converted 11")]
    [TestCase("XII", 12, TestName = "then XII is converted 12")]
    [TestCase("XIII", 13, TestName = "then XIII is converted 13")]
    [TestCase("XIV", 14, TestName = "then XIV is converted 14")]
    [TestCase("XV", 15, TestName = "then XV is converted 15")]
    [TestCase("XL", 40, TestName = "then XL is converted 40")]
    [TestCase("L", 50, TestName = "then L is converted 50")]
    [TestCase("XC", 90, TestName = "then XC is converted 90")]
    [TestCase("C", 100, TestName = "then C is converted 100")]
    [TestCase("CCCLXIX", 369, TestName = "then CCCLXIX is converted 369")]
    public void when_converting_it_to_an_arabic_numeral(string Roman, int ExpectedArabic) {
      Roman.ToArabic().Should().Be(ExpectedArabic);
    }
  }

  public static class RomanNumeralConverter {
    public static int ToArabic(this string Roman) {
      IDictionary<string, int> SimpleNumerals = new Dictionary<string, int> {{"I", 1}, {"V", 5}, {"X", 10}, {"L", 50}, {"C", 100}};
      IDictionary<string, int> CompoundNumerals = new Dictionary<string, int> {{"IV", 4}, {"IX", 9}, {"XL", 40}, {"XC", 90}};

      var Total = 0;
      while (Roman.Length > 0) {
        var MatchingKey = string.Empty;
        if (CompoundNumerals.Any(x => Roman.StartsWith(MatchingKey = x.Key))) {
          Total += CompoundNumerals[MatchingKey];
          Roman = Roman.Remove(0, 2);
        }
        else {
          Total += SimpleNumerals[Roman.First().ToString(CultureInfo.InvariantCulture)];
          Roman = Roman.Remove(0, 1);
        }
      }

      return Total;
    }
  }
}