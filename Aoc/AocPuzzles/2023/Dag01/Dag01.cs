using AocPuzzles.PuzzleHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AocPuzzles._2023.Dag01;

public static class CharExtensions
{
    public static double ToNumeric(this char _char)
    {
        if (char.IsDigit(_char))
        {
            return char.GetNumericValue(_char);
        }
        throw new ArgumentException($"{_char} is not a digit");
    }

    internal class Dag01
    {
        [Test]
        public void Example()
        {
            var result = PuzzleFileReader
                .Read_lines("2023//Dag01//example.txt")
                .Sum(GetDigitsAndSumFirstAndLast);

            Assert.That(result, Is.EqualTo(142));
        }

        [Test]
        public void Example_part2()
        {
            var result = PuzzleFileReader
                .Read_lines("2023//Dag01//example_part2.txt")
                .Sum(GetDigitsWithPhonetics);

            Assert.That(result, Is.EqualTo(281));
        }

        [Test]
        public void Puzzle()
        {
            var result = PuzzleFileReader
                .Read_lines("2023//Dag01//puzzle.txt")
                .Sum(GetDigitsAndSumFirstAndLast);

            Assert.That(result, Is.EqualTo(53651));
        }

        [Test]
        public void Puzzle_part2()
        {
            var result = PuzzleFileReader
                .Read_lines("2023//Dag01//puzzle.txt")
                .Sum(GetDigitsWithPhonetics);

            Assert.That(result, Is.EqualTo(53894));
        }

        private static int GetDigitsAndSumFirstAndLast(string input)
        {
            var digits = input.Where(c => char.IsDigit(c));
            var added = new string(new char[] { digits.First() , digits.Last()});
            return int.Parse(added);
        }

        public record Alias(string Name, char Value);

        private static readonly IEnumerable<Alias> NumberAlias = new[]
        {
            new Alias("ONE",'1'),
            new Alias("TWO",'2'),
            new Alias("THREE",'3'),
            new Alias("FOUR",'4'),
            new Alias("FIVE",'5'),
            new Alias("SIX",'6'),
            new Alias("SEVEN",'7'),
            new Alias("EIGHT",'8'),
            new Alias("NINE",'9'),
        };

        private record NumberIndex(int index, char value);

        private static int GetDigitsWithPhonetics(string input)
        {
            var upper = input.ToUpper();

            var indices = new List<NumberIndex>();
            foreach (var alias in NumberAlias)
            {
                var firstIndex = upper.IndexOf(alias.Name);
                var lastIndex = upper.LastIndexOf(alias.Name);
                if (firstIndex > -1)
                {
                    indices.Add(new NumberIndex(firstIndex, alias.Value));
                }

                if (lastIndex > -1 && firstIndex != lastIndex)
                {
                    indices.Add(new NumberIndex(lastIndex, alias.Value));
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                var field = input[i];
                if (char.IsDigit(field))
                {
                    indices.Add(new NumberIndex(i, field));
                }
            }

            var ordered = indices.OrderBy(x => x.index);

            var added = new string(new char[] { ordered.First().value, ordered.Last().value });
            return int.Parse(added);
        }
    }
}
