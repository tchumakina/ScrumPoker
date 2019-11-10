using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrumPoker
{
    class ConsoleProcessor
    {
        public Dictionary<string, int> VoitingData { get; set; }

        public ConsoleProcessor()
        {
            VoitingData = new Dictionary<string, int>();
        }

        public void PopulateData()
        {
            Console.WriteLine("How many users will vote?");
            int numberVoters = ReadInt();
            for (int i = 0; i < numberVoters; i++)
            {
                Voiting();
            }
        }

        private void Voiting()
        {
            string user;
            int point;
            Console.WriteLine("Please enter user name");
            user = Console.ReadLine();
            Console.WriteLine("Enter point");
            point = ReadInt();

            VoitingData.Add(user, point);
        }

        public void PrintAll()
        {
            foreach (var keyValuePair in VoitingData)
            {
                Console.WriteLine(keyValuePair);
            }
        }

        public void CheckPoints()
        {
            if (VoitingData.Values.Max() > VoitingData.Values.Min())
            {
                Console.WriteLine("Points are different");
                PrintAll();
                Console.WriteLine("Max point: "+ VoitingData.Values.Max());
                Console.WriteLine("Min point: "+ VoitingData.Values.Min());
                Revote();
            }
            else
            {
                Console.WriteLine("Points are the same: "+VoitingData.Values.Max());
                PrintAll();
            }
        }

        private void Revote()
        {
            Console.WriteLine("Do you want users to revote? Y/N");
            string choice = Console.ReadLine();
            if ( choice.Equals("Y"))
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
                Console.WriteLine("Your choice is not valid. Choose correct value");
                Revote();
            }
        }

        private void ScrumMasterPointSet()
        {
            Console.WriteLine("Start a discussion! Set a final point yourself after discussion. Enter your point");
            string finalPoint = Console.ReadLine();
            Console.WriteLine("Final point: "+finalPoint);
        }

        private int ReadInt()
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Entered value is not valid. Please enter valid value:"+e.Message);
                return ReadInt();
            }
        }

    }
}
