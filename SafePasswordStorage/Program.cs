using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SafePasswordStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            // new instances 
            Hash hash = new Hash();

            Gui gui = new Gui();

            InteractWithFile interactWithFile = new InteractWithFile();

            Validation validation = new Validation();

            bool start = false;

            while (!start)
            {
                Console.Clear();
                gui.HashMenu();
                int userInput = int.Parse(Console.ReadLine());
                // switch case for HashMenu if the user wants use SHA256 or PBKDF2
                switch (userInput)
                {
                    // case 1 the user choose SHA256
                    case 1:
                        Console.Clear();
                        gui.Menu();
                        int userInput1 = int.Parse(Console.ReadLine());
                        // switch case for menu if the user wants to create a user or login 
                        switch (userInput1)
                        {
                            // case 1 the user wants to create a user
                            case 1:
                                Console.Clear();
                                Console.Write("username: ");
                                string userName = Console.ReadLine();
                                Console.Clear();
                                Console.Write("Password :");
                                string userPassword = Console.ReadLine();
                                byte[] salt = hash.GenerateSalt();
                                byte[] pwd =
                                    hash.HashPasswordWithSaltSHA256(Encoding.UTF8.GetBytes(userPassword), salt);
                                Console.Clear();
                                Console.WriteLine("Creating user beep boop...");
                                interactWithFile.SaveCredentials(userName, pwd, salt);
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Done");
                                Thread.Sleep(1000);
                                Console.Clear();
                                gui.Menu();
                                break;
                            // case 2 the user wants to login
                            case 2:

                                Console.Clear();
                                Console.Write("Username :");
                                string usrName = Console.ReadLine();
                                Console.Clear();
                                byte[] usrSalt = interactWithFile.ReadSaltFromFile(usrName);
                                Console.Write("Password :");
                                string usrPassword = Console.ReadLine();
                                byte[] usrPwd =
                                    hash.HashPasswordWithSaltSHA256(Encoding.UTF8.GetBytes(usrPassword), usrSalt);
                                string userInsertedPassword = Convert.ToBase64String(usrPwd);
                                byte[] bytePasswordFromFile = interactWithFile.ReadPasswordFromFile(usrName);
                                string passwordFromFile = Convert.ToBase64String(bytePasswordFromFile);
                                validation.CheckIfPasswordMatches(userInsertedPassword, passwordFromFile, usrName);
                                Thread.Sleep(2000);
                                break;

                            default:
                                Console.WriteLine("Insert valid number");
                                Thread.Sleep(1000);
                                Console.Clear();
                                gui.Menu();
                                break;
                        }

                        break;
                    // case 2 of switch menu. The user choose PBKDF2
                    case 2:
                        Console.Clear();
                        gui.Menu();
                        int userInput2 = int.Parse(Console.ReadLine());
                        // switch case for menu if the user wants to create a user or login 
                        switch (userInput2)
                        {
                            // case 1 the user wants to create a user
                            case 1:
                                Console.Clear();
                                Console.Write("username: ");
                                string userName1 = Console.ReadLine();
                                Console.Clear();
                                Console.Write("Password :");
                                string userPassword1 = Console.ReadLine();
                                byte[] salt1 = hash.GenerateSalt();
                                byte[] pwd1 =
                                    hash.hashPasswordWithSaltPBKDF2(Encoding.UTF8.GetBytes(userPassword1), salt1);
                                Console.Clear();
                                Console.WriteLine("Creating user beep boop...");
                                interactWithFile.SaveCredentials(userName1, pwd1, salt1);
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Done");
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                            // case 2 the user wants to login
                            case 2:
                                Console.Clear();
                                Console.Write("Username :");
                                string usrName1 = Console.ReadLine();
                                Console.Clear();
                                byte[] usrSalt1 = interactWithFile.ReadSaltFromFile(usrName1);
                                Console.Write("Password :");
                                string usrPassword1 = Console.ReadLine();
                                byte[] usrPwd1 = hash.hashPasswordWithSaltPBKDF2(Encoding.UTF8.GetBytes(usrPassword1),
                                    usrSalt1);
                                string userInsertedPassword1 = Convert.ToBase64String(usrPwd1);
                                byte[] bytePasswordFromFile1 = interactWithFile.ReadPasswordFromFile(usrName1);
                                string passwordFromFile1 = Convert.ToBase64String(bytePasswordFromFile1);
                                validation.CheckIfPasswordMatches(userInsertedPassword1, passwordFromFile1, usrName1);
                                Thread.Sleep(2000);
                                break;
                        }

                        break;
                }
            }
        }
    }
}