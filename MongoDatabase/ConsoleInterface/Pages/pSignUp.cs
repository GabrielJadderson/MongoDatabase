using System;
using EasyConsole;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    public class pSignUp : Page
    {
        public pSignUp(Program program) : base("Sign Up Page", program)
        {


        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            Globals.Username = Input.ReadString("Enter your Username: ");

            if (Operations.login(Globals.Username))
            {
                Program.NavigateTo<MainMenu>();
            }
            else
            {
                if (Operations.createUser(Globals.Username))
                {
                    Program.NavigateTo<MainMenu>();
                }
                else
                    Output.WriteLine(ConsoleColor.Red, "Failed to signup {0}.", Globals.Username);
            }

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}