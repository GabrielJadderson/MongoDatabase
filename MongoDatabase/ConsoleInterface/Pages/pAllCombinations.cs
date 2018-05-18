using System;
using System.Collections.Generic;
using EasyConsole;
using MongoDatabase.DBElements;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class pAllCombinations : Page
    {
        public pAllCombinations(Program program) : base("All Combinations", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            int limit = Input.ReadInt("Please Enter how many combinations you want to list between (1 - 1000000)", 1, 1000000);
            List<Combination> limitedCombinations = Operations.ReturnAllCombinationsWithLimit(limit);

            if (limitedCombinations != null)
            {
                Output.WriteLine("");
                foreach (var limitedCombination in limitedCombinations)
                {
                    Output.WriteLine(ConsoleColor.Green, limitedCombination.ToString());
                }
                Output.WriteLine(ConsoleColor.Green, "A Total of {0} combinations retrieved.", limitedCombinations.Count);
            }

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();

        }
    }

}