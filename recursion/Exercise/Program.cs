// int n = int.Parse(Console.ReadLine());
// List<int> kids = Console.ReadLine().Split().Select(int.Parse).ToList();
// int sweets = int.Parse(Console.ReadLine());

// System.Console.WriteLine(GreedyRaspredelation(n, kids, sweets));

// NOVA ZADACHA - RESHENA

string[] words = ["blue", "red", "green", "yellow", "purple"];
List<string> permutation = new();
GeneratePermutations(words, permutation);

List<List<object>> sweets = new List<List<object>>()
        {
            new List<object> { "ореховки", 6 },
            new List<object> { "масленка", 5 },
            new List<object> { "меденки", 8 },
            new List<object> { "сусамки", 3 }
        };

GreedyRaspredelation2(sweets);

void GreedyRaspredelation2(List<List<object>> sweets)
{
    sweets.Sort((x, y) => ((int)x[1]).CompareTo((int)y[1]));

    foreach (var desert in sweets)
    {
            Console.WriteLine($"{desert[0]} - {desert[1]} бр.");
    }

    
}


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