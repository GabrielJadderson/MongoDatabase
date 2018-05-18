using System;
using System.Collections.Generic;
using EasyConsole;
using MongoDatabase.DBElements;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class pMyRatings : Page
    {
        public pMyRatings(Program program) : base("My Ratings", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            List<Rating> ratings = Operations.ReturnRatingsForUser(Globals.Username);
            if (ratings.Count > 0)
            {
                foreach (var rating in ratings)
                    Output.WriteLine(ConsoleColor.Green, rating.ToString());
                Output.WriteLine(ConsoleColor.Green, "You have a total of {0} ratings.", ratings.Count);
            }
            else
                Output.WriteLine(ConsoleColor.Red, "You don't have any ratings yet.");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();
        }
    }

}