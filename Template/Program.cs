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

void Solve(string inputPath)
{
    var items = Load(inputPath);
}

Solve("ex.txt");
// Solve("input.txt");
