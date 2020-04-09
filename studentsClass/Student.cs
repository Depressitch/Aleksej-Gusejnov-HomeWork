using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Student : Groups
{
	public string TotalName;
	public Dictionary<string, List<int>> Marks = new Dictionary<string, List<int>>(); //словарь из оценок(оформлены списком), ключ к которым - название предмета

	public Student()
	{
		Console.WriteLine("Type student's name and surname: ");
		TotalName = Console.ReadLine();
		while (TotalName.Length == 0)
		{
			TotalName = Console.ReadLine();
		}

	}
	public IEnumerator GetEnumerator() //добавляет возможность использовать Student в foreach
	{
		foreach (var subject in Marks)
		{
			foreach (var mark in Marks[subject.Key])
			{
				yield return mark;
			}
		}
	}
	public void MenuS()
	{
		StudentOperList();
		switch (Console.ReadLine().ToLower())
		{
			case "add":
				ChangeSubject();
				break;

			case "change":
				ChangeMarks();
				break;

			case "show":
				ShowMarks();
				break;

			case "avrg":
				if (Marks.Count == 0) //если предметов нет, то ShowMarks() выведет об этом информацию
				{
					ShowMarks();
					break;
				}
				Console.WriteLine("\nChoose a subject to calculate it's average mark:");
				ShowMarks();
				string inSubject = Console.ReadLine().ToLower();
				if (!Marks.ContainsKey(inSubject))
					Console.WriteLine("There's no such subject added");
				else if (Marks[inSubject].Count == 0)
					Console.WriteLine("There are no marks added for this subject");
				else
					Console.WriteLine($"{TotalName}'s average mark in {inSubject} is {AverageMark(inSubject):#.##}");
				break;

			case "avrgt":
				if (Marks.Count == 0 || Marks.Values.Sum(list => list.Count) == 0)
					Console.WriteLine("There are no marks added to be calculated");
				else
					Console.WriteLine($"{TotalName}'s average mark in everything is {AverageTotal():#.##}");
				break;

			case "clear":
				Console.Clear();
				break;

			case "operations":
				StudentOperList();
				break;

			case "quit":
				return;

			default:
				Console.Write("Incorrect input. ");
				break;
		}
		MenuS();
	}
	public void ChangeSubject()
	{
		Console.WriteLine("\nType \"add/del subject\" to add/delete a subject, \"quit\" to stop:");
		while(true)
		{
			string[] inSubject = Console.ReadLine().ToLower().Split(' ', 2); //разделяем ввод именно на два подмассива, в первом - команда, во втором - предмет
			if ((inSubject[0] == "add" || inSubject[0] == "del") && inSubject.Length == 2)
			{
				if (inSubject[0] == "add")
				{
					if (!Marks.ContainsKey(inSubject[1]))
						Marks.Add(inSubject[1], new List<int>());
					else
						Console.WriteLine("There's already such subject in the list. Type again:");
				}
				else if (Marks.ContainsKey(inSubject[1]))
					Marks.Remove(inSubject[1]);
				else
					Console.WriteLine("There's no such subject in the list to be deleted. Type again:");
			}
			else if (inSubject[0] == "quit")
				return;
			else
				Console.WriteLine("Incorrect input. Type again:");
		}
		
	}
	public void ChangeMarks()
	{
		while (Marks.Count > 0) //если есть предметы, для которых можно менять оценки
		{
				Console.Write("\nChoose a subject to change it's marks:");
				ShowMarks();
				string inSubject = Console.ReadLine().ToLower();
				if (Marks.ContainsKey(inSubject))
				{
					Console.WriteLine($"\nUse \"add/del mark\" to add/delete a mark for {inSubject}, \"quit\" to stop:");
					while (true)
					{
						string[] inMark = Console.ReadLine().ToLower().Split(' ', 2); //разделяем ввод именно на два подмассива, в первом - команда, во втором - оценка
						if ((inMark[0] == "add" || inMark[0] == "del") && int.TryParse(inMark[1], out int mark))
						{
							if (inMark[0] == "add")
								Marks[inSubject].Add(mark);
							else if (Marks[inSubject].Contains(mark))
								Marks[inSubject].Remove(mark);
							else
								Console.WriteLine("There's no such mark to be deleted. Type again:");
						}
						else if (inMark[0] == "quit")
							return;
						else
							Console.WriteLine("Incorrect input. Type again:");
					}
				}
				else
					Console.Write("There's no such subject.");
		}
		Console.WriteLine("There are currently no subjects to change their marks. Choose another operation");
	}
	public void ShowMarks()
	{
		if (Marks.Count > 0) //если добавлены предметы
		{
			Console.WriteLine($"\n{TotalName}'s marks:");
			foreach (KeyValuePair<string, List<int>> item in Marks)
			{
				Console.Write($"{item.Key}: ");
				if (item.Value.Count > 0)
				{
					for (int i = 0; i < item.Value.Count; i++)
					{
						Console.Write($"{item.Value[i]}, ");
					}
					Console.WriteLine("\b\b  "); //удалить последний пробел и запятую
				}
				else
				{
					Console.WriteLine("none");
				}
			}
		}
		else
		{
			Console.WriteLine("There are currently no subjects added.");
		}

	}
	public float AverageMark(string subject)
	{
		float sum = 0;
		int i = 0;
		foreach (var mark in Marks[subject])
		{
			sum += mark;
			i++;
		}
		return sum/i;
	}
	public float AverageTotal()
	{
		float sum = 0;
		int i = 0;
		foreach (var subject in Marks)
		{
			foreach (var mark in Marks[subject.Key])
			{
				sum += mark;
				i++;
			}
		}
		return sum/i;
	}
	public void StudentOperList()
	{
		Console.WriteLine($"\nChoose an operation for {TotalName}:\n" +
					"\nAdd - add or delete a subject in subjects' list" +
					"\nChange - change marks for a specified subject" +
					"\nShow - show marks for all subjects" +
					"\nAvrg - show an average mark in a specified subject" +
					"\nAvrgT - show an average mark in all subjects" +
					"\nClear - clear console window" +
					"\nOperations - show list of operations" +
					"\nQuit - quit, obviously\n"
					);
	}
}