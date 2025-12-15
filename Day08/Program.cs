// We need to determine the distance between every possible pair of junction boxes
// Then order the results from closest to longest distance and start connecting

// RESULT
// The result is the size of each group multiplied by eachother

var file = File.ReadAllLines("input.txt");
var union = new UnionFind(file.Length);

var coords = new List<Coords>();
var connections = new List<Connection>();

foreach(var line in file)
{
    // Parse the file into coordinates
    coords.Add(new Coords() {X = int.Parse(line.Split(',')[0]), Y = int.Parse(line.Split(',')[1]), Z = int.Parse(line.Split(',')[2])});
}

for (int i = 0; i < coords.Count; i++)
{
    for (int j = i + 1; j < coords.Count; j++)
    {
        connections.Add(new Connection() {Index1 = i, Index2 = j, distance = calculateDistance(coords[i], coords[j])});
    }
}

connections = connections.OrderBy(c => c.distance).Take(1000).ToList();

foreach(var connection in connections)
{
    int root1 = union.Find(connection.Index1);
    int root2 = union.Find(connection.Index2);

    //If they aren't already merged
    if(root1 != root2)
    {
        union.Union(root1, root2);
    }
}

var sizes = union.GetCircuitSizes().OrderByDescending(s => s).ToList();

long result = 1;
for (int i = 0; i < 3; i++)
{
    result*=sizes[i];
}

Console.WriteLine(result);

// UTILS

double calculateDistance(Coords a, Coords b)
{
    return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
}

public struct Connection
{
    public int Index1 {get; set;}
    public int Index2 {get; set;}
    public double distance {get; set;}
}
public struct Coords
{
    public int X {get; set;}
    public int Y {get; set;}
    public int Z {get; set;}
}
public class UnionFind
{
    private int[] parentIds;
    private int[] size;

    public UnionFind(int count)
    {
        parentIds = new int[count];
        size = new int[count];
        for(int i = 0; i < count; i++)
        {
            parentIds[i] = i;
            size[i] = 1;
        }
    }

    // Find the "root" of id i
    public int Find(int i)
    {
        if (parentIds[i] == i)
        {
            return i;
        }

        return parentIds[i] = Find(parentIds[i]); 
    }

    // Connect 2 ids to the same root
    public void Union(int i, int j)
    {
        int rootI = Find(i);
        int rootJ = Find(j);

        if (rootI != rootJ)
        {
            if (size[rootI] < size[rootJ])
            {
                parentIds[rootI] = rootJ;
                size[rootJ] += size[rootI];
            }
            else
            {
                parentIds[rootJ] = rootI;
                size[rootI] += size[rootJ];
            }
        }
    }

    public List<int> GetCircuitSizes()
    {
        var circuitSizes = new List<int>();
        for (int i = 0; i < parentIds.Length; i++)
        {
            if (parentIds[i] == i)
            {
                circuitSizes.Add(size[i]);
            }
        }
        return circuitSizes;
    }
}

