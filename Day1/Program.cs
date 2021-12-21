using System.Text;

List<int> Load(string inputPath)
{
    var fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
    var list = new List<int>();
    using(var sr = new StreamReader(fs, Encoding.UTF8))
    {
        string l;
        while((l = sr.ReadLine()) != null)
        {
            int.TryParse(l, out var i);
            list.Add(i);
        }
    }

    return list;
}

void Solve(string inputPath, int step)
{
    var items = Load(inputPath);
    var t = 0;
    for (var i = 0; i < items.Count - step;  i++)
    {
        if (items[i] < items[i + step])
        {
            t++;
        }
    }

    Console.WriteLine(t);
}

Solve("input.txt", 1);
Solve("input.txt", 3);
