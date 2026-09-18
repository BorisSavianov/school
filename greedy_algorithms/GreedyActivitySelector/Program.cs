using System;
using System.Collections.Generic;
using System.Linq;

class Activity
{
    public string Name { get; set; }
    public int Start { get; set; }
    public int End { get; set; }

    public Activity(string name, int start, int end)
    {
        Name = name;
        Start = start;
        End = end;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Activity> activities = new List<Activity>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = input[0];
            int start = int.Parse(input[1]);
            int end = int.Parse(input[2]);

            activities.Add(new Activity(name, start, end));
        }

        activities = activities
            .OrderBy(a => a.End)
            .ToList();

        List<Activity> selectedActivities = new List<Activity>();

        if (activities.Count > 0)
        {
            selectedActivities.Add(activities[0]);
            int lastEndTime = activities[0].End;

            for (int i = 1; i < activities.Count; i++)
            {
                if (activities[i].Start >= lastEndTime)
                {
                    selectedActivities.Add(activities[i]);
                    lastEndTime = activities[i].End;
                }
            }
        }

        Console.WriteLine(selectedActivities.Count);

        foreach (Activity activity in selectedActivities)
        {
            Console.WriteLine($"{activity.Name} {activity.Start} {activity.End}");
        }
    }
}