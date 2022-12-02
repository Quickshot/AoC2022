namespace Day1;

public static class ElfCalories
{
    public static int Run(string inputPath)
    {
        return ParseInput(inputPath).Select(elf => elf.Calories.Sum()).Max();
    }

    public static int Top3TotalCalories(string path)
    {
        return ParseInput(path).Select(elf => elf.Calories.Sum()).OrderDescending().Take(3).Sum();
    }

    private static Elf[] ParseInput(string path)
    {
        var lines = File.ReadAllLines(path);
        var elves = new List<Elf>();

        var allCalories = new List<int>();
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrEmpty(trimmedLine))
            {
                // Found separator entry
                if (allCalories.Count != 0)
                {
                    // Create new elf entry if there are any calories listed
                    elves.Add(new Elf(allCalories.ToArray()));
                    allCalories = new List<int>();
                }

                continue;
            }

            var calories = int.Parse(trimmedLine);
            allCalories.Add(calories);
        }
        
        // If end is reached with allCalories having entries, create a new elf entry for it
        if (allCalories.Count != 0)
        {
            elves.Add(new Elf(allCalories.ToArray()));
        }

        return elves.ToArray();
    }
}