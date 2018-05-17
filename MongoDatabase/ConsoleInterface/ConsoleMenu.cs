using System;
using MongoDatabase.ConsoleInterface.Pages;

namespace MongoDBProject.ConsoleInterface
{
    public class ConsoleMenu : EasyConsole.Program
    {

        public ConsoleMenu() : base("Bartender", breadcrumbHeader: true)
        {
            ConfigPages();

            Run();
        }

        public static void Intro()
        {
            Console.WriteLine("---      -------- WELCOME TO --------       ---");
            Console.WriteLine("-   ######  #     # ####### #######  #####    -");
            Console.WriteLine("-   #     # ##   ## #       #       #     #   -");
            Console.WriteLine("-   #     # # # # # #       #       #         -");
            Console.WriteLine("-   #     # #  #  # ######  ######  ######    -");
            Console.WriteLine("-   #     # #     #       #       # #     #   -");
            Console.WriteLine("-   #     # #     # #     # #     # #     #   -");
            Console.WriteLine("-   ######  #     #  #####   #####   #####    -");
            Console.WriteLine("---                                         ---");
            Console.WriteLine("---           Bartender Initiated           ---" + "\n");
            Console.WriteLine("-----------------------------------------------");
        }


        public void ConfigPages()
        {
            AddPage(new StartMenu(this));
            AddPage(new MainMenu(this));
            AddPage(new pSignUp(this));
            AddPage(new pLogin(this));
            AddPage(new InputPage(this));

            SetPage<StartMenu>();
        }


    }
}