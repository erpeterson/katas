using System;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class RomanNumeralTests
    {
         [Test]
         [TestCase("i", 1)]
         [TestCase("v", 5)]
         public void convertNumeralToArabic(string numeral, int expectedNumber)
         {
             var converter = new RomanNumeralConverter();

             var result = converter.ToArabic(numeral);

             Assert.That(result, Is.EqualTo(expectedNumber));
         }
    }


    public class RomanNumeralConverter
    {
        public int ToArabic(string numeral)
        {
            switch (numeral)
            {
                case "i":
                    return 1;
                case "v":
                    return 5;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}