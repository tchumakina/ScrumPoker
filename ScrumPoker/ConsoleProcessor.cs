using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumPoker
{
    class ConsoleProcessor
    {
        private List<string> userName;
        private List<int> point;

        public List<string> UserNames
        {
            get { return userName; }
            set { userName = value; }
        }

        public List<int> Points
        {
            get { return point; }
            set { point = value; }
        }

        public ConsoleProcessor()
        {
            UserNames = new List<string>();
            Points = new List<int>();
        }

        public void Voiting()
        {
            string user;
            int point;
            Console.WriteLine("Please enter user name");
            user = Console.ReadLine();
            Console.WriteLine("Enter point");
            point = Int32.Parse(Console.ReadLine());

            UserNames.Add(user);
            Points.Add(point);
        }

        public void PrintAll()
        {
            UserNames.ForEach(Console.WriteLine);
            Points.ForEach(Console.WriteLine);
        }

    }
}
