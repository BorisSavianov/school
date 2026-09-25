Item[] items = new Item[]
{
    new Item("Laptop", 3, 2000),
    new Item("Camera", 1, 800),
    new Item("Water bottle", 1, 10),
    new Item("Tent", 5, 300),
    new Item("Sleeping bag", 2, 150),
    new Item("Books", 4, 60),
    new Item("Headphones", 0.5, 200)
};

double capacity = 10;

Console.Clear();

List<Item> selectedItems = new();
double remainingCapacity = capacity;
double totalValue = 0;

foreach (Item item in items.OrderByDescending(i => i.ValuePerKG()))
{
    if (item.Weight <= remainingCapacity)
    {
        selectedItems.Add(item);
        remainingCapacity -= item.Weight;
        totalValue += item.Value;
    }
}

Console.WriteLine("Selected items:");

foreach (Item item in selectedItems)
{
    Console.WriteLine($"{item.Name}: weight {item.Weight}, value {item.Value}");
}
Console.WriteLine();
Console.WriteLine($"Total weight: {capacity - remainingCapacity} / {capacity}");
Console.WriteLine($"Total value: {totalValue}");


public class Item
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Value { get; set; }

    public double ValuePerKG()
    {
        return Value / Weight;
    }

    public Item(string name, double weight, double value)
    {
        Name = name;
        Weight = weight;
        Value = value;
    }
}
