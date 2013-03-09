using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class RomanNumeralTests
    {
         [Test]
         [TestCase("i", 1)]
         public void convertNumeralToArabic(string numeral, int expectedNumber)
         {
             var converter = new RomanNumeralConverter();

             var result = converter.ToArabic(numeral);

             Assert.That(result, Is.EqualTo(expectedNumber));
         }
    }
}