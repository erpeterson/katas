using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class RomanNumeralTests
    {
        [Test]
        [TestCase("i", 1)]
        [TestCase("ii", 2)]
        [TestCase("iv", 4)]
        [TestCase("v", 5)]
        public void ConvertNumeralToArabic(string numeral, int expectedNumber)
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
            var rules = new IRule[] {new IRules(), new VRules() };
            var numbers = new Queue<int>();

            foreach (var letter in numeral.ToCharArray())
            {
                var rule = rules.FirstOrDefault(x => x.CanHandle(letter));
                if (rule != null)
                {
                    numbers.Enqueue(rule.GetNumber());
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            var total = 0;
            while (numbers.Any())
            {
                var number = numbers.Dequeue();


                if (numbers.Any() && numbers.Peek() == 5)
                {
                    total += 4;
                    numbers.Dequeue();
                }
                else
                {
                    total += number;
                }
                
            }

            return total;
        }

        private class IRules : IRule
        {
            public bool CanHandle(char letter)
            {
                return letter == 'i';
            }

            public int GetNumber()
            {
                return 1;
            }
        }
    }

    public class VRules : IRule
    {
        public bool CanHandle(char letter)
        {
            return letter == 'v';
        }

        public int GetNumber()
        {
            return 5;
        }
    }

    internal interface IRule
    {
        bool CanHandle(char letter);
        int GetNumber();
    }
}