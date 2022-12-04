namespace Day4;

public static class Cleanup
{
    public static int AssignmentFullyContains(string path)
    {
        return File
            .ReadLines(path)
            .Select(l => l.Trim().Split('-', ','))
            .Select(l => new ElfPair(new ElfAssignment(int.Parse(l[0]), int.Parse(l[1])),
                new ElfAssignment(int.Parse(l[2]), int.Parse(l[3]))))
            .Count(pair => (pair.first.min <= pair.second.min && pair.first.max >= pair.second.max)
                           || (pair.second.min <= pair.first.min && pair.second.max >= pair.first.max));
    }
    
    public static int AssignmentOverlaps(string path)
    {
        return File
            .ReadLines(path)
            .Select(l => l.Trim().Split('-', ','))
            .Select(l => new ElfPair(new ElfAssignment(int.Parse(l[0]), int.Parse(l[1])),
                new ElfAssignment(int.Parse(l[2]), int.Parse(l[3]))))
            .Count(pair => (pair.first.min <= pair.second.min && pair.first.max >= pair.second.max) // Contains
                           || (pair.second.min <= pair.first.min && pair.second.max >= pair.first.max) // Contains
                           || (pair.first.max >= pair.second.min && pair.first.min < pair.second.min) // Overlaps
                           || (pair.second.max >= pair.first.min && pair.second.min < pair.first.min)); // Overlaps
    }
}