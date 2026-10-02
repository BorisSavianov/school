int n = int.Parse(Console.ReadLine()!);
string[] names = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
int k = int.Parse(Console.ReadLine()!);

string[] team = new string[k];
Choose(0, 0);
return 0;

void Choose(int start, int count)
{
    if (count == k)
    {
        Console.WriteLine(string.Join(" ", team));
        return;
    }

    for (int i = start; i < n; i++)
    {
        team[count] = names[i];
        Choose(i + 1, count + 1);
    }
}
