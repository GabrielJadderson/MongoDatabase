using System;
using System.Collections.Generic;
using EasyConsole;
using MongoDatabase.DBElements;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class pCreateRating : Page
    {
        public pCreateRating(Program program) : base("Create Rating", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            string combinationID = Input.ReadString("Enter a CombinationID that you would like to rate: ");

            if (string.IsNullOrWhiteSpace(combinationID))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid CombinationID string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }

            string comment = Input.ReadString("Enter a Comment for the rating: ");

            if (string.IsNullOrWhiteSpace(comment))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid Comment string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }

            int rating = Input.ReadInt("Enter a rating for the combination between 1-5: ", 1, 5);


            Rating r = Operations.CreateRating(rating, comment, combinationID);

            if (r != null)
            {
                Output.WriteLine("Sucessfully created a rating.");
                Output.WriteLine(ConsoleColor.Green, r.ToString());
            }
            else
                Output.WriteLine(ConsoleColor.Red, "Failed to create a rating, remember, you can only rate once per combination.");


            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();
        }
    }

}