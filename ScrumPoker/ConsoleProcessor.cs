using System.Collections.Generic;
using System.Linq;

namespace ScrumPoker
{
    public class ConsoleProcessor
    {
        public Dictionary<string, int> VoitingData { get; set; }
        private readonly IConsoleWrapper consoleWrapper;

        public ConsoleProcessor(IConsoleWrapper consoleWrapper)
        {
            this.consoleWrapper = consoleWrapper;
            VoitingData = new Dictionary<string, int>();
        }

        public void PopulateData()
        {
            consoleWrapper.Write("How many users will vote?");
            int numberVoters = consoleWrapper.ReadInt();
            for (int i = 0; i < numberVoters; i++)
            {
                Voiting();
            }
        }

        public void Voiting()
        {
            string user;
            int point;
            consoleWrapper.Write("Please enter user name");
            user = consoleWrapper.Read();
            consoleWrapper.Write("Enter point");
            point = consoleWrapper.ReadInt();

            VoitingData.Add(user, point);
        }

        public void PrintAll()
        {
            foreach (var keyValuePair in VoitingData)
            {
                consoleWrapper.Write("user: " + keyValuePair.Key + ", score: " + keyValuePair.Value);
            }
        }

        public void CheckPoints()
        {
            if (VoitingData.Values.Max() > VoitingData.Values.Min())
            {
                consoleWrapper.Write("Points are different");
                PrintAll();
                consoleWrapper.Write("Max point: " + VoitingData.Values.Max());
                consoleWrapper.Write("Min point: " + VoitingData.Values.Min());
                Revote();
            }
            else
            {
                consoleWrapper.Write("Points are the same: " + VoitingData.Values.Max());
                PrintAll();
            }
        }

        private void Revote()
        {
            consoleWrapper.Write("Do you want users to revote? Y/N");
            string choice = consoleWrapper.Read();
            if (choice.Equals("Y"))
            {
                VoitingData.Clear();
                PopulateData();
                CheckPoints();
            }
            else if (choice.Equals("N"))
            {
                ScrumMasterPointSet();
            }
            else
            {
                consoleWrapper.Write("Your choice is not valid. Choose correct value");
                Revote();
            }
        }

        public void ScrumMasterPointSet()
        {
            consoleWrapper.Write("Start a discussion! Set a final point yourself after discussion. Enter your point");
            int finalPoint = consoleWrapper.ReadInt();
            consoleWrapper.Write("Final point: " + finalPoint);
        }

    }
}
