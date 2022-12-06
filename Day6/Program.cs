using Day6;

Console.WriteLine("Day 6: Tuning Trouble");
if (args.Length != 1)
{
    Console.WriteLine($"Wrong number of args. Expected 1, got {args.Length}");
    Console.WriteLine("Args should only contain path to the input file.");
    return;
}

var data = File.ReadLines(args[0]).First();

var result = Tuning.FindFirstMarker(data);

Console.WriteLine($"First packet marker found at character number {result}");

result = Tuning.FindFirstMessageMarker(data);

Console.WriteLine($"First message marker found at character number {result}");

