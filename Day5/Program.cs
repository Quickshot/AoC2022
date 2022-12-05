using Day5;

Console.WriteLine("Day 5: Supply Stacks");
if (args.Length != 1)
{
    Console.WriteLine($"Wrong number of args. Expected 1, got {args.Length}");
    Console.WriteLine("Args should only contain path to the input file.");
    return;
}

var result = Stacks.PlayInstructions(args[0]);

Console.WriteLine($"The top crates are {result}");

result = Stacks.PlayInstructionsOrdered(args[0]);

Console.WriteLine($"The top crates are {result} when using ordered movements");