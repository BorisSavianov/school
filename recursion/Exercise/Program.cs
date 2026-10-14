// int n = int.Parse(Console.ReadLine());
// List<int> kids = Console.ReadLine().Split().Select(int.Parse).ToList();
// int sweets = int.Parse(Console.ReadLine());

// System.Console.WriteLine(GreedyRaspredelation(n, kids, sweets));

// NOVA ZADACHA - RESHENA

string[] words = ["blue", "red", "green", "yellow", "purple"];
List<string> permutation = new();
GeneratePermutations(words, permutation);




int GreedyRaspredelation(int n, List<int> kids, int sweets)
{
    int numOfKids = 0;
    kids.Sort();

    foreach (int greed in kids)
    {
        if(greed <= sweets)
        {
            numOfKids++;
            sweets -= greed;
        } else
        {
            break;
        }
    }

    return numOfKids;
}

void GeneratePermutations(string[] words, List<string> permutation, bool[] used = null)
{
    used ??= new bool[words.Length]; 

    if (permutation.Count == words.Length)
    {
        foreach (string perm in permutation)
        {
            Console.Write(perm + " ");
        }
        Console.WriteLine();
        return;
    }

    for(int i = words.Length - 1; i >= 0; i--)
    {
        if (!used[i])
        {
            permutation.Add(words[i]);
            used[i] = true;
            GeneratePermutations(words, permutation, used);
            permutation.RemoveAt(permutation.Count - 1);
            used[i] = false;
        }
    }
}