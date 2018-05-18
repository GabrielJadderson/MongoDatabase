using System;
using System.Collections.Generic;
using EasyConsole;
using MongoDatabase.DBElements;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class pGetSortedRatings : Page
    {
        public pGetSortedRatings(Program program) : base("Sorted Ratings", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();


            List<Rating> sortedRatings = Operations.GetSortedRatings();

            if (sortedRatings != null && sortedRatings.Count > 0)
                foreach (var sortedRating in sortedRatings)
                    Output.WriteLine(ConsoleColor.Green, sortedRating.ToString());
            else
                Output.WriteLine(ConsoleColor.Red, "There were no ratings found.");


            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();
        }
    }

}