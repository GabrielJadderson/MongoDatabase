﻿using System;
using EasyConsole;
using MongoDBProject;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    public class pLogin : Page
    {
        public pLogin(Program program) : base("Login Page", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            Globals.Username = Input.ReadString("Enter your Username: ");

            if (Operations.login(Globals.Username))
            {
                Output.WriteLine(ConsoleColor.Cyan, Globals.Username);
                Output.WriteLine(ConsoleColor.Cyan, "Welcome");

                // Program.SetPage<MainMenu>();
                // Program.NavigateHome();
                Environment.Exit(0);
                return;
            }
            else
            {
                Output.WriteLine(ConsoleColor.White, "The Username {0} does not exist.", Globals.Username);

            }

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}