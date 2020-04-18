using System;
using System.Collections.Generic;
using System.Text;

namespace TrelloClone
{

    public class Task
    {
        public Statuses Status;
        public string ResponsibleUser;
        public string Text;
        public string Title;

        public Task()
        {
            Text = "";
        }
        public void ShowStatuses()
        {
            int i = 0; 
            foreach (var status in Enum.GetValues(typeof(Statuses)))
            {
                Console.WriteLine($"{i++}: {status}");
            }
        }
        public enum Statuses
        {
            ToDo,
            OnTeacher,
            OnStudent,
            Closed,
        }
    }
}


//!карточка:
//!отдельный класс, имеет параметры:
//!статус, исполнитель, текст