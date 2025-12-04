var lines = File.ReadLines("input.txt");

var result = 0;

foreach (var line in lines)
{
    var currentLargest = 0;
    //for each character in the line
    for (int i = 0; i < line.Length; i++)
    {
        //for each character in the line again, to match with the other current character
        for (int j = i; j < line.Length; j++)
        {
            //the number can't match with itself
            if(i != j)
            {
                int number = int.Parse(String.Concat(line[i], line[j]));
                if (number > currentLargest) currentLargest=number;
            }
        }
    }
    result+=currentLargest;
}

Console.WriteLine(result);