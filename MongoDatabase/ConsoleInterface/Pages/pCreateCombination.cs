using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;
using MongoDatabase.DBElements;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    public class pCreateCombination : Page
    {
        public pCreateCombination(Program program) : base("Create Combination", program)
        {

        }


        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            string gin = Input.ReadString("Enter the Gin combination: ");

            if (string.IsNullOrWhiteSpace(gin))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid Gin string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }

            string tonic = Input.ReadString("Enter the Tonic combination: ");

            if (string.IsNullOrWhiteSpace(tonic))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid Tonic string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }

            string garnish = Input.ReadString("Enter the Garnish combination: ");

            if (string.IsNullOrWhiteSpace(garnish))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid Garnish string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }

            string comment = Input.ReadString("Enter a comment for the combination: ");

            if (string.IsNullOrWhiteSpace(comment))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid Comment string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }

            int rating = Input.ReadInt("Enter a rating for the combination between 1-5: ", 1, 5);

            (Combination, Rating) combination = Operations.CreateCombination(gin, tonic, garnish, comment, rating);
            if (combination.Item1 != null && combination.Item2 != null)
            {
                Output.WriteLine(ConsoleColor.Green, "\n-------------------------------------------------------");
                Output.WriteLine(ConsoleColor.Green, "Added The Following into the database: ");
                Output.WriteLine(ConsoleColor.Green, combination.Item1.ToString());
                Output.WriteLine(ConsoleColor.Green, combination.Item2.ToString());
                Output.WriteLine(ConsoleColor.Green, "-------------------------------------------------------");
            }
            else
                Output.WriteLine(ConsoleColor.Red, "Failed to create Combination. May already exist");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();
        }
    }

}