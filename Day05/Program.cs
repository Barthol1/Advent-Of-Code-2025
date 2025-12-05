var input = File.ReadAllLines("input.txt").ToArray();
int seperatorIndex = Array.IndexOf(input, "");

var ranges = input.Take(seperatorIndex).ToArray();
var values = input.Skip(seperatorIndex + 1).ToArray();

HashSet<long> result = [];
foreach(string value in values)
{
    var intValue = long.Parse(value);
    if (result.Contains(intValue)) continue;

    foreach(string range in ranges)
    {        
        if(intValue >= long.Parse(range.Split('-')[0]) && intValue <= long.Parse(range.Split('-')[1]))
        {
            result.Add(intValue);
            break;
        }
    }
}

Console.WriteLine(result.Count);