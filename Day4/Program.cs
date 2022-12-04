using Day4;

Console.WriteLine("Day 4: Camp Cleanup");
if (args.Length != 1)
{
    Console.WriteLine($"Wrong number of args. Expected 1, got {args.Length}");
    Console.WriteLine("Args should only contain path to the input file.");
    return;
}

var result = Cleanup.AssignmentFullyContains(args[0]);

Console.WriteLine($"There are {result} assignments that fully contains the other pair.");

result = Cleanup.AssignmentOverlaps(args[0]);

Console.WriteLine($"There are {result} assignments that overlaps with each other.");