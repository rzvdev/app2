using System;

namespace learning.softing.app2
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleController consoleController = new ConsoleController();
            consoleController.ShowOptions();
            
            bool exit = false;

            while (!exit)
            {
                int option = consoleController.ValidateOption();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("EXIT!");
                        exit = true;
                        break;
                    case 1:
                        Console.WriteLine("Type path:");
                        consoleController.DisplayFiles(Console.ReadLine());
                        consoleController.ShowOptions();
                        break;
                    case 2:
                        Console.WriteLine("Type path:");
                        consoleController.DisplayDuplicatesByName(Console.ReadLine());
                        consoleController.ShowOptions();
                        break;
                    case 3:
                        Console.WriteLine("Type path:");
                        consoleController.DisplayDuplicatesByLength(Console.ReadLine());
                        consoleController.ShowOptions();
                        break;
                    case 4:
                        Console.WriteLine("Type path:");
                        consoleController.RemoveByLength(Console.ReadLine());
                        consoleController.ShowOptions();
                        break;
                    case 5:
                        Console.WriteLine("Type path:");
                        consoleController.RemoveByName(Console.ReadLine());
                        consoleController.ShowOptions();
                        break;

                }
            }


        }





    }
}
