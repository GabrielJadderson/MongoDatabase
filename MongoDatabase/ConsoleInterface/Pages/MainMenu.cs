using EasyConsole;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class MainMenu : MenuPage
    {
        public MainMenu(Program program)
            : base("Main Menu", program,
                new Option("Create Combination", () => program.NavigateTo<pSignUp>()),
                new Option("Search Combinations", () => program.NavigateTo<pLogin>()),
                new Option("List My Ratings", () => program.NavigateTo<pLogin>()),
                new Option("List My Ratings", () => program.NavigateTo<pLogin>()),
                new Option("List all Ratings", () => program.NavigateTo<pLogin>()))
        {

        }






        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();
        }
    }
}