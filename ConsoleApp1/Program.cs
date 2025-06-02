using ConsoleApp1;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
namespace ConsoleApp1
{
    class Program
    {

        

        static void Main(string[] args)
        {
            Post post1 = new Post("123A", "I did my homework.", DateTime.Now, 0, 0);
            Post post2 = new Post("123B", "I did my Proyekt.", DateTime.Now.AddDays(1).AddHours(5).AddMinutes(29).AddSeconds(26), 0, 0);
            List<Post> posts1 = new List<Post> { post1, post2 };
            Post post3 = new Post("123C", "The lessons were to hard", DateTime.Now, 0, 0);
            Post post4 = new Post("123D", "But i did them.", DateTime.Now.AddDays(1).AddHours(3).AddMinutes(16).AddSeconds(37), 0, 0);
            List<Post> posts2 = new List<Post> { post3, post4 };
            Admin admin1 = new Admin("A123", "Omer", "aliyevomer386@gmail.com", "omer123", posts1);
            Admin admin2 = new Admin("B123", "Ayan", "ayanaliyev1986@gmail.com", "ayan123", posts2);
            Admin[] admins = { admin1, admin2 };
            User user1 = new User("C123", "Nermin", "Mursudova", 24);
            User user2 = new User("D123", "Benovshe", "Rehimova", 21);
            User user3 = new User("E123", "Nigar", "Xelilova", 19);
            User user4 = new User("F123", "Burhan", "Orucov", 15);
            User[] users = { user1, user2, user3, user4 };
            List<Post> postsList = new List<Post>();
            List<User> usersList = new List<User>();
            postsList.AddRange(posts1);
            postsList.AddRange(posts2);


            #region Admin or User
            string[] options = {
    "\t\t#-------------#\n\t\t|    Admin    |\n\t\t#-------------#",
    "\t\t#-------------#\n\t\t|    User     |\n\t\t#-------------#",
};
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("Seçim edin:\n");

                int numLines = options[0].Split('\n').Length;

                for (int line = 0; line < numLines; line++)
                {
                    for (int i = 0; i < options.Length; i++)
                    {
                        string[] lines = options[i].Split('\n');

                        if (i == selectedIndex)
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

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow)
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                else if (key == ConsoleKey.RightArrow)
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;

            } while (key != ConsoleKey.Enter);

            #endregion
            #region AdminPanel
            if (selectedIndex == 0)
            {

                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                bool exitAdminPanel = true;
                for (int adminI = 0; adminI < admins.Length; adminI++)
                {
                    while (exitAdminPanel)
                    {

                        if (username == admins[adminI].Username && password == admins[adminI].Password)
                        {
                            string[] options2 = {
    "\t\t#----------------------#\n\t\t|    Show all post     |\n\t\t#----------------------#",
    "\t\t#----------------------#\n\t\t|    Add new post      |\n\t\t#----------------------#",
};
                            int selectedIndex2 = 0;
                            ConsoleKey key2;

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Seçim edin:\n");

                                int numLines2 = options2[0].Split('\n').Length;

                                for (int line2 = 0; line2 < numLines2; line2++)
                                {
                                    for (int i2 = 0; i2 < options2.Length; i2++)
                                    {
                                        string[] lines2 = options2[i2].Split('\n');

                                        if (i2 == selectedIndex2)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write(lines2[line2]);
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.Write(lines2[line2]);
                                        }

                                        Console.Write("     ");
                                    }

                                    Console.WriteLine();
                                }

                                key2 = Console.ReadKey(true).Key;

                                if (key2 == ConsoleKey.LeftArrow)
                                    selectedIndex2 = (selectedIndex2 == 0) ? options2.Length - 1 : selectedIndex2 - 1;
                                else if (key2 == ConsoleKey.RightArrow)
                                    selectedIndex2 = (selectedIndex2 == options2.Length - 1) ? 0 : selectedIndex2 + 1;
                                else if (key2 == ConsoleKey.Escape)
                                {
                                    Main(args);
                                    break;
                                }
                            } while (key2 != ConsoleKey.Enter);
                            if (selectedIndex2 == 0)
                            {
                                foreach (var item in admins[adminI].Posts)
                                {
                                    item.ShowPost();
                                }
                                Console.WriteLine("Press enter for continue...");
                                Console.ReadLine();
                                continue;
                            }
                            else if (!exitAdminPanel)
                            {
                                Main(args);
                                break;
                            }
                            else if (selectedIndex2 == 1)
                            {
                                Console.Write("Enter post id: ");
                                string newid = Console.ReadLine();
                                Post idIndex = admins[adminI].SearchPostId(newid);
                                if (idIndex == null)
                                {
                                    Console.Write("Enter post content: ");
                                    string newcontent = Console.ReadLine();
                                    DateTime creatingTime = DateTime.Now;
                                    uint likeCount = 0, viewCount = 0;
                                    Post newPost = new Post(newid, newcontent, creatingTime, likeCount, viewCount);
                                    admins[adminI].Posts.Add(newPost);
                                    Admin.SendEmail("aliyevomer386@gmail.com", "uoir wrgz xdxw pnry", "aliyevomer386@gmail.com", "Notification", " post added successfully!");
                                }
                                Console.WriteLine("Press enter for continue...");
                                Console.ReadLine();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Username or password is wrong!!!");
                                break;
                            }
                        }
                    }

                }
            }
            #endregion
            else if (selectedIndex == 1)
            {
                string[] options2 = {
    "\t\t#--------------------#\n\t\t|      Sign In       |\n\t\t#--------------------#",
    "\t\t#--------------------#\n\t\t|      Sign Up       |\n\t\t#--------------------#",
};
                int selectedIndex2 = 0;
                ConsoleKey key2;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Seçim edin:\n");

                    int numLines2 = options2[0].Split('\n').Length;

                    for (int line2 = 0; line2 < numLines2; line2++)
                    {
                        for (int i2 = 0; i2 < options2.Length; i2++)
                        {
                            string[] lines2 = options2[i2].Split('\n');

                            if (i2 == selectedIndex2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(lines2[line2]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(lines2[line2]);
                            }

                            Console.Write("     ");
                        }

                        Console.WriteLine();
                    }

                    key2 = Console.ReadKey(true).Key;

                    if (key2 == ConsoleKey.LeftArrow)
                        selectedIndex2 = (selectedIndex2 == 0) ? options2.Length - 1 : selectedIndex2 - 1;
                    else if (key2 == ConsoleKey.RightArrow)
                        selectedIndex2 = (selectedIndex2 == options2.Length - 1) ? 0 : selectedIndex2 + 1;

                } while (key2 != ConsoleKey.Enter);
                if (selectedIndex2 == 0)
                {
                    Console.Write("Enter id: ");
                    string id = Console.ReadLine();
                    for (int userI = 0; userI < users.Length; userI++)
                    {

                        if (id == users[userI].Id)
                        {
                            Console.Write("Welcome!!!");
                            users[userI].UserPanel(users, postsList);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("User is not fount");
                            break;

                        }

                    }

                }
                else if(selectedIndex2 == 1)
                {
                    Console.Write("Enter id: ");
                    string newId = Console.ReadLine();

                    for (int i = 0; i < users.Length; i++)
                    {
                        if(newId != users[i].Id)
                        {
                            Console.Write("Enter Name: ");
                            string newName = Console.ReadLine();
                            Console.Write("Enter Surname: ");
                            string newSurname = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            uint newAge = uint.Parse(Console.ReadLine());
                            User newUser = new User(newId,newName, newSurname,newAge);
                            usersList.Add(newUser);
                            Console.WriteLine("Welcomee!!!");
                            users[i].UserPanel(users, postsList);
                            Admin.SendEmail("aliyevomer386@gmail.com", "uoir wrgz xdxw pnry", "aliyevomer386@gmail.com", "Notification", "new user register!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("User already exists");
                            break;
                        }
                    }
                }
            }
        }
    }
}