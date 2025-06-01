using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public User(string id, string name, string surname, uint age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
        }
        public void UserPanel(User[] users, List<Post> posts)
        {
            while (true)
            {
                string[] topOptions = {
            "\t\t#-------------------#\n\t\t|    Show Posts     |\n\t\t#-------------------#",
            "\t\t#-------------------#\n\t\t|      Profile      |\n\t\t#-------------------#"
        };

                string exitOption = "\t\t#-------------------#\n\t\t|       Exit        |\n\t\t#-------------------#";

                int selectedIndex = 0;
                bool exitSelected = false;
                ConsoleKey key;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Seçim edin:\n");


                    int numLines = topOptions[0].Split('\n').Length;
                    for (int line = 0; line < numLines; line++)
                    {
                        for (int i = 0; i < topOptions.Length; i++)
                        {
                            string[] lines = topOptions[i].Split('\n');

                            if (i == selectedIndex && !exitSelected)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(lines[line]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(lines[line]);
                            }

                            Console.Write("     ");
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine("\n");


                    if (exitSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(exitOption);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(exitOption);
                    }

                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.LeftArrow && !exitSelected)
                        selectedIndex = (selectedIndex == 0) ? topOptions.Length - 1 : selectedIndex - 1;
                    else if (key == ConsoleKey.RightArrow && !exitSelected)
                        selectedIndex = (selectedIndex == topOptions.Length - 1) ? 0 : selectedIndex + 1;
                    else if (key == ConsoleKey.DownArrow)
                        exitSelected = true;
                    else if (key == ConsoleKey.UpArrow)
                        exitSelected = false;

                } while (key != ConsoleKey.Enter);

                if (!exitSelected && selectedIndex == 0)
                {
                    Console.Clear();
                    for (int i = 0; i < posts.Count; i++)
                    {
                        Console.WriteLine($"Content: {posts[i].Content}");
                        Console.WriteLine($"Creation time: {posts[i].CreationDateTime}");
                        posts[i].ViewCount++;
                        Console.WriteLine("-----------------------------");
                    }
                    Console.ReadLine();
                }
                else if (!exitSelected && selectedIndex == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"\t\t\t\t#---------------#\n\t\t\t\t|    {Name}     |\n\t\t\t\t#---------------#");
                    Console.WriteLine($"Id: {Id}");
                    Console.WriteLine($"Name: {Name}");
                    Console.WriteLine($"Surname: {Surname}");
                    Console.WriteLine($"Age: {Age}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t\t\t\t#----------#\n\t\t\t\t|   Exit   |\n\t\t\t\t#----------#");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else if (exitSelected)
                {
                    break;
                }
            }
        }

    }
}
