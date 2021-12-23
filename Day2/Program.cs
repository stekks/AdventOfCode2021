using System.Text;

List<(string, int)> Load(string inputPath)
{
    var fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
    var list = new List<(string, int)>();
    using(var sr = new StreamReader(fs, Encoding.UTF8))
    {
        string? l;
        while((l = sr.ReadLine()) != null)
        {
            var dir = l.Split(" ");
            int.TryParse(dir[1], out var i);
            list.Add((dir[0], i));
        }
    }

    return list;
}

void SolveA(string inputPath)
{
    var items = Load(inputPath);
    int x = 0, y1 = 0, y2 = 0, a = 0;
    foreach(var i in items)
    {
        switch (i.Item1)
        {
            case "forward": 
                x += i.Item2;
                y2 += i.Item2 * a;
                break;
            case "down":
                y1 -= i.Item2;
                a += i.Item2;
                break;
            case "up":
                y1 += i.Item2;
                a -= i.Item2;
                break;
            default:
                throw new Exception();
        }
    }
    
    Console.WriteLine($"Part A: {Math.Abs(x) * Math.Abs(y1)}");
    Console.WriteLine($"Part A: {Math.Abs(x) * Math.Abs(y2)}");
}

SolveA("ex.txt");
SolveA("input.txt");
