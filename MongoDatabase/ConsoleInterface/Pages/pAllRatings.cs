using System;
using System.Collections.Generic;
using EasyConsole;
using MongoDatabase.DBElements;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class pAllRatings : Page
    {
        public pAllRatings(Program program) : base("All Ratings", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            int limit = Input.ReadInt("Please Enter how many ratings you want to list between (1 - 1000000)", 1, 1000000);
            List<Rating> limitedRatings = Operations.ReturnAllRatingsWithLimit(limit);

            if (limitedRatings != null)
            {
                Output.WriteLine("");
                foreach (var limitedCombination in limitedRatings)
                    Output.WriteLine(ConsoleColor.Green, limitedCombination.ToString());
                Output.WriteLine(ConsoleColor.Green, "A Total of {0} ratings retrieved.", limitedRatings.Count);
            }

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();

        }
    }

}