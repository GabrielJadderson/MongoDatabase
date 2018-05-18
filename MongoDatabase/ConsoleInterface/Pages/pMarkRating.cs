using System;
using System.Collections.Generic;
using EasyConsole;
using MongoDatabase.DBElements;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class pMarkRating : Page
    {
        public pMarkRating(Program program) : base("Mark Rating", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            string ratingID = Input.ReadString("Enter the ratingID you would like to mark as Helpful: ");

            if (!string.IsNullOrWhiteSpace(ratingID))
            {
                bool v = Operations.MarkRatingAsHelpful(ratingID);
                if (v)
                    Output.WriteLine(ConsoleColor.Green, "Sucessfully Marked {0} as Helpful.", ratingID);
                else
                    Output.WriteLine(ConsoleColor.Red, "Failed to mark Rating, Rating may not exist in the database.");
            }
            else
                Output.WriteLine(ConsoleColor.Red, "The entered ratingID is invalid, You can list all ratings from the menu to view all ratingIDs.");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();
        }
    }

}