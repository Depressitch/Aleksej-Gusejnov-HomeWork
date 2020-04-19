using System;

namespace TrelloClone
{
    public class Program
    {
        public static void Main()
        {
            Trello trello = new Trello();
            trello.Menu();
            AddCmd.Repeat('r');
        }
    }
}
