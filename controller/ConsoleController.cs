using System;
using System.Collections.Generic;

namespace learning.softing.app2
{
    class ConsoleController
    {
        FileController fileController = FileController.GetInstance();

        public void DisplayFiles(string pathToFolder)
        {
            fileController.ReadFiles(new Folder(pathToFolder));

            if (fileController.GetFiles() != null)
            {
                foreach (var file in fileController.GetFiles())
                {
                    Console.WriteLine($"{file.Index}.{file.Name}");
                }
            }
        }

        public void DisplayDuplicatesByName(string pathToFolder)
        {
            fileController.ReadFiles(new Folder(pathToFolder));

            foreach (var file in fileController.GetDuplicatesFileByName(fileController.GetFiles()))
            {
                Console.WriteLine($"{file.Index}.{file.Name}");
            }
        }

        public void ShowOptions(){
            WriteColorLine("Hello, your options:\n1.Display files from a folder\n2.Show duplicates by name\n3.Show duplicates by length" +
            "\n4.Delete duplicates by length\n5.Delete duplicates by name ", "blue");
        }

        public void DisplayDuplicatesByLength(string pathToFolder)
        {
            fileController.ReadFiles(new Folder(pathToFolder));

            foreach (var file in fileController.GetDuplicatesFileByLength(fileController.GetFiles()))
            {
                Console.WriteLine($"{file.Index}.{file.Name}");
            }
        }

        public void RemoveByName(string pathToFolder){
            fileController.ReadFiles(new Folder(pathToFolder));

            foreach(var file in fileController.GetDuplicatesFileByName(fileController.GetFiles())){
                Console.WriteLine($"{file.Index}.{file.Name} removed succesfully.");
                fileController.RemoveFile(file);
            }
        }

        public void RemoveByLength(string pathToFolder)
        {
            fileController.ReadFiles(new Folder(pathToFolder));

            foreach (var file in fileController.GetDuplicatesFileByLength(fileController.GetFiles()))
            {
                Console.WriteLine($"{file.Index}.{file.Name} removed succesfully.");
                fileController.RemoveFile(file);
            }
        }

        public int ValidateOption()
        {
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                return option;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid option");
                return 0;
            }

        }


        public void WriteColorLine(string s, string color)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Substring(0, 1).ToUpper() + color.Substring(1));
            Console.WriteLine(s);
            Console.ResetColor();
        }

    }
}
