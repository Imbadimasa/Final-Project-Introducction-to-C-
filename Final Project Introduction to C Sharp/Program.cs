using System;
using System.IO;
using System.Linq;

namespace Final_Project_Introduction_to_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the File directory! Please include a space after every command");
                instructions();
                Console.WriteLine();
                Console.WriteLine("Please enter the initial file path");
                string userFilePath = Console.ReadLine(); //Setting a default file path

                bool loop = true;//Loop condition
                while (loop)
                {
                    Console.WriteLine(userFilePath);
                    string userInput = Console.ReadLine();
                    string command = userInput.Substring(0, 3);
                    string modifier = userInput.Substring(3);

                    if (command == "cd ") //Choosing a file path
                    {
                        userFilePath = modifier;
                    }
                    else if (command == "ct ")//Creating a new file in a folder
                    {
                        Console.WriteLine("You chose file creation.");
                        File.AppendAllText(@$"{userFilePath}{modifier}", "New file has been created.");
                    }
                    else if (command == "cp ")
                    {
                        Console.WriteLine("You chose a copy.");
                    }
                    else if (command == "dt ")
                    {
                        Console.WriteLine("You chose delete.");
                        File.Delete($@"{userFilePath}/{modifier}");
                    }
                    else if (command == "mv ")
                    {
                        Console.WriteLine("You chose move.");
                    }
                    else if (command == "ls ")
                    {
                        Console.WriteLine("You chose list of flies.");
                        directoryList(userFilePath);
                    }
                    else if (command == "fi ")
                    {
                        Console.WriteLine("You chose file info.");
                        FileInfo(userFilePath, modifier);
                    }
                    else if (command == "ci ")
                    {
                        Console.WriteLine("You chose catalogue info.");
                    }
                    else if (command == "qt ")
                    {
                        Console.WriteLine("You chose to exit. Goodbye");
                        loop = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter the correct command.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static void directoryList(string userFilePath)
        {
            string path = $@"{userFilePath}";
            string[] dirInfo = Directory.GetFiles(path);
            string[] subDir = Directory.GetDirectories(path);
            Console.WriteLine("List of directories: ");
            foreach (var directory in subDir)
            {
                Console.WriteLine(directory);
            }
            Console.WriteLine("List of files: ");
            foreach (var element in dirInfo)
            {
                Console.WriteLine(element);
            }
        }

        private static void FileInfo(string userFilePath, string modifier)
        {
            try
            {
                string file = $@"{userFilePath}{modifier}";
                FileInfo fileInfo = new FileInfo(file);
                Console.WriteLine("Full Name: " + fileInfo.Name.ToString());
                Console.WriteLine("File Extension: " + fileInfo.Extension.ToString());
                Console.WriteLine("File Attribute: " + fileInfo.Attributes.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        public static void instructions()
        {
            Console.WriteLine("cd - Go to the path");
            Console.WriteLine("cp - Copy the file");
            Console.WriteLine("dt - Delete the file");
            Console.WriteLine("mv - Move the file");
            Console.WriteLine("ls - List of files");
            Console.WriteLine("fi - File info");
            Console.WriteLine("ci - Catalogue info");
            Console.WriteLine("qt - Exit the program");

        }
    }
}


//Console.WriteLine("Please enter the path to the file.");
//string location = Console.ReadLine();
//Console.WriteLine("Please enter the file name.");
//string fileName = Console.ReadLine();

//string dummyLines = "This is first line." + Environment.NewLine +
//        "This is second line." + Environment.NewLine +
//        "This is third line.";

////Opens DummyFile.txt and append lines. If file is not exists then create and open.
//File.AppendAllLines(@$"{location}\{fileName}", dummyLines.Split(Environment.NewLine.ToCharArray()).ToList<string>());