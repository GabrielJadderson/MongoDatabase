using System;

namespace MongoDBProject
{
    public class Menu : EasyConsole.Program
    {        
           
     
        public Menu() : base("EasyConsole Demo", breadcrumbHeader: true)
        {
            
            /*
            
            AddPage(new MainPage(this));
            AddPage(new Page1(this));
            AddPage(new Page1A(this));
            AddPage(new Page1B(this));
            AddPage(new Page2(this));

            SetPage<MainPage>();    
            */
            Intro();
    
            
            var menu = new EasyConsole.Menu()
                .Add("Sign Up", () => Console.WriteLine(""))
                .Add("Sign In", () => Console.WriteLine("bar selected"));
            menu.Display();
        }

        private void Intro()
        {
            Console.WriteLine("---      -------- WELCOME TO --------       ---");
            Console.WriteLine("-   ######  #     # ####### #######  #####    -");
            Console.WriteLine("-   #     # ##   ## #       #       #     #   -");
            Console.WriteLine("-   #     # # # # # #       #       #         -");
            Console.WriteLine("-   #     # #  #  # ######  ######  ######    -");
            Console.WriteLine("-   #     # #     #       #       # #     #   -");
            Console.WriteLine("-   #     # #     # #     # #     # #     #   -");
            Console.WriteLine("-   ######  #     #  #####   #####   #####    -");
            Console.WriteLine("---       ---------         ---------       ---");
            Console.WriteLine("---           Bartender Initiated           ---" + "\n");
            Console.WriteLine("-----------------------------------------------");
        }

        public void UpdateMenu()
        {
            Console.Clear();
            Intro();
        }
        
        
    }
}