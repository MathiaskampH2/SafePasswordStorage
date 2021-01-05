using System;
using System.Threading;

namespace SafePasswordStorage
{

    class Validation
    {
        // counter variable with 5 tires. which is beeing used to check if the user has inserted a incorrect passwordd
        private int counter = 5;

        // method checks if the ínserted password is equal to the password from the file.
        public void CheckIfPasswordMatches(string userInsertedPassword, string passwordFromFile, string usrName)
        {

            if (userInsertedPassword == passwordFromFile)
            {
                Console.Clear();
                Console.WriteLine("Checking password...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("password is correct" + "\n" + "Welcome");
                Thread.Sleep(2000);
                Console.Clear();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Checking password...");
                Thread.Sleep(1000);
                counter--;
                Console.Clear();
                Console.WriteLine("wrong password you´ve got :" + counter + " tries left");
                Thread.Sleep(2000);
                Console.Clear();
            }

            if (counter == 0)
            {
                Console.Clear();
                Console.WriteLine("you have used all 5 tries" + "\n" + "account " + usrName +
                                  " has been locked" + "Please contact superuser to unlock it.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}