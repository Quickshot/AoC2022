using System.Collections;

namespace Day3;

public static class RucksackSorter
{
    public static int FindCommonPriority(string path)
    {
        return ParseInput(path)
            .Select(rucksack => rucksack.compartment1.Intersect(rucksack.compartment2).FirstOrDefault(' '))
            .GetItemPriority()
            .Sum();
    }
    
    public static int FindGroupPriority(string path)
    {
        return ParseInput(path)
            .Select((rucksack, index) => new {rucksack, index})
            .GroupBy(g => g.index/3, r => r.rucksack)
            .Select(rg => rg.Select(r => r.allItems).GetCommonItemsInGroup())
            .GetItemPriority()
            .Sum();
    }

    private static Rucksack[] ParseInput(string path)
    {
        var lines = File.ReadAllLines(path);
        var rucksacks = new List<Rucksack>();

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrEmpty(trimmedLine))
            {
                // Skip line if empty
                continue;
            }

            var cont1 = trimmedLine[..(trimmedLine.Length / 2)];
            var cont2 = trimmedLine[(trimmedLine.Length / 2)..];
            rucksacks.Add(new Rucksack(trimmedLine, cont1, cont2));
        }

        return rucksacks.ToArray();
    }

    private static char GetCommonItemsInGroup(this IEnumerable<string> rucksacks)
    {
        var common = rucksacks.First().Select(c => c);
        foreach (var rucksack in rucksacks)
        {
            common = rucksack.Intersect(common);
        }

        return common.FirstOrDefault(' ');
    }

    private static IEnumerable<int> GetItemPriority(this IEnumerable<char> items)
    {
        foreach (var item in items)
        {
            var value = Convert.ToInt32(item);
            if (value < 97)
            {
                // Uppercase letter
                value = value - 38;
            }
            else
            {
                // Lowercase letter
                value = value - 96;
            }

            yield return value;
        }
    }
}