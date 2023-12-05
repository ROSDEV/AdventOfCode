using AocPuzzles.PuzzleHelpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AocPuzzles._2022.Dag2;

internal class Dag2
{
    [Test]
    public void example()
    {
        Assert.That(PuzzleFileReader.Read_and_group_lines("2022//Dag1//example.txt").Max(), Is.EqualTo(24000));
    }

    [Test]
    public void puzzle_part1()
    {
        Assert
            .That(PuzzleFileReader.Read_and_group_lines("2022//Dag1//puzzle.txt")
            .Max(), Is.EqualTo(71502));
    }

    [Test]
    public void puzzle_part2()
    {
        Assert
            .That(PuzzleFileReader.Read_and_group_lines("2022//Dag1//puzzle.txt")
            .OrderByDescending(x => x)
            .Take(3).Sum(),Is.EqualTo(208191));
    }

    public static class Score
    {
        private static Dictionary<char,int> pairs = new Dictionary<char, int>
        {
            {'A', 1},
            {'B', 1},
            {'C', 1},
            {'Y', 1},
            {'X', 1},
            {'Z', 1},
        };
        public static int Parse(char character)
        {
            if(pairs.TryGetValue(character, out int result))
            {
                return result;
            }
            return 0;
        }
    }

    /*
    public IEnumerable<int> read_and_group_lines(string file)
    {
        foreach (var round in read_lines(file))
        {
            var

            if(string.IsNullOrEmpty(line))
            {
                //Next group
                groups.Add(sum);
                sum = 0;
                continue;
            }
            if(int.TryParse(line, out var value))
            {
                //Add value
                sum += value;
            }
        }
        if (sum > 0)
        {
            //Add remainder if any
            groups.Add(sum);
        }

        return groups;
    }

    public string[] read_lines(string file)
    {
        return File.ReadAllLines(file);
    }
    */
}
