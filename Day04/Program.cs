var input = File.ReadAllLines("input.txt");

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

List<(int x, int y)> calculatePositions((int x, int y) position, int cols, int rows, string[] map)
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

List<(int x, int y)> resultpositions = [];

for(int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        if(input[i][j] == '@')
        {
            var positions = calculatePositions((j, i), input[i].Length, input.Length, input);
            if (positions.Count < 4)
            {
                resultpositions.Add((j, i));
            }
        }
    }
}

Console.WriteLine(resultpositions.Count);