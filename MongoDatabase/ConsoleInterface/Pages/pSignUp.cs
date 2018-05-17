using EasyConsole;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    public class pSignUp : MenuPage
    {
        public pSignUp(Program program) : base("Sign Up Page", program)
        {


        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();
        }
    }
}