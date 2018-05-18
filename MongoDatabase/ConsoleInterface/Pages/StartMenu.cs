using System;
using EasyConsole;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class StartMenu : MenuPage
    {
        public StartMenu(Program program)
            : base("Start Menu", program,
                new Option("Sign Up", () => program.NavigateTo<pSignUp>()),
                new Option("Log in", () => program.NavigateTo<pLogin>()),
                new Option("Exit", () => Environment.Exit(0)))
        {

        }



        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();
        }
    }
}