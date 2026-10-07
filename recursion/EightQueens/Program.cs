const int N = 8;

int[] col = new int[N];
int count = 0;
Place(0);
Console.WriteLine(count);

void Place(int row)
{
    if (row == N)
    {
        count++;
        for (int r = 0; r < N; r++)
            Console.WriteLine(string.Concat(Enumerable.Range(0, N).Select(c => c == col[r] ? 'Q' : '.')));
        Console.WriteLine();
        return;
    }

    for (int c = 0; c < N; c++)
    {
        if (IsSafe(row, c))
        {
            col[row] = c;
            Place(row + 1);
        }
    }
}

bool IsSafe(int row, int c)
{
    for (int r = 0; r < row; r++)
        if (col[r] == c || Math.Abs(col[r] - c) == row - r)
            return false;
    return true;
}


