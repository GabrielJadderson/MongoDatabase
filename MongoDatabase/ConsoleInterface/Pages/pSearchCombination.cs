using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    public class pSearchCombination : Page
    {
        public pSearchCombination(Program program) : base("Search Combination", program)
        {

        }


        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();


            string gin = Input.ReadString("Enter the Gin: ");
            if (string.IsNullOrWhiteSpace(gin))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid Gin string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }
            string tonic = Input.ReadString("Enter the Tonic: ");
            if (string.IsNullOrWhiteSpace(tonic))
            {
                Output.WriteLine(ConsoleColor.Red, "Invalid Tonic string given.");
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<MainMenu>();
            }
            string garnish = Input.ReadString("Enter the Garnish: ");

            int avg = 0;
            var v = Operations.SearchCombination(gin, tonic, garnish);
            if (v.Item1 != null && v.Item2 != null)
            {
                Output.WriteLine("Found the following: ");
                foreach (var rating in v.Item1)
                {
                    Output.WriteLine(ConsoleColor.Green, rating.ToString());
                    avg += rating.rating;
                }
                Output.WriteLine(ConsoleColor.Green, "Found {0} distinct combinations", v.Item2.Count);
                int users = 0;
                foreach (var c in v.Item2)
                {
                    if (users < c)
                        users = c;
                }
                Output.WriteLine(ConsoleColor.Green, "The Total Average Rating for the result is: " + avg / users);
                Output.WriteLine(ConsoleColor.Green, "The Total Number of users for the result is: " + users);
            }
            else
                Output.WriteLine(ConsoleColor.Red, "The combination does not exist.");



            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateTo<MainMenu>();
        }

    }

}