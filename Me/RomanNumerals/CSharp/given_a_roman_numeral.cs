﻿using System.Globalization;
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
    [TestCase("CD", 400, TestName = "then CD is converted 400")]
    [TestCase("D", 500, TestName = "then D is converted 500")]
    [TestCase("CM", 900, TestName = "then CM is converted 900")]
    [TestCase("M", 1000, TestName = "then M is converted 1000")]
    [TestCase("MCMXCVIII", 1998, TestName = "then MCMXCVIII is converted 1998")]
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
      var Value = 0;
      if (Roman.Length == 0) return Value;
            
      var MatchingKey = string.Empty;
      if (Conversions.Any(x => Roman.StartsWith(MatchingKey = x.Key))) {
        Value = Conversions[MatchingKey] + Roman.Remove(0, MatchingKey.Length).ToArabic();          
      }
        
      return Value;            
    }
  }
}