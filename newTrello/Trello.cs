using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrelloClone
{
    public class Trello
    {
        public Dictionary<int, Task> Tasks = new Dictionary<int, Task>();
        public List<string> Users = new List<string>();

        public void Menu()
        {
            int option = AddCmd.ChoiсeMenu("Choose operation",
               "Create new task",
               "Change task's text",
               "Change task's status",
               "Change task's responsible user",
               "Show all tasks of set status",
               "Show all tasks of a set user",
               "Show all tasks");
            while (true)
            {
                if (option == 1)
                    AddCard();
                else if (Tasks.Count > 0) //проверяем что есть что изменять
                {
                    switch (option)
                    {
                        case 2:
                            ChangeText();
                            break;
                        case 3:
                            ChangeStatus();
                            break;
                        case 4:
                            ChangeUser();
                            break;
                        case 5:
                            ShowSetTasks();
                            break;
                        case 6:
                            ShowUserTasks();
                            break;
                        case 7:
                            ShowAllTasks();
                            break;
                        default:
                            return;
                    }
                }
                else
                    Console.WriteLine("There are currently no tasks added.");
                Console.WriteLine("\nChoose operation:");
                option = Parse.IntValue();
            } 
        }
        private void AddCard()
        {
            Tasks.Add(Tasks.Count + 1, new Task()); //создаём новую карточку с ключом равным кол-ву карточек + 1
            int id = Tasks.Count; //работаем с последней добавленной карточкой
            Console.WriteLine("Input task's title: ");
            string input = Console.ReadLine();
            while (input.Length == 0 || Tasks.Any(c => c.Value.Text == input)) //проверяем, чтобы заголовок не был пустым и не было карточки с таким заголовком
            {
                Console.WriteLine("Incorrect input or task with such title already exists. Input again:");
                input = Console.ReadLine();
            }
            Tasks[id].Title = input;

            Console.WriteLine("Input task's responsible user: ");
            input = Console.ReadLine();
            if (!Users.Contains(input)) //если такой пользователь не был введён, то добавляем нового пользователя в список всех пользователей
            {
                Users.Add(input);
            }
            Tasks[id].ResponsibleUser = input;

            Console.WriteLine("Input task's text: ");
            Tasks[id].Text = Console.ReadLine();
        }
        private void ChangeText()
        {
            Console.WriteLine("Input task's number to change:");
            int id = Parse.IntValue();
            if (!Tasks.ContainsKey(id))
            {
                Console.WriteLine("There's no task with such number.");
                return;
            }
            Console.WriteLine("Input new task's text:");
            Tasks[id].Text = Console.ReadLine();
        }
        private void ChangeStatus()
        {
            Console.WriteLine("Input task's number to change:");
            int id = Parse.IntValue();
            if (!Tasks.ContainsKey(id))
            {
                Console.WriteLine("There's no task with such number.");
                return;
            }
            Console.WriteLine("Input number of a status:");
            Tasks[id].ShowStatuses();
            int statusNum = Parse.IntValue();
            if (statusNum > Enum.GetNames(typeof(Task.Statuses)).Length || statusNum < 0) //проверяем есть ли статус с таким номером 
            {
                Console.WriteLine("There's no status with such number.");
                return;
            }
            Tasks[id].Status = (Task.Statuses)statusNum;
        }
        private void ChangeUser()
        {
            Console.WriteLine("Input task's number to change:");
            int id = Parse.IntValue();
            if (!Tasks.ContainsKey(id))
            {
                Console.WriteLine("There's no task with such number.");
                return;
            }
            string input;
            Console.WriteLine("Input task's new responsible user: ");
            input = Console.ReadLine();
            if (!Users.Contains(input)) //если такой пользователь не был введён, то добавляем нового пользователя в список всех пользователей
            {
                Users.Add(input);
            }
            Tasks[id].ResponsibleUser = input;
        }
        private void ShowSetTasks()
        {
            Console.WriteLine("Choose a status:");
            Tasks[1].ShowStatuses();
            int statusNum = Parse.IntValue();
            if (statusNum > Enum.GetNames(typeof(Task.Statuses)).Length || statusNum < 0) //проверяем есть ли статус с таким номером 
            {
                Console.WriteLine("There's no status with such number.");
                return;
            }
            foreach (var task in Tasks)
            {
                if (task.Value.Status == (Task.Statuses)statusNum)
                {
                    Console.WriteLine($"{task.Key}. {task.Value.Title}" +
                        $"\nResponsible: {task.Value.ResponsibleUser}" +
                        $"\n{task.Value.Text}\n");
                }
            }
        }
        private void ShowUserTasks()
        {
            Console.WriteLine("Choose user:");
            ShowAllUsers();
            int userNum = Parse.IntValue();
            if (userNum > Users.Count || userNum < 0) //проверяем есть ли пользователь с таким номером 
            {
                Console.WriteLine("There's no user with such number.");
                return;
            }
            foreach (var task in Tasks)
            {
                if (task.Value.ResponsibleUser == Users[userNum])
                {
                    Console.WriteLine($"{task.Key}. {task.Value.Title}" +
                        $"\nStatus: {task.Value.Status}" +
                        $"\n{task.Value.Text}\n");
                }
            }
        }
        private void ShowAllTasks()
        {
            foreach (var task in Tasks)
            {
                Console.WriteLine($"\n{task.Key}. {task.Value.Title}" +
                    $"\nResponsible: {task.Value.ResponsibleUser}" +
                    $"\nStatus: {task.Value.Status}" +
                    $"\n{task.Value.Text}\n");
            }
        }
        private void ShowAllUsers()
        {
            int i = 0;
            foreach (var user in Users)
            {
                Console.WriteLine($"{i}. {user}");
            }
        }
    }
}
