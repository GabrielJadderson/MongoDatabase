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

            if (Operations.Login(Globals.Username))
            {
                Program.NavigateTo<MainMenu>();
                pLogin.didLogIn = true;
            }
            else
            {
                if (Operations.CreateUser(Globals.Username))
                {
                    Program.NavigateTo<MainMenu>();
                    pLogin.didLogIn = true;
                }
                else
                    Output.WriteLine(ConsoleColor.Red, "Failed to signup {0}.", Globals.Username);
            }

            if (pLogin.didLogIn)
                Program.NavigateTo<MainMenu>();
            else
            {
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateHome();
            }
        }
    }
}