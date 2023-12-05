using AocPuzzles.PuzzleHelpers;
using NUnit.Framework;
using System.Linq;

namespace AocPuzzles._2022.Dag1;

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
}
