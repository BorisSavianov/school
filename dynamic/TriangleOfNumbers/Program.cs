int[,] d =
{
    { 0, 7, 0, 0, 0, 0 },
    { 0, 3, 8, 0, 0, 0 },
    { 0, 8, 1, 0, 0, 0 },
    { 0, 2, 7, 4, 4, 0 },
    { 0, 4, 5, 2, 6, 5 }
};

int n = d.GetLength(0);
int[,] r = new int[n, n + 1];

r[0, 1] = d[0, 1];

for (int i = 1; i < n; i++)
{
    for (int j = 1; j <= i + 1; j++)
    {
        r[i, j] = d[i, j] + Math.Max(r[i - 1, j - 1], r[i - 1, j]);
    }
}

int best = 0;

for (int j = 1; j <= n; j++)
{
    best = Math.Max(best, r[n - 1, j]);
}

Console.WriteLine(best);
