using System;
using EasyConsole;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    public class pLogin : Page
    {
        public static volatile bool didLogIn = false;

        public pLogin(Program program) : base("Login Page", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            Globals.Username = Input.ReadString("Enter your Username: ");

            if (Operations.Login(Globals.Username))
            {
                Program.NavigateTo<MainMenu>();
                didLogIn = true;
            }
            else
                Output.WriteLine(ConsoleColor.White, "The Username {0} does not exist.", Globals.Username);

            if (didLogIn)
                Program.NavigateTo<MainMenu>();
            else
            {
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateHome();
            }
        }
    }
}