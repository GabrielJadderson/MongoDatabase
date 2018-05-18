using System;
using EasyConsole;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class MainMenu : MenuPage
    {
        public MainMenu(Program program)
            : base("Main Menu", program,
                new Option("Create Combination", () => program.NavigateTo<pCreateCombination>()), //done
                new Option("Search Combinations", () => program.NavigateTo<pSearchCombination>()), //done
                new Option("List All Combinations", () => program.NavigateTo<pAllCombinations>()), //done
                new Option("------------------------------------", () => program.NavigateTo<MainMenu>()),
                new Option("Create Rating", () => program.NavigateTo<pCreateRating>()), //done
                new Option("List My Ratings", () => program.NavigateTo<pMyRatings>()), //done
                new Option("List All Ratings", () => program.NavigateTo<pAllRatings>()), //done
                new Option("Mark Rating as Helpful", () => program.NavigateTo<pMarkRating>()), //done
                new Option("Get Ratings sorted by HelpfulMarks (descending order)", () => program.NavigateTo<pGetSortedRatings>()), //done
                new Option("------------------------------------", () => program.NavigateTo<MainMenu>()),
                new Option("Log out", () => program.NavigateHome()),
                new Option("Exit", () => Environment.Exit(0)))
        {

        }


        public override void Display()
        {
            ConsoleMenu.Intro();

            Output.WriteLine(ConsoleColor.Green, "               Welcome {0}", Globals.Username);
            Output.WriteLine(ConsoleColor.Green, "");

            base.Display();
        }


    }
}