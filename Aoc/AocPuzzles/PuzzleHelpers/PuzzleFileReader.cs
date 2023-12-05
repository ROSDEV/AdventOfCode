using System.Collections.Generic;
using System.IO;

namespace AocPuzzles.PuzzleHelpers;

internal static class PuzzleFileReader
{
    public static IEnumerable<string> Read_lines(string file) => File.ReadAllLines(file);

    public static IEnumerable<int> Read_and_group_lines(string file)
    {
        var groups = new List<int>();
        var sum = 0;
        foreach (var line in Read_lines(file))
        {
            if (string.IsNullOrEmpty(line))
            {
                //Next group
                groups.Add(sum);
                sum = 0;
                continue;
            }
            if (int.TryParse(line, out var value))
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
}
