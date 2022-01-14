using System.Text;

(List<ushort>, ushort) Load(string inputPath)
{
    var fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
    var list = new List<ushort>();
    ushort width = 0;
    using(var sr = new StreamReader(fs, Encoding.UTF8))
    {
        string? l;
        while ((l = sr.ReadLine()) != null)
        {
            list.Add(Convert.ToUInt16(l.Trim(), 2));
            width = width == 0 ? (ushort)l.Trim().Length : width;
        }
    }

    return (list, width);
}

static bool MatchMask(ushort i, ushort mask)
{
    return (i & mask) > 0;
}

void Solve(string inputPath)
{
    var (input, width) = Load(inputPath);
    var m = new int[width];
    ushort g = 0;
    ushort e = 0;
    ushort mask = 1;
    foreach (var i in input)
    {
        mask = 1;
        for (int j=0; j < width; j++)
        {
            if ((i & mask) > 0)
            {
                ++m[j];
            }

            mask <<= 1;
        }
    }

    var h = input.Count / 2;
    var o2 = new List<ushort>(input);
    var co2 = new List<ushort>(input);
    for (int i = (ushort)(width - 1); i >= 0; i--)
    {
        g <<= 1;
        e <<= 1;
        if (m[i] > h)
        {
            ++g;
        }
        else
        {
            ++e;
        }

        mask = (ushort)(1 << i);
        if (o2.Count > 1)
        {
            var match = o2.FindAll(f => MatchMask(f, mask));
            if (match.Count >= o2.Count - match.Count)
            {
                o2 = match;
            }
            else
            {
                o2 = o2.Except(match).ToList();
            }
        }

        if (co2.Count > 1)
        {
            var match = co2.FindAll(f => MatchMask(f, mask));
            if (match.Count >= co2.Count - match.Count)
            {
                co2 = co2.Except(match).ToList();
            }
            else
            {
                co2 = match;
            }
        }
    }

    Console.WriteLine($"Part a: e={e} g={g} g*e={g*e}");
    Console.WriteLine($"Part b: o2={o2.FirstOrDefault()} co2={co2.FirstOrDefault()} o2*co2={o2.FirstOrDefault() * co2.FirstOrDefault()}");
}

//Solve("ex.txt");
Solve("input.txt");
