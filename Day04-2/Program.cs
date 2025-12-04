var input = File.ReadAllLines("input.txt");
// mutate to char array to allow mutability
char[][] grid = [.. input.Select(s => s.ToCharArray())];

var directions = new List<(int dx, int dy)>
{
    (-1, -1), // up-left
    (-1,  0), // left
    (-1,  1), // down-left
     (0, -1), // up
     (0,  1), // down
     (1, -1), // up-right
     (1,  0), // right
     (1,  1)  // down-right
};

List<(int x, int y)> calculatePositions((int x, int y) position, int cols, int rows, char[][] map)
{
    List<(int x, int y)> result = [];
    foreach(var direction in directions)
    {
        var nX = direction.dx + position.x;
        var nY = direction.dy + position.y;

        if(nX >= 0 && nX < cols && nY >= 0 && nY < rows)
        {
            if(map[nY][nX] == '@') result.Add((nX, nY));
        }
    }
    return result;
}

long totalRemovedRolls = 0;
bool removalsMadeInPass = true;

while (removalsMadeInPass)
{
    removalsMadeInPass = false;
    
    List<(int x, int y)> removablePositions = new List<(int x, int y)>();

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == '@')
            {
                int neighborCount = calculatePositions((j, i), grid[i].Length, grid.Length, grid).Count;
                if (neighborCount < 4)
                {
                    removablePositions.Add((j, i));
                }
            }
        }
    }

    if (removablePositions.Count > 0)
    {
        foreach (var position in removablePositions)
        {
            grid[position.y][position.x] = 'x'; 
        }

        totalRemovedRolls += removablePositions.Count;
        removalsMadeInPass = true;
    }
}

Console.WriteLine(totalRemovedRolls);