string[] lines = File.ReadAllLines("input.txt");

const int RANGE = 100;

int calculateNumber(int value, int delta, int range)
{
    return ((value + delta) % range + range) % range;
}

int currentPosition = 50;
int amountOfZeros = 0;
foreach(string line in lines)
{
    var direction = line[..1];
    var amount = Int32.Parse(line[1..]);

    Console.WriteLine(direction, amount);

    if(direction == "L")
    {
        amount *= -1;
    }

    currentPosition = calculateNumber(currentPosition, amount, RANGE);
    Console.WriteLine(currentPosition);
    if(currentPosition == 0) amountOfZeros+=1;
}

Console.WriteLine(amountOfZeros);