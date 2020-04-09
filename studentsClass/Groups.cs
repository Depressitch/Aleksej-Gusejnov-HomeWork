using System;
using System.Collections.Generic;

public class Groups
{
    public List<Student> Group = new List<Student>();

    public void Menu()
    {
		GroupOperList();
		switch (Console.ReadLine().ToLower())
		{
			case "add":
				Group.Add(new Student());
				break;

            case "mng":
				Console.WriteLine("\nType name of student you want to manage or \"quit\" to quit:");
				ShowAllStudents();
				while (true)
				{
					string inStudent = Console.ReadLine();
					if (inStudent == "quit")
						break;
					else
					{
						int index = Group.FindIndex(item => item.TotalName == inStudent);
						if (index >= 0)
							Group[index].MenuS();
						else
							Console.WriteLine("There's no such student in this group. Type again:");
					}
				}
				break;

			case "showa":
				ShowAllMarks();
				break;

			case "showas":
                if (Group.Count == 0)
                    Console.WriteLine("There are currently no students in this group");
				ShowAllStudents();
				break;

			case "avrgg":
				float ?avg = AverageInGroup();
				if (avg == null)
				{
					Console.WriteLine("There are no marks to count");
				}
				else
					Console.WriteLine($"Average mark in the group is {AverageInGroup():#.##}");
				break;

			case "clear":
				Console.Clear();
				break;

			case "operations":
				GroupOperList();
				break;

			case "quit":
				return;

			default:
				Console.Write("Incorrect input. ");
				break;
		}
		Menu();
	}
    public void ShowAllStudents()
    {
        foreach (var student in Group)
        {
            Console.WriteLine(student.TotalName);
        }
    }
    public float AverageInGroup()
    {
        int sum = 0;
        int i = 0;
        foreach (var student in Group)
        {
            foreach (int mark in student)
            {
                    sum += mark;
                    i++;
            }
        }
        return sum / i;
    }
    public void ShowAllMarks()
    {
		if (Group.Count > 0)
			foreach (var student in Group)
			{
				student.ShowMarks();
			}
		else
			Console.WriteLine("There are no students in this group");
    }
    public void GroupOperList()
    {
        Console.WriteLine($"\nChoose an operation for this group:\n" +
                    "\nAdd - add a student" +
                    "\nShowA - show marks of all students" +
					"\nShowAS - show list of all students" +
					"\nAvrgG - show an average mark of all students" +
                    "\nClear - clear console window" +
                    "\nOperations - show list of operations" +
                    "\nQuit - quit, obviously\n"
                    );
    }
}