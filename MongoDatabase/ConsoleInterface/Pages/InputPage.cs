using System;
using EasyConsole;
using MongoDBProject.ConsoleInterface;

namespace MongoDatabase.ConsoleInterface.Pages
{
    internal class InputPage : Page
    {
        public InputPage(Program program)
            : base("Input", program)
        {
        }

        public override void Display()
        {
            ConsoleMenu.Intro();
            base.Display();

            Fruit input = Input.ReadEnum<Fruit>("Select a fruit");
            Output.WriteLine(ConsoleColor.Green, "You selected {0}", input);

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }

    internal enum Fruit
    {
        Sign,
        Banana
    }
}